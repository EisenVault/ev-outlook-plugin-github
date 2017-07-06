using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EisenVaultOutlookPlugin.Data.DataBase;
using EisenVaultOutlookPlugin.Data.Entity;

namespace EisenVaultOutlookPlugin.Data.Modul
{
    public class Option
    {
        public static string ServerUrl
        {
            get
            {
                if (Optiondb.UserInfo.Count == 0) return null;
                var item = Optiondb.UserInfo[0];
                return item.Server;
            }           
        }

        private static DataSet_Config _optiondb;
        public static DataSet_Config Optiondb
        {
            get
            {
                if (_optiondb == null)
                {
                    _optiondb = new DataSet_Config();
                    //Read();
                }
                return _optiondb;
            }
            set { _optiondb = value; }
        }

        public static string PluginFolder
        {
            get
            {
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\EisenVaultOutlook_plugin\\";
                if (Directory.Exists(folder) == false)
                {
                    Directory.CreateDirectory(folder);
                }
                return folder;
            }
        }
        public static string TempFolder
        {
            get
            {
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\EisenVaultOutlook_plugin\\Temp\\";
                if (Directory.Exists(folder) == false)
                {
                    Directory.CreateDirectory(folder);
                }
                return folder;
            }
        }

        private static string OptionPath
        {
            get
            {
                return PluginFolder + "Plugin-option";
            }
        }
        public static void Read()
        {
            try
            {
                Optiondb = new DataSet_Config();
                if (IsExist())
                {                    
                    Optiondb.ReadXml(OptionPath, XmlReadMode.IgnoreSchema);
                }                
            }
            catch (Exception ex)
            {
                LogClass.WriteException(ex.Message, ex.StackTrace, ex.InnerException == null ? "" : ex.InnerException.Message);
            }
        }
        public static void Save()
        {
            try
            {
                Optiondb.WriteXml(OptionPath, XmlWriteMode.IgnoreSchema);
            }
            catch (Exception ex)
            {
                LogClass.WriteException(ex.Message, ex.StackTrace, ex.InnerException == null ? "" : ex.InnerException.Message);
            }
        }
        public static bool IsExist()
        {
            return File.Exists(OptionPath);
        }
        public static void SaveUserInfo(string server, string userName, string password, string token, string userId)
        {

            if (Optiondb.UserInfo.Count == 0)
            {
                Optiondb.UserInfo.AddUserInfoRow(Optiondb.UserInfo.NewUserInfoRow());
            }
            DataSet_Config.UserInfoRow row = Optiondb.UserInfo[0];
            row.Server = server;
            row.UserName = userName;
            row.Password = password;
            row.Token = token;
            row.UserId = userId;
            Save();
        }
        public static PluginUserInfo GetUserInfo()
        {
            if (Optiondb.UserInfo.Count == 0) return null;
            var item = Optiondb.UserInfo[0];


            return new PluginUserInfo()
            {
                UserName = item.IsUserNameNull() ? null : item.UserName,
                Password = item.IsPasswordNull() ? null : item.Password,
                Server = item.IsServerNull() ? null : item.Server,
                Token = item.IsTokenNull() ? null : item.Token,
                UserId = item.IsUserIdNull() ? null : item.UserId,                
            };
        }

        public static void Clear()
        {
            Optiondb.UserInfo.Clear();
            Save();            
        }

    }
}
