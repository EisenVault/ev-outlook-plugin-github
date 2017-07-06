using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EisenVaultOutlookPlugin.Data.Entity;

namespace EisenVaultOutlookPlugin.Data.Modul
{

    public class Nodes
    {
        public string Error { get; set; }
        public bool UseAlternative { get; set; }
        public async Task<List<NodeEntry>> Get(string nodeId="-root-")
        {
            List<NodeEntry> list = new List<NodeEntry>();
            try
            {
                string urlPath = $"alfresco/api/-default-/public/alfresco/versions/1/nodes/{nodeId}/children?maxItems=10000";
                string text = await API.Get(urlPath);
                if (string.IsNullOrEmpty(text))
                {

                }
                else
                {
                    var jsonresult = Newtonsoft.Json.JsonConvert.DeserializeObject<NodeRootobject>(text);
                    if (jsonresult.error != null)
                    {
                        Error = jsonresult.error.errorKey;
                    }
                    else
                    {
                        var nodeList = jsonresult.list;
                        list.AddRange(nodeList.entries.Select(c => c.entry));
                    }
                }
            }
            catch (Exception ex)
            {
                LogClass.WriteException(ex.Message, ex.StackTrace, ex.InnerException == null ? "" : ex.InnerException.Message);
            }


            return list;
        }

        public async Task<string> CreateFolder(string nodeId,string name,string alternativeName= null)
        {
            string folderId = "";
            try
            {
                string urlPath = $"alfresco/api/-default-/public/alfresco/versions/1/nodes/{nodeId}/children";
                var parameter = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("name",name),
                    new KeyValuePair<string, string>("nodeType","cm:folder")
                };
                string text = await API.Post(urlPath, parameter);
                if (API.IsSuccessStatus)
                {
                    if (string.IsNullOrEmpty(text) == false)
                    {
                        var jsonresult = Newtonsoft.Json.JsonConvert.DeserializeObject<FolderRootobject>(text);
                        if (jsonresult.error != null)
                        {
                            Error = jsonresult.error.errorKey;
                            if (!string.IsNullOrEmpty(alternativeName)
                                && jsonresult.error.statusCode == 409
                            )
                            {
                                Error = "";
                                UseAlternative = true;
                                folderId = await CreateFolder(nodeId, alternativeName);
                            }
                            if (jsonresult.error.statusCode == 403)
                            {
                                Error = "You do not have write permission on this folder!";
                            }
                        }
                        else
                        {
                            folderId = jsonresult.entry.id;
                        }
                    }
                    else
                    {
                        Error = $"API Issue with Code :{API.StatusCode}!";
                    }
                }
                else
                {
                    Error = $"API Issue with Code :{API.StatusCode}!";
                    if (string.IsNullOrEmpty(text) == false)
                    {
                        var jsonresult = Newtonsoft.Json.JsonConvert.DeserializeObject<FolderRootobject>(text);
                        if (jsonresult.error != null)
                        {
                            Error = jsonresult.error.errorKey;
                            if (!string.IsNullOrEmpty(alternativeName)
                                && jsonresult.error.statusCode == 409
                            )
                            {
                                Error = "";
                                UseAlternative = true;
                                folderId = await CreateFolder(nodeId, alternativeName);
                            }
                            if (jsonresult.error.statusCode == 403)
                            {
                                Error = "You do not have write permission on this folder!";
                            }
                        }                        
                    }                    
                }
            }
            catch (Exception ex)
            {
                LogClass.WriteException(ex.Message, ex.StackTrace, ex.InnerException == null ? "" : ex.InnerException.Message);
            }

            return folderId;

        }

    }
}
