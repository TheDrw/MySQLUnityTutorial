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
		SELECT username 
		FROM players 
		WHERE username ='" .$username_clean. "';
		";
	
	$name_check = mysqli_query($con, $name_check_query) or die('2 : name check query failed'); // err code #2 : name check query failed
	
	if(mysqli_num_rows($name_check) > 0)
	{
		echo '3 : name already exists'; // error code #3: name exists - can't register.
		exit();
	}

	// add user to table
	$salt = '\$5\$rounds=5000\$' . 'sphinctertinker' . $username_clean . '\$';
	$hash = crypt($password_clean, $salt);
	
	$insert_user_query = "INSERT INTO players (username, hash, salt) VALUES ('" . $username_clean . "', '" . $hash . "', '" . $salt . "');";
	mysqli_query($con, $insert_user_query) or die('4: insert player query failed'); // err code #4 : insery query failed
	
	echo '0';
?>