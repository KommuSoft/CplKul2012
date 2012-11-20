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
		$codeEx1 = $this->codeInline($this->readFromFile("code/LuaSemicolonExample.lua"), "lua");
		$codeEx2 = $this->codeInline($this->readFromFile("code/LuaMultipleAssignmentExample.lua"), "lua");
		$codeEx2b = $this->codeInline($this->readFromFile("code/TryAtMultipleAssignmentExample.java"), "java");
		$codeEx3 = $this->codeInline($this->readFromFile("code/JavaSpecialAssignmentExample.java"), "java");
		$codeEx4 = $this->codeInline($this->readFromFile("code/LuaSwapValuesExample.lua"), "lua");
		$codeEx5 = $this->codeInline($this->readFromFile("code/CPPMultipleAssignmentExample.cpp"), "c++");

		$lua0 = parent::luaSays("In Lua, it isn't necessary to have a separator between consecutive statements, but a semicolon is allowed for those who like to. Furthermore, line breaks play no role in Lua, Lua is a so called free format language. To illustrate this, all following groups of statements are valid and equivalent." . $codeEx1);

		$java0 = parent::javaSays("In Java, you can put multiple statements on the same line, but the semicolon is necessary. It makes the code more readable by using it. Is there a special reason for making the semicolon optional?");
		
		$lua1 = parent::luaSays("The designers thought that it could be a little confusing for people with a Fortran background by requiring semicolons. However, not allowing them could confuse people with a Pascal or C background. For that reason, optional semicolons were introduced".parent::bib()->cite(0).". Another feature that is nonexistent in some other languages, is the concept of multiple assignments (and multiple returns from function calls). This means for example that a list of values can be assigned to a list of variables. To give an example:".$codeEx2."The result is that the variable x gets the value 100 and the variable y gets the value 200.");//Java heeft wel een expressie int x=100,y=100 (alleen werkt dit niet met lijsten)!
		
		$java1 = parent::javaSays("In Java, you can do something that is semantically equivalent, I think. For example:".$codeEx2b);		

		$lua2 = parent::luaSays("I didn't explain it well. Lua evaluates all the values on the right side and then performs the assignment, so that's the difference. In this way, it is very easy to swap two values.".$codeEx4);

		$cpp0 = parent::cppSays("C++ can do something that looks the same. Although it's syntactically the same thing, semantically it's very different. It's even more curious with parentheses. Here is an example." . $codeEx5 . "This so because this is'nt a list like in Lua, the ',' is actually an operator.");

		$java2 = parent::javaSays("What happens in Lua when the numbers of elements isn't the same on both sides? Does this result in an error?");

		$lua3 = parent::luaSays("Surprisingly not. If the number of elements on the right is less than the number of elements on the left, then the extra variables on the left will receive nil as their value. But if the number of elements on the left are less than the number of elements on the right, then the extra values will be discarded.");

		$python1 = parent::pythonSays("Python also supports multiple assignments. But Python is more strict, the number of values on both sides of the '=' have to match.");

		$java3 = parent::javaSays("");

		$lua4 = parent::luaSays("");
//Bron van het bovenstaande: vooral het boek Programming in Lua (2de editie) van ROBERTO IERUSALIMSCHY


//Jonas: Syntax en semantiek zijn soms aan elkaar gekoppeld maar toch heb ik het moeilijk met "length" en "maxn". Een goede plaats weet ik niet echt, ze vallen volgens mij tussen syntax en language design. Aangezien er bij language design zeker wat verteld zal worden over tables, zou ik het dan daar plaatsen. PJ: als ik het goed begrepen heb, gaat semantics over de betekenis van expressies. En de length operator betekent verschillende dingen in de verschillende talen.
//the length operator werkt niet correct bij tabellen waarin nil elementen zitten. In alle andere talen werkt dit wel vermoed ik. Een vb.
//x = {}
//x[1] = "begin"
//x[100] = "einde"
//rarara, wat is de uitvoer van print(#x)? -> 1. Reden x[2] is een nil waarde, dus dat wordt als het einde van de table gezien.

//you can use the function table.maxn, which returns the largest numerical positive index of a table, vb:
//a = {}
//a[10000] = 1
//print(table.maxn(a))
//uitvoer --> 10000

		$lua5 = parent::luaSays("Lua has also very few keywords. Only 22. How much keywords do the other languages have?"); //TODO: misschien vraag specieker maken (bv rechtstreeks aan C++ vragen)
		
		$cpp1 = parent::cppSays("86" . parent::bib()->cite(15));
		
		$java4 = parent::javaSays("50 but two of them are unused and only reserverd" . parent::bib()->cite(20) . "But how does this correspond to the syntax");
		
		$lua6 = parent::luaSays("Designed for end users => they are not able to learn a programming language => as simple as possible but not simpler => few keywords is good");
		
//ook slechts 22 keywords in lua
//and       break     do        else      elseif    end
//false     for       function  goto      if        in
//local     nil       not       or        repeat    return
//then      true      until     while


		$lua = parent::luaSays("Verbose syntax");
		
		$cpp = parent::cppSays("Matig verbose (curly braces, )");
		
		$cSharp = parent::cSharpSays("Matig verbose");
		
		$java = parent::javaSays("quasi verbose");
		
		$python = parent::pythonSays("niet verbose");
		
		$haskell = parent::haskellSays("niet verbose");
		
		return $lua0.$java0.$lua1.$java1.$lua2.$cpp0.$java2.$lua3.$python1.$lua4.$cpp1.$java3.$lua5;
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
