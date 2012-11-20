<?php
error_reporting(-1);
ini_set('display_errors', '1');
include_once("question.php");
include_once("bibliography.php");

class Portability extends Question {	
	public function __construct() {
		parent::__construct($this);
	}

	public function questionName(){
		return "What about the portability?";
	}
	
	public function introduction(){
		return "Each individual is walking in a \"Zoo of Platforms\". How are languages adapted to the purpose of portability?";
	}
	
	/*TODO (door Jonas):
		* Is het niet zo dat vm instructies gemakkelijk te decompilen zijn (tenzij je een obfucater gebruikt)? Bij Java gaat het gemakkelijk, over C# heb ik geen idee.
		* Over C++: er zijn geen 1300 pagina's geschreven om de taal compatible te houden. Dat is de volledige standaard.
		* Er wordt gesproken over een runtime compiler. Voor mij klinkt dit raar, zou er iets beter bestaan? runtime interpreter mss
		* Bron voor stack-based en register-based vermelden.
	*/
	public function answers(){
		$codeEx1 = "int main(){
	unsigned long size = 5;
	int arr[size];
}";
		$lua0 = parent::luaSays("Most designers of programming languages today spend a lot of effort to make their language more portable, I guess. The designers of Lua however wanted a portable system from the start.");
		$cSharp0 = parent::cSharpSays("Can you give any evidence for this statement?");
		$lua1 = parent::luaSays("Well, Lua originates from two languages: DEL and SOL. The designers of Lua argued that since both languages were used by a slightly different audience, they could not make much assumptions about their platform configurations.");
		$cpp0 = parent::cppSays("I have a remark: aren't all programming languages that are interpreted or run in a virtual machine in some extent portable? What makes Lua special in this perspective?");
		$lua2 = parent::luaSays("Lua's case is special: the designers wanted the language to be portable, but at the same time they didn't want early implemented features to inhibit new developments.");
		$java0 = parent::javaSays("That sounds like a paradox? How can a language be both portable but not backwards compatible? How can you combine these features?");
		$lua3 = parent::luaSays("Quite simple: Lua is interpreted and in contrast with Java, the developers of Lua didn't want to write an interpreter for each platform. Therefore the Lua interpreter is written in very portable ANSI C. However the language itself doesn't need to be backwards compatible: since most Lua software is shipped with the interpreter, the programmers are sure their programs will run on the proper Lua interpreter.");
		$cSharp1 = parent::cSharpSays("That idea looks interesting. What are the drawbacks of this strategy you think?");
		$lua4 = parent::luaSays("The main issue I guess is that libraries have to be rewritten to support a new version of Lua. One could of course solve this problem by running two Lua interpreters side by side. However this would make matters complicated and would probably result in bad performance. Furthermore since the interpreter is highly portable, it can't take much advantage on special characteristics of the platform it runs on.");
		$cpp1 = parent::cppSays("Yes, since performance is very important in C++, this would already be a strong argument against using a virtual machine, not to mention a platform-independent interpreter.");
		$java1 = parent::javaSays("I'm not quite sure I understand your statement. Since virtual machines can be tweaked for a special platform, they have a potential to yield better results.");
		$cpp2 = parent::cppSays("I don't follow. Why could a virtual machine potentially yield better performance?");
		$java2 = parent::javaSays("Well, if you compile your system to machine code, you have to make assumptions about the system. With a virtual machine, you postpone this decisions until you run the program. If the processor for instance supports the MMX or SSE, the virtual machine can optimize the code in order to take advantage of this extended instruction set. The same holds for instance for GPU's with OpenCL support.");
		$cpp3 = parent::cppSays("Most C++ compilers support a lot of popular instruction set extensions. Therefore, the virtual machines will not increase performance.");
		$cSharp2 = parent::cSharpSays("Probably true. However this requires the code to be compiled on the target machine. Therefore the source code should be available. Most software developers tend to hide the source code in order to protect their technology. Compiling the code to virtual machine instructions is a first step to hide the source code.");
		$lua5 = parent::luaSays("Probably true. An open question however is if backwards compatibility is really necessary. I don't see what backwards compatibility has to do with portability?");
		$cpp4 = parent::cppSays("Since you can't ship each possible driver and library with your code, backwards compatibility is somehow related to portability. If your code is not backwards compatible, you have a large chance stuff will break at the client side. In C++ backwards compatibility is an important issue. More than 1300 pages were written in order to keep the language backwards compatible".parent::bib()->cite(1).". I agree that's a huge cost to achieve compatibility, but C++ is used with a lot of legacy code which makes the effort justified. However a glue language like Lua probably doesn't need to be backwards compatible since the glue logic is used for only one application.");
		$lua6 = parent::luaSays("True, another reason I think is that Lua remains an interpreted language. The more complex the runtime compiler, the slower the program will run. Therefore legacy features probably imply a bloated language and thus bloated programs.");
		$cSharp3 = parent::cSharpSays("But hasn't Lua got a compiler? As far as I know one can already preprocess the programming code into byte code for a Lua virtual machine. In that aspect Lua doesn't have to worry about a bloated language.");
		$lua7 = parent::luaSays("Lua has a compiler, but keep in mind even the virtual machine instructions are not backwards compatible. For instance until version 4, the virtual machine was stack-based. Now Lua uses a register-based approach. Furthermore the number of instructions has been reduced: the first version had more than sixty instructions, now there are less than forty.");
		$cSharp4 = parent::cSharpSays("That's quite small. C# has more than 230 virtual machine instructions. However that's probably reasonable since the language has more programming concepts. Furthermore in response to C++: I think a virtual machine approach can at least partly solve backwards compatibility issues. Of course the virtual machine can process different versions of the language by implementing their proper virtual machines. Furthermore C# uses a system called Global Assembly Cache: a repository where different versions of each library are stored. Each version of each library has a unique identifier called GUID. When you include a library into a C# project, one has to specify this GUID. Therefore the virtual machine can load the proper version of that library.");

		//TODO: add haskell and python?


		/*$lua = parent::luaSays("Lua is very portable. There are a couple reasons for this. Like I said before Lua was designed to be used by a lot of different people. This means that a lot of different systems can be used. So Lua wa designed with portability in mind. Another point is that Lua was (and is) designed to be a small language. The designers say it's easier to add a feature than removing an excessive one. Also they aren't afraid to break backwards compatibility. This results in a small language. For example: the reference manual is less than 100 pages. How big is the C++ reference?, VM => portable");
		
		$cpp = parent::cppSays("More than 1300 pages." . parent::bib()->cite(1) . " But C++ can't permit to break backwards compatibility. The language is used very intensively. Also Lua users can download the interpreter and support it themselves, something that is much much more difficult to do with C++. The reason why C++ isn't that portable in real life, is that compiler writers and library designers create stuff that is useful but not portable. For example the following code isn't valid C++" . $this->codeInline($codeEx1, "c++") . "Although some compilers accept it and make a C++ extension of it.");
		
		$python = parent::pythonSays("That's why Python has a \"batteries included\" philosophy. A lot of functionality is implemented in the Python standard, so less libraries are needed and better portability is achieved. Also good for portability is a small group of designers. This ensures that the global is consistent through the whole language. [TODO: goed argument?] Python gebruikt ook VM");
		
		$lua2 = parent::luaSays("But that leads to a more bloated language. Also it introduces problems if the languages changes, so there can be backwards compability problems.");
		
		$cSharp = parent::cSharpSays("[Jonas: vertel dat C# dat mooi oplost door abstractie te maken van taal en framework maar ze hebben sterke integratie, vb. ASP], VM => portable");
		
		$java = parent::javaSays("Goede portabiliteit, zolang het geen low level stuff is zoals drivers. JVM zorgt er voor dat het portable is.");

		$haskell = parent::haskellSays("Geen vm, compileert naar C-- (of een C variant, afhankelijk van de compiler).");*/
		
		return $lua0.$cSharp0.$lua1.$cpp0.$lua2.$java0.$lua3.$cSharp1.$lua4.$cpp1.$java1.$cpp2.$java2.$cpp3.$cSharp2.$lua5.$cpp4.$lua6.$cSharp3.$lua7.$cSharp4;
	}
	
	public function link(){
		return "portability.php";
	}
	
	public function name(){
		return "Portability";
	}
	
	public function bibliography(){
		return parent::bib()->format();
	}
}
?>
