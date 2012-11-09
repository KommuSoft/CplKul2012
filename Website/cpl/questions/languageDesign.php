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
		$lua0 = parent::luaSays("Lua has always been based on very simple principles: each object is a first-order variable, the number of basic value types is fixed, and each concept that can't be stored as one of those basic types is a table.");
		$cSharp0 = parent::cSharpSays("And you can write each program based on this principle? Personally I think one needs a large amount of language structures. This eanbles the programmer to chose the most optimal construct in order to solve his problem.");
		$lua1 = parent::luaSays("Personally I strongly disagree with this idea: if the number of language structures increases so does the amount of options to consider. It makes software development harder. Another issue is consistency: sometimes such a program starts looking like ad hoc hacking. Aren't these programs just harder to read?");
		$cpp0 = parent::cppSays("I think it's a little bit strange to say such thing Lua. Since Lua is a very simple language, the concepts implemented are very general. This can make it quite hard to understand a program. Java, C++ and C# use an object-oriented approach. Therefore one can exactly know what will happen when we call a method of a certain object: if the object is not available at the most concrete class, it will search for an implementation higher in the class hierarchy. If it fails to find one, the compiler will throw an error. Doesn't make this approach the life of the programmer way more easy?");
		$java0 = parent::javaSays("I agree with C++. In Lua one defines functions on values. However most of these functions are builded with a particular object structure in mind. Since that information is implicit, the programmer must be patient enough to analyze a piece of Lua code. It generalizes a lot of features found in for instance Java by using for instance the ''fallback'' mechanism. However I'm not sure generalizing ideas will always yield better results. Will generalizing features not imply bad use?");
		$lua2 = parent::luaSays("I partly agree using a general approach can lead to bad usage. However one also has to consider the fact that the limited features in static-typed object oriented language yields some problems. In those languages, downcasts are quite common. Downcasts typically happen when the programmer can't give the compiler sufficient information about the stored data types. Downcasts are anoying, lead to a lot of errors (if the real value turns out to be from a different type) and in my opinion shows static typing still as to overcome some issues.");
		

		$lua0 = parent::luaSays("as simple as possible +voorbeelden");
		$cpp0 = parent::cppSays("not good for performance, because it is to general +voorbeelden. How is your design, c#?");
		$cShahrp0 = parent::cSharpSays("multiparadigm and oo");
	
		$lua = parent::luaSays("multiparadigm\n[Requirement: geen OOP, embeddable, portable (geen veronderstelling onderliggende hardware), simple (alles is tables), functioneel, tables in lua mogen verschillende types hebben => cache problemen, table highly optimized (can be array or associative array internally)]");
		
		$cpp = parent::cppSays("Wel OOP. Gaandeweg functioneel programmeren invloed. Niet zo portable, tuples mogen verschillende type hebben (anders strikt)");
		
		$cSharp = parent::cSharpSays("Kloon java, dus vereist OOP & portable. Gaandeweg functioneel programmeren invloed. Vorm van dynamic typing, strikt type");
		
		$java = parent::javaSays("OOP, portable");
		
		$haskell = parent::haskellSays("Pure lambda calculus implementatie, portable (geen veronderstelling onderliggende hardware maar geen cross compiler)");
		
		return $lua0.$cSharp0.$lua1.$cpp0.$java0.$lua2;
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
