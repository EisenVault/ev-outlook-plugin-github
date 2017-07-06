using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EisenVaultOutlookPlugin.Data.Entity;

namespace EisenVaultOutlookPlugin.Data.Modul
{
    public class UploadFile
    {
        public string Error { get; set; }
        public async Task<bool> Upload(string nodeId,string path)
        {
            string urlPath = $"alfresco/api/-default-/public/alfresco/versions/1/nodes/{nodeId}/children";
            string text = await API.Upload(urlPath, path);
            Error = $"API Issue with Code :{API.StatusCode}!";
            if (API.IsSuccessStatus)
            {
                Error = "";
                if (string.IsNullOrEmpty(text) == false)
                {                   
                    var jsonresult = Newtonsoft.Json.JsonConvert.DeserializeObject<UploadNodeRootobject>(text);
                    if (jsonresult.error != null)
                    {
                        Error = jsonresult.error.errorKey;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
