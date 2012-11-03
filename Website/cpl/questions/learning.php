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
		$lua = parent::luaSays("");
		$cpp = parent::cppSays("");
		$cSharp = parent::cSharpSays("");
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
