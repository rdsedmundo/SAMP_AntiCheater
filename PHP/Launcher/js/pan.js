LOAD = function() {
	$("#t-exe").html('');
	$("#t-win").html('');
	$("#t-mol").html('');
	
	$.get("search.php", {t:1}, function (__resp) {
		var __registros = __resp.split("<br>");
					
		for(i = 0; i < __registros.length - 1; i++) {
			var __atual = __registros[i], __campos = __atual.split(","), HTML = "";
						
			HTML += "<tr>";
			HTML += "<td>"+__campos[0]+"</td>";
			HTML += "<td>"+__campos[1]+"</td>";
			HTML += "<td>"+__campos[2]+"</td>";
			HTML += "<td>"+__campos[3]+"</td>";
			HTML += "</tr>";
						
			$("#t-exe").append(HTML);
		}
	});
	
	$.get("search.php", {t:2}, function (__resp) {
		var __registros = __resp.split("<br>");
					
		for(i = 0; i < __registros.length - 1; i++) {
			var __atual = __registros[i], __campos = __atual.split(","), HTML = "";
					
			HTML += "<tr>";
			HTML += "<td>"+__campos[0]+"</td>";
			HTML += "<td>"+__campos[1]+"</td>";
			HTML += "<td>"+__campos[2]+"</td>";
			HTML += "<td>"+__campos[3]+"</td>";
			HTML += "</tr>";
				
			$("#t-win").append(HTML);
		}
	});
	
	$.get("search.php", {t:3}, function (__resp) {
		var __registros = __resp.split("<br>");
					
		for(i = 0; i < __registros.length - 1; i++) {
			var __atual = __registros[i], __campos = __atual.split(","), HTML = "";
						
			HTML += "<tr>";
			HTML += "<td>"+__campos[0]+"</td>";
			HTML += "<td>"+__campos[1]+"</td>";
			HTML += "<td>"+__campos[2]+"</td>";
			HTML += "<td>"+__campos[3]+"</td>";
			HTML += "</tr>";
						
			$("#t-mol").append(HTML);
		}
	});
}

$(function() {
	if(navigator.userAgent.search("Chrome") == -1)
		alert("Para uma melhor exibição deste site, é recomendado usar o Google Chrome.");
		
	$("#pan-site").tabs();
	
	setInterval(function(){
		try{
			$("label").each(function(){
				if($(this).hasClass("select")==false && $(this).html().match(/option/gi))
					$(this).addClass("select");
			})
			$('input[type="submit"],input[type="button"],button').button().css("-webkit-appearance", "none");
            $("input,textarea,button").css("outline", "none");
		} catch(E) {}
		
	}, 1);
	
	LOAD();
});

function validString(__str) {
	if(__str == "" || __str == undefined)
		return false;
		return true;
}

add = function () {
	var __def = prompt("Digite o tipo (veja as opções).\n\n1 - Executável ilegal.\n2 - Janela ilegal.\n3 - Módulo ilegal", ""),
		__nom = prompt("Digite o nome.", "");
		
	if(!validString(__def) || !validString(__nom)) {
		alert("Campos inválidos");
		return;	
	}
		
	$.post("add.php", {"n": __nom, "def": __def}, function(__resp) {
		LOAD();
		alert(__resp);
	});
}

move = function () {
	var __req = prompt("Digite o ID ou o nome.", "");
	
	$.post("remove.php", {"__req":__req}, function(__resp) {
		LOAD();
		alert(__resp);	
	});
}