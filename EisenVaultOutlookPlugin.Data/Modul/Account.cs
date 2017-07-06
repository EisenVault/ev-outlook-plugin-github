using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using EisenVaultOutlookPlugin.Data.Entity;
using Newtonsoft.Json;

namespace EisenVaultOutlookPlugin.Data.Modul
{
   public  class Account
    {
        public string Error { get; set; }
        public async Task<bool> Loign(string server ,string username, string password)
        {
            Error = "";
            string url= server + "alfresco/api/-default-/public/authentication/versions/1/tickets";            
            string text = await API.Auth(url, username, password);

            if (string.IsNullOrEmpty(text))
            {
                Error = "Incorrect Username or password!!";
            }
            else
            {
                var jsonresult = Newtonsoft.Json.JsonConvert.DeserializeObject<TicketRootobject>(text);
                if (jsonresult.error != null)
                {
                    Error = jsonresult.error.errorKey;
                }
                else
                {
                    Option.SaveUserInfo(server, username, password, jsonresult.entry.id, jsonresult.entry.userId);
                    return true;
                }               
            }
            return false;           
        }

        public async Task<bool> CheckInfo()
        {
            Error = "";
            var info = Option.GetUserInfo();
            if (info == null)
            {
                return false;
            }
            string url = info.Server + "alfresco/api/-default-/public/authentication/versions/1/tickets";
            string text = await API.Auth(url, info.UserName, info.Password);

            if (string.IsNullOrEmpty(text))
            {}
            else
            {
                var jsonresult = JsonConvert.DeserializeObject<TicketRootobject>(text);
                if (jsonresult.error != null)
                {
                }
                else
                {                    
                    return true;
                }
            }
            return false;
        }

    }
}
