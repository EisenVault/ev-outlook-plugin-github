using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EisenVaultOutlookPlugin.Data.Modul;
using EisenVaultOutlookPlugin.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
namespace EisenVaultOutlookPlugin.Helper
{
    public class MenuController
    {
        public void Process(Outlook.MailItem item)
        {
            try
            {
                FormFolders frm = new FormFolders()
                {
                    EmailItem = item
                };
                frm.ShowDialog(ThisAddIn.OwnerWindow);
                if (!frm.IsDisposed)
                {
                    if (frm.ShowLogin)
                    {
                        frm.Close();
                        //frm.ShowLogin = false;
                        FormLogin frmLogin = new FormLogin();
                        frmLogin.ShowDialog(ThisAddIn.OwnerWindow);
                        var info = Option.GetUserInfo();
                        if (info != null)
                        {
                            Process(item);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                LogClass.WriteException(ex.Message, ex.StackTrace,
                    ex.InnerException == null ? "" : ex.InnerException.Message);
            }
        }
    }
}
