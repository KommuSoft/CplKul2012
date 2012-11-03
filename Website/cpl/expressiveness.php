<!DOCTYPE html>
<?php
	error_reporting(-1);
	ini_set('display_errors', '1');
	
	include("questions.php");
	include_once("questions/expressiveness.php");
	$question = new Expressiveness();
	
	include_once("question_template.php");
?>
