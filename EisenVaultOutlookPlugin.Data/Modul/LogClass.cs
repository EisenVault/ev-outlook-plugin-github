using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisenVaultOutlookPlugin.Data.Modul
{
    public class LogClass
    {
        public Option Options { get; set; }
        private static int NumberLfiles = 0;
        private static int NumberWfiles = 0;
        public static string LogFile
        {
            get
            {
                if (NumberLfiles == 0 && Directory.Exists(Option.PluginFolder + "log\\") == false)
                {
                    NumberLfiles = 1;
                }
                else if (NumberLfiles == 0)
                {
                    DirectoryInfo info = new DirectoryInfo(Option.PluginFolder + "log\\");
                    var files = info.GetFiles().Where(c => c.Name.StartsWith("Log_")).OrderByDescending(c => c.LastWriteTime).ToList();
                    if (files.Count > 0)
                    {
                        double size = (files[0].Length / 1024f) / 1024f; // 20MB
                        if (size > 20)
                        {
                            NumberLfiles = NumberLfiles + 1;
                        }
                    }
                }
                return "Log_" + NumberLfiles + ".txt";
            }
        }

        public static string LogWbFile
        {
            get
            {
                if (NumberWfiles == 0 && Directory.Exists(Option.PluginFolder + "log\\") == false)
                {
                    NumberWfiles = 1;
                }
                else if (NumberWfiles == 0)
                {
                    DirectoryInfo info = new DirectoryInfo(Option.PluginFolder + "log\\");
                    var files = info.GetFiles().Where(c => c.Name.StartsWith("Logwb_")).OrderByDescending(c => c.LastWriteTime).ToList();
                    if (files.Count > 0)
                    {
                        double size = (files[0].Length / 1024f) / 1024f; // 20MB
                        if (size > 20)
                        {
                            NumberWfiles = NumberWfiles + 1;
                        }
                    }
                }

                return "Logwb_" + NumberWfiles + ".txt";
            }
        }
        public static string LogPath
        {
            get
            {
                return Option.PluginFolder + "log\\" + LogFile;
            }
        }
        public static string LogWbPath
        {
            get
            {
                return Option.PluginFolder + "log\\" + LogWbFile;
            }
        }
        public void WriteLog(string msg)
        {
            if (string.IsNullOrEmpty(msg))
                return;
            if (Directory.Exists(LogPath.Replace(LogFile, "")) == false)
                Directory.CreateDirectory(LogPath.Replace(LogFile, ""));


            using (FileStream fs = new FileStream(LogPath, FileMode.Append, FileAccess.Write, FileShare.None))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    string message = string.Format("{0} : {1}", DateTime.Now, msg);
                    sw.WriteLine(message);
                }
            }
        }
        public static void WriteException(string msg, string trace, string innermsg)
        {
            if (Directory.Exists(LogPath.Replace(LogFile, "")) == false)
                Directory.CreateDirectory(LogPath.Replace(LogFile, ""));


            using (FileStream fs = new FileStream(LogPath, FileMode.Append, FileAccess.Write, FileShare.None))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    string message = string.Format("{0} : {1} \n ##-##-#### Trace : {2} \n ##-##-#### Inner : {3}", DateTime.Now, msg, trace, innermsg);
                    sw.WriteLine(message);
                }
            }
        }
        public static void WriteWbLog(string msg, string code, string status, string method, string module, string exception, string url)
        {
            if (Directory.Exists(LogWbPath.Replace(LogWbFile, "")) == false)
                Directory.CreateDirectory(LogWbPath.Replace(LogWbFile, ""));


            using (FileStream fs = new FileStream(LogWbPath, FileMode.Append, FileAccess.Write, FileShare.None))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    string message = string.Format("{0} : method:{1}, module: {2}", DateTime.Now, method, module);
                    if (string.IsNullOrEmpty(code) == false)
                        message += ", Code: " + code;
                    if (string.IsNullOrEmpty(status) == false)
                        message += ", status: " + status;

                    if (string.IsNullOrEmpty(url) == false)
                        message += ", url: " + url;
                    if (string.IsNullOrEmpty(msg) == false)
                        message += ", status: " + msg;
                    if (string.IsNullOrEmpty(exception) == false)
                        message += ", status: " + exception;


                    //string message = string.Format("{0} : method:{1}, module: {2}, Code: {3} , status:{3} , message: {4} , Exception: {5} ", DateTime.Now, msg, trace, innermsg);

                    sw.WriteLine(message);
                }
            }
        }
    }
}
