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
		return "Programmers agree on one thing: there is no agreement about what's the best typing system: static or dynamic [Jonas: strong, weak, safe, unsafe vermelden?]. What typing systems are used? Why? And more importanly: what are the advantages?";
	}
	
	public function answers(){
		$lua = parent::luaSays("Lua has a dynamic type sytem. This reduces the code-compile-test cycle because the compile step can be reduced.");
		
		$cpp = parent::cppSays("But this way you can have problems at run-time while they could be detected at compile-time. So the programmer has the burden that he/she must write code that will be valid at run-time. Also for compiled languages it's cheaper to do compile-time type checking" . parent::bib()->cite(2));
		
		$cSharp = parent::cSharpSays("");
		
		$lua2 = parent::luaSays("Lua is also weakly typed. Lua uses a system that is named coercion. This system can convert numbers to strings and vice versa when this is appropriate." . parent::bib()->cite(4) . " An important exception is that coercion isn't performed in comparison operators.");
		
		$python = parent::pythonSays("Although weakly typed can be easy to use, it can also introduce ambiguity in the language. This makes is harder for beginners.");
		
		$lua3 = parent::luaSays("I agree. In retrospect, we could have removed this" . parent::bib()->cite(0) . ".");
		
		return $lua.$cpp.$cSharp.$lua2.$python.$lua3;
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
