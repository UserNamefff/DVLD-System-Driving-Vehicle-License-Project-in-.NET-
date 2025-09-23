namespace DVLD_Project
{
    partial class frmTesting
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
            this.ctrlPersonal_Details1 = new DVLD_Project.ctrlPersonal_Details();
            this.SuspendLayout();
            // 
            // ctrlPersonal_Details1
            // 
            this.ctrlPersonal_Details1.Location = new System.Drawing.Point(29, 48);
            this.ctrlPersonal_Details1.Name = "ctrlPersonal_Details1";
            this.ctrlPersonal_Details1.PersonID = 0;
            this.ctrlPersonal_Details1.Size = new System.Drawing.Size(1217, 404);
            this.ctrlPersonal_Details1.TabIndex = 0;
            // 
            // frmTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 529);
            this.Controls.Add(this.ctrlPersonal_Details1);
            this.Name = "frmTesting";
            this.Text = "frmTesting";
            this.Load += new System.EventHandler(this.frmTesting_Load);
            this.ResumeLayout(false);

        }


        #endregion

        private ctrlPersonal_Details ctrlPersonal_Details1;
    }
}