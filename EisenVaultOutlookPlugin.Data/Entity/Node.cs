using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisenVaultOutlookPlugin.Data.Entity
{
    public class NodeRootobject
    {
        public NodeList list { get; set; }
        public Error error { get; set; }
    }

    public class NodeList
    {
        public Pagination pagination { get; set; }
        public NodeEntryObj[] entries { get; set; }
    }

    public class NodeEntryObj
    {
        public NodeEntry entry { get; set; }
    }

    public class NodeEntry
    {
        public string[] aspectNames { get; set; }
        public DateTime createdAt { get; set; }
        public bool isFolder { get; set; }
        public bool isFile { get; set; }
        public UserInfo createdByUser { get; set; }
        public DateTime modifiedAt { get; set; }
        public UserInfo modifiedByUser { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public string nodeType { get; set; }
        public string parentId { get; set; }
    }
 
}

