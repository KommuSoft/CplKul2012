<?php
error_reporting(-1);
ini_set('display_errors', '1');
include_once("question.php");
include_once("bibliography.php");

class OOP extends Question {	
	public function __construct() {
		parent::__construct($this);
	}

	public function questionName(){
		return "How is object oriented programming implemented?";
	}
	
	public function introduction(){
		return "One of the most popular paradigm is \"Object oriented programming\". But how is it implemented in different languages?";
	}
	
	public function answers(){
		$pop_events = $this->popover("events","Events","Events are a language structure in C# and is used as a syntactical sugar for the Visitor pattern. An event is basically a table of delegates (method pointers). By adding and removing, the programmer can register delegates to a certain event. The programmer can than call the event with the proper arguments resulting in a multicast of these arguments to the registered methods.");
		$pop_operators = $this->popover("operators","Operators","C# supports operator overloading. Therefore one can define a + operator on a custom class (for instance complex numbers).");
		$code = $this->code($this->readFromFile("code/cppInheritance.cpp"), "c++");

		$code0 = $this->codeInline($this->readFromFile("code/JavaClassExample.java"), "java");
		$code1 = $this->codeInline($this->readFromFile("code/LuaClassExample.lua"), "lua");
		$code2 = $this->codeInline($this->readFromFile("code/LuaClassExampleAlternative.lua"), "lua");
		$code3 = $this->codeInline($this->readFromFile("code/LuaClassExampleWithInheritance.lua"), "lua");
		$code4 = $this->codeInline($this->readFromFile("code/AmbiguityExample.cpp"), "c++");
		$code5 = $this->codeInline($this->readFromFile("code/TableInformation.lua"), "lua");
		$code6 = $this->codeInline($this->readFromFile("code/LuaClassExampleWithInheritanceUsage.lua"), "lua");

//operator overloading (ad hoc polymorphism) -> java niet; lua, c++, c#, python wel; haskell nog uitgebreider 
//JavaScript is perhaps the best known prototype-based programming language, which employs cloning from prototypes rather than inheriting from a class. Another scripting language that takes this approach is Lua.
//Prototype-based programming is a style of object-oriented programming in which classes are not present, and behavior reuse (known as inheritance in class-based languages) is performed via a process of cloning existing objects that serve as prototypes. This model can also be known as classless, prototype-oriented or instance-based programming. Delegation is the language feature that supports prototype-based programming.

		$lua0 = parent::luaSays("The authors of Lua didn't want to turn Lua into an object-oriented language, because a fixed programming paradigm wasn't what they wanted. However, the mechanism of classes and objects can be implemented with tables. A table is the main, and the only, data structure in Lua. Tables are arrays where not only numbers can be used as indexes, but also strings or any other value (except nil). This is shown in the example below.".$code5."On line 3, an alternative notation is mentioned for retrieving a value. The reason is that this looks more related to notation used in languages like C++ or Java."); 
		$cpp0 = parent::cppSays("I see that the notation is adapted to be more familiar for users who have experience with classes in object-oriented languages. Can you explain now how those tables can be used to emulate classes?");		
		$lua1 = parent::luaSays("Yes, the names of fields and methods can be stored as keys in a table. This is done by using the type string. Above that, functions are first-class values. This means that functions can be assigned to variables, passed as arguments to functions, returned from functions and stored in tables. So, the values in a table can be functions. Therefore, it is possible to call a method by using the appropriate key in the table, which represents the name of the method.");
		$java0 = parent::javaSays("Java is an object-oriented language and provides direct support for classes. To give an example of a class:".$code0."Is it possible to give an equivalent example in Lua?");
		$lua2 = parent::luaSays("Of course.".$code1. "I will clarify this piece of code a bit. Car is of type table as mentioned above. At line 2, an element with key \"speed\" and value 0 is added to the table. At line 5, we declare a constructor and put it in the table Car as well. At line 13, a similar thing happens. The \"self\"  variable is necessary, because we want to specify the object the method has to operate on.");
		$cpp1 = parent::cppSays("For me, the body of the constructor isn't clear yet. What is meant with the setmetatable method and the \"__index\" construct on lines 7 and 8?");
		$lua3 = parent::luaSays("Before I explain this, I will give some background about metatables and metamethods. When you try to access an absent field in a table, the result is nil. However, there is a way to get around this. In the case of an absent field, the interpreter looks for an \"__index\" metamethod in the metatable of that table. Usually this method isn't available, so the result is a nil value as explained before. But if it is available, the metamethod will provide the result. A metatable is just like any other table, except that it also contains metamethods. A table can have a metatable by using the \"setmetatable\" construct as shown in line 7 where \"self\" is the metatable of \"o\". This mechanism allows the programmer to propose a way to proceed if the basic execution mechanism fails. Operator overloading is possible with this too. There are metamethods like \"__add\", \"__mod\", \"__pow\", \"__eq\", \"__lt\", etc. For example, the way to perform the \"+\" operation on two tables isn't defined. The solution is to define the \"__add\" metamethod.");
		$java1 = parent::javaSays("Another essential part of object-oriented programming is inheritance. Can this also be emulated in Lua?");
		$lua4 = parent::luaSays("Yes, I will illustrate this with an example.".$code3."The implication of the fact that Car is set to the metatable of FastCar is very important. Without line 16, we can't retrieve the speed of a FastCar, simply because this isn't stored in FastCar. However, with the \"__index\" metamethod defined in Car, this is nevertheless possible.");
		$csharp0 = parent::csharpSays("You have now defined a base class and a subclass. However, they aren't used. Can you show what you can do with them?");
		$lua5 = parent::luaSays("Yes, I will show how you can create a instance of both classes and how methods can be performed on them.".$code6);
		$java2 = parent::javaSays("Now we have seen how classes and inheritance can be emulated. Are there drawbacks or subtleties with this approach?");
		$lua6 = parent::luaSays("First, I want to mention that this is just an approach. There are other possible approaches, for example to provide multiple inheritance".parent::bib()->cite(22).". The main design for objects offers no privacy mechanisms. This is a reflection of some of the basic design decisions behind Lua. The aim of Lua is at building small to medium programs where just a few programmers work on. For that reason, Lua wants to avoid such redundancy. But again, there are ways to implement the privacy mechanism. If we judge based on simplicity, performance and flexibility, the approach using the \"__index\" is probably the best".parent::bib()->cite(22).".");


//NIET GEBRUIKTE DINGEN

		$lua = parent::luaSays("Lua uses a quite special paradigm: the only real datastructure is a table. Lua itself contains only 8 types: nil, number, string, table, function, userdata, boolean and threads. Therefore one can argue Lua isn't a real object-oriented language. The authors of Lua are of course aware of the object-oriented paradigm and see it benefits. However in their opinion the language should remain simple and small. Lua however allows object-oriented programming since objects can be represented by the tables (where the keys are the names of the fields and methods). Inheritance in tables is supported by the so called ''fallback'' mechanism" . parent::bib()->cite(0) . ". This mechanism allows the programmer to propose a way to proceed if the basic execution mechanism fails. One can use this mechanism for instance when an index of a table doesn't exist by looking at the parent's table. Since inheritance is widely used one doesn't need to define these fallbacks manually. Lua offers an __index entry a pointer to the parent table. One can easily see the fallback mechanism gives birth to more dynamic typing: an object can change it's parent on the fly while keeping it's own specific attributes.");
		
		$cpp = parent::cppSays("C++ has good support for object oriented programming, in fact C++ is an object oriented language. For example, Strings are classes with their own member functions and such. Multiple inheritance is available"); //afgeleid van SIMULA
		
		$cSharp = parent::cSharpSays("C# is a language with clear structures supporting the object-oriented programming paradigm. It has classes quite similar to Java. A class can only have one parent. Furthermore a class can have fields, properties, methods, ".$pop_events.", constructors, destructors and ".$pop_operators.". Most of these structures are quite similar to other object-oriented languages. The language forces one to structure his or her classes. The advantage is that the compiler can check a lot of issues. Resulting in more failsafe code."); //interfaces voor multiple inheritance vermelden
		
		$python = parent::pythonSays("Pyhon is also an object oriented language. Actually the class mechanism is based on C++ and Modula-3. Python provides a very clean syntax for creating classes (and their hierarchies). Unfortunately constructors introduce uglier syntax (lots of underscores).");
		
		$lua2_old = parent::luaSays("The main [Jonas: main is een gevaarlijk woord] issue with using a strict object-oriented paradigm is that it forces users to use objects everywhere. Not everything in the world can easily be modelled as objects. Also the usage of object orientation makes programming more difficult, because it forces you to think in a certain way.");
		
		$cpp2 = parent::cppSays("C++ doesn't force you to use objects either. You can freely write some code outside a class, in fact a \"Main\" class isn't needed like some other languages. Also some functionality is available with nonmember functions and member functions. E.g." .$code4. 'However this introduces "ambiguity" in the language.');
		
		$java = parent::javaSays("Afgeleid van Smalltalk, multiple inheritance door interfaces");
		
		return $lua0.$cpp0.$lua1.$java0.$lua2.$cpp1.$lua3.$java1.$lua4.$csharp0.$lua5.$java2.$lua6; 
		//return $lua.$cpp.$cSharp.$python.$lua2_old.$cpp2.$java.$code;
	}
	
	public function link(){
		return "oop.php";
	}
	
	public function name(){
		return "OOP";
	}
	
	public function bibliography(){
		return parent::bib()->format();
	}
}
?>
