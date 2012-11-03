<!DOCTYPE html>
<?php 
	error_reporting(-1);
	ini_set('display_errors', '1');
	
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
	include_once("overview.php");
?>
<html lang="en">
	<?php include("core.php"); ?>
	<body>
		<?php include("navbarTop/navbarTopHome.php"); ?>
		
		<div class="container-fluid">
			<div class="row-fluid">
				<?php Sidebar::create(); ?>
				<div class="span9">
					<div class="hero-unit">
						<h1>Hello, Lua!</h1>
						<p>Lua isn't a language that is very well known. With some questions an answers we try to tell the strengths and weakness of Lua in comparison with other languages (C++, C#, Haskell, Java, Python)</p>
					</div>
					<?php echo(Overview::create()); ?>
				</div><!--/span-->
			</div><!--/row-->

			<hr>

			<footer>
				<p>&copy; Willem Van Onsem, Jonas Vanthornhout, Pieter-Jan Vuylsteke 2012</p>
			</footer>

		</div><!--/.fluid-container-->
		<?php include("javascript.php"); ?>
	</body>
</html>

