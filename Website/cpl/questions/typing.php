<?php
error_reporting(-1);
ini_set('display_errors', '1');
include_once("question.php");
include_once("bibliography.php");

class Typing extends Question {	
	public function __construct() {
		parent::__construct($this);
	}

	public function questionName(){
		return "What about the typing system?";
	}
	
	public function introduction(){
		return "Programmers agree on one thing: there is no agreement about what's the best typing system: static or dynamic. What typing systems are used? Why? And more importanly: what are the advantages?";
	}
	
	public function answers(){
		$lua = parent::luaSays("");
		$cpp = parent::cppSays("");
		$cSharp = parent::cSharpSays("");
		return $lua.$cpp.$cSharp;
	}
	
	public function link(){
		return "typing.php";
	}
	
	public function name(){
		return "Typing";
	}
	
	public function bibliography(){
		return parent::bib()->format();
	}
}
?>
