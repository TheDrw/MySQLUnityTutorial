<?php

	$con = mysqli_connect('localhost', 'root', 'root', 'unityaccess');
	
	// check connection happened
	if(mysqli_connect_errno())
	{
		echo '1 : connection failed'; // error code #1 : connection failed
		exit();
	}
	
	
	// used this as a guide/reference for posting a table.
	// kind of old, but kind of works as a starting point
	// https://www.cs.vu.nl/~eliens/.CREATE/local/essay/09/nm2/klitsie-joost.pdf
	
	$query = "
		SELECT username, score
		FROM players
		ORDER BY score DESC
		LIMIT 5;
		";
	

	$result = mysqli_query($con, $query);
	while($array = mysqli_fetch_array($result))
	{
		echo $array['username'].'#' .$array['score'].'#';
	}
?>