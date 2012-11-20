<?php
error_reporting(-1);
ini_set('display_errors', '1');
include_once("question.php");
include_once("bibliography.php");

class Learning extends Question {	
	public function __construct() {
		parent::__construct($this);
	}

	public function questionName(){
		return "What about the kids?";
	}
	
	public function introduction(){
		return "Each programmer once started as a freshman. Which languages are easy to learn? What actions were taken to make the language easier to learn?";
	}
	
	public function answers(){
		//Experiment doen met het aantal geactiveerde features voor een Hello World programma
		
		$codeLuaIf = 'if 1==1 then
	print "equal"
end';

		$codePythonIf = 'if 1==1:
	print("equal")';
		
		$popoverTMP = parent::popover("TMP", "TMP", "Template Metaprogramming is a technique to write programs in templates, which are in C++ used for generics. Templates are proven to be Turing complete, so it's actually a programming language in another programming language.");
		
		$lua0 = parent::luaSays("Lua is a language that is very easy to learn. When the language was created, one of the requirements was that it should be very simple. The intention was to create a language that non-programmers (e.g. geologists, engineers, etc) could use.");
		
		$cpp0 = parent::cppSays("How is that elaborated in the language?");
		
		$lua1 = parent::luaSays("I will give an example." . parent::codeInline($codeLuaIf, "lua") . "The if statement starts with an 'if' followed by a condition. The word 'then' introduces the code that must be executed when the statement is true. At the end the word 'end' denotes the end of the if construct. This way Lua looks like English so this makes the language very readable.");
		
		$python0 = parent::pythonSays("But that's just some syntax, it's an alternative for writing curly braces, which indeed can look intimidating for beginners. This way Python is also very easy to learn. In Python the example above would look as follows" . parent::codeInline($codePythonIf, "python") . "You see that the if statements is followed by a colon, just like an explanation in English. Also Python forces indentation, this way beginners see easily which part of code belongs where.");
		
		$lua2 = parent::luaSays("That's right, but also the fact that the programmer doesn't have to specify the type of a variable makes the language easier. Another example is that Lua only contains tables as a container. This way the programmer doesn't need to know the different data structures. Tables are also very easy to use, once you know how they work, you can use them as arrays, maps, ...");
		
		$cSharp0 = parent::cSharpSays("But this way, you have a problem when a user wants to learn certain algorithms and data structures. If you want to implement a certain algorithm that uses an array, you can have problems because the array can be implemented as an associative array. So a different time complexity is possible. Also it's difficult for a user to learn certain paradigms with Lua. How do you use object-oriented programming in Lua?");
		
		$lua3 = parent::luaSays("In Lua you have to implement the inheritance system yourself. So in this sense Lua is bad for people who want to learn OOP but that's not the aim of Lua. Also if object-orientation is needed, Lua can use a host language. But Lua itself doesn't want you to force to think in a certain paradigm, like C# and Java do. A simple program like Hello World is already pretty long in these languages."); //Jonas: de pagina over oop zal wss vermelding maken over het inheritance systeem in Lua en een voorbeeld over inheritance in Lua zal dus daar staan. Hier is het dan misschien goed om een verwijzing naar die pagina te maken.
		
		$java0 = parent::javaSays("Indeed, you need to have a Main class, with a static main function which receives a couple of arguments. But on the other hand this way a novice will directly know the different things that are needed in object-oriented programming.");
		
		$haskell0 = parent::haskellSays("That's frustrating for a language that uses another paradigm. Haskell is actually a clean and easy to learn language. But a lot of people have problems with Haskell because some other languages force everyone to think in terms of objects.");
		
		$cSharp1 = parent::cSharpSays("I want to comment on what Lua said about C# that forces you to think in a certain paradigm. Nowadays C# is really becoming multiparadigm (which is maybe a paradigm by itself). For example functional programming (like Haskell) is somewhat supported in C#" . parent::bib()->cite(5) . ". I think C++ is going in a similar direction, am I correct?");
		
		$cpp1 = parent::cppSays("Yeah, but in the past this was different. C++ was originally made for programmers, in particular C programmers. In this perspective, C++ was easy to learn. This also led to the fact that no 'Main' class is needed, so in this sense C++ is easier than C# and Java. But indeed, the current C++ version supports multiple paradigms. For example there is almost a one-to-one mapping between Haskell and C++ " . $popoverTMP . parent::bib()->cite(6) . ". However the syntax is very intimidating so I wouldn't recommend it for beginners.");

		$python1 = parent::pythonSays("But even if you don't use TMP in C++, it still is a pretty difficult language for a beginner? With beginner I mean a person who hasn't programmed before, not a programmer who already knows C.");
		
		$cpp2 = parent::cppSays("Yes, C++ is not that easy for a beginner. A couple of symbols have a lot of different meanings, e.g. *. C++ has a lot of rules with a lot of exceptions. In this sense smaller languages like Python and Lua are better for novice programmers.");
		
		$lua4 = parent::luaSays("So, you say that the size of a language is a pretty good metric for the difficulty of the language?");
		
		$cpp3 = parent::cppSays("Yes, of course there are some exceptions.");
		
		$lua5 = parent::luaSays("Then I think Lua did a good job in making the language easy to learn.");
		
		return $lua0.$cpp0.$lua1.$python0.$lua2.$cSharp0.$lua3.$java0.$haskell0.$cSharp1.$cpp1.$python1.$cpp2.$lua4.$cpp3.$lua5;
	}
	
	public function link(){
		return "learning.php";
	}
	
	public function name(){
		return "Learning";
	}
	
	public function bibliography(){
		return parent::bib()->format();
	}
}
?>
