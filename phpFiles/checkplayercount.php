<?php

	$con = mysqli_connect('localhost', 'root', 'root', 'unityaccess');
	
	// check connection happened
	if(mysqli_connect_errno())
	{
		echo '1 : connection failed'; // error code #1 : connection failed
		exit();
	}
	
	// i was trying to use SELECT(COUNT) FROM players;
	// but it wasn't working, so I'm using mysqli_num_rows() instead
	$count_query = "
		SELECT username
		FROM players;
		";
	
	$result = mysqli_query($con, $count_query);
	
	$min_players = 5;
	if(mysqli_num_rows($result) < $min_players)
	{
		echo '0 : the player needs to have table filled';
	}
	else
	{
		echo '1 : player has ' .$min_players. ' or more in table';
	}
?>