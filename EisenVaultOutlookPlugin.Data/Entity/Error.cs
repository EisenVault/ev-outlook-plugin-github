using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisenVaultOutlookPlugin.Data.Entity
{
    public class Error
    {
        public string errorKey { get; set; }
        public int statusCode { get; set; }
        public string briefSummary { get; set; }
        public string stackTrace { get; set; }
        public string descriptionURL { get; set; }
    }
}
