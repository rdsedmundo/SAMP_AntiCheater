<?php
$nome = $_POST["n"];
$def  = $_POST["def"];

if(!isset($nome) || empty($nome)
	|| !isset($def) || empty($def))
		exit("Campos inválidos");
		
require_once "config.php";

$nome = mysql_real_escape_string($nome);
$def = mysql_real_escape_string($def);

$data = date("d/m/Y");

$query = mysql_query("INSERT INTO `launcher` (id, nome, def, data) VALUES ('', '$nome', '$def', '$data')");

if(!$query)
	exit("Ocorreu um erro.\n\n". mysql_error());
else
	exit("Adicionado com sucesso");
?>