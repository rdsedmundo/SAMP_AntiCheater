<?php
require_once "config.php";

ini_set("display_errors", 0);

$nick = $_GET["def"];

if(!isset($nick))
	die("");

$query = sprintf("SELECT * FROM `launcher` WHERE def='%s'", mysql_real_escape_string($nick));
$query = mysql_query($query); 

if(mysql_num_rows($query) == 0)
	exit("");	
	
$count = 0;
$real  = mysql_num_rows($query);
	
while ($row = mysql_fetch_assoc($query)) {
    echo $row["nome"];
	
	if(($count+1)!=$real)
		echo ",";
	
	$count++;
}
?>