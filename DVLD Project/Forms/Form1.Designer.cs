namespace DVLD_Project
{
    partial class frmPersonDetails
    {

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPersonDetails));
            this.lblNameScreen = new System.Windows.Forms.Label();
            this.ctrlPersonal_Details1 = new DVLD_Project.ctrlPersonal_Details();
            this.SuspendLayout();
            // 
            // lblNameScreen
            // 
            resources.ApplyResources(this.lblNameScreen, "lblNameScreen");
            this.lblNameScreen.ForeColor = System.Drawing.Color.Red;
            this.lblNameScreen.Name = "lblNameScreen";
            // 
            // ctrlPersonal_Details1
            // 
            resources.ApplyResources(this.ctrlPersonal_Details1, "ctrlPersonal_Details1");
            this.ctrlPersonal_Details1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlPersonal_Details1.Name = "ctrlPersonal_Details1";
            this.ctrlPersonal_Details1.Load += new System.EventHandler(this.ctrlPersonal_Details1_Load);
            // 
            // frmPersonDetails
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.ctrlPersonal_Details1);
            this.Controls.Add(this.lblNameScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPersonDetails";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNameScreen;
        private ctrlPersonal_Details ctrlPersonal_Details1;
    }
}

