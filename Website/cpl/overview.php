<?php

class Overview{
	public static function create(){
		$html = "";
		$row = false;
		for($i = 0; $i < count(Question::$questions); $i++){
			if($i % 3 === 0){
				$row = true;
				$html = $html . '<div class="row-fluid">';
			}
			$question = Question::$questions[$i];
			$html = $html . '<div class="span4"><h2>' . $question->name() . '</h2><p>' . $question->introduction() . '</p><p><a class="btn" href="' . $question->link() . '">Read more &raquo;</a></p></div>';
			if($i % 3 === 2){
				$row = false;
				$html = $html . '</div>';
			}
		}
		
		if($row){
			$html = $html . '</div>';
		}
		
		return $html;
	}
}

?>
