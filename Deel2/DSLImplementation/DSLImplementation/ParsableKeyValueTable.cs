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
		public ParsableKeyValueTable () {
			this.keyparsers = new List<Parse<TKey>>();
			this.valparsers = new List<Parse<TValue>>();
		}
		public IEnumerable<KeyValuePair<string,string>> GetKeyValues () {
			foreach(KeyValuePair<TKey,TValue> kvp in this) {
				yield return new KeyValuePair<string, string>(kvp.Key.ToString(),kvp.Value.ToString());
			}
		}
		public void AddParserPair (Parse<TKey> keyparser, Parse<TValue> valparser) {
			this.keyparsers.Add(keyparser);
			this.valparsers.Add(valparser);
		}
		public void SetKeyValues (IEnumerable<KeyValuePair<string,string>> keyvalues) {
			int n = Math.Min (Math.Min (keyparsers.Count, this.Count), valparsers.Count), i = 0x00;
			TKey keyt;
			string skey, sval;
			foreach(KeyValuePair<string,string> kvp in keyvalues) {
				skey = kvp.Key;
				sval = kvp.Value;
				for (; i < n; i++) {
					keyt = keyparsers [i] (skey);
					if (this [i].Key.Equals (keyt)) {
						this[i] = new KeyValuePair<TKey, TValue>(keyt,valparsers[i](sval));
						break;
					}
				}
			}
		}
		public void CheckCanParse (string key, string value)
		{
			int n = Math.Min (Math.Min (keyparsers.Count, this.Count), valparsers.Count), i = 0x00;
			TKey keyt;
			for (; i < n; i++) {
				keyt = keyparsers [i] (key);
				if (this [i].Key.Equals (keyt)) {
					this.valparsers [i] (value);
					return;
				}
			}
			if (i < this.Count) {
				throw new ArgumentException("No parser found to parse this data!");
			}
			else {
				throw new ArgumentException("Cannot find the proper key!");
			}
		}

	}
}

