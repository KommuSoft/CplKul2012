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

		$codeEx1 = 
"x = 4
y = 2*x

x = 4;
y = 2*x;

x = 4 y = 2*x

x = 4; y = 2*x;";

		$codeEx2 =
"x,y = 100,200"; 

		$codeEx3 = 
"int a,b;
a = b = 100;"; 

		$codeEx4 = 
"x,y = y,x";

		$lua0_1 = parent::luaSays("In Lua, it isn't necessary to have a separator between consecutive statements, but a semicolon is allowed for those who like to. Furthermore, line breaks play no role in Lua.
To illustrate this, all following groups of statemens are valid and equivalent." . $this->codeInline($codeEx1, "lua"));

		$java0_1 = parent::javaSays("In Java, you can put multiple statements on the same line, but the semicolon is necessary. It makes the code more readable by using it. Are there other unusual things that can be written in Lua?");

		$lua0_2 = parent::luaSays("Another feature that isn't present in Java is the concept of multiple assignments. This means for example that a list of values can be assigned to a list of variables. An example is given:" .$this->codeInline($codeEx2, "lua"). "The result is that the variable x gets the value 100 and the variable y gets the value 200.");

		$java0_2 = parent::javaSays("Java can do something similar. The same value can be assigned to different variables in one statement. For example,". $this->codeInline($codeEx3, "java") . "But I have to admit that this is more limited. I was also wondering what happens if the number of elements isn't the same on both sides. Does this result in an error?");

		$lua0_3 = parent::luaSays("Surprisingly no. If the number of elements on the right is less than the number of elements on the left, then the extra variables on the left will receive nil as their value. But if the number of elements on the left are less than the number of elements on the right, then the extra values will be discarded.");

		$java0_3 = parent::javaSays("Ok, now I think I have a good understanding of how it works. But I am missing a good example where this construct really proves its usefulness");

		$lua0_4 = parent::luaSays("Let's think. Ok, I know. When you need to swap two values, just one expression is needed." .$this->codeInline($codeEx4, "lua"). "So no explicit temporary variable is used. Here, Lua evaluates all the values on the right side and then performs the assignment. To refer to my second example, multiple assignment doesn't work faster than when you had put that expression on two lines."); 
//Bron van het bovenstaande: vooral het boek Programming in Lua (2de editie) van ROBERTO IERUSALIMSCHY

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
		
		return $lua0_1.$java0_1.$lua0_2.$java0_2.$lua0_3.$java0_3.$lua0_4;
		//return $lua.$cpp.$cSharp.$java.$python.$haskell;
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
