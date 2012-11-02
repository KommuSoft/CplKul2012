<?php
class Bibliography{
	private $counter;
	private $map;
	
	function __construct() {
		$this->counter = 1;
		$this->map = array();
	}
	
	private static function fetch($hash){
		$bib = array();
		$bib[0] = 'The evolution of Lua';
		$bib[3] = '<a href="http://www.gamedev.net/page/resources/_/technical/game-programming/using-lua-with-c-r2275">http://www.gamedev.net/page/resources/_/technical/game-programming/using-lua-with-c-r2275</a>';
		return $bib[$hash];
	}
	
	public function create($name){
		return $name;
	}
	
	public function cite($hash){
		$this->map[$this->counter] = self::fetch($hash);
		return '<a href="#bib" onclick="showBib(\'bib' . $this->counter . '\')">[' . ($this->counter++) . ']</a>';
	}
	
	public function format(){
		$html = '<ul id="bib">';
		
		foreach($this->map as $key => $value){
			$html = $html . '<li id="bib' . $key . '">['. $key . "]: " . $value . '</li>';
		}
		
		return $html . "</ul>";
	}
}
?>
