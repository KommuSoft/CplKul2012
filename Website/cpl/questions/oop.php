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
		
		$codeEx1 = "int main(){
	std::vector<int> v = {1,2,3,4,5,6};
	auto it0 = std::begin(v);
	auto it1 = v.begin();
}";
		
		$lua = parent::luaSays("Lua uses a quite special paradigm: the only real datastructure is a table. Lua itself contains only 8 types: nil, number, string, table, function, userdata, boolean and threads. Therefore one can argue Lua isn't a real object-oriented language. The authors of Lua are of course aware of the object-oriented paradigm and see it benefits. However in their opinion the language should remain simple and small. Lua however allows object-oriented programming since objects can be represented by the tables (where the keys are the names of the fields and methods). Inheritance in tables is supported by the so called ''fallback'' mechanism. This mechanism allows the programmer to propose a way to proceed if the basic execution mechanism fails. One can use this mechanism for instance when an index of a table doesn't exist by looking at the parent's table. Since inheritance is widely used one doesn't need to define these fallbacks manually. Lua offers an __index entry a pointer to the parent table. One can easily see the fallback mechanism gives birth to more dynamic typing: an object can change it's parent on the fly while keeping it's own specific attributes.");
		
		$cpp = parent::cppSays("C++ has good support for object oriented programming, in fact C++ is an object oriented language. For example, Strings are classes with their own member functions and such.");
		
		$cSharp = parent::cSharpSays("C# is a language with clear structures supporting the object-oriented programming paradigm. It has classes quite similar to Java. A class can only have one parent. Furthermore a class can have fields, properties, methods, ".$pop_events.", constructors, destructors and ".$pop_operators.". Most of these structures are quite similar to other object-oriented languages. The language forces one to structure his or her classes. The advantage is that the compiler can check a lot of issues. Resulting in more failsafe code.");
		
		$python = parent::pythonSays("Pyhon is also an object oriented language. Actually the class mechanism is based on C++ and Modula-3. Python provides a very clean syntax for creating classes (and their hierarchies). Unfortunately constructors introduce uglier syntax (lots of underscores).");
		
		$lua2 = parent::luaSays("The main [Jonas: main is een gevaarlijk woord] issue with using a strict object-oriented paradigm is that it forces users to use objects everywhere. Not everything in the world can easily be modelled as objects. Also the usage of object orientation makes programming more difficult, because it forces you to think in a certain way.");
		
		$cpp2 = parent::cppSays("C++ doesn't force you to use objects either. You can freely write some code outside a class, in fact a \"Main\" class isn't needed like some other languages. Also some functionality is available with nonmember functions and member functions. E.g." . $this->codeInline($codeEx1, "c++") . 'However this introduces "ambiguity" in the language.');
		
		$code = $this->code($this->readFromFile("code/cppInheritance.cpp"), "c++");
		
		return $lua.$cpp.$cSharp.$python.$lua2.$cpp2.$code;
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
