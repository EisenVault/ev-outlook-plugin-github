using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EisenVaultOutlookPlugin.Data.Modul;
using EisenVaultOutlookPlugin.Forms;
using EisenVaultOutlookPlugin.Helper;
using Microsoft.Office.Tools.Ribbon;
using Outlook = Microsoft.Office.Interop.Outlook;
namespace EisenVaultOutlookPlugin
{
    public partial class RibbonReadEmail
    {
        private void RibbonReadEmail_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btnEV_Click(object sender, RibbonControlEventArgs e)
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
                Outlook.Inspector currentInspector = this.Context as Outlook.Inspector;
                if (currentInspector?.CurrentItem is Outlook.MailItem)
                {
                    MenuController controller = new MenuController();
                    controller.Process(currentInspector.CurrentItem);
                }
            }
        }
    }
}
