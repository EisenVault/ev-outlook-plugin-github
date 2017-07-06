using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using EisenVaultOutlookPlugin.Data.Entity;
using EisenVaultOutlookPlugin.Data.Modul;
using EisenVaultOutlookPlugin.Forms;
using EisenVaultOutlookPlugin.Helper;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace EisenVaultOutlookPlugin
{
    public partial class ThisAddIn
    {
        public PluginUserInfo TempUserInfo { get; set; }
        public static IWin32Window OwnerWindow
        {
            get { return new OfficeWin32Window(Globals.ThisAddIn.Application.ActiveWindow()); }
        }

        public OutlookMonitor Monitor { get; set; }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Option.Read();
            Monitor = new OutlookMonitor();
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see http://go.microsoft.com/fwlink/?LinkId=506785
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
