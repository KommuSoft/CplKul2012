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
		
		$lua = parent::luaSays("Lua was designed so it could be used by engineers, geologists and so forth" . parent::bib()->cite(0) . ". This visible through the fact that Lua doesn't have an intimidating syntax. Instead of using curly braces, Lua uses \"do\" and \"end\". Also Lua does have a garbage collector which results in a less steeper learning curve. In retrospect, Lua is currently used a lot in games, which wasn't a specific aim for the designers of Lua. There is even a book for writing Lua in combination with World of Warcraft. This suggests that Lua has achieved this goal very well. [TODO: portable vermelden?] [TODO: geschiedenis zegt dat Lua eerder ontwikkeld is om twee eerdere talen DEL en SOL uit te breiden (mss vermelden)]");
		
		$cpp = parent::cppSays("In contrast to Lua, C++ isn't designed for end users (i.e. geologists, game designers). It's designed for people who want to write high performance systems but need object orientation, which isn't available in C (a highly popular language at that time), hence the original name \"C with classes\". Although C++ has changed so much in the last years and thereby also its audience, the audience of Lua and C++ is very different. This doesn't mean they have a connection with each other. For example " . $WorldOfWarcraft . " has a C++ core with a layer of Lua for the user interface. 
[Willem: De hele game wereld werkt met C++, is dit statement betrouwbaar?]");

		$python = parent::pythonSays("The audience of Python is more like the audience of Lua. Everyone who wants to automate a certain task can use Python. This is why Python is very readable. Instead of using curly braces, Python uses indentation. An approach which is very similar to Lua's one. Like Lua Python also has a garbage collector. It's a language for everyone who wants to have fun, as long as you like " . $monty . ". [TODO: portable vermelden?]");


		$cSharp = parent::cSharpSays("C# aims to be a broad language: mainly for business purposes however some scientific libraries and applications are written in C# (for instance the Math.NET framework). Therefore it implements most of features that can be found in other languages (even constructions who are considered harmfull like the goto statement). C# is quite extensible: it allows programmers to write code in other languages inside their C# code. For instance if you want to write a program where some methods should be executed quite fast, one can write Assembly code in C#. Lua is also supported" . parent::bib()->cite(3) .".");
		
		return $lua.$cpp.$python.$cSharp;
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
