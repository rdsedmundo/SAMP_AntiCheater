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
using System.Text.RegularExpressions;
using System.Net;
using System.Web;
using System.Threading.Tasks;

namespace SAMP_Launcher
{
    public partial class AntiCheater
    {
        public static void alert(string Text, MessageBoxIcon IconType)
        {
            MessageBox.Show(Text, "Aviso", MessageBoxButtons.OK, IconType);
        }

        public static void alert(string Text)
        {
            MessageBox.Show(Text, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static string Do_REQ(String url)
        {
            try
            {
                String resp = null;
                HttpWebRequest WebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                WebRequest.Method = "GET";
                HttpWebResponse myWebResponse = (HttpWebResponse)WebRequest.GetResponse();
                StreamReader Source = new StreamReader(myWebResponse.GetResponseStream());
                resp = Source.ReadToEnd();
                myWebResponse.Close();
                return resp;
            }
            catch (Exception err)
            {
                alert("Ocorreu uma falha durante a autenticação com o Banco de Dados.\n\n"+err, MessageBoxIcon.Exclamation);

                Application.Exit();
                Environment.Exit(0);

                return "-1";
            }
        }

        public static string Do_REQ(string url, int exit)
        {
            try
            {
                string resp = null;
                HttpWebRequest WebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                WebRequest.Method = "GET";
                HttpWebResponse myWebResponse = (HttpWebResponse)WebRequest.GetResponse();
                StreamReader Source = new StreamReader(myWebResponse.GetResponseStream());
                resp = Source.ReadToEnd();
                myWebResponse.Close();

                KillProcess("gta_sa");

                Environment.Exit(0);
                Application.Exit();

                return resp;
            }
            catch (Exception)
            {
                alert("Ocorreu uma falha durante a autenticação com o Banco de Dados.", MessageBoxIcon.Exclamation);

                Application.Exit();
                Environment.Exit(0);

                return "-1";
            }
        }

        public static string GetIP()
        {
            return Do_REQ("http://"+ LAUNCHER_BASE_URL +"/Launcher/g_ip.php");
        }

        public static string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes
                  = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
            string returnValue
                  = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }

        public static bool IsProcessOpen(string ProcessName)
        {
            try
            {
                Process[] pid = Process.GetProcessesByName(ProcessName);
                if (pid[0].Id > 0)
                    return true;

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool KillProcess(string ProcessName)
        {
            try
            {
                Process[] pid = Process.GetProcessesByName(ProcessName);
                if (pid[0].Id > 0)
                {
                    pid[0].Kill();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static int GetProcessId(string ProcessName)
        {
            if (IsProcessOpen(ProcessName))
            {
                Process[] pid = Process.GetProcessesByName(ProcessName);
                return pid[0].Id;
            }
            return -1;
        }

        public void UserCalledHelp()
        {
            string[] Msg = {
              "Versão " + ver + "\n\n",
              "Esta ferramenta foi criada com o intuito de diminuir a incidência de Cheaters, Hackers e Modificações no Servidor, sendo essas que, ao serem utilizadas por algum jogador, passam a dar benefícios sobre os demais.\n\n",
              "Nenhuma informação sobre seu Computador, com exceção do seu endereço de IP, ou da sua conta no Servidor são reproduzidas, armazenadas ou utilizadas por esta ferramenta."
            };

            string HelpDialog = "";

            foreach(string zMsg in Msg)
                HelpDialog += zMsg;

            alert(HelpDialog);
        }

    }
}
