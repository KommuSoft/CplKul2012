<?php
error_reporting(-1);
ini_set('display_errors', '1');
include_once("question.php");
include_once("bibliography.php");

class LanguageDesign extends Question {	
	public function __construct() {
		parent::__construct($this);
	}

	public function questionName(){
		return "How do the blueprints look like?";
	}
	
	public function introduction(){
		return "Before we can write a program in a language, one first needs to design that language. What are the key ideas behind Lua, C++,...?";
	}
	
	public function answers(){
		$lua = parent::luaSays("[Requirement: geen OOP, embeddable, portable, simple]");
		
		$cpp = parent::cppSays("[Requirement: wel OOP]");
		
		$cSharp = parent::cSharpSays("");
		
		return $lua.$cpp.$cSharp;
	}
	
	public function link(){
		return "languageDesign.php";
	}
	
	public function name(){
		return "Language Design";
	}
	
	public function bibliography(){
		return parent::bib()->format();
	}
}
?>
