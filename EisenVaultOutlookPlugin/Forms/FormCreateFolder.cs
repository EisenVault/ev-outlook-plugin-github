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
    public partial class FormCreateFolder : Form
    {

        private string FolderName
        {
            get { return txtFolderName.Text; }
            set { txtFolderName.Text = value; }
        }

        public FormFolders ParentForm { get; set; }
        private string FolderId { get; set; }
        public string NodeId { get; set; }
        public string Error
        {
            get { return txtError.Text; }
            set { txtError.Text = value; }
        }
        public FormCreateFolder()
        {
            InitializeComponent(); imgLoad.Visible = false;
        }
        public bool IsValid()
        {
            bool result = true;
            if (string.IsNullOrEmpty(FolderName) ||
                string.IsNullOrEmpty(NodeId))
            {
                Error = "Please fill all information and try again!!";
                result = false;
            }           

            return result;

        }
        private async void btnCreate_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                imgLoad.Visible = true;
                btnCreate.Enabled = false;

                Nodes nodes = new Nodes();
                FolderId = await nodes.CreateFolder(NodeId, FolderName);
                if (!string.IsNullOrEmpty(FolderId))
                {
                    if (ParentForm != null)
                    {
                        ParentForm.CreatedFolderId = FolderId;
                        ParentForm.CreatedFolderName = FolderName;
                    }
                    this.Close();
                }
                if (string.IsNullOrEmpty(nodes.Error))
                    Error = "Error when create Folder!!";
                else
                    Error = nodes.Error;
               

                imgLoad.Visible = false;
                btnCreate.Enabled = true;
            }
        }
    }
}
