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
		return "Programmers agree on one thing: there is no agreement about what's the best typing system: static or dynamic, weak or strong. What typing systems are used? Why? And more importanly: what are the advantages?";
	}
	
	public function answers(){
		$pop_it = $this->popover("implicit typing","implicit typing","This is a language concept in C# where a programmer uses the keyword 'var' to denote the type declaration of a variable. Instead of letting the programmer specify the type of the variable, the compiler will determine the type by intereference. For C++ programmers: it's similar like 'auto'.");
		
		$codeCoercion = 'a = 5
b = "5"
c = a+b
print(c) -- output: 10
print(a==b) -- output: false';
		
		$codeRTTI = "x = {1, 2, 3}
print(type(x)) -- output: table
print(type(x[1])) -- output: number";
		
		//--------------------------
		//Static: type that is inferred at compile-time
		//Dynamic: type that is inferred at run-time
		//Weak: automatic conversion
		//Strong: no automatic conversion
		//Weaker: int -> string but not string -> int
		//Duck: [uitleg] + most of the duck type definitions use duck typing in a dynamic environment. We eliminate this constraint because some constructs that use types are run at compile time.
		
		$lua0 = parent::luaSays("Lua has a dynamic type sytem. One of the advantages is that a dynamic type system reduces the code-compile-test cycle because the compile step is shorter. This is because the type is inferred at run-time. Inferring the type can also be done in a more lazy way, because only the types in the pieces of code that will be executed have to be inferred. Another advantage is that a dynamic type system is simpler than a static system" . parent::bib()->cite(0) . ".");
		
		$cpp0 = parent::cppSays("But don't you introduce an extra burden for the programmer? Some problems will only be detected at run-time while they could be prevented because the compiler would have spotted them. Also for compiled languages it's cheaper to do compile-time type checking" . parent::bib()->cite(2) . ".");
		
		$cSharp0 = parent::cSharpSays("It's true that static typing makes a programming language faster. However some programming languages have very complicated type systems, C# for example has " . $pop_it . ". This increases the work that the compiler must do, but it can result in better code because the most specific type will be used. Although this can look like weakly typed, it's actually strongly typed because the compiler will replace it to the correct type before compilation something that a programmer will not always do.");
		
		$lua1 = parent::luaSays("But doesn't a strong type system lead to horrible code? In strong type systems not every type is compatible with the expected type, so a lot of conversions are needed. Also the reuse of variables is more difficult.");
		
		$cpp1 = parent::cppSays("That's not completely true. You can use casting. This means that the programmer specifies how a value of one type can be converted in another type. If you use implicit casting you don't have to do anything else. When you try to use a value as a different type then its declared type, the compiler tries to cast the value in the desired type. Of course this is sometimes a source of unwanted behaviour. That's why a programmer can declare the cast operator 'explicit', this way you have to specify a cast operator if you want to cast the value. I think C# has a similar thing?");
		
		$cSharp1 = parent::cSharpSays("Indeed, although it's called a conversion in C#. The programmer specifies the conversions and the compiler will search for a chain of conversions to convert a variable to a given object. This is of course an argument to say C# is a weakly typed language. However since the program has to specify these conversions first, it's debatable. It can make the type system less strong but it doesn't create a weak type system.");
		
		$lua2 = parent::luaSays("On the other hand, Lua is weakly typed. Lua uses a system that is named coercion. This system can convert numbers to strings and vice versa when this is appropriate" . parent::bib()->cite(4) . ". An important exception is that coercion isn't performed in comparison operators. The following example illustrates this." . parent::codeInline($codeCoercion, "lua") . "Furthermore the dynamic aspect enables other features in the language like functions. Functions are treated in Lua as variables. If you want a higher order programming language, it's somehow difficult to do this by static typing.");
		
		$cpp1_0 = parent::cppSays("Although weakly typed can be easy to use, it can also introduce ambiguity in the language. This makes is harder for beginners. A beginner doesn't always understand that a program does what you write, not wat you want.");
		
		$lua3 = parent::luaSays("I agree. In retrospect, the designers could have removed this" . parent::bib()->cite(0) . ". The automatic conversion from strings to numbers can indeed be troublesome. But the automatic conversion from numbers to strings doesn't really lead to problems.");
		
		$cSharp2 = parent::cSharpSays("I want to react on the argument of higher-order programming: it's not that difficult to implement it in the static typing paradigm: C# is a higher-order programming language. Methods can be stored as variables. These methods are then stored in a ''delegate'' structure. The delegate structure specifies the signature of the function. The compiler uses duck typing to check if the selected function matches with the given signature.");
		
		$lua4 = parent::luaSays("I see, so C# has some elegant structures to deal with higher-order programming. But the Lua support is even more elegant: use first-class values. However Lua is still an interpreted scripting language. That means code is compiled and checked at run-time. In order to make the run-time compiler fast, we needs small and simple code. C# is way too complex to be a fast scripting language. You also mentioned duck typing, this system is also used by Lua.");		

		$cpp2 = parent::cppSays("Something different. Lua is an embeddable language, this means that Lua should be compatible with the type system of the host language. How does Lua do this?");

		$lua5 = parent::luaSays("Lua solves this problem with something called an abstract stack" . parent::bib()->cite(0) . ". The slots in this stack can contain Lua values with an arbitrary type. When a certain type has a mapping between C and Lua (for example numbers) there are 2 available functions. The injection function transforms a C value to a Lua one, the projection function works the other way around. The real problem is when there is no direct mapping. Then the API offers you to manipulate the Lua values by using their stack positions.");
		
		$java0 = parent::javaSays("If a programmer doesn't have to specify the types of his/her variables in Lua, how can you check the type?");
		
		$lua6 = parent::luaSays("It's not so that Lua doesn't use types internally, they are only transparent for the programmer. But to answer your question: Lua has support for run-time type information. For example:" . parent::codeInline($codeRTTI, "lua") . "So if a programmer would like to use the type of his/her variables, Lua provides an answer.");
		
		return $lua0.$cpp0.$cSharp0.$lua1.$cpp1.$cSharp1.$lua2.$cpp1_0.$lua3.$cSharp2.$lua4.$cpp2.$lua5.$java0.$lua6;
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
