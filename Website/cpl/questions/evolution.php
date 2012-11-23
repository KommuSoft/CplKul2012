<?php
error_reporting(-1);
ini_set('display_errors', '1');
include_once("question.php");
include_once("bibliography.php");

class Evolution extends Question {	
	public function __construct() {
		parent::__construct($this);
	}

	public function questionName(){
		return "How does a language evolve?";
	}
	
	public function introduction(){
		return "One does not simply adds features to a language. All popular languages have some aspects that limitate the evolution of this language. The audience of the language plays of course a crucial part. How do these programming languages maintain themselves?";
	}
	
	public function answers(){
		$WorldOfWarcraft = $this->popover("World of Warcraft", "World of Warcraft", "World of Warcraft is a massively multiplayer online role-playing game.");
		$monty = $this->popover("Monty Python's Flying Circus", "Title", "Uitleg");

		$lua0 = parent::luaSays("Lua was never intended to become a real popular language. Therefore if you look at the first versions of the language, a lot of features were missing. Basically Lua originated from merging two other programming languages together: DEL and SOL" . parent::bib()->cite(0) . ".");
		$cpp0 = parent::cppSays("What was the purpose of merging these two languages together? You say the language was missing some aspects, can you give some examples?");
		$lua1 = parent::luaSays("DEL is a language that was used to format data. It aimed to help engineers enter data into files. Before DEL, the engineers had to know the format of the files themselves. This made the task way more difficult. SOL was more a language to generate reports: the SOL interpreter could check if the data was correctly typed and could generate a report summarizing this data.");
		$cpp1 = parent::cppSays("I don't realy see what these languages have to do with Lua. The languages you're describing are very domain specific and probably aren't even Turing complete. Why were these languages merged after all?");
		$lua2 = parent::luaSays("One can say both languages were growing out of the box. SOL could do type checking but the users wanted more sophisticated tests and even procedural programming. Users of DEL wanted more control over the user interface. If both languages would remain separated a lot of work would be done twice. Therefore the developers decided to merge the languages.");
		$cSharp0 = parent::cSharpSays("What issues arose while merging both languages? I think you can't claim there are no problems merging languages since the developers of C# have some problems merging different programming paradigms.");
		$lua3 = parent::luaSays("The developers of Lua didn't merge the languages in a pure semantical way. Therefore they had more freedom to create new concepts. For instance DEL was not really integrated in Lua. It was merely the idea that everything could be stored in tables that represents the influence of DEL.");
		$cSharp1 = parent::cSharpSays("But can you say that Lua really merged those two languages? When do you consider a language to be a predecessor of another language?");
		$lua4 = parent::luaSays("One can claim Lua doesn't have a predecessor since the developers didn't worked with the implementations of both DEL and SOL. But I don't think one has to judge a language that way. At that time DEL and SOL were, and still are, used by a non-programmer community. The audience of both languages were merely the geologists and petroleum engineers of Petrobras. Given the success of SOL in this environment, the developers of Lua created a language with a quite simular syntax.");
		$cSharp2 = parent::cSharpSays("Did this make any difference? Most people know the syntax of the C-family since it's very widespread.");
		$lua5 = parent::luaSays("I wouldn't count that much on that, C#. However the main customer of DEL and SOL was Petrobras at that time. Lua was intended to replace those systems. In order to defend the choice of a new language, we could argue that the engineers at Petrobras wouldn't have a hard time in order to learn the language. But as far as I know both C# and C++ adapted syntax from their predecessor.");
		$cSharp3 = parent::cSharpSays("That's true. C# originates from Java. When Java became popular, Microsoft implemented their own virtual machine in order to run Java-applets. However the implementation of the Java standard remained incomplete for a long time. The incomplete implementation was a bottleneck for the further development of Java. Therefore Sun, the creators of Java, sued Microsoft. As a result of the trial, Microsoft wasn't allowed to build Java applications anymore. Therefore they started building a new language and framework: the .NET framework" . parent::bib()->cite(17) . ".");
		$cpp2 = parent::cppSays("But doesn't make such a decision both language quite similar? At what points C# differs from Java?");
		$cSharp4 = parent::cSharpSays("Since Java was developed earlier, the developers of C# had detected some bad aspects of Java. Some of these aspects were eliminated in the first version of C#.");
		$lua6 = parent::luaSays("Can you give some examples of such aspects?");
		$cSharp5 = parent::cSharpSays("One of the most annoying things about Java is the implementation of primitive types. When you want to use primitive types in an object oriented way (for instance in a generic class), you need to cast them to their class-equivalents (int to Integer,...). C# doesn't use these dual types. In C# int is an alias for Integer.");
		$cpp3 = parent::cppSays("Are these small aspects the only differences between Java and C#?");
		$cSharp6 = parent::cSharpSays("When the project started, yes. However if we look at the evolution of C#, one can argue that C# moved away from Java and more to functional languages like Haskell. But I think most programming languages are moving to the functional paradigm?");
		$lua7 = parent::luaSays("Lua implemented functional programming quite early: in 1998 anonymous functions were introduced. However one has to see this in a more broader context: Lua has always adopted very general concepts in order to keep the language small but powerful. I think languages like C# and C++ don't implement such concepts. Or am I mistaken?");
		$cpp4 = parent::cppSays("What do you mean by adopting very general concepts? C++ has some general concepts as well. In fact C++'s evolution is determined by a large group of people who work in the industry. The job of this committee is to prevent that someone implements domain specific features which would cause harm to the other C++ users.");
		$lua8 = parent::luaSays("For example Lua uses a fallback mechanisms when some operations aren't provided. You can argue that this is similar to inheritance but it is in fact more general.");
		
		//return $lua0.$random.$lua1.$lua.$cpp.$python.$cSharp;
		return $lua0.$cpp0.$lua1.$cpp1.$lua2.$cSharp0.$lua3.$cSharp1.$lua4.$cSharp2.$lua5.$cSharp3.$cpp2.$cSharp4.$lua6.$cSharp5.$cpp3.$cSharp6.$lua7.$cpp4.$lua8;
	}
	
	public function link(){
		return "evolution.php";
	}
	
	public function name(){
		return "Evolution";
	}
	
	public function bibliography(){
		return parent::bib()->format();
	}
}
?>
