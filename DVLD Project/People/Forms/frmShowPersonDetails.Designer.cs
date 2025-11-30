namespace DVLD_Project
{
    partial class frmShowPersonDetails
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
            this.lblNameScreen = new System.Windows.Forms.Label();
            this.ctrlPersonal_Details1 = new DVLD_Project.ctrlPersonal_Details();
            this.SuspendLayout();
            // 
            // lblNameScreen
            // 
            this.lblNameScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblNameScreen.ForeColor = System.Drawing.Color.Red;
            this.lblNameScreen.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNameScreen.Location = new System.Drawing.Point(8, 4);
            this.lblNameScreen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNameScreen.Name = "lblNameScreen";
            this.lblNameScreen.Size = new System.Drawing.Size(1065, 36);
            this.lblNameScreen.TabIndex = 5;
            this.lblNameScreen.Text = " _Person Details";
            this.lblNameScreen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlPersonal_Details1
            // 
            this.ctrlPersonal_Details1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlPersonal_Details1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlPersonal_Details1.Location = new System.Drawing.Point(8, 47);
            this.ctrlPersonal_Details1.Name = "ctrlPersonal_Details1";
           
            this.ctrlPersonal_Details1.Size = new System.Drawing.Size(1061, 315);
            this.ctrlPersonal_Details1.TabIndex = 0;
            // 
            // frmShowPersonDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 370);
            this.Controls.Add(this.lblNameScreen);
            this.Controls.Add(this.ctrlPersonal_Details1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmShowPersonDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmShowPersonDetails";
            this.Load += new System.EventHandler(this.frmShowPersonDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersonal_Details ctrlPersonal_Details1;
        private System.Windows.Forms.Label lblNameScreen;
    }
}