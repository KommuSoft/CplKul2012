<?php
error_reporting(-1);
ini_set('display_errors', '1');
include_once("question.php");
include_once("bibliography.php");

class OOP extends Question {	
	public function __construct() {
		parent::__construct($this);
	}

	public function questionName(){
		return "How is object oriented programming implemented?";
	}
	
	public function introduction(){
		return "One of the most popular paradigm is \"Object oriented programming\". But how is it implemented in different languages";
	}
	
	public function answers(){
	}
	
	public function link(){
		return "oop.php";
	}
	
	public function name(){
		return "OOP";
	}
	
	public function bibliography(){
		return parent::bib()->format();
	}
}
?>
