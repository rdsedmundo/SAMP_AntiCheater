using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.IO;
using System.Collections;
using System.Net.NetworkInformation;
using System.Management;
using System.Net;
using System.Web;
using Magic;

namespace SAMP_Launcher
{
    public partial class AntiCheater : Form
    {
        public AntiCheater()
        {
            InitializeComponent();
        }

        public const string LAUNCHER_BASE_URL = "kyl3.6te.net", ver = "v0.0.1";

        private string[] BadModules, BadWindows, BadExec;

        BlackMagic mMagic = new BlackMagic();

        private string PLAYER_IP, BAD_TOOL_NAME;

        private void Log(string log_msg)
        {
            string path = Directory.GetCurrentDirectory();
            path += "/Anticheater.log";
            if (!File.Exists(path))
                System.IO.File.Create(path).Close();

            System.IO.TextWriter log = System.IO.File.AppendText(path);

            string Horas = DateTime.Now.Hour.ToString(),
                   Minutos = DateTime.Now.Minute.ToString(),
                   Segundos = DateTime.Now.Second.ToString();

            if (DateTime.Now.Hour < 10)
                Horas = "0" + DateTime.Now.Hour.ToString();

            if (DateTime.Now.Minute < 10)
                Minutos = "0" + DateTime.Now.Minute.ToString();

            if (DateTime.Now.Second < 10)
                Segundos = "0" + DateTime.Now.Second.ToString();

            string LOG_MSG = "[" + Horas + ":" + Minutos + ":" + Segundos + "] " + log_msg;

            if (log_msg != "")
                logBox.AppendText(logBox.Text == "" ? LOG_MSG : "\n" + LOG_MSG);

            string Dia = DateTime.Now.Day.ToString(),
                   Mes = DateTime.Now.Month.ToString(),
                   Ano = DateTime.Now.Year.ToString();

            if (DateTime.Now.Day < 10)
                Dia = "0" + Dia;

            if (DateTime.Now.Month < 10)
                Mes = "0" + Mes;

            if (DateTime.Now.Year < 10)
                Ano = "0" + Ano;

            LOG_MSG = "[" + Dia + "/" + Mes + "/" + Ano + " " + Horas + ":" + Minutos + ":" + Segundos + "] " + log_msg;

            log.WriteLine(LOG_MSG);
            log.Close();
        }

        private void AntiCheater_FormClosing(object sender, FormClosingEventArgs e)
        {
            Do_REQ("http://" + LAUNCHER_BASE_URL + "/Launcher/f_Delete.php?n=" + PLAYER_IP, 1);
        }

        private void AntiCheater_FormClosed(object sender, FormClosedEventArgs e)
        {
            Do_REQ("http://" + LAUNCHER_BASE_URL + "/Launcher/f_Delete.php?n=" + PLAYER_IP, 1);
        }

        private void AntiCheater_Load(object sender, EventArgs e)
        {
            Log("");
            Log("Iniciando [versão " + ver + "].");

            PLAYER_IP = GetIP();

            Do_REQ("http://" + LAUNCHER_BASE_URL + "/Launcher/f_Create.php?n=" + PLAYER_IP + "&data=" + EncodeTo64(ver));

            lHash.Text = EncodeTo64("[FSYNC]" + PLAYER_IP[1] + PLAYER_IP[3] + PLAYER_IP[5]);
            Log("Current-unique-hash: " + lHash.Text);

            lAuth.Text = "Aguardando SA-MP...";
            lAuth.ForeColor = Color.Blue;

            Log("Aguardando SA-MP...");

            cSamp.Start();
        }

        private void cSamp_Tick(object sender, EventArgs e)
        {
            if (IsProcessOpen("samp") && IsProcessOpen("gta_sa"))
            {
                Log("Jogo encontrado.");

                lAuth.Text = "Jogo encontrado";
                lAuth.ForeColor = Color.Green;

                IsRunning.Start();
                cSamp.Stop();

                LoadProtect();

                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void IsRunning_Tick(object sender, EventArgs e)
        {
            if (!IsProcessOpen("gta_sa"))
            {
                Log("O processo \"gta_sa.exe\" foi fechado.");
                Log("Fechando o Launcher.");

                IsRunning.Stop();
                this.OnFormClosing(null);
            }
        }

        private void Exit()
        {
            this.OnFormClosing(null);
        }

        private void LoadProtect()
        {
            Log("Carregando informações sobre ferramentas ilegais.");
            BadModules = Do_REQ("http://" + LAUNCHER_BASE_URL + "/Launcher/BAD.php?def=3").Split(',');
            BadWindows = Do_REQ("http://" + LAUNCHER_BASE_URL + "/Launcher/BAD.php?def=2").Split(',');
            BadExec = Do_REQ("http://" + LAUNCHER_BASE_URL + "/Launcher/BAD.php?def=1").Split(',');

            Checking_Start();
        }

        private void Checking_Start()
        {
            mMagic.OpenProcessAndThread(GetProcessId("gta_sa"));

            Log("Iniciando verificação de módulos, bibliotecas e executáveis.");
            tCheck.Start();

            Log("Iniciando sincronização automática do Anti-cheater.");
            CreateFile.Start(); // sync
        }

        private void CreateFile_Tick(object sender, EventArgs e)
        {
            Log("Re-sincronizando estado do Anti-cheater.");
            Do_REQ("http://" + LAUNCHER_BASE_URL + "/Launcher/f_Create.php?n=" + PLAYER_IP + "&data=" + EncodeTo64(ver));
        }

        private void HackDetected()
        {
            Log("O Anti-cheater detectou uma ferramenta ilegal funcionando ["+BAD_TOOL_NAME+"].");
            Log("Módulo-base: \"gta_sa.exe\"");
            Log("Fechando o processo.");
        }

        /* Anti-Cheater starts here */

        private bool Check_Modules(int bLog)
        {
            try
            {
                if (Convert.ToBoolean(bLog))
                    Log("módulos ilegais...");

                foreach (ProcessModule pm in mMagic.Modules)
                {
                    foreach (string zModule in BadModules)
                    {
                        string srch1 = zModule + ".asi", srch2 = zModule + ".dll";
                        if (pm.ModuleName == srch1 || pm.ModuleName == srch2)
                        {
                            BAD_TOOL_NAME = zModule;
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool Check_Windows(int bLog)
        {
            try
            {
                if (Convert.ToBoolean(bLog))
                    Log("janelas ilegais...");

                Process[] listProc = Process.GetProcesses();
                foreach (Process proc in listProc)
                {
                    foreach (string zWindow in BadWindows)
                    {
                        if (zWindow == proc.MainWindowTitle)
                        {
                            BAD_TOOL_NAME = proc.ProcessName;
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool Check_Exec(int bLog)
        {
            try
            {
                if (Convert.ToBoolean(bLog))
                    Log("executáveis ilegais...");

                foreach (string zExec in BadExec)
                {
                    if (IsProcessOpen(zExec))
                    {
                        BAD_TOOL_NAME = zExec + ".exe";
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void tCheck_Tick(object sender, EventArgs e)
        {
            Log("Verificando por...");

            if (Check_Exec(1) || Check_Windows(1) || Check_Modules(1))
            {
                HackDetected();
                Exit();

                tCheck.Stop();
            }
            else
            {
                Log("Sucesso!");
            }
        }

        private void AntiCheater_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            Log("Abrindo diálogo de informações sobre o programa.");

            UserCalledHelp();

            e.Cancel = true;
        }

        private void bClearLog_Click(object sender, EventArgs e)
        {
            logBox.Text = "";

            Log("Limpando mensagens.");
        }

    }
}