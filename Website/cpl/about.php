<!DOCTYPE html>
<?php

	include_once("questions/audience.php");
	include_once("questions/oop.php");
	include_once("questions/portability.php");
	include_once("questions/expressiveness.php");
	include_once("questions/typing.php");
	include_once("questions/languageDesign.php");
	include_once("questions/learning.php");
	include_once("questions/libraries.php");
	include_once("questions/syntax.php");
	$audience = new Audience();
	$oop = new OOP();
	$por = new Portability();
	$exp = new Expressiveness();
	$typ = new Typing();
	$lan = new LanguageDesign();
	$lea = new Learning();
	$lib = new Libraries();
	$syn = new Syntax();
	
	include_once("sidebar.php");
?>
<html lang="en">
	<?php include("core.php"); ?>
	<body>
		<?php include("navbarTop/navbarTopAbout.php"); ?>
		
		<div class="container-fluid">
			<div class="row-fluid">
				<?php Sidebar::create(); ?>
				<div class="span9">
					<div class="hero-unit">
						<h1>this->what() = ?</h1>
						<p>What's this website about and what is the purpose?</p>
					</div>
					<div class="span12" id="about">
						<p>This is a website we (= Willem Van Onsem, Jonas Vanthornhout & Pieter-Jan Vuylsteke) created for the first project of the course "Comparative Programming Languages". The goal was to select a programming language and compare it with languages you already knew. We've chosen Lua and compared it with mainly C#, C++ but also with Java and to a lesser extent with Haskell and Python.</p>
						<p>The purpose was to do this comparison in a Socratic dialogue. This can be done in a couple of ways, but our approach is as follows. We've selected a few topics, see the sidebar on the left. Each topic has a main question and a short introduction. Then we let the experts of the languages discuss about this topic.</p>
						
						<p>We hope you enjoy it and learn something new about Lua.</p>
					</div>
				</div><!--/span-->
			</div><!--/row-->

			<hr>

			<footer>
				<p>&copy; Willem Van Onsem, Jonas Vanthornhout, Pieter-Jan Vuylsteke 2012</p>
			</footer>

			<!--
         ,aaadddd8888888bbbbaaa,_
     ,adP"::' 888  "Y8ba,  ```::Y8aa,_
   ,dP"  ::' ,88P    ,88P'   ,::: ``8"Yba,
  ,88'  ,::  d88'   d8P'     :::'  ,P  `)88a,
 ,888   ::'  888   "Y8ba,    :::   d'   d8P`Ya,
,888P  ,::  ,88P     ,88P'  ,:::  ,P   ,88'  `Ya,
8888'  ::'  d88'    d8P'    :::'  d'   d8P   ,::b,
8888   ::   888    "Y8ba,   :::   8    88'   ::::b
8888   ::   888      ,88P'  :::   8    88,   ::::P
8888,  ::,  Y88,    d8P'    :::,  Y,   Y8b   `::P'
`888b  `::  `88b   "Y8ba,   `:::  `b   `88,  ,d"
 `888   ::,  888     ,88P'   :::   Y,   Y8b,d"
  `88,  `::  Y88,   d8P'     :::,  `b  _)8P"
   `Yb,  ::, `88b  "Y8ba,    `::: _,8adP"  
     `"Yb,::, 888    ,88P'  __::adP""'     
         `"""YYYY8888888PPPP"""'
			-->
		</div><!--/.fluid-container-->
		<?php include("javascript.php"); ?>
	</body>
</html>

