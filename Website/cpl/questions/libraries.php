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
	
		$lua = parent::luaSays("Lua is a less known language, so the libary support is a bit less than those of the big ones. The fact that Lua is very small language, so not a lot of functionality is included doesn't really help. On the other hand, Lua has a good integration with C. So for popular C libraries, their is a good chance that someone already made a wrapper for it. If this is not the case you can write easily one yourself. Game industry gebruikt veel Lua, dus er is bijdrage van game ontwikkelaars. Ook is er niet veel functionaliteit nodig want Lua wordt vaak als embedded language gebruikt, dus moet de host language maar de functionaliteit aanbieden.");
		
		$cpp = parent::cppSays("Because C++ is a language that is widely used, a lot of libraries are available (not a lot of functionality in the STL). Also helpful is the fact that C++ is pretty much compatible with C, which increases the range of libraries a lot. A disadvantage is that linking to libraries isn't always very easy. On the other hand there are some high quality libraries available. For example: " . $popoverQt . ", " . $popoverBoost . ", Intel Threading Building Blocks.");

		$cSharp = parent::cSharpSays(".Net framework is standaard meegeleverd :=:=> heel veel features standaard in de taal. Er zijn ook systemen beschikbaar die bijvoorbeeld java libraries kunnen importen. Heel modulair opgebouwd (voordeel: consistent, nadeel: veel using statements)");
		
		$python = parent::pythonSays("Python has very support for libraries. First of all Python uses the philosophy \"Batteries included\", so a lot of functionality is already present in Python. It also has a third-party software repository called PyPI which hosts a lot of libraries. Must of these libraries are very easy to install. However there are some compability problems between Python 2 and Python 3");
		
		$java = parent::javaSays("A lot of libraries available. Standaard veel beschikbaar in de taal. (vaak slechte kwaliteit van libraries). Ook modulair opgebouwd.");
		
		$haskell = parent::haskellSays("Dependencies zijn een hel. Maar sommige libraries zijn heel goed (vb. parsers), sommige vakgebieden liggen braak.");
		
		return $lua.$cpp.$cSharp.$python.$java.$haskell;
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
