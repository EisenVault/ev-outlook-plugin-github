using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisenVaultOutlookPlugin.Data.Entity
{
    public class UploadNodeRootobject
    {
        public UploadNodeEntry entry { get; set; }
        public Error error { get; set; }
    }

    public class UploadNodeEntry
    {
        public bool isFile { get; set; }
        public UserInfo createdByUser { get; set; }
        public DateTime modifiedAt { get; set; }
        public string nodeType { get; set; }
        public Content content { get; set; }
        public string parentId { get; set; }
        public string[] aspectNames { get; set; }
        public DateTime createdAt { get; set; }
        public bool isFolder { get; set; }
        public UserInfo modifiedByUser { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public Properties properties { get; set; }
    }

   

    public class Content
    {
        public string mimeType { get; set; }
        public string mimeTypeName { get; set; }
        public int sizeInBytes { get; set; }
        public string encoding { get; set; }
    }

    

    public class Properties
    {
        public string[] cmaddressees { get; set; }
        public string cmaddressee { get; set; }
        public string cmversionType { get; set; }
        public string cmversionLabel { get; set; }
        public string cmsubjectline { get; set; }
        public string cmauthor { get; set; }
        public string cmoriginator { get; set; }
        public DateTime cmsentdate { get; set; }
        public string cmdescription { get; set; }
    }

}
