<?php
error_reporting(-1);
ini_set('display_errors', '1');
include_once("question.php");
include_once("bibliography.php");

class Learning extends Question {	
	public function __construct() {
		parent::__construct($this);
	}

	public function questionName(){
		return "What about the kids?";
	}
	
	public function introduction(){
		return "Each programmer once started as a freshman. Which languages are easy to learn? What actions were taken to make the language easier to learn?";
	}
	
	public function answers(){
		//Experiment doen met het aantal geactiveerde features voor een Hello World programma
	
		$lua = parent::luaSays("[Vertellen dat het voor end-users is en dus vanaf het begin al eenvoudig moest zijn.]");
		
		$cpp = parent::cppSays("Whereas Lua is designed for end-users, C++ was originally made for programmers. One of the requirements was that it must be easy to use for C programmers. In this perspective, C++ is easy to learn. But as time passed C++ changed and differs more and more from C.");

		//C# en Java niet geschikt om te leren (class nodig, ...)
		$cSharp = parent::cSharpSays("");
		
		//Python heel goed geschikt om te leren
		
		//Haskell goed wanneer je nog geen programmeertaal kent
		
		return $lua.$cpp.$cSharp;
	}
	
	public function link(){
		return "learning.php";
	}
	
	public function name(){
		return "Learning";
	}
	
	public function bibliography(){
		return parent::bib()->format();
	}
}
?>
