using System;

namespace DSLImplementation.UserInterface {

	[Flags]
	public enum TypeColors : ulong {
		Red		= 0x01,
		Green	= 0x02,
		Blue	= 0x04,
		Yellow	= 0x08,
		Purple	= 0x10,
		Orange	= 0x20,
		White	= 0x40
	}
}

