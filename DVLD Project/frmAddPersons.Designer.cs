namespace DVLD_Project
{
    partial class frmAddPersons
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
            this.label6 = new System.Windows.Forms.Label();
            this.lblNameScreen = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.crtlAddPerson1 = new DVLD_Project.crtlAddPerson();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(21, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Person ID";
            // 
            // lblNameScreen
            // 
            this.lblNameScreen.AutoSize = true;
            this.lblNameScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblNameScreen.ForeColor = System.Drawing.Color.Red;
            this.lblNameScreen.Location = new System.Drawing.Point(493, 9);
            this.lblNameScreen.Name = "lblNameScreen";
            this.lblNameScreen.Size = new System.Drawing.Size(255, 36);
            this.lblNameScreen.TabIndex = 12;
            this.lblNameScreen.Text = "Add New Person";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblID.Location = new System.Drawing.Point(133, 54);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(28, 20);
            this.lblID.TabIndex = 13;
            this.lblID.Text = "ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(275, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "N/A";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(219, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 35);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // crtlAddPerson1
            // 
            this.crtlAddPerson1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crtlAddPerson1.Location = new System.Drawing.Point(24, 86);
            this.crtlAddPerson1.Name = "crtlAddPerson1";
            this.crtlAddPerson1.Size = new System.Drawing.Size(1189, 417);
            this.crtlAddPerson1.TabIndex = 11;
            // 
            // frmAddPersons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 523);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblNameScreen);
            this.Controls.Add(this.crtlAddPerson1);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddPersons";
            this.Text = "Add New Person";
            this.Load += new System.EventHandler(this.frmAddPersons_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private crtlAddPerson crtlAddPerson1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblNameScreen;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}