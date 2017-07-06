using EisenVaultOutlookPlugin.Data.Modul;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EisenVaultOutlookPlugin.Data.Entity;
using EisenVaultOutlookPlugin.Helper;
using EisenVaultOutlookPlugin.Properties;

namespace EisenVaultOutlookPlugin.Forms
{
    public partial class FormFolders : Form
    {
        public Microsoft.Office.Interop.Outlook.MailItem EmailItem = null;
        public bool ShowLogin { get; set; }

        public string Username
        {
            get { return txtLoggedName.Text; }
            set { txtLoggedName.Text = value; }
        }
        public string CreatedFolderId { get; set; }
        public string CreatedFolderName { get; set; }

        public FormFolders()
        {
            InitializeComponent();
            imgLoad.Visible = false;

            var info = Option.GetUserInfo();
            Username = $"Logged in as {info?.UserName}";
        }

        private async void FormFolders_Load(object sender, EventArgs e)
        {
            Nodes nodes = new Nodes();
            imgLoad.Visible = true;
            btnUpload.Enabled = false;
            var list = await nodes.Get();
            List<string> acceptFolders = new List<string>()
            {
                "shared","sites","user homes"
            };
            foreach (NodeEntry entry in list.Where(c=> acceptFolders.Any(x=> x.Contains(c.name.ToLower()))))
            {
                if (entry.isFolder)
                {
                    var node = treeViewNodes.Nodes.Add(entry.id, entry.name);                    
                    node.Tag = new NodeTag()
                    {
                      Id  = entry.id,
                      IsFolder = entry.isFolder,
                      IsLoaded = false
                    };
                }
            }
            imgLoad.Visible = false;
            btnUpload.Enabled = true;
        }
       

        private async void treeViewNodes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode tNode = e.Node;
            bool isSiteNode = tNode?.Parent == null && tNode?.Text?.ToLower() == "sites";
            bool isSiteChild = tNode?.Parent != null && tNode?.Parent?.Text?.ToLower() == "sites";


            var tagInfo = e.Node.Tag as NodeTag;
            if (tagInfo !=null &&
                tagInfo.IsFolder &&
                tagInfo.IsLoaded==false
                )
            {
                Nodes nodes = new Nodes();
                imgLoad.Visible = true;
                btnUpload.Enabled = false;
                var list =await nodes.Get(tagInfo.Id);                
                foreach (NodeEntry entry in list)
                {
                    if (isSiteChild && entry.name.ToLower() != "documentlibrary")
                    {
                        continue;
                    }
                    e.Node.ImageIndex = e.Node.StateImageIndex = e.Node.SelectedImageIndex = 1;
                    
                    if (entry.isFolder)
                    {
                        var node = e.Node.Nodes.Add(entry.id, entry.name);
                        node.Tag = new NodeTag()
                        {
                            Id = entry.id,
                            IsFolder = entry.isFolder,
                            IsLoaded = false
                        };
                    }
                }
                e.Node.Expand();
                tagInfo.IsLoaded = true;

                imgLoad.Visible = false;
                btnUpload.Enabled = true;              
            }
            if (isSiteNode || isSiteChild)
            {
                if (tNode.Nodes.Count > 0)
                {
                    treeViewNodes.SelectedNode = tNode.Nodes[0];
                }
            }

        }


        class NodeTag
        {
            public bool IsLoaded { get; set; }
            public string Id { get; set; }
            public bool IsFolder { get; set; }
        }

        private async void btnUpload_Click(object sender, EventArgs e)
        {
            TreeNode node = treeViewNodes?.SelectedNode;            
            NodeTag tag = node?.Tag as NodeTag;            
            if (tag != null)
            {
                imgLoad.Visible = true; btnUpload.Enabled = false;
                Controller controller= new Controller();
                int? folderCount =  node?.Nodes?.Count;
                bool isUploaded = await controller.UploadEmail(EmailItem, tag.Id, folderCount);
                if (isUploaded)
                {
                    MessageBox.Show("File(s) uploaded successfully");
                    this.Close();
                }
                else
                {
                    if (string.IsNullOrEmpty(controller.Error))
                        MessageBox.Show("Error while uploading file, Please try again!!");
                    else
                        MessageBox.Show(controller.Error);
                }
            }
            imgLoad.Visible = false ; btnUpload.Enabled = true;

        }

        private void lnkLogOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Globals.ThisAddIn.TempUserInfo = Option.GetUserInfo();
            Option.Clear();
            ShowLogin = true;
            this.Hide();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            TreeNode node = treeViewNodes?.SelectedNode;
            bool isSiteNode = node?.Parent == null && node?.Text?.ToLower() == "sites";
            bool isSiteChild = node?.Parent != null && node?.Parent?.Text?.ToLower() == "sites";

            if (isSiteNode || isSiteChild)
                return;

            CreatedFolderId = "";            
            if (node != null)
            {
                FormCreateFolder frm = new FormCreateFolder()
                {
                    NodeId = (node.Tag as NodeTag).Id,
                    ParentForm = this
                };
                frm.ShowDialog(ThisAddIn.OwnerWindow);
                if (string.IsNullOrEmpty(CreatedFolderId) == false)
                {
                    node = node.Nodes.Add(CreatedFolderId, CreatedFolderName);
                    node.Tag = new NodeTag()
                    {
                        Id = CreatedFolderId,
                        IsFolder = true,
                        IsLoaded = false
                    };
                    treeViewNodes.SelectedNode = node;
                    node.TreeView.Focus();
                }
                                
            }

        }
    }
}
