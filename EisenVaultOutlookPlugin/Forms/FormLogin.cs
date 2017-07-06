using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EisenVaultOutlookPlugin.Data.Modul;

namespace EisenVaultOutlookPlugin.Forms
{
    public partial class FormLogin : Form
    {
        public string Username
        {
            get { return txtUsername.Text; }
            set { txtUsername.Text = value; }
        }
        public string Password
        {
            get { return txtPassword.Text; }
            set { txtPassword.Text = value; }
        }
        public string Server
        {
            get { return txtServer.Text; }
            set { txtServer.Text = value; }
        }
        public string Error
        {
            get { return txtError.Text; }
            set { txtError.Text = value; }
        }

        public bool IsValid()
        {
            bool result = true;
            if (string.IsNullOrEmpty(Username) ||
                string.IsNullOrEmpty(Password) ||
                string.IsNullOrEmpty(Server)
            )
            {
                Error = "Please fill all information and try again!!";
                result = false;
            }


            if (Uri.IsWellFormedUriString(Server, UriKind.RelativeOrAbsolute)==false)
            {
                Error = "Please add a correct url!!";
                result = false;
            }


            return result;

        }

        public FormLogin()
        {
            InitializeComponent();
            imgLoad.Visible = false;

            var info = Globals.ThisAddIn.TempUserInfo;
            if (info != null)
            {
                Username = info.UserName;
                Password = info.Password;
                Server = info.Server;
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                imgLoad.Visible = true;
                btnLogin.Enabled = false;
                if (!Server.EndsWith("/"))
                    Server= Server+"/";
                Account account = new Account();
                if (await account.Loign(Server, Username, Password))
                {
                    Option.Read();
                    Globals.ThisAddIn.TempUserInfo = null;
                    this.Close();
                }
                else
                {
                    if(string.IsNullOrEmpty(account.Error))
                        Error = "Incorrect username or password!!";
                    else 
                    Error = account.Error;
                }

                imgLoad.Visible = false;
                btnLogin.Enabled = true;
            }
        }
    }
}
