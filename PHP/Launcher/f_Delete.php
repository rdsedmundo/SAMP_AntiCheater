<?php
if(!isset($_GET["n"]))
	die("Error: nick not found.");
	
$nick         = $_GET["n"];
$arqname  = $nick.".txt";

if(file_exists($arqname))
	unlink($arqname);
?>