<?php
error_reporting(-1);
ini_set('display_errors', '1');
include_once("question.php");
include_once("bibliography.php");

class Expressiveness extends Question {	
	public function __construct() {
		parent::__construct($this);
	}

	public function questionName(){
		return "How expressive is Lua?";
	}
	
	public function introduction(){
		return "Some people call it entropy: the amount of information one stores in a fixed number of characters. How expressive is Lua compared to it's contestants? What are the domains Lua can talk about?";
	}
	
	public function answers(){
		//GUI, data serializeren, SQL
		$lua0 = parent::luaSays("Lua aims to be an expressive language. However Lua is not expressive in the sense domain specific features are supported in the syntax. But more in the broad way: it supports some features who are quite usefull like coroutines.");
		$cSharp0 = parent::cSharpSays("What makes coroutines actually an expressive part of the language?");
		$lua1 = parent::luaSays("I think the expressiveness of coroutines is well known. It is a feature introduced in the 60's and still active in a lot of programming languages.");
		//$cSharp0 = parent::cSharpSays("How does coroutines actually relate to this discussion. C# has coroutines too, but that doesn't make the language that much more expressive.");
		//$lua0 = parent::luaSays("Well, Lua has no built-in functionalities, it doesn't has syntactical sugar for most features other languages support easily. However it has some standard libraries to cope with these problems. Most of these libraries try to implement short but general methods to cope with a lot of problems at once.");
		//$cSharp0 = parent::cSharpSays("Since C# is an object oriented language, syntactical");
		//$lua = parent::luaSays("Lua has builtin functionality for matching regular expressions and file I/O. Lambda, XML library bestaat maar niet standaard meegeleverd, Library nodig");
		
		//$cSharp = parent::cSharpSays("C# doesn't have such functionalities. However it has the LINQ framework, this framework comes with additional syntax to write queries to objects. Furthermore, like C++ it has operator overloading. Everything in classes, lambda, XML (na system.xml import)");
		
		//$cpp = parent::cppSays("Operator overloading, lambda, alles in library die niet meegeleverd is");
		
		//$python = parent::pythonSays("Operator overloading, regular expressions, file I/O, lambda, standaard support xml");
		
		//$haskell = parent::haskellSays("Easy to write statements that can be easily parallellised. lambda :), ");
		
		//$java = parent::javaSays("not expressive (geen operator overloading, ... + decorator file input vb), lambda (wss in java 8), xml zit er standaard in maar is lelijk en niet echt expressief");

		return $lua0.$cSharp0.$lua1;
	}
	
	public function link(){
		return "expressiveness.php";
	}
	
	public function name(){
		return "Expressiveness";
	}
	
	public function bibliography(){
		return parent::bib()->format();
	}
}
?>
