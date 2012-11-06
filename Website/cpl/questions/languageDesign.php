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
		//aligneert Lua zijn arrays? Worden er bijvoorbeeld referenties gebruikt ipv de data zelf zodat alles in 64 bit past?
		$lua0 = parent::luaSays("as simple as possible +voorbeelden");
		$cpp0 = parent::cppSays("not good for performance, because it is to general +voorbeelden. How is your design, c#?");
		$cShahrp0 = parent::cSharpSays("multiparadigm and oo");
	
		$lua = parent::luaSays("multiparadigm\n[Requirement: geen OOP, embeddable, portable (geen veronderstelling onderliggende hardware), simple (alles is tables), functioneel, tables in lua mogen verschillende types hebben => cache problemen, table highly optimized (can be array or associative array internally)]");
		
		$cpp = parent::cppSays("Wel OOP. Gaandeweg functioneel programmeren invloed. Niet zo portable, tuples mogen verschillende type hebben (anders strikt)");
		
		$cSharp = parent::cSharpSays("Kloon java, dus vereist OOP & portable. Gaandeweg functioneel programmeren invloed. Vorm van dynamic typing, strikt type");
		
		$java = parent::javaSays("OOP, portable");
		
		$haskell = parent::haskellSays("Pure lambda calculus implementatie, portable (geen veronderstelling onderliggende hardware maar geen cross compiler)");
		
		return $lua.$cpp.$cSharp.$java.$haskell;
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
