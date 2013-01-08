using System;
using System.Collections.Generic;

namespace DSLImplementation.UserInterface {

	public class TypeBind {

		private readonly Type type;
		private readonly Dictionary<string,string> bindingtable;
		private readonly int index = -0x01;

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
		public int Index {
			get {
				return index;
			}
		}

		public TypeBind (Type type) {
			this.type = type;
		}
		public TypeBind (Type type, int index) : this(type) {
			this.index = index;
		}
		public TypeBind (Type type, Dictionary<string,string> bindingtable) : this(type) {
			this.bindingtable = bindingtable;
		}
		public TypeBind (Type type, int index, Dictionary<string,string> bindingtable) : this(type,index) {
			this.bindingtable = bindingtable;
		}
		public TypeBind (Type type, params string[] bindingtable) : this(type) {
			if (bindingtable.Length > 0x00) {
				this.bindingtable = new Dictionary<string, string> ();
				for (int i = 0x00; i < bindingtable.Length; i += 0x02) {
					this.bindingtable.Add (bindingtable [i], bindingtable [i + 0x01]);
				}
			} else {
				this.bindingtable = null;
			}
		}
		public TypeBind (Type type, int index, params string[] bindingtable) : this(type,bindingtable) {
			this.index = index;
		}

		public static bool Match (TypeBind tb, int index, IPuzzlePiece ipp) {
			return (ipp != null && tb.type.IsAssignableFrom(ipp.GetType()) && (tb.index == -0x01 || tb.index == index));
		}
		public bool Match (IPuzzlePiece ipp, int index) {
			return Match(this,index,ipp);
		}
		public static bool MatchAndBind (TypeBind tb, int index, IPuzzlePiece ipp, Dictionary<string,object> tobind) {
			if(Match(tb,index,ipp)) {
				if(tb.bindingtable != null && tb.bindingtable.Count > 0x00) {
					Console.WriteLine("tromgeroffel2...");
					if(!(ipp is IKeyValueTablePuzzlePiece<string,object>)) {
						Console.WriteLine("...tadaa");
						return false;
					}
					KeyValueTable<string,object> conv = ((IKeyValueTablePuzzlePiece<string,object>) ipp).Table;
					foreach(KeyValuePair<string,string> entry in tb.bindingtable) {
						Console.WriteLine("Bind key {0} of {1}",entry.Key,ipp);
						try {
							tobind.Add(entry.Value,conv[entry.Key]);
						}
						catch {
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

