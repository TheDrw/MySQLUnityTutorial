<?php

	$con = mysqli_connect('localhost', 'root', 'root', 'unityaccess');
	
	// check connection happened
	if(mysqli_connect_errno())
	{
		echo '1 : connection failed'; // error code #1 : connection failed
		exit();
	}
	
	$username = mysqli_real_escape_string( $con, $_POST['name']);
	$username_clean = filter_var($username, FILTER_SANITIZE_STRING, FILTER_FLAG_STRIP_LOW | FILTER_FLAG_STRIP_HIGH);
	
	// i don't know how to filter it for only numbers. this will do.
	$new_score = mysqli_real_escape_string( $con, $_POST['score']);
	$new_score_clean = filter_var($new_score, FILTER_SANITIZE_STRING, FILTER_FLAG_STRIP_LOW | FILTER_FLAG_STRIP_HIGH);


	// double check there is only one user with this name
	$name_check_query = "
		SELECT username 
		FROM players 
		WHERE username = '" .$username. "';
		";
	
	$name_check = mysqli_query($con, $name_check_query) or die('2 : name check query failed'); // err code #2 : name check query failed
	
	if(mysqli_num_rows($name_check) != 1)
	{
		echo '5: Either no user with name or more than one';
	}

	$update_query = "
		UPDATE players 
		SET score = " .$new_score_clean. " 
		WHERE username = '".$username."'; 
		";
		
	mysqli_query($con, $update_query) or die('7: Save query failed'); // redundant comment

	echo '0';
?>