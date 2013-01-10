using System;
using DSLImplementation.UserInterface;
using System.Collections.Generic;

namespace DSLImplementation.Tiling {

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
			return (ipp != null && (tb.index == -0x01 || tb.index == index) && ipp.Match(tb));
		}
		public bool Match (IPuzzlePiece ipp, int index) {
			return Match(this,index,ipp);
		}
		public static bool MatchBind (TypeBind tb, int index, IPuzzlePiece ipp, Dictionary<string,object> tobind) {
			if(Match(tb,index,ipp)) {
				return ipp.MatchBind(tb,tobind);
			}
			return false;
		}
		public bool MatchBind (int index, IPuzzlePiece ipp, Dictionary<string,object> tobind) {
			return TypeBind.MatchBind(this,index,ipp,tobind);
		}
		public static implicit operator TypeBind (Type t) {
			return new TypeBind(t);
		}
		public override string ToString () {
			return string.Format ("[TypeBind: Type={0}, Bindingtable={1}, Index={2}]", Type, Bindingtable, Index);
		}

	}
}

