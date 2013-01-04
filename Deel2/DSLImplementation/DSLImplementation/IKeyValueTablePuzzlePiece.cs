using System;

namespace DSLImplementation.UserInterface
{
	public interface IKeyValueTablePuzzlePiece<TKey,TValue> : IPuzzlePiece {

		KeyValueTable<TKey,TValue> Table {
			get;
		}

	}
}

