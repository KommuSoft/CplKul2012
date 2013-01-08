using System;
using System.Collections.Generic;

namespace DSLImplementation.UserInterface {

	public class TypeBind {

		private readonly Type type;
		private readonly Dictionary<string,string> bindingtable;

		public Type Type {
			get {
				return type;
			}
		}
		public Dictionary<string, string> Bindingtable {
			get {
				return bindingtable;
			}
		}

		public TypeBind (Type type) {
			this.type = type;
			this.bindingtable = null;
		}
		public TypeBind (Type type, Dictionary<string,string> bindingtable) {
			this.type = type;
			this.bindingtable = bindingtable;
		}
		public TypeBind (Type type, params string[] bindingtable)
		{
			this.type = type;
			if (bindingtable.Length > 0x00) {
				this.bindingtable = new Dictionary<string, string> ();
				for (int i = 0x00; i < bindingtable.Length; i += 0x02) {
					this.bindingtable.Add (bindingtable [i], bindingtable [i + 0x01]);
				}
			} else {
				this.bindingtable = null;
			}
		}

		public static bool Match (TypeBind tb, IPuzzlePiece ipp) {
			return (ipp != null && tb.type.IsAssignableFrom(ipp.GetType()));
		}
		public bool Match (IPuzzlePiece ipp) {
			return Match(this,ipp);
		}
		public static bool MatchAndBind (TypeBind tb, IPuzzlePiece ipp, Dictionary<string,object> tobind) {
			if(Match(tb,ipp)) {
				if(tb.bindingtable != null && tb.bindingtable.Count > 0x00) {
					if(!(ipp is IKeyValueTablePuzzlePiece<string,object>)) {
						return false;
					}
					KeyValueTable<string,object> conv = ((IKeyValueTablePuzzlePiece<string,object>) ipp).Table;
					foreach(KeyValuePair<string,string> entry in tb.bindingtable) {
						Console.WriteLine("Bind key {0} of {1}",entry.Key,ipp);
						try {
							tobind.Add(entry.Value,conv[entry.Key]);
						}
						catch(Exception e) {
							return false;
						}
					}
				}
				return true;
			}
			return false;
		}
		public static implicit operator TypeBind (Type t) {
			return new TypeBind(t);
		}

	}
}
