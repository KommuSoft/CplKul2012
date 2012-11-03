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
		$lua = parent::luaSays("");
		$cpp = parent::cppSays("");
		$cSharp = parent::cSharpSays("");
		return $lua.$cpp.$cSharp;
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
