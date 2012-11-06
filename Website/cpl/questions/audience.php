<?php
error_reporting(-1);
ini_set('display_errors', '1');
include_once("question.php");
include_once("bibliography.php");

class Audience extends Question {	
	public function __construct() {
		parent::__construct($this);
	}

	public function questionName(){
		return "What's the target audience of Lua?";
	}
	
	public function introduction(){
		return "Every language has its own audience. Some languages are made for a particular audience, others discover by accident their audience.";
	}
	
	public function answers(){
		$WorldOfWarcraft = $this->popover("World of Warcraft", "World of Warcraft", "World of Warcraft is a massively multiplayer online role-playing game.");
		$monty = $this->popover("Monty Python's Flying Circus", "Title", "Uitleg");		
		$lua0 = parent::luaSays("merge sol del brazilie petrobras. Gemakkelijk data te verwerken, configuration files. Lua is erin geslaagd zichzelf up to date te houden.");

		$random = parent::cppSays("What are the implications of keeping yourself up to date? users themselves suggest adaptations for 'me''");

		$lua1 = parent::luaSays("backwards compatibility is not a real issue, because you can support your own vm. Furthermore we assume users will use a host language for functional aspects. Therefore Lua is more a glue-language.");

		$cpp2 = parent::cppSays("Thats quite easy. Lua uses the evolution of host languages instead of adapting itself to new trends. But of course thats one of the main reasons of the popularity of Lua: from the moment one language implements a feature, Lua can benefit from that implementation.");

		$csharp0 = parent::cSharpSays("C# aims to be a broad language. Mainly for business users and stand alone. Therefore backwards compatibility is an issue for C#. However obsolete features will dissapear eventually. I know that's a reason why some systems written in C# will break eventually. But removing bad concepts keeps a language fresh. Furthermore C# benefits also from the .NET framework. A framework where systems can be written in several compatible languages. Therefore it benefits from implementation in other languages, like Lua.");
		
		$lua = parent::luaSays("Lua was designed so it could be used by engineers, geologists and so forth" . parent::bib()->cite(0) . ". This visible through the fact that Lua doesn't have an intimidating syntax. Instead of using curly braces, Lua uses \"do\" and \"end\". In retrospect, Lua is currently used a lot in games, which wasn't a specific aim for the designers of Lua. There is even a book for writing Lua in combination with World of Warcraft. This suggests that Lua has achieved this goal very well. //// Lua has a garbage collector which results in a less steeper learning curve: we don't expect user to do bookkeeping about memory. This approach is very user friendly. Specially for non-technical users.");
		
		$cpp = parent::cppSays("In contrast to Lua, C++ isn't designed for end users. It's designed for people who want to write high performance systems but need object orientation, which isn't available in C (a highly popular language at that time), hence the original name \"C with classes\". //// C++ aims to be a performance language. Therefore it doesn't have a garbage collector. Doing memory management yourself results in a faster system. //// Although C++ has changed so much in the last years and thereby also its audience, the audience of Lua and C++ is very different. This doesn't mean they have a connection with each other. For example " . $WorldOfWarcraft . " has a C++ core with a layer of Lua for the user interface. 
[Willem: De hele game wereld werkt met C++, is dit statement betrouwbaar?]");

		$python = parent::pythonSays("The audience of Python is more like the audience of Lua. Everyone who wants to automate a certain task can use Python. This is why Python is very readable. Instead of using curly braces, Python uses indentation. An approach which is very similar to Lua's one. It's a language for everyone who wants to have fun, as long as you like " . $monty . ".//// Like Lua Python also has a garbage collector. However the system is quite open: one can turn off the garbage collector and implement one himself. Therefore both performance and general users benefit from Python.");


		$cSharp = parent::cSharpSays("C# aims to be a broad language: mainly for business purposes however some scientific libraries and applications are written in C# (for instance the Math.NET framework). Therefore it mixes a lot of concepts found in other languages. //// C# has a garbage collector the options available are quite the same as in Java. C# argues introducing a garbage collector will not slow down the system that much, the garbage collector is quite lazy. /// C# is quite extensible: it allows programmers to write code in other languages inside their C# code. For instance if you want to write a program where some methods should be executed quite fast, one can write Assembly code in C#. Lua is also supported" . parent::bib()->cite(3) .".");
		
		return $lua0.$random.$lua1.$lua.$cpp.$python.$cSharp;
	}
	
	public function link(){
		return "audience.php";
	}
	
	public function name(){
		return "Target audience";
	}
	
	public function bibliography(){
		return parent::bib()->format();
	}
}
?>
