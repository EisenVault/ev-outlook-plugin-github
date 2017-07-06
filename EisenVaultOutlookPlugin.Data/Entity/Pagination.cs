using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisenVaultOutlookPlugin.Data.Entity
{
    public class Pagination
    {
        public int count { get; set; }
        public bool hasMoreItems { get; set; }
        public int totalItems { get; set; }
        public int skipCount { get; set; }
        public int maxItems { get; set; }
    }
}
