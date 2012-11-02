<?php
abstract class Question {
	public static $questions;
	protected static function luaSays($stuff){
		return '<div class="LuaContainer"><div class="LanguageName">Lua</div> <div class="Quote">' . $stuff . '</div></div></p>';
	}
	protected static function cppSays($stuff){
		return '<div class="CppContainer"><div class="LanguageName">C++</div> <div class="Quote">' . $stuff . '</div></div></p>';
	}
	protected static function pythonSays($stuff){
		return '<div class="PythonContainer"><div class="LanguageName">Python</div> <div class="Quote">' . $stuff . '</div></div></p>';
	}
	protected static function cSharpSays($stuff){
		return '<div class="CSharpContainer"><div class="LanguageName">C#</div> <div class="Quote">' . $stuff . '</div></div></p>';
	}
	
	protected $bib_;
	public function __construct($child){
		$this->bib_ = new Bibliography();

		if(isset(self::$questions)){
			if(!in_array($this, self::$questions)){
				self::$questions[] = $child;
			}
		} else {
			self::$questions[] = $child;
		}
	}
	
	public function questionName(){}
	public function introduction(){}
	public function answers(){}
	public function link(){}
	public function name(){}
	protected function bib(){
		return $this->bib_;
	}
	public function popover($display, $title, $content){
		return '<a class="myPopover" rel="popover" data-content="' . $content . '" data-original-title="' . $title . '">' . $display . '</a>';
	}
}
?>
