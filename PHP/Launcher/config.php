<?php
$connect = mysql_connect("localhost", "user_error", "passwd");

if(!$connect) {
	exit("Ocorreu um erro ao conectar: ".mysql_error());
}

mysql_select_db("database", $connect);
?>
