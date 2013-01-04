using System;
using System.Collections.Generic;

namespace DSLImplementation.UserInterface {

	public delegate TResult Parse<TResult> (string input);

	public class ParsableKeyValueTable<TKey,TValue> : KeyValueTable<TKey,TValue> {

		private readonly List<Parse<TKey>> keyparsers;
		private readonly List<Parse<TValue>> valparsers;

		public string this [string key] {
			get {
				int n = Math.Min (keyparsers.Count, this.Count);
				TKey keyt;
				for (int i = 0x00; i < n; i++) {
					keyt = keyparsers [i] (key);
					if (this [i].Key.Equals (keyt)) {
						return this [i].Value.ToString();
					}
				}
				return string.Empty;
			}
			set {
				int n = Math.Min(Math.Min (keyparsers.Count, this.Count),valparsers.Count);
				TKey keyt;
				for (int i = 0x00; i < n; i++) {
					keyt = keyparsers [i] (key);
					if (this [i].Key.Equals (keyt)) {
						this[i] = new KeyValuePair<TKey, TValue>(keyt,valparsers[i](value));
						return;
					}
				}
				throw new ArgumentException("Cannot find the proper key!");
			}
		}

		public ParsableKeyValueTable (IEnumerable<Parse<TKey>> keyparsers, IEnumerable<Parse<TValue>> valueparsers) {
			this.keyparsers = new List<Parse<TKey>>(keyparsers);
			this.valparsers = new List<Parse<TValue>>(valueparsers);
		}

	}
}

