using System;

namespace DSLImplementation.UserInterface
{
	public interface IKeyValueTablePuzzlePiece<TKey,TValue> : IPuzzlePiece {

		ParsableKeyValueTable<TKey,TValue> Table {
			get;
		}

	}
}

