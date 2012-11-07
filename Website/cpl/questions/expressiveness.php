<?php
error_reporting(-1);
ini_set('display_errors', '1');
include_once("question.php");
include_once("bibliography.php");

class Expressiveness extends Question {	
	public function __construct() {
		parent::__construct($this);
	}

	public function questionName(){
		return "How expressive is Lua?";
	}
	
	public function introduction(){
		return "Some people call it entropy: the amount of information one stores in a fixed number of characters. How expressive is Lua compared to it's contestants? What are the domains Lua can talk about?";
	}
	
	public function answers(){
		//GUI, data serializeren, SQL
		$code0 = $this->code($this->readFromFile("code/LinqExample.cs"), "c#");
		$code1 = $this->code($this->readFromFile("code/templateProgramming.cpp"), "c++");
		$code2 = $this->code($this->readFromFile("code/coroutines.lua"), "lua");
		$code3 = $this->code($this->readFromFile("code/YieldExample.cs"), "c#");
		$code4 = $this->code($this->readFromFile("code/YieldExample.java"), "java");
		$cSharp0 = parent::cSharpSays("In C# expressiveness is mainly supported by introducing special syntax for domain specific features. As an example take for instance the LINQ framework. It enables one to write object-oriented queries in SQL-style:".$code0);
		$lua0 = parent::luaSays("I don't see the importance of this syntactical sugar. It's a nice feature that eliminates a lot of noise, but one can't argue by using LINQ the amount of code is reduced signifcantly since one can write this by method calls. In my opinion the expressiveness of a language is more determined by the ability of the compiler to modify simple lines of code into a complex structure. Since this reduces the amount of work the programmer needs to do.");
		$cpp0 = parent::cppSays("I agree with Lua. The syntactical sugar of LINQ is very nice, but it doesn't yield that much gain. C++ has for instance template programming. It is a powerfull mechanism to generalize code and reduces the amount of code significantly.");
		$java0 = parent::javaSays("I don't really see what's so unique about template programming C++. Java has generic classes to reduce the amount of code. Since generic classes use type parameters, it's a kind of template.");
		$cpp0 = parent::cppSays("Template programming goes beyond generic classes. You can do some nice things with generic classes but template programming is turing complete.");
		$java1 = parent::javaSays("Can you give an example of this principle?");
		$cpp1 = parent::cppSays("Sure, look at the following piece of code:".$code1.". In the above code one calculates the factorial of 4. Instead of building a method to calculate the result, one simply creates a class that holds the result of the factorial of 4. The result is thus calculated at compile time! Of course this minimal example won't gain that much performance, but I think one can imagine we can calculate a lot of partial results at compile time. Furthermore template programming enables the programmer to let the compiler write code that is way to long or complex to be written by hand.");
		$lua1 = parent::luaSays("My question to C++ is: do you see any advantage of this if you run code by an interpreter. Since the interpreter is working at runtime, such optimizations will probably don't yield any benefit. However even Lua has some structures to make the language more expressive, but keep in mind since the language is interpreted, we can't go that far. A powerful principle are coroutines.");
		$java2 = parent::javaSays("What are coroutines?");
		$lua2 = parent::luaSays("Coroutines are methods who work in a collaborative fashion with the main program. They have their own stack and local variables, but are used for instance for data manipulation. One can think of the like threads. However coroutines work sequentially.");
		$java3 = parent::javaSays("I don't really understand what you mean? How do you work with these methods and how to they know when they should be executed? Can you give a minimal example?");
		$lua3 = parent::luaSays("Well as I already said a typical application is data generation or data modification. So take a look at the following code: ".$code2."You see a function who returns the chemical symbols of all noble gasses. No we can turn this method into a coroutine and use that method in a loop. As long as their are still symbols, the coroutine is still alive and we can print symbols. Now i guess one can imagine a method where we simple generate all prime numbers. One can this function as a coroutine to generate for instance all prime numbers smaller than 42.");
		$cSharp1 = parent::cSharpSays("C# has a similar feature: however the fact that you are working with a coroutine doesn't has to be specified. One simply uses the yield statement in order to emit an element of the list.");
		$lua4 = parent::luaSays("I'm not entirely sure we this feature is exactly the same. Can you give me an example?");
		$cSharp2 = parent::cSharpSays("Sure:".$code3);
		$java2 = parent::javaSays("That looks nice, but again it's more syntactical sugar. In Java you can emulate those coroutines in the following way:".$code4);
		$lua5 = parent::luaSays("True, but I don't see why that's relevant Java? Of course everything can be emulated since all languages here are turing complete. But we are talking about expressiveness. In C# you can write in 30 lines what requires 50 in Java. Since this is only a minimal example, I expect the difference to grow more significant with more complicated examples.");
		$java4 = parent::javaSays("But I guess internally the compiler or the runtime environment will modify the code to an object-oriented pattern.");
		$cpp3 = parent::cppSays("");
		//$lua0 = parent::luaSays("Lua aims to be an expressive language. A proof of this expressiveness is for instance coroutine support.");
		//$cSharp0 = parent::cSharpSays("What makes coroutines actually an expressive part of the language? C# itself has coroutine support too. Of course it helps the programmer to specify better list generation, but it doesn't but let's say that it adds only little expressiveness to the language.");
		//$lua1 = parent::luaSays("That's partly because the coroutine support in C# is somehow limited to list generation.");
		//$cSharp0 = parent::cSharpSays("How does coroutines actually relate to this discussion. C# has coroutines too, but that doesn't make the language that much more expressive.");
		//$lua0 = parent::luaSays("Well, Lua has no built-in functionalities, it doesn't has syntactical sugar for most features other languages support easily. However it has some standard libraries to cope with these problems. Most of these libraries try to implement short but general methods to cope with a lot of problems at once.");
		//$cSharp0 = parent::cSharpSays("Since C# is an object oriented language, syntactical");
		//$lua = parent::luaSays("Lua has builtin functionality for matching regular expressions and file I/O. Lambda, XML library bestaat maar niet standaard meegeleverd, Library nodig");
		
		//$cSharp = parent::cSharpSays("C# doesn't have such functionalities. However it has the LINQ framework, this framework comes with additional syntax to write queries to objects. Furthermore, like C++ it has operator overloading. Everything in classes, lambda, XML (na system.xml import)");
		
		//$cpp = parent::cppSays("Operator overloading, lambda, alles in library die niet meegeleverd is");
		
		//$python = parent::pythonSays("Operator overloading, regular expressions, file I/O, lambda, standaard support xml");
		
		//$haskell = parent::haskellSays("Easy to write statements that can be easily parallellised. lambda :), ");
		
		//$java = parent::javaSays("not expressive (geen operator overloading, ... + decorator file input vb), lambda (wss in java 8), xml zit er standaard in maar is lelijk en niet echt expressief");

		return $cSharp0.$lua0.$cpp0.$java1.$cpp1.$lua1.$java2.$lua2.$java3.$lua3.$cSharp1.$lua4.$cSharp2.$java2.$lua5.$java4.$cpp3;
	}
	
	public function link(){
		return "expressiveness.php";
	}
	
	public function name(){
		return "Expressiveness";
	}
	
	public function bibliography(){
		return parent::bib()->format();
	}
}
?>
