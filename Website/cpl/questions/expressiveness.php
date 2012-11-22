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
		return "Some people call it entropy: the amount of information one stores in a fixed number of characters. How expressive is Lua compared to its contestants? What are the domains Lua can talk about?";
	}
	
	public function answers(){
		//GUI, data serializeren, SQL
		$code0 = $this->codeInline($this->readFromFile("code/LinqExample.cs"), "c#");
		$code1 = $this->codeInline($this->readFromFile("code/templateProgramming.cpp"), "c++");
		$code2 = $this->codeInline($this->readFromFile("code/coroutines.lua"), "lua");
		$code3 = $this->codeInline($this->readFromFile("code/YieldExample.cs"), "c#");
		$code4 = $this->codeInline($this->readFromFile("code/YieldExample.java"), "java");
		$cSharp0 = parent::cSharpSays("In C# expressiveness is mainly supported by introducing special syntax for domain specific features. As an example, take for instance the LINQ framework. It enables the programmer to write object-oriented queries in SQL-style:".$code0);
		$lua0 = parent::luaSays("I don't see the importance of this syntactical sugar. It's a nice feature that eliminates a lot of noise, but one can argue that by using LINQ the amount of code isn't reduced signifcantly since we can write this by method calls. In my opinion the expressiveness of a language is more determined by the ability of the compiler to modify simple lines of code into a complex structure. Since this reduces the amount of work the programmer needs to do.");
		$cpp0_0 = parent::cppSays("I agree with Lua. The syntactical sugar of LINQ is very nice, but it doesn't yield that much gain. C++ has for instance templates. It is a powerful mechanism to generalize code and reduces the amount of code significantly.");
		$java0 = parent::javaSays("I don't really see what's so unique about templates, C++? Java has generic classes to reduce the amount of code. Since generic classes use type parameters. isn't this just a kind of templates?");
		$cpp0 = parent::cppSays("Templates go beyond generic classes. You can do some nice things with generic classes but templates are Turing complete. I don't think C# and Java generics go that far?");
		$java1 = parent::javaSays("Can you give an example of this principle?");
		$cpp1 = parent::cppSays("Sure, look at the following piece of code:".$code1."In the above code we calculate the factorial of 4. Instead of building a method to calculate the result, this implementation simply creates a struct that holds the result of the factorial of 4. This is done with templates, the result is therefore calculated at compile-time! Of course this minimal example won't gain that much performance, but I think one can imagine we can calculate a lot of partial results at compile-time. Furthermore templates enable the programmer to let the compiler write code that is way to long or complex to be written by hand.");
		$lua1 = parent::luaSays("My question to C++ is: do you see any advantage of this if you run code by an interpreter. Since the interpreter is working at run-time, such optimizations will probably don't yield any benefit. However even Lua has some structures to make the language more expressive, but keep in mind since the language is interpreted, the amount of syntactical sugar is limited. A powerful principle we implement are coroutines. Are coroutines implemented in other languages as well?");
		$java2_0 = parent::javaSays("What are coroutines?");
		$lua2 = parent::luaSays("A coroutine is a special method with multiple entry and exit points. Each time the caller calls that method it will resume execution starting from the previous exit point. The method suspends when it reaches the next exit point return the result of the next item. They have their own stack and local variables, but are used for instance for data manipulation. One can think of them like threads. However coroutines work sequentially.");
		$java3 = parent::javaSays("I don't really understand what you mean? How do you work with these methods and how do they know when they should be executed? Can you give a minimal example?");
		$lua3 = parent::luaSays("Well, as I already said a typical application is data generation or data modification. So take a look at the following code: ".$code2."You see a function that returns the chemical symbols of all noble gasses. Now we can turn this method into a coroutine and use that method in a loop. As long as there are still symbols, the coroutine is still alive and we can print symbols. I guess one can imagine a method where we simply generate all Fibonacci numbers. You can write this function as a coroutine to generate for instance all Fibonacci numbers smaller than 42.");
		$cSharp1 = parent::cSharpSays("C# has a similar feature: the fact that you are working with a coroutine doesn't have to be specified. One simply uses the yield statement in order to emit an element of the virtual list.");
		$lua4 = parent::luaSays("I'm not entirely sure this feature is exactly the same. Can you give me an example?");
		$cSharp2 = parent::cSharpSays("Sure:".$code3);
		$java2 = parent::javaSays("That looks nice, but again it's more syntactical sugar. In Java you can emulate those coroutines in the following way: ".$code4." So you can just turn your coroutine in some sort of state machine. Each time the caller asks for another element you run the program until an element should be emitted. Then you save the state of the variables and the program counter.");
		$lua5 = parent::luaSays("True, but I don't see why that's relevant Java? Of course everything can be emulated since all languages here are Turing complete. But we are talking about expressiveness. In C# you can write in 26 lines where Java requires 39. Since this is only a minimal example, I expect the difference to grow more significant with more complicated examples.");
		$java4 = parent::javaSays("But I guess internally the compiler or the run-time environment will modify the code to an object-oriented pattern.");
		$lua5_0 = parent::luaSays("Not in Lua. Coroutines in Lua have their own execution stack, root set,... Therefore one can look at these methods as an independent method which runs when the main program needs another element.");
		$cpp3 = parent::cppSays("Coroutines are indeed nice. And the fact that Java lacks coroutines is a shame. C++ doesn't have a standard implementation for coroutines but there are precompiler extensions in order to handle coroutines. Another expressiveness aspect I would like to discuss is how we transport elements from one machine to another one?");
		$java5 = parent::javaSays("That's one of the cool features of Java: one simply needs to let the class implement the serialization interface and serialization is handled by the Java Runtime Environment itself. Whether one wants to store that object into a file or send it over a network doesn't matter: Java simply converts the object into a binary stream. As far as I know most languages don't have such an elegant level of serialization?");
		$cSharp3 = parent::cSharpSays("You are right in one way: in C# you have to specify how the object is serialized/deserialized. The reason is that a system can change and the fields of a class can be modified. I guess Java will break when you modify the class definition? Since a C# programmer specifies how to deserialize data, he/she can implement a deserializer for different versions in the language.");
		$java6 = parent::javaSays("The structure of the class is also encoded (of course together with its superclasses). To make sure the system doesn't deserialize the data into a wrong version of the same class, Java uses a class signature. Only when the fields are modified (and not for instance methods), one can't deserialize the data into an object. The point is however, that most classes don't change that often. Therefore in most of the cases the default serialization suits the programmers needs.");
		$cpp4 = parent::cppSays("And this doesn't result in bloated files and bandwidth usage? C++ doesn't have this form of serialization (of course there are libraries to help programmers write their serializers). The main reason is that C++ compiles to machine code. Therefore there is no virtual machine who can take a look into the objects at run-time. One can of course argue that the precompiler could write serialization functions. But even then there are problems: what if an object has a method pointer. There is a chance for instance that the program on the other side of the network doesn't use the same program, or is written in a different machine language. Therefore there is no straightforward solution to automatic serialization. However I guess most languages who run in virtual machines don't suffer from this problems?");
		$lua6 = parent::luaSays("That's true. Lua has no built-in functionalities to serialize objects. But since each object is a table, it's not that hard to build a generic method doing the job. Methods aren't a problem either: the virtual machine can send Lua code through the network. Since it's interpreted at the other side, there are no compatibility issues.");
		$cSharp4 = parent::cSharpSays("Another type of serialization that is very popular these days is XML. C# has a very elegant way to serialize and deserialize objects into XML. One only has to annotate the proper fields and provide a default constructor. The C# library can handle these annotations and does the whole serialization/deserialization process. The main reason to implement this feature were web servers: web servers mainly communicate through the HTTP protocol. This protocol doesn't allow binary data. Do the other languages have built-in features for XML serialization?");
		$java7 = parent::javaSays("Java has some libraries who work in a simular way like C#: with annotations. You simply annotate the code of your class and the library can serialize and deserialize objects to XML code. A problem is that there are many libraries and thus there is no real standard procedure for XML serialization/deserialization.");
		$lua7 = parent::luaSays("Again: Lua has no syntactical sugar for XML serialization. But since the typing system is extremely simpe, it's very easy to write a generic method who can serialize any type of table. An example of a library who serializes tables is TinyXml.");

		return $cSharp0.$lua0.$cpp0_0.$java0.$cpp0.$java1.$cpp1.$lua1.$java2_0.$lua2.$java3.$lua3.$cSharp1.$lua4.$cSharp2.$java2.$lua5.$java4.$lua5_0.$cpp3.$java5.$cSharp3.$java6.$cpp4.$lua6.$cSharp4.$java7.$lua7;
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
