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
	
	$password = mysqli_real_escape_string( $con, $_POST['password']);
	$password_clean = filter_var($password, FILTER_SANITIZE_STRING, FILTER_FLAG_STRIP_LOW | FILTER_FLAG_STRIP_HIGH);
	
	// check if name exists
	$name_check_query = "
		SELECT username, hash, salt, score 
		FROM players 
		WHERE username ='" .$username_clean. "';
		";
	
	$name_check = mysqli_query($con, $name_check_query) or die('2 : name check query failed'); // err code #2 : name check query failed
	if(mysqli_num_rows($name_check) != 1)
	{
		echo '5: either no user exists or more than one'; // err code #5: number of names matching != 1
		exit();
	}

	// get login info from query
	$existing_info = mysqli_fetch_assoc($name_check);
	$salt = '\$5\$rounds=5000\$' . 'sphinctertinker' . $username_clean . '\$';
	$hash = $existing_info['hash'];

	$login_hash = crypt($password_clean, $salt);
	$login_hash = substr($login_hash, 1);
	if($hash != $login_hash)
	{
		echo '6: incorrect password'; // err code #6: password does not match table
		exit();
	}

	echo '0#' . $existing_info['score']; // # is the delimiter
?>