<?php

	$con = mysqli_connect('localhost', 'root', 'root', 'unityaccess');
	
	// check connection happened
	if(mysqli_connect_errno())
	{
		echo '1 : connection failed'; // error code #1 : connection failed
		exit();
	}

	$password = 'ezhackzpassw0rd123'; // obviously, don't do this in a real thing.

	$usernames = array("Jeff Bozos", "Mark Hackerberg", "Bill Fences", "Linus Travolta", "Drw T3h Mastur");
	$arrLength = count($usernames);
	for($x = 0; $x < $arrLength; $x++)
	{
		$salt = '\$5\$rounds=5000\$' . 'sphinctertinker' . $usernames[$x] . '\$';
		$hash = crypt($password, $salt);
		$random_score = mt_rand(1,20);
		$insert_user_query = "
			INSERT INTO players (username, hash, salt, score) 
			VALUES ('".$usernames[$x]."' , '".$hash."' , '".$salt."' , '".$random_score."');
			";
			
		mysqli_query($con, $insert_user_query) or die('4: insert random players query failed'); 
	}
	
	echo '0: inserted 5 random lozrz into table.';
?>