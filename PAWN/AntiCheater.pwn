#include <a_samp>
#include <a_http>

#define LAUNCHER_BASE_URL "kyl3.6te.net"
#define STATIC_VER "v0.0.1"

#define MUST_USE_LAUNCHER "[ATEN��O] %d lembre-se de baixar o nosso ANTI-XITER. Ao atingir n�vel 3 e voc� n�o estiver com ele ligado, voc� ser� desconectado."
#define LAUNCHER_DOWNLOAD "Voc� pode encontrar-lo em nosso f�rum: google.com"

#define MSG_SERVERERROR "[Anti-cheater] N�o foi poss�vel conectar-se ao Servidor de autentica��o. C�digo do erro: %d."
#define MSG_NOTOPEN "[Anti-cheater] Voc� precisa abrir o Anti-cheater antes de entrar no Servidor."
#define MSG_AUTHED "[Anti-cheater] Voc� est� conectado com o Anti-cheater."
#define MSG_OLDVERSION "[Anti-cheater] Voc� est� usando uma vers�o desatualizada do Launcher, por favor, baixe a mais atualizada (%s)."

new timerChecking[MAX_PLAYERS] = -1;

forward KickPublic(playerid);
forward OnResponse(playerid, response_code, data[]);
forward C_LAUNCHER(playerid);
forward S_LAUNCHER_OFF(playerid);

stock Nome(playerid) {
	new buffer[MAX_PLAYER_NAME];
	GetPlayerName(playerid, buffer, MAX_PLAYER_NAME);

	return buffer;
}

stock mKick(playerid, message[])
{
    SendClientMessage(playerid, -1, message);
    return
		SetTimerEx("KickPublic", 1000, 0, "d", playerid);
}

stock GetIP(playerid) {
	new IP[32];
	GetPlayerIp(playerid, IP, 32);
	return IP;
}

public OnFilterScriptInit() {
	printf("[FS Anti-cheater] Carregado [vers�o %s].", STATIC_VER);
	printf("Criado por Kyl3 (c) 2013.");
	printf("Refer�ncia: www.pastebin.com/u/Kyl3 - www.kyl3.6te.net");
	return 1;
}

public KickPublic(playerid) {
	Kick(playerid);
}

public C_LAUNCHER(playerid) {
	new url[128];
	format(url, sizeof(url), "%s/Launcher/f_Seek.php?n=%s", LAUNCHER_BASE_URL, GetIP(playerid));
	HTTP(playerid, HTTP_GET, url, "", "OnResponse");
}

public S_LAUNCHER_OFF(playerid) {
	new url[128];
	format(url, sizeof(url), "%s/Launcher/f_Delete.php?n=%s", LAUNCHER_BASE_URL, GetIP(playerid));
	HTTP(playerid, HTTP_GET, url, "", "");
}

forward CheckLevelAndLauncher(playerid);
public CheckLevelAndLauncher(playerid) {
	if(GetPlayerScore(playerid) > 3)
		C_LAUNCHER(playerid);
	else {
		new buffer[256];
		format(buffer, sizeof(buffer), MUST_USE_LAUNCHER, Nome(playerid));
		SendClientMessage(playerid, 0xB4B5B7FF, MUST_USE_LAUNCHER);
		SendClientMessage(playerid, 0xB4B5B7FF, LAUNCHER_DOWNLOAD);
	}
}

public OnPlayerConnect(playerid)
{
	SendClientMessage(playerid, -1, "[Anti-cheater] Voc� tem 30 segundos para logar no Servidor antes da verifica��o do Launcher iniciar.");
	SetTimerEx("CheckLevelAndLauncher", 30000, false, "%d", playerid);
    return 0;
}

public OnPlayerDisconnect(playerid)
{
	S_LAUNCHER_OFF(playerid);
	KillTimer(timerChecking[playerid]);
	timerChecking[playerid] = -1;
	return 0;
}

public OnResponse(playerid, response_code, data[])
{
    new buffer[128];

    if(response_code != 200) // sem sucesso
    {
        format(buffer, sizeof(buffer), MSG_SERVERERROR, response_code);
        return
			mKick(playerid, buffer);
    } else { // sucesso
		if(strcmp(data, "0") == 0)
			return
				mKick(playerid, MSG_NOTOPEN);

		if(strcmp(data, STATIC_VER) != 0) { // vers�es incompat�veis
		    S_LAUNCHER_OFF(playerid);

			format(buffer, sizeof(buffer), MSG_OLDVERSION, STATIC_VER);
			return
			    mKick(playerid, buffer);
		}
    }

    if(timerChecking[playerid] == -1) {
		SendClientMessage(playerid, -1, MSG_AUTHED);
		timerChecking[playerid] = SetTimerEx("C_LAUNCHER", 30000, true, "%d", playerid);
    }

    S_LAUNCHER_OFF(playerid); // sync

    return 1;
}
