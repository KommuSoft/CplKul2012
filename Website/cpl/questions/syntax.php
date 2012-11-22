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
		$codeEx6 = $this->codeInline($this->readFromFile("code/LuaIndexFrom1Example.lua"), "lua");
		$codeEx7 = $this->codeInline($this->readFromFile("code/LuaIndexFrom0Example.lua"), "lua");
		$codeEx8 = $this->codeInline($this->readFromFile("code/LuaHolesInArray.lua"), "lua");

		$lua0 = parent::luaSays("In Lua, it isn't necessary to have a separator between consecutive statements, but a semicolon is allowed for those who like to. Furthermore, line breaks play no role in Lua, Lua is a so called free format language. To illustrate this, all following groups of statements are valid and equivalent." . $codeEx1);

		$java0 = parent::javaSays("In Java, you can put multiple statements on the same line, but the semicolon is necessary. It makes the code more readable by using it. Is there a special reason for making the semicolon optional?");
		
		$lua1 = parent::luaSays("The designers thought that it could be a little confusing for people with a Fortran background by requiring semicolons. However, not allowing them could confuse people with a Pascal or C background. For that reason, optional semicolons were introduced".parent::bib()->cite(0).". Another feature that is nonexistent in some other languages, is the concept of multiple assignments (and multiple returns from function calls). This means for example that a list of values can be assigned to a list of variables. To give an example:".$codeEx2."The result is that the variable x gets the value 100 and the variable y gets the value 200.");
		
		$java1 = parent::javaSays("In Java, you can do something that is semantically equivalent, I think. For example:".$codeEx2b);		

		$lua2 = parent::luaSays("I didn't explain it well. Lua evaluates all the values on the right side and then performs the assignment, so that's the difference. In this way, it is very easy to swap two values.".$codeEx4);

		$cpp0 = parent::cppSays("C++ can do something that looks the same. Although it's syntactically the same thing, semantically it's very different. It's even more curious with parentheses. Here is an example." . $codeEx5 . "This so because this isn't a list like in Lua, the ',' is actually an operator.");

		$java2 = parent::javaSays("What happens in Lua when the numbers of elements isn't the same on both sides? Does this result in an error?");

		$lua3 = parent::luaSays("Surprisingly not. If the number of elements on the right is less than the number of elements on the left, then the extra variables on the left will receive nil as their value. But if the number of elements on the left are less than the number of elements on the right, then the extra values will be discarded.");

		$python1 = parent::pythonSays("Python also supports multiple assignments. But Python is more strict, the number of values on both sides of the '=' have to match. As mentioned before, Lua supports multiple return values from function calls. How does this work? Is it just putting the return values, separated by commas, after the return statement?" );

		$lua4 = parent::luaSays("Indeed, it's as simple as that.");
		
		$cpp1 = parent::cppSays("Now, to discuss something else, arrays in for example C++, C# and Java all start at index 0. On the other hand, I know that arrays in Lua start at index 1. Is there a way to circumvent this and nevertheless let them start at index 0?");
		
		$lua5 = parent::luaSays("Yes, it's possible. This is done by explicitly declaring the first index of the array as 0.".$codeEx7."However, it isn't recommended. This is because most built-in functions assume that arrays start at index 1. So, an unexpected result will appear. This is seen in the example above where the length operator doesn't return the expected result. In the next example, the case is shown where the array is started at index 1.".$codeEx6);
		
		$csharp0 = parent::csharpSays("You introducted the length operator and its odd behaviour. Can you explain how it works? I suppose it is based on the indices of the array as shown in the two previous examples.");
		$lua6 = parent::luaSays("Yes, that's true. The length operator looks for the last index of an array and returns that result. Lua finds the end of the array by looking for a nil value. This is done because any non-initialized index gives a nil value. Consider the following code:".$codeEx8. "So, when there are holes in an array, it is better to avoid using the length operator if you want to know the length.");
		
		return $lua0.$java0.$lua1.$java1.$lua2.$cpp0.$java2.$lua3.$python1.$lua4.$cpp1.$lua5.$csharp0.$lua6;
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
