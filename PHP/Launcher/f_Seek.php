<?php
if(!isset($_GET["n"]))
	die("Error: nick not found.");

die((file_exists($_GET["n"].".txt")) ? "".file_get_contents($_GET["n"].".txt") : "0");
?>