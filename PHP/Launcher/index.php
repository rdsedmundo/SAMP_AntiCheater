<?php
session_start();

if(isset($_GET['passw'])) {
	$pass = $_GET['passw'];
	if($pass != "ladylinda001")
		exit("Senha incorreta!");
		
	setcookie("pass", ''.md5($pass));
	exit("<script>location.href = location.href.toString().split('?')[0];</script>");
}

if(!isset($_COOKIE["pass"]))
	exit("<form method='get'>Senha: <input name='passw' type='text' maxlength='20'><br><input type='submit' value='Submeter'></form><br>");
else {
	$pass = $_COOKIE["pass"]; // ladylinda001
	if($pass != md5("ladylinda001")) {
		setcookie("pass");
		exit("Senha incorreta!");	
	}
}
?>
<DOCTYPE html>
<html lang="pt-BR">
<head>
<meta charset="utf-8">

<title>Anti-Cheater Painel</title>

<link rel="stylesheet" type="text/css" href="css/smoothness/jquery-ui-1.10.3.custom.min.css">
<script type="text/javascript" src="js/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="js/jquery-ui-1.10.3.custom.min.js"></script>
<script type="text/javascript" src="js/pan.js"></script>

<link rel="stylesheet" type="text/css" href="css/pan.css">
</head>
<body>
<center style="padding-top:50px">
<div id="pan-site" style="text-align:justify">
<ul>
    <li><a href="#pan-box">Início</a></li>
    <li><a href="#pan-exe">Executáveis bloqueados</a></li>
    <li><a href="#pan-win">Janelas bloqueadas</a></li>
    <li><a href="#pan-mol">Módulos bloqueados</a></li>
</ul>
<div id="pan-box" style="text-align:center">
<button onclick="add();">Adicionar bloqueio</button> <button onclick="move();">Remover bloqueio</button>
</div>
<div id="pan-exe">
<table class="table-3"
	<thead>
			<th>ID</th>
			<th>Nome</th>
			<th>Tipo</th>
			<th>Data</th>
		</thead>
	<tbody id="t-exe">
	</tbody>
</table>
</div>
<div id="pan-win">
<table class="table-3"
	<thead>
			<th>ID</th>
			<th>Nome</th>
			<th>Tipo</th>
			<th>Data</th>
		</thead>
	<tbody id="t-win">
	</tbody>
</table>
</div>
<div id="pan-mol">
<table class="table-3"
	<thead>
			<th>ID</th>
			<th>Nome</th>
			<th>Tipo</th>
			<th>Data</th>
		</thead>
	<tbody id="t-mol">
	</tbody>
</table>
</div>
</center>
</body>
</html>