using System;

namespace DSLImplementation.UserInterface {

	[Flags]
	public enum TypeColors : ulong {
		None	= 0x0000000000000000,
		Red		= 0x0000000000000001,
		Green	= 0x0000000000000002,
		Blue	= 0x0000000000000004,
		Yellow	= 0x0000000000000008,
		Purple	= 0x0000000000000010,
		Orange	= 0x0000000000000020,
		White	= 0x0000000000000040,
		Brown	= 0x0000000000000080,
		All		= 0x00000000000000ff
	}
}

