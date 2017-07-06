namespace EisenVaultOutlookPlugin
{
    partial class RibbonReadEmail : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RibbonReadEmail()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.btnEV = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.ControlId.OfficeId = "TabReadMessage";
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "TabReadMessage";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.btnEV);
            this.group1.Label = "EisenVault";
            this.group1.Name = "group1";
            // 
            // btnEV
            // 
            this.btnEV.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnEV.Image = global::EisenVaultOutlookPlugin.Properties.Resources.logo2;
            this.btnEV.Label = "Save to DMS";
            this.btnEV.Name = "btnEV";
            this.btnEV.ShowImage = true;
            this.btnEV.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnEV_Click);
            // 
            // RibbonReadEmail
            // 
            this.Name = "RibbonReadEmail";
            this.RibbonType = "Microsoft.Outlook.Mail.Read";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.RibbonReadEmail_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnEV;
    }

    partial class ThisRibbonCollection
    {
        internal RibbonReadEmail RibbonReadEmail
        {
            get { return this.GetRibbon<RibbonReadEmail>(); }
        }
    }
}
