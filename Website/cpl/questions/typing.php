<?php
error_reporting(-1);
ini_set('display_errors', '1');
include_once("question.php");
include_once("bibliography.php");

class Typing extends Question {	
	public function __construct() {
		parent::__construct($this);
	}

	public function questionName(){
		return "What about the typing system?";
	}
	
	public function introduction(){
		return "Programmers agree on one thing: there is no agreement about what's the best typing system: static or dynamic [Jonas: strong, weak, safe, unsafe vermelden?]. What typing systems are used? Why? And more importanly: what are the advantages?";
	}
	
	public function answers(){
		$pop_it = $this->popover("interferred typing","Interferred typing","Interferred typing is a language concept in C# where a programmer uses the keyword 'var' to denote the declaration of a variable. Instead of letting the programmer specify the type of the variable, the compiler will determine the type by intereference.");
		$pop_tc = $this->popover("type conversions","Type Conversions","Type conversions are a language concepts in C# where a programmer can specify how an object of one type can be converted into another type. These conversions can be implicit. If they are implicit the programmer doesn't have to specify the object should convert itself.");
		$lua = parent::luaSays("Lua has a dynamic type sytem. This reduces the code-compile-test cycle because the compile step can be reduced.");
		
		$cpp = parent::cppSays("But this way you can have problems at run-time while they could be detected at compile-time. So the programmer has the burden that he/she must write code that will be valid at run-time. Also for compiled languages it's cheaper to do compile-time type checking" . parent::bib()->cite(2));
		
		$cSharp = parent::cSharpSays("It's true that static typing makes a programming language faster. The type system in C# is however more compilcated. I think even C++ won't have a problem with ".$pop_it." since the performance boost is equivalent. A second aspect are the ".$pop_tc.": a programmer specifies the conversions and the compiler will search for a chain of conversions to convert a variable to a given object. This is of course an argument to say C# is a weakly typed language. However since the program has to specify these conversions first, it's debatable.");
		
		$lua2 = parent::luaSays("Lua is also weakly typed. Lua uses a system that is named coercion. This system can convert numbers to strings and vice versa when this is appropriate." . parent::bib()->cite(4) . " An important exception is that coercion isn't performed in comparison operators. Furthermore the dynamic aspect enables other features in the language like functions. Functions are treated in Lua as variables. If you want a higher order programming language, it's somehow difficult to do this by static typing.");
		
		$python = parent::pythonSays("Although weakly typed can be easy to use, it can also introduce ambiguity in the language. This makes is harder for beginners.");
		
		$lua3 = parent::luaSays("I agree. In retrospect, we could have removed this" . parent::bib()->cite(0) . ".");

		$cSharp2 = parent::cSharpSays("I want to react on argument of higher-order programming: it's not difficult to implement in the static typing paradigm: C# is a higer-order programming language. Methods can be stored as variables. These methods are then stored in a ''delegate'' structure. The delegate structure specifies the signature of the function. The compiler uses duck-typing to check if the selected function matches with the given signature.");
		
		$lua4 = parent::luaSays("I know C# has some elegant structures to deal with higher-order programming. However Lua is still a scripting language. That means code is compiled and checked at runtime. In order to make the runtime compiler fast, we needs small and simple code. C# is way too complex to be a fast scripting language.");		

		return $lua.$cpp.$cSharp.$lua2.$python.$lua3.$cSharp2.$lua4;
	}
	
	public function link(){
		return "typing.php";
	}
	
	public function name(){
		return "Typing";
	}
	
	public function bibliography(){
		return parent::bib()->format();
	}
}
?>
