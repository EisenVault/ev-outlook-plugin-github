using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using EisenVaultOutlookPlugin.Data.Modul;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace EisenVaultOutlookPlugin.Helper
{
    public class OutlookMonitor
    {
        public Outlook.MailItem LastEmailItem = null;
        private Outlook.Explorer currentExplorer = null;
        private Outlook.Application Application => Globals.ThisAddIn.Application;

        public OutlookMonitor()
        {
            try
            {
                currentExplorer = Application.ActiveExplorer();
                currentExplorer.SelectionChange += CurrentExplorer_SelectionChange;                
            }
            catch (Exception ex)
            {
                LogClass.WriteException(ex.Message, ex.StackTrace, ex.InnerException == null ? "" : ex.InnerException.Message);
            }
        }

        private void CurrentExplorer_SelectionChange()
        {
            try
            {
                ReleaseEmail();
                if (Application.ActiveExplorer().Selection.Count > 0)
                {
                    var item = Application.ActiveExplorer().Selection[1];
                    if (item is Outlook.MailItem)
                    {
                        LastEmailItem = item;                        
                    }                    
                }
            }
            catch (Exception ex)
            {
                LogClass.WriteException(ex.Message, ex.StackTrace,
                    ex.InnerException == null ? "" : ex.InnerException.Message);
            }
        }

        private void ReleaseEmail()
        {
            if (LastEmailItem != null )
            {
                Marshal.ReleaseComObject(LastEmailItem);
            }
        }
    }
}
