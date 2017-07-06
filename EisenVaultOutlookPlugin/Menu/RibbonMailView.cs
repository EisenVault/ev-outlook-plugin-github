using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EisenVaultOutlookPlugin.Data.Modul;
using EisenVaultOutlookPlugin.Forms;
using EisenVaultOutlookPlugin.Helper;
using Microsoft.Office.Tools.Ribbon;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace EisenVaultOutlookPlugin
{
    public partial class RibbonMailView
    {
        private void RibbonMailView_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private async void btnEV_Click(object sender, RibbonControlEventArgs e)
        {
            Option.Read();           
            var info = Option.GetUserInfo();
            if (info == null)
            {
                FormLogin frm = new FormLogin();
                frm.ShowDialog(ThisAddIn.OwnerWindow);
            }
            info = Option.GetUserInfo();
            if (info != null)
            {
                var item = Globals.ThisAddIn.Monitor.LastEmailItem;
                if (item != null)
                {
                    MenuController controller = new MenuController();
                    controller.Process(item);                   
                }
            }
        }
    }
}
