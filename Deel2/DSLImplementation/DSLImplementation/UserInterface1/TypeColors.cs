using System;

namespace DSLImplementation.UserInterface {

	[Flags]
	public enum TypeColors : ulong {
		None			= 0x000000,
		Blue			= 0x000001,
		Green			= 0x000002,
		Cyan			= 0x000004,
		Red				= 0x000008,
		Magenta			= 0x000010,
		Brown			= 0x000020,
		LightGray		= 0x000040,
		DarkGray		= 0x000080,
		BrightBlue		= 0x000100,
		BrightGreen		= 0x000200,
		BrightCyan		= 0x000400,
		BrightRed		= 0x000800,
		BrightMagenta	= 0x001000,
		BrightYellow	= 0x002000,
		White			= 0x004000,
		Orange			= 0x008000,
		Purple			= 0x010000,
		All				= 0x01ffff
	}
}

