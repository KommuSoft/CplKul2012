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
	protected static function haskellSays($stuff){
		return '<div class="HaskellContainer"><div class="LanguageName">Haskell</div> <div class="Quote">' . $stuff . '</div></div></p>';
	}
	protected static function javaSays($stuff){
		return '<div class="JavaContainer"><div class="LanguageName">Java</div> <div class="Quote">' . $stuff . '</div></div></p>';
	}
	private static function languages($language){
		$langs = array();
		$langs["c++"] =  "language-cpp";
		$langs["lua"] =  "prettyprint lang-lua";
		$langs["python"] =  "language-python";		
		$langs["c#"] =  "language-csharp";	
		$langs["java"] =  "language-java";	
		$langs["haskell"] =  "language-hs";		
		
		return $langs[$language];
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
	public function codeInline($code, $language, $linenums=1){
		return '<pre class="prettyprint linenums:' . $linenums . '"><code class="'. self::languages($language) . '">' . $code . '</code></pre>';
	}
	public function code($code, $language, $linenums=1){
		return '<div class="CodeContainer"><div class="LanguageName">' . $language . '</div> <div class="Quote"><pre class="prettyprint linenums:' . $linenums . '"><code class="'. self::languages($language) . '">' . $code . '</code></pre></div></div></p>';
	}
	public function readFromFile($file){
		return htmlspecialchars(file_get_contents($file));
	}
}
?>
