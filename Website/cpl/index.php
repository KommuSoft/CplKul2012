<!DOCTYPE html>
<?php 
	error_reporting(-1);
	ini_set('display_errors', '1');
	
	include_once("questions/audience.php");
	include_once("questions/oop.php");
	$audience = new Audience();
	$oop = new OOP();
	
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
					<div class="row-fluid">
						<div class="span4">
							<h2>Heading</h2>
							<p>Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui. </p>
							<p><a class="btn" href="#">View details &raquo;</a></p>
						</div><!--/span-->
						<div class="span4">
							<h2>Heading</h2>
							<p>Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui. </p>
							<p><a class="btn" href="#">View details &raquo;</a></p>
						</div><!--/span-->
						<div class="span4">
							<h2>Heading</h2>
							<p>Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui. </p>
							<p><a class="btn" href="#">View details &raquo;</a></p>
						</div><!--/span-->
					</div><!--/row-->
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

