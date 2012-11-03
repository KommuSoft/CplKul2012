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
		$codeEx1 = "int main(){
	unsigned long size = 5;
	int arr[size];
}";
	
		$lua = parent::luaSays("Lua is very portable. There are a couple reasons for this. Like I said before Lua was designed to be used by a lot of different people. This means that a lot of different systems can be used. So Lua wa designed with portability in mind. Another point is that Lua was (and is) designed to be a small language. The designers say it's easier to add a feature than removing an excessive one. Also they aren't afraid to break backwards compatibility. This results in a small language. For example: the reference manual is less than 100 pages. How big is the C++ reference?");
		
		$cpp = parent::cppSays("More than 1300 pages." . parent::bib()->cite(1) . " But C++ can't permit to break backwards compatibility. The language is used very intensively. Also Lua users can download the interpreter and support it themselves, something that is much much more difficult to do with C++. The reason why C++ isn't that portable in real life, is that compiler writers and library designers create stuff that is useful but not portable. For example the following code isn't valid C++" . $this->codeInline($codeEx1, "c++") . "Although some compilers accept it and make a C++ extension of it.");
		
		$python = parent::pythonSays("That's why Python has a \"batteries included\" philosophy. A lot of functionality is implemented in the Python standard, so less libraries are needed and better portability is achieved. Also good for portability is a small group of designers. This ensures that the global is consistent through the whole language. [TODO: goed argument?]");
		
		$lua2 = parent::luaSays("But that leads to a more bloated language. Also it introduces problems if the languages changes, so there can be backwards compability problems.");
		
		$cSharp = parent::cSharpSays("[Jonas: vertel dat C# dat mooi oplost door abstractie te maken van taal en framework maar ze hebben sterke integratie, vb. ASP]");
		
		return $lua.$cpp.$python.$lua2.$cSharp;
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
