<?php
error_reporting(-1);
ini_set('display_errors', '1');
include_once("question.php");
include_once("bibliography.php");

class Syntax extends Question {	
	public function __construct() {
		parent::__construct($this);
	}

	public function questionName(){
		return "Does the language provide some eye-candy?";
	}
	
	public function introduction(){
		return "Ever written a document in LaTeX? It looks beautiful. Programming code can have the same characteristics. What are the main differences in syntax and what makes one syntactical family better than the other one.";
	}
	
	public function answers(){
		$lua = parent::luaSays("Verbose syntax");
		
		$cpp = parent::cppSays("Matig verbose (curly braces, )");
		
		$cSharp = parent::cSharpSays("Matig verbose");
		
		$java = parent::javaSays("quasi verbose");
		
		$python = parent::pythonSays("niet verbose");
		
		$haskell = parent::haskellSays("niet verbose");
		
		return $lua.$cpp.$cSharp.$java.$python.$haskell;
	}
	
	public function link(){
		return "syntax.php";
	}
	
	public function name(){
		return "Syntax";
	}
	
	public function bibliography(){
		return parent::bib()->format();
	}
}
?>
