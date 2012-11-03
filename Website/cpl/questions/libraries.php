<?php
error_reporting(-1);
ini_set('display_errors', '1');
include_once("question.php");
include_once("bibliography.php");

class Libraries extends Question {	
	public function __construct() {
		parent::__construct($this);
	}

	public function questionName(){
		return "Has the machine some literature?";
	}
	
	public function introduction(){
		return "Newton already knew it: ''If I have seen further it is by standing on the shoulders of giants''. One can't simply implement everything. Are there good libraries available, or do we have to do it all by ourselves?";
	}
	
	public function answers(){
		$lua = parent::luaSays("");
		$cpp = parent::cppSays("");
		$cSharp = parent::cSharpSays("");
		return $lua.$cpp.$cSharp;
	}
	
	public function link(){
		return "libraries.php";
	}
	
	public function name(){
		return "Libraries";
	}
	
	public function bibliography(){
		return parent::bib()->format();
	}
}
?>
