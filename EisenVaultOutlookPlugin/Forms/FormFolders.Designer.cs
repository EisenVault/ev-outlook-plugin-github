namespace EisenVaultOutlookPlugin.Forms
{
    partial class FormFolders
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFolders));
            this.label1 = new System.Windows.Forms.Label();
            this.treeViewNodes = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnUpload = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lnkLogOut = new System.Windows.Forms.LinkLabel();
            this.txtLoggedName = new System.Windows.Forms.Label();
            this.imgLoad = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCreate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.label1.Location = new System.Drawing.Point(77, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(369, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Browse Repositories and Select a Folder to Save Email In";
            // 
            // treeViewNodes
            // 
            this.treeViewNodes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.treeViewNodes.ImageIndex = 0;
            this.treeViewNodes.ImageList = this.imageList1;
            this.treeViewNodes.Location = new System.Drawing.Point(21, 69);
            this.treeViewNodes.Name = "treeViewNodes";
            this.treeViewNodes.SelectedImageIndex = 0;
            this.treeViewNodes.ShowLines = false;
            this.treeViewNodes.Size = new System.Drawing.Size(528, 409);
            this.treeViewNodes.TabIndex = 12;
            this.treeViewNodes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewNodes_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Close-Folder-icon.png");
            this.imageList1.Images.SetKeyName(1, "Opened-Folder-icon.png");
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.Coral;
            this.btnUpload.FlatAppearance.BorderSize = 0;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpload.Location = new System.Drawing.Point(169, 484);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(233, 40);
            this.btnUpload.TabIndex = 13;
            this.btnUpload.Text = "Save to Selected Folder";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(77, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "EisenVault";
            // 
            // lnkLogOut
            // 
            this.lnkLogOut.AutoSize = true;
            this.lnkLogOut.Location = new System.Drawing.Point(493, 13);
            this.lnkLogOut.Name = "lnkLogOut";
            this.lnkLogOut.Size = new System.Drawing.Size(46, 13);
            this.lnkLogOut.TabIndex = 16;
            this.lnkLogOut.TabStop = true;
            this.lnkLogOut.Text = "(Logout)";
            this.lnkLogOut.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLogOut_LinkClicked);
            // 
            // txtLoggedName
            // 
            this.txtLoggedName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLoggedName.ForeColor = System.Drawing.Color.Red;
            this.txtLoggedName.Location = new System.Drawing.Point(216, 8);
            this.txtLoggedName.Name = "txtLoggedName";
            this.txtLoggedName.Size = new System.Drawing.Size(272, 23);
            this.txtLoggedName.TabIndex = 17;
            this.txtLoggedName.Text = "Logged in as ";
            this.txtLoggedName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // imgLoad
            // 
            this.imgLoad.Image = global::EisenVaultOutlookPlugin.Properties.Resources.loading;
            this.imgLoad.Location = new System.Drawing.Point(408, 484);
            this.imgLoad.Name = "imgLoad";
            this.imgLoad.Size = new System.Drawing.Size(60, 40);
            this.imgLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgLoad.TabIndex = 15;
            this.imgLoad.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EisenVaultOutlookPlugin.Properties.Resources.logo2;
            this.pictureBox1.Location = new System.Drawing.Point(21, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.Coral;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCreate.Location = new System.Drawing.Point(464, 43);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(85, 23);
            this.btnCreate.TabIndex = 18;
            this.btnCreate.Text = "Create Folder";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // FormFolders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(584, 531);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txtLoggedName);
            this.Controls.Add(this.lnkLogOut);
            this.Controls.Add(this.imgLoad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.treeViewNodes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFolders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Folders";
            this.Load += new System.EventHandler(this.FormFolders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeViewNodes;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox imgLoad;
        private System.Windows.Forms.LinkLabel lnkLogOut;
        private System.Windows.Forms.Label txtLoggedName;
        private System.Windows.Forms.Button btnCreate;
    }
}