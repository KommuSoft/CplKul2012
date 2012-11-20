<?php
error_reporting(-1);
ini_set('display_errors', '1');
include_once("question.php");
include_once("bibliography.php");

class Libraries extends Question {	
	public function __construct() {
		parent::__construct($this);
	}

	public function questionName(){
		return "Has the machine some literature?";
	}
	
	public function introduction(){
		return "Newton already knew it: ''If I have seen further it is by standing on the shoulders of giants''. One can't simply implement everything. Are there good libraries available, or do we have to do it all by ourselves?";
	}
	
	public function answers(){
		$popoverQt = parent::popover("Qt", "Qt framework", "Qt is actually a framework. It's main purpose is to make programs more portable. It also provides nice elements for creating GUIs. Because of the high popularity, Qt is also ported to a lot of other programming languages.");
	
		$popoverBoost = parent::popover("Boost", "Boost", "The Boost library is a collection of files that just must be included. This reduces the problems that occur at the linking step. Boost is so good that some parts are included in the C++11 standard.");
		
		$popoverSTL = parent::popover("STL", "STL", "The standard template library is a library that constains generic algorithms and data structures.");
	
		$popoverCryENGINE = parent::popover("CryENGINE", "CryENGINE", "This is a game engine made by Crytek, a company which made games like the Crysis serie and Far Cry.");
	
		$lua0 = parent::luaSays("Lua is a less known language, so the libary support is a bit less than those of the big ones. The fact that Lua is very small language, so not a lot of functionality is included doesn't really help."); 
		
		$cpp0 = parent::cppSays("But does this mean that Lua has very little available libraries? For example C++ has a good integration with C, so a lot of C libraries can be reused as C++ library. Of course sometimes some little adjustments are needed, but this isn't a big problem.");
		
		$lua1 = parent::luaSays("No this doesn't mean that there are few libraries. Similar like C++, Lua has also a good integration with C, it has a nice C API. So for popular C libraries, there is a good chance that someone already made a wrapper for it. If this is not the case, you can easily write one yourself. This keeps the language simple and clean because it seperates language definition from provided functionality.");
		
		$cSharp0 = parent::cSharpSays("But this sometimes results in bad consistency and also dependency problems can occur. You don't only depend on the library but also on the Lua wrapper for it. So it can be a problem when the wrapper is written for another Lua version than the one you are using. This can be a real problem if you know that the designers of Lua aren't afraid to break backwards compatibility. I think that the C# approach is better. C# ships with the .NET framework. This results in a lot of features that are present in the language.");
		
		$python0 = parent::pythonSays("So this is similar like the Python approach? Python has the \"Batteries Included\" philosophy. This means that Python ships with a lot of functionality already present in the language. For example Python has by default support for a webserver, managing mails, SQLite databases, data compression and so forth.");
		
		$cSharp1 = parent::cSharpSays("Not really, in C# there is a difference between the language (i.e. C#) and the libraries (the .NET framework). Also the libraries are very modular, this results in a very good consistency but it can lead to a lot of \"meaningless\" code because a lot of \"using\" statements will be used.");
		
		$cpp1 = parent::cppSays("But shipping with a lot of libraries can have its problems too. A library can restrict the programmer, because he/she isn't used to work with something else. Also a library doesn't always tackle the programmers wants to be solved.");
		
		$cSharp2 = parent::cSharpSays("But it's good to provide some default behaviour. Of course the .NET framework was aimed to be used at Windows which reduces some problems because you only have to implement default behaviour for one platform (there exists a cross platform version of the .NET framework called Mono, but it depends on other libraries like GTK+ for creating windows). But isn't it so that C++ has also better library support than in the early years?");
		
		$cpp2 = parent::cppSays("Indeed, the original version of C++ didn't contain the " . $popoverSTL . ". Also some functionality in C++11 is lent from " . $popoverBoost . ", for example function objects. It's logical that some things are lent from Boost because it's high quality library. C++ does have some other high quality libraries like " . $popoverQt . " and Intel Threading Building Blocks. Has Python a lot of high quality libraries?");

		$python1 = parent::pythonSays("It has a third-party software repository called PyPI which hosts a lot of libraries. Must of these libraries are very easy to install. However there are some compability problems between Python 2 and Python 3. I think that having a software repository tool for libraries is pretty unique, isn't it?");
		
		$haskell0 = parent::haskellSays("Haskell has also a package manager, it's named Cabal. This program makes it easy to install Haskell libraries. However the quality of Haskell libraries can differ. For example, parsers libraries are awesome but libraries for machine learning are a lot worse. Also the libraries are very pluggable but sometimes there are some dependencies problems.");
		
		$lua2 = parent::luaSays("Lua has also some high quality libraries. Lua is used a lot in the game industry, this resulted in a lot of contributions from game developers. For example " . $popoverCryENGINE ." supports Lua for the AI system" . parent::bib()->cite(10) . ". But Lua doesn't really need that much libraries. Lua is designed to be an embeddable language, so it can use the functionality/libraries that are present in the host language.");	
		
		
		//TODO: vertel iets over Java (zie $java0) en link dan $cSharp3 daaraan
		$java0 = parent::javaSays("A lot of libraries available. Standaard veel beschikbaar in de taal. Ook modulair opgebouwd.");
		$cSharp3 = parent::cSharpSays("Er zijn ook systemen beschikbaar die bijvoorbeeld java libraries kunnen importen. Werkt soms niet volledig als er low level stuff gebruikt wordt");
		
		return $lua0.$cpp0.$lua1.$cSharp0.$python0.$cSharp1.$cpp1.$cSharp2.$cpp2.$python1.$haskell0.$lua2.$java0.$cSharp3;
	}
	
	public function link(){
		return "libraries.php";
	}
	
	public function name(){
		return "Libraries";
	}
	
	public function bibliography(){
		return parent::bib()->format();
	}
}
?>
