<?php
if(!isset($_GET["n"]))
	die("Error: nick not found.");

if(!isset($_GET["data"]))
	die("Error: data of request not found.");
	
$nick     = $_GET["n"];
$data     = base64_decode($_GET["data"]);

$arqname  = $nick.".txt";
$arq = fopen($arqname, "w");
chmod($arqname, 0777);
fwrite($arq, $data);
fclose($arq);
?>