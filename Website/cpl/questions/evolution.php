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
		return "How Does a Language Evolve?";
	}
	
	public function introduction(){
		return "One does not simply adds features to a language. All popular languages have some limitations evolving the development of that language. The audience of the language plays of course a crucial part. How does these programming languages maintain themselves?";
	}
	
	public function answers(){
		$WorldOfWarcraft = $this->popover("World of Warcraft", "World of Warcraft", "World of Warcraft is a massively multiplayer online role-playing game.");
		$monty = $this->popover("Monty Python's Flying Circus", "Title", "Uitleg");		
		/*$lua0 = parent::luaSays("merge sol del brazilie petrobras. Gemakkelijk data te verwerken, configuration files. Lua is erin geslaagd zichzelf up to date te houden.");

		$random = parent::cppSays("What are the implications of keeping yourself up to date? users themselves suggest adaptations for 'me''");

		$lua1 = parent::luaSays("backwards compatibility is not a real issue, because you can support your own vm. Furthermore we assume users will use a host language for functional aspects. Therefore Lua is more a glue-language.");

		$cpp2 = parent::cppSays("Thats quite easy. Lua uses the evolution of host languages instead of adapting itself to new trends. But of course thats one of the main reasons of the popularity of Lua: from the moment one language implements a feature, Lua can benefit from that implementation.");

		$csharp0 = parent::cSharpSays("C# aims to be a broad language. Mainly for business users and stand alone. Therefore backwards compatibility is an issue for C#. However obsolete features will dissapear eventually. I know that's a reason why some systems written in C# will break eventually. But removing bad concepts keeps a language fresh. Furthermore C# benefits also from the .NET framework. A framework where systems can be written in several compatible languages. Therefore it benefits from implementation in other languages, like Lua.");
		
		$lua = parent::luaSays("Lua was designed so it could be used by engineers, geologists and so forth" . parent::bib()->cite(0) . ". This visible through the fact that Lua doesn't have an intimidating syntax. Instead of using curly braces, Lua uses \"do\" and \"end\". In retrospect, Lua is currently used a lot in games, which wasn't a specific aim for the designers of Lua. There is even a book for writing Lua in combination with World of Warcraft. This suggests that Lua has achieved this goal very well. //// Lua has a garbage collector which results in a less steeper learning curve: we don't expect user to do bookkeeping about memory. This approach is very user friendly. Specially for non-technical users.");
		
		$cpp = parent::cppSays("In contrast to Lua, C++ isn't designed for end users. It's designed for people who want to write high performance systems but need object orientation, which isn't available in C (a highly popular language at that time), hence the original name \"C with classes\". //// C++ aims to be a performance language. Therefore it doesn't have a garbage collector. Doing memory management yourself results in a faster system. //// Although C++ has changed so much in the last years and thereby also its audience, the audience of Lua and C++ is very different. This doesn't mean they have a connection with each other. For example " . $WorldOfWarcraft . " has a C++ core with a layer of Lua for the user interface. 
[Willem: De hele game wereld werkt met C++, is dit statement betrouwbaar?]");

		$python = parent::pythonSays("The audience of Python is more like the audience of Lua. Everyone who wants to automate a certain task can use Python. This is why Python is very readable. Instead of using curly braces, Python uses indentation. An approach which is very similar to Lua's one. It's a language for everyone who wants to have fun, as long as you like " . $monty . ".//// Like Lua Python also has a garbage collector. However the system is quite open: one can turn off the garbage collector and implement one himself. Therefore both performance and general users benefit from Python.");


		$cSharp = parent::cSharpSays("C# aims to be a broad language: mainly for business purposes however some scientific libraries and applications are written in C# (for instance the Math.NET framework). Therefore it mixes a lot of concepts found in other languages. //// C# has a garbage collector the options available are quite the same as in Java. C# argues introducing a garbage collector will not slow down the system that much, the garbage collector is quite lazy. /// C# is quite extensible: it allows programmers to write code in other languages inside their C# code. For instance if you want to write a program where some methods should be executed quite fast, one can write Assembly code in C#. Lua is also supported" . parent::bib()->cite(3) .".");*/

		$lua0 = parent::luaSays("Lua was never intended to become a real popular language. Therefore if you look at the first versions of the language, a lot of features were missing. Basically Lua originated from merging two other programming languages together: DEL and SOL.");
		$cpp0 = parent::cppSays("What was the purpose of merging these two languages together? You say the language was missing some aspects, can you give some examples?");
		$lua1 = parent::luaSays("DEL is a language that was used to format data. It aimed to help engineers enter data into files. Before DEL the engineers had to know the format of the files themselves. This made the task way more difficult. SOL was more a language to generate reports: the SOL interpreter could check if the data was correctly typed and generate a report summarizing that data.");
		$cpp1 = parent::cppSays("I don't realy see what these languages have to do with Lua. The languages you're describing are very domain specific and probably aren't even Turing complete. Why were these languages merged after all?");
		$lua2 = parent::luaSays("One can say both languages were growing out of the box. SOL could do type checking but it's user wanted more sophisticated tests and even procedural programming. Users of DEL wanted more control over the user interface. If both languages would remain separated a lot of work would be done twice. Therefore the developers decided to merge the languages.");
		$cSharp0 = parent::cSharpSays("What issues arose while merging both languages? I think one can't claim there are no problems merging languages since the developers of C# have some problems merging different programming paradigms.");
		$lua3 = parent::luaSays("The developers of Lua didn't merged the languages in a pure semantical way. Therefore they had more freedom to create new concepts. For instance DEL was not really integrated in Lua. It was merely the idea that everything could be stored in tables that represents the influence of DEL.");
		$cSharp1 = parent::cSharpSays("Can one argue that Lua didn't really merged those two languages. When does you consider a language to be predecessor of that language?");
		$lua4 = parent::luaSays("One can claim Lua doesn't has a predecessor since the developers didn't worked with the implementations of both DEL and SOL. But I don't think one has to judge a language that way. At that time DEL and SOL were, and still are, used by a non-programmer community. The audience of both languages were merely the geologist and petroleum engineers of Petrobras. Given the success of SOL in this environment, the developers of Lua created a language with a quite simular syntax.");
		$cSharp2 = parent::cSharpSays("Did this make any difference? Most people know the syntax of the C-family since it's very widespead.");
		$lua5 = parent::luaSays("I wouldn't count that much on that C#. However the main customer of DEL and SOL was Petrobras at that time. Lua was intended to replace those systems. In order to defend the choise of a new language, we could argue that the engineers at Petrobras wouldn't have a hard time in order to learn the language. But as far as I know both C# and C++ adapted syntax from their predecessor.");
		$cSharp3 = parent::cSharpSays("That's true. C# originates from Java. When Java became popular, Microsoft implemented their own virtual machine in order to run Java-applets. However the implementation of the Java standard remained incomplete for a long time. The incomplete implementation was a bottleneck for the further development of Java. Therefore Sun, the creators of Java, sued Microsoft. As a result of the trial, Microsoft wasn't allowed to build Java applications anymore. Therefore they started building a new language and framework: the .NET framework.");
		$cpp2 = parent::cppSays("But doesn't make such a decision both language quite similar? At what points C# differs from Java?");
		$cSharp4 = parent::cSharpSays("Since Java was developed earlier, the developers of C# had detected some bad aspects of Java. Some of these aspects were eliminated in the first version of C#.");
		$lua6 = parent::luaSays("Can you give some examples of such aspects?");
		$cSharp5 = parent::cSharpSays("One of the most annoying things about Java is the implementation of primitive types. When you want to use primitive types, you need to cast them to their class-equivalents (int to Integer,...). C# doesn't use these dual types. In C# int is an alias for Integer.");
		$cpp3 = parent::cppSays("Are these small aspects the only differences between Java and C#?");
		$cSharp6 = parent::cSharpSays("When the project started, yes. However if we look at the evolution of C#, one can argue that C# moved away from Java and more to functional languages like Haskell. But I think most programming languages are moving to the functional paradigm?");
		$lua7 = parent::luaSays("Lua implemented functional programming quite early: in 1998 anonymous functions were introduced. However one has to see this in a more broader context: Lua has always adopted very general concepts in order to keep the language small but powerfull. I think languages like C# and C++ don't implement such concepts. Or am I mistaken?");
		$cpp4 = parent::cppSays("What do you mean by adopting very general concepts. C++ has some general concepts as well. In fact C++'s evolution is determined by a large group of people who work in the industry. The job of these committees is to prevent one of implementing small and domain specific features who will cause more harm in the end their potential gain. Since the evolution of C++ is supervised by an army of specialists, I think most people will agree that the design of C++ is more consistent?");
		$lua8 = parent::luaSays("Lua has a very small team of three developers who maintain the system and introduce new features. The main advantage of this approach is that Lua can be modified more dynamically. If you look how much time it takes to introduce a feature in C++. Everybody is of course free to write his or her own Lua interpreter or compiler but the Lua standard is set by a very small group. The advantage I guess is that Lua is more developed with a certain vision in mind, while decisions in C++ are more a compromise between several opinions. What about C#? Who maintains C#?");
		$cSharp7 = parent::cSharpSays("C# is a product of Microsoft, and thus Microsoft introduces new features. An interesting sidenode however is Mono. Mono is an implementation of C# developed mainly by Miguel De Icaza. An interesting ");
		
		//return $lua0.$random.$lua1.$lua.$cpp.$python.$cSharp;
		return $lua0.$cpp0.$lua1.$cpp1.$lua2.$cSharp0.$lua3.$cSharp1.$lua4.$cSharp2.$lua5.$cSharp3.$cpp2.$cSharp4.$lua6.$cSharp5.$cpp3.$cSharp6.$lua7.$cpp4;
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
