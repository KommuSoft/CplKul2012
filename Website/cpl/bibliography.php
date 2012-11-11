<?php

class Item{
	private $title;
	private $author;
	private $date;	

	public function __construct($title, $author, $date){
		$this->title = $title;
		$this->author = $author;
		$this->date = $date;
	}
	
	public function format(){
		return '<strong>' . $this->title . '</strong> by ' . $this->author . ' (' . $this->date . ')';
	}
}

class Website {
	private $url;
	private $date;
	
	public function __construct($url, $date){
		$this->url = $url;
		$this->date = $date;
	}
	
	public function format(){
		return '<a href="' . $this->url . '">' . $this->url . "</a> (" . $this->date . ')';
	}
}

class Bibliography{
	private $counter;
	private $map;
	
	function __construct() {
		$this->counter = 1;
		$this->map = array();
	}
	
	private static function fetch($hash){
		$bib = array();
		$bib[0] = new Item('The evolution of Lua', 'Roberto Ierusalimschy, Luiz Henrique de Figueiredo, Waldemar Celes', '2007');
		$bib[1] = new Item('Programming Languages - C++ N3290', 'ANSI', '11/04/2011');
		$bib[2] = new Item("The design and evolution of C++", "Bjarne Stroustrup", "1994");
		$bib[3] = new Website("http://www.gamedev.net/page/resources/_/technical/game-programming/using-lua-with-c-r2275", "03/10/2012");
		$bib[4] = new Website("http://www.lua.org/manual/2.1/subsection3_4_2.html", "03/10/2012");
		$bib[5] = new Item("Functional Programming for Everyday .NET Development", "Jeremy Miller", '2009');
		$bib[6] = new Item("Haskell and C++ Template Metaprogramming", "Bartosz Milewski", "2011");
		//$bib[7] = new Item("Concepts of Programming Languages, Tenth Edition", "Robert W. Sebesta", "2012");
		$bib[8] = new Website("http://math.andrej.com/2009/04/11/on-programming-language-design/","10/11/2012");
		$bib[9] = new Website("http://www.redmountainsw.com/wordpress/2007/06/11/considerations-when-designing-your-own-programmingscripting-language/", '10/11/2012');
		$bib[10] = new Website("http://www.crytek.com/cryengine/cryengine2/overview", "08/11/2012");
		$bib[15] = new Website("http://en.cppreference.com/w/cpp/keyword", "09/11/2012");
		$bib[20] = new Website("http://docs.oracle.com/javase/tutorial/java/nutsandbolts/_keywords.html", "09/11/2012");
		return $bib[$hash];
	}
	
	public function create($name){
		return $name;
	}
	
	public function cite($hash){
		if(array_key_exists($hash, $this->map)){
			return '<a href="#bib" onclick="showBib(\'bib' . $this->map[$hash] . '\')">[' . ($this->map[$hash]) . ']</a>';		
		}
		$this->map[$hash] = $this->counter;
		return '<a href="#bib" onclick="showBib(\'bib' . $this->counter . '\')">[' . ($this->counter++) . ']</a>';
	}
	
	public function format(){
		$html = '<ul id="bib">';
		
		foreach($this->map as $key => $value){
			$html = $html . '<li id="bib' . $value . '">['. $value . "]: " . $this->fetch($key)->format() . '</li>';
		}
		
		return $html . "</ul>";
	}
}
?>
