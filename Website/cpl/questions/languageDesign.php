<?php
error_reporting(-1);
ini_set('display_errors', '1');
include_once("question.php");
include_once("bibliography.php");

class LanguageDesign extends Question {	
	public function __construct() {
		parent::__construct($this);
	}

	public function questionName(){
		return "How do the blueprints look like?";
	}
	
	public function introduction(){
		return "Before we can write a program in a language, one first needs to design that language. What are the key ideas behind Lua, C++,...?";
	}
	
	/*TODO (door Jonas):
		* Bij het first-class value gedeelte: is table ook geen basic type? De zin zegt volgens mij "elk concept dat niet opgeslagen kan worden als basis type is een tabel", waaruit ik concludeer dat tabel geen basis type is. Maar volgens "the evolution of Lua" is dit wel zo. Wellicht bedoel je iets anders?
		* Bron voor het dynamisch type in C#.
		* Bron voor LucasArts. Ook vind ik raar dat er therefore op die zin volgt, het klinkt alsof dit de een reden is. Ik zou afterwards logischer vinden.
		* De zin "Yeah, Lua is too much based on nominal programming: each function has an implicit set of conditions when it will work?" vind ik complex. Het is een antwoord, een vraag en een uitleg in 1.
	*/
	public function answers(){
	
		$clua0 = 'function printsum(a,b)
	print(a+b)
end';
	
		//aligneert Lua zijn arrays? Worden er bijvoorbeeld referenties gebruikt ipv de data zelf zodat alles in 64 bit past?
		$lua0 = parent::luaSays("Lua has always been based on very simple principles: each object is a first-class value, the number of basic value types is fixed, and each concept that can't be stored as one of those basic types is a table.");
		$cSharp0 = parent::cSharpSays("And you can write each program based on this principle? Personally I think one needs a large amount of language structures. This enables the programmer to choose the most optimal construct in order to solve his/her problem.");
		$lua1 = parent::luaSays("Personally I strongly disagree with this idea: if the number of language structures increases so does the amount of options to consider. It makes software development harder. Since programmers are just humans, a language should not be too complex".parent::bib()->cite(8).". Another issue is consistency: sometimes such a program starts looking like ad hoc hacking. Aren't these programs just harder to read?");
		$haskell0 = parent::haskellSays("I agree with Lua. Look at Haskell, there are only two basic language constructions: functions and data. Functions just modify one instance of data to another instance. Since this is basically what each program does: data modification, that should be more that sufficient, don't you think?");
		$cpp0 = parent::cppSays("Of course a program modifies data, however when that program starts to become larger, one can't simply work that way anymore. One can appreciate the generality of both Lua and Haskell and for scripting purposes it's more than fine. But shouldn't you shield yourself from the generality when you are building a huge application? Especially when you are working in team?");//I think it's a little bit strange to say such thing Lua. Since Lua is a very simple language, the concepts implemented are very general. This can make it quite hard to understand a program. Java, C++ and C# use an object-oriented approach. Therefore one can exactly know what will happen when we call a method of a certain object: if the object is not available at the most concrete class, it will search for an implementation higher in the class hierarchy. If it fails to find one, the compiler will throw an error. Doesn't make this approach the life of the programmer way more easy?
		$java0 = parent::javaSays("Yes, Lua is too much based on nominal programming: each function has an implicit set of conditions when it will work.");
		$lua2 = parent::luaSays("I don't understand what you mean by nominal programming?");
		$java1 = parent::javaSays("Well take for instance the following function:".parent::codeInline($clua0, "lua")."By writing this function you make a contract that you only will use this method with values of types where the plus operator is defined. This case is of course simple. But if you have a lot of functions and an entire team of people working on that system, things can become pretty complicated. Having a compiler to check if you didn't make mistakes is then a necessity. Why was dynamic typing introduced as a language concept of Lua in the first place?");
		$lua3 = parent::luaSays("The main reason is its simplicity".parent::bib()->cite(0).". However there are other factors: first of all Lua was and still is a scripting language. This means there is no compiler step. Since the program is also lazily loaded, doing type checking would not discover that much issues.");
		$cSharp1 = parent::cSharpSays("Yes, but Lua has a compiler now, and since I recall Lua doesn't think that much about backward compatibility, Lua could abandon the dynamic typing idea. C# tries to navigate in the middle of dynamic and static typing: in the earlier versions of C# variables had to be strictly typed. Since C# 4.0 however one can use the 'dynamic' keyword".parent::bib()->cite(21).". By using dynamic, one can call methods where the compiler is not sure whether these methods exist. Perhaps Lua could become more statically typed by allowing the programmer to annotate variables with types who are then checked by the compiler?");
		$haskell1 = parent::haskellSays("I propose we look for other aspects of language design, since we will also have another discussion about typing. An important decision in a programming language is its execution mechanism. I think Haskell is the only lazy language here. Why isn't laziness implemented in Lua, C++, ...?");
		$cSharp2 = parent::cSharpSays("First I think you overgeneralize Haskell. C++, Lua and C# have laziness available in some way. Coroutines are handled with a lazy approach in mind: only calculate the next item if one asks for it. Furthermore object-oriented languages can perfectly emulate laziness by using a proxy: let an object maintain pointers to the objects from which it's originates and calculate the result of a query on demand.");
		$cpp1 = parent::cppSays("I agree with C# one can emulate laziness with a proxy approach. The proxy can also maintain a buffer where calculated items are stored to prevent items from being calculated a second time. However as a performance language, I personally don't think lazy programs will yield much performance gain.");
		$haskell2 = parent::haskellSays("Why do you say that? Lazy programs only evaluate items if they are really needed and thus saves cycles on calculations who turn out to be useless.");
		$cpp2 = parent::cppSays("You don't always save cycles since maintaining which aspects were already evaluated also burns cycles. A second aspect is the nature of laziness itself. Functions are only evaluated when one needs the result. A problem I see however is that lazy programs will be executed in bursts. When one yields a query, a lot of evaluation is done. Some of these evaluations could already have been done while the machine was idling. Isn't this a problem for typical applications with a lot of idle time like web servers?");
		$haskell3 = parent::haskellSays("Haskell has some operators for this who force the execution environment to evaluate a function in a non-lazy way to deal with this problem. This is of course also necessary to do I/O since evaluating statements in a different order could result in data being written in the wrong order. I wouldn't say lazy evaluations solves all issues, but isn't it strange that programming languages don't offer a more friendly way to build lazy functions?");
		$lua4 = parent::luaSays("In Lua that's not really a problem. One could create a table containing a function. The program could then query the value field of that table and one could imlement a fallback mechanism that in case the value field isn't found the function is evaluated and the result is stored as the value of that table. Since we can do this in a very generic way, it's very easy to add this feature, isn't it?");
		$cSharp3 = parent::cSharpSays("Looks nice. C# has also some built in classes who encapsulate a method and evaluate that method in a lazy way. I agree this is not a very elegant solution. However an interesting feature is that C# compiles to the Common Interpreter Language (CIL). Another language who is converted to the same bytecode is F#. F# is a functional language who has better support  for  laziness. This makes things interesting since one can write one part in C# and the other in F#.");
		$lua5 = parent::luaSays("Isn't that a general aspect of C#? Using several domain specific languages with C# more as a language to interfere with all of these sublanguages.");
		$cSharp4 = parent::cSharpSays("The developers of the framework around C# have indeed invented some languages like XAML and LINQ in order to make GUI and database development easier. However these languages are no part of C#. Doesn't Lua aims to be a language integrated in such a host language?");
		$lua6 = parent::luaSays("Lua wasn't intended to become a glue language. However LucasArts created a game and used Lua as a scripting engine" . parent::bib()->cite(0) . ". Therefore Lua got a lot of attention from the gaming industry. Probably it's generic and dynamic design were key features for it's succes.");
		$cpp3 = parent::cppSays("What do you mean?");
		$lua7 = parent::luaSays("Typically scripts for games are already written in an early stage of the development. However at that time some aspects are not decided yet. Since Lua is that generic, a developer changing his mind will not yield that much additional work to adapt the scripts on new code in the host language.");
		
		
		/*$java0 = parent::javaSays("I agree with C++. In Lua one defines functions on values. However most of these functions are builded with a particular object structure in mind. Since that information is implicit, the programmer must be patient enough to analyze a piece of Lua code. It generalizes a lot of features found in for instance Java by using for instance the ''fallback'' mechanism. However I'm not sure generalizing ideas will always yield better results. Will generalizing features not imply bad use?");
		$lua2 = parent::luaSays("I partly agree using a general approach can lead to bad usage. However one also has to consider the fact that the limited features in static-typed object oriented language yields some problems. In those languages, downcasts are quite common. This typically happen when the programmer can't give the compiler sufficient information about the stored data types. Downcasts are anoying, lead to a lot of errors (if the real value turns out to be from a different type) and in my opinion shows static typing still as to overcome some issues.");

		$haskell0 = parent::haskellSays("That's why Haskell avoids type casting. Haskell aims to be a pure language with only some basic concepts like Lua. The only real concept Haskell uses is lambda calculus. However a modification is made for datatypes: in the original lambda calculus data only existed by gratitude of functions. Of course this would be quite impractical.");
		$cSharp1 = parent::cSharpSays("But Haskell solves the inheritance problem? I assume sometimes you have to do operations depending on the type of data you are dealing with, without knowing the exact type of that data.");
		$haskell1 = parent::haskellSays("Well Haskell doesn't support inheritance the way it's done in object oriented languages: one type doesn't inherit data from another type. However Haskell has a notion of classes, who group different data types. These types share some behavious: functions where the implemention depends on the data type. Therfore the programmer can implement these functionalities for a specific datatype. And can later make abstraction of this implementation.");
		$lua3 = parent::luaSays("That's of course nice, however I miss the dynamic nature i find in Lua: As long as the programmer of some module functions was clever enough to use interfaces, their is not that much of a problem. From the moment however a function is defined on some datatype, you can't use that function in order to process data from another type. Even if that would be theoretically possible.");
		

		$lua0 = parent::luaSays("as simple as possible +voorbeelden");
		$cpp0 = parent::cppSays("not good for performance, because it is to general +voorbeelden. How is your design, c#?");
		$cShahrp0 = parent::cSharpSays("multiparadigm and oo");
	
		$lua = parent::luaSays("multiparadigm\n[Requirement: geen OOP, embeddable, portable (geen veronderstelling onderliggende hardware), simple (alles is tables), functioneel, tables in lua mogen verschillende types hebben => cache problemen, table highly optimized (can be array or associative array internally)]");
		
		$cpp = parent::cppSays("Wel OOP. Gaandeweg functioneel programmeren invloed. Niet zo portable, tuples mogen verschillende type hebben (anders strikt)");
		
		$cSharp = parent::cSharpSays("Kloon java, dus vereist OOP & portable. Gaandeweg functioneel programmeren invloed. Vorm van dynamic typing, strikt type");
		
		$java = parent::javaSays("OOP, portable");
		
		$haskell = parent::haskellSays("Pure lambda calculus implementatie, portable (geen veronderstelling onderliggende hardware maar geen cross compiler)");*/
		
//		return $lua0.$cSharp0.$lua1.$cpp0.$java0.$lua2.$haskell0.$cSharp1.$haskell1.$lua3;
		return $lua0.$cSharp0.$lua1.$haskell0.$cpp0.$java0.$lua2.$java1.$lua3.$cSharp1.$haskell1.$cSharp2.$cpp1.$haskell2.$cpp2.$haskell3.$cSharp3.$lua5.$cSharp4.$lua6.$cpp3.$lua7;
	}
	
	public function link(){
		return "languageDesign.php";
	}
	
	public function name(){
		return "Language Design";
	}
	
	public function bibliography(){
		return parent::bib()->format();
	}
}
?>
