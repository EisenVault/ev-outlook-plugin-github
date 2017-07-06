using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisenVaultOutlookPlugin.Data.Entity
{
    public class TicketRootobject
    {
        public TicketEntry entry { get; set; }
        public Error error { get; set; }
    }

    public class TicketEntry
    {
        public string id { get; set; }
        public string userId { get; set; }
    }

}
