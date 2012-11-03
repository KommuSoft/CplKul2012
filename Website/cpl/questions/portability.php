<?php
error_reporting(-1);
ini_set('display_errors', '1');
include_once("question.php");
include_once("bibliography.php");

class Portability extends Question {	
	public function __construct() {
		parent::__construct($this);
	}

	public function questionName(){
		return "What about the portability?";
	}
	
	public function introduction(){
		return "Each individual is walking in a \"Zoo of Platforms\". How are languages adapted to the purpose of portability?";
	}
	
	public function answers(){
		$lua = parent::luaSays("");
		$cpp = parent::cppSays("");
		$cSharp = parent::cSharpSays("");
		return $lua.$cpp.$cSharp;
	}
	
	public function link(){
		return "portability.php";
	}
	
	public function name(){
		return "Portability";
	}
	
	public function bibliography(){
		return parent::bib()->format();
	}
}
?>
