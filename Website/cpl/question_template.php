<?php include_once("sidebar.php"); ?>
<html lang="en">
	<?php include("core.php"); ?>
	<body>
		<?php include("navbarTop/navbarTop.php"); ?>

		<div class="container-fluid">
			<div class="row-fluid">
				<?php Sidebar::create($question->name()); ?>
			
				<div class="span9">
					<div class="hero-unit">
						<h1><?php echo($question->questionName()); ?></h1>
						<?php echo($question->introduction()); ?>
					</div>
					<div class="row-fluid">
						<div class="span12">
							<?php echo($question->answers()); ?>
						</div><!--/span-->
					</div><!--/row-->
					<div class="row-fluid">
						<div class="span12">
							<?php echo($question->bibliography()); ?>
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
