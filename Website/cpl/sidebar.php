<?php

include_once("questions/question.php");

class Sidebar{
	public static function create($name = ""){
		echo('<div class="span3"><div class="well sidebar-nav"><ul class="nav nav-list"><li class="nav-header">Questions</li>');
		
		foreach(Question::$questions as $question){
			if($name === $question->name()){
				echo('<li class="active">');
			} else {
				echo('<li>');
			}
			echo('<a href="'); echo($question->link()); echo('">');
			echo($question->name());
			echo('</a></li>');
		}
		
		echo('</ul></div></div>');
	}
}
?>
