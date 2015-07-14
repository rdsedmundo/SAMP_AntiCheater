<?php
require_once "config.php";

$id = $_POST["__req"];

if(!isset($id))
	exit("N/A");

if(is_numeric($id))
	mysql_query("DELETE FROM `launcher` WHERE id='$id'") or die('Erro: '.mysql_error());
else
	mysql_query("DELETE FROM `launcher` WHERE nome='$id'") or die('Erro: '.mysql_error());
	
exit("Deletado.");
?>