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
		return "One of the most popular paradigm is \"Object oriented programming\". But how is it implemented in different languages";
	}
	
	public function answers(){
		$lua = parent::luaSays("Lua uses a quite special paradigm: the only real datastructure are tables and values. A value is either a boolean, number, table, nil or function. Therefore one can argue Lua isn't a real object-oriented language. The authors of Lua are of course aware of the object-oriented paradigm and see it benefits. However in their opinion the language should remain simple and small. Lua however allows object-oriented programming since objects can be represented by the tables (where the keys are the names of the fields and methods). Inheritance in tables is supported by the so called ''fallback'' mechanism. This mechanism allows the programmer to propose a way to proceed if the basic execution mechanism fails. One can use this mechanism for instance when an index of a table doesn't exist by looking at the parent's table. Since inheritance is widely used one doesn't need to define these fallbacks manually. Lua offers an __index entry a pointer to the parent table. One can easily see the fallback mechanism gives birth to more dynamic typing: an object can change it's parent on the fly while keeping it's own specific attributes.");
		$cpp = parent::cppSays("");
		$cSharp = parent::cSharpSays("Csharp doesn't use dynamic typing and therefore ");
		return $lua.$cpp.$cSharp;
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
