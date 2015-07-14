<?php
ini_set("display_errors", 0);

$nick = $_GET["t"];

if(!isset($nick))
	exit;
	
require_once "config.php";

$query = sprintf("SELECT * FROM `launcher` WHERE def='%s' ORDER BY `data` ASC", mysql_real_escape_string($nick));
$query = mysql_query($query); 

if(mysql_num_rows($query) == 0)
	exit("");	
	
while ($row = mysql_fetch_assoc($query)) {
    echo $row["id"].",";
    echo $row["nome"].",";
    echo $row["def"].",";
	echo $row["data"];
	echo "<br>";
}
?>