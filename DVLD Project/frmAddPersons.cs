using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BusinessLayer;

namespace DVLD_Project
{
    public partial class frmAddPersons : Form
    {
        public frmAddPersons()
        {
            InitializeComponent();
        }

        private void crtlAddPerson1_Load(object sender, EventArgs e)
        {
            
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblPersonID = new System.Windows.Forms.Label();
            this.crtlAddPerson1 = new DVLD_Project.crtlAddPerson();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(495, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(255, 36);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Add New Person";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbl.Location = new System.Drawing.Point(14, 65);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(89, 20);
            this.lbl.TabIndex = 2;
            this.lbl.Text = "Perosn ID ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Project.Properties.Resources.Person_321;
            this.pictureBox1.Location = new System.Drawing.Point(109, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lblPersonID
            // 
            this.lblPersonID.AutoSize = true;
            this.lblPersonID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPersonID.Location = new System.Drawing.Point(155, 62);
            this.lblPersonID.Name = "lblPersonID";
            this.lblPersonID.Size = new System.Drawing.Size(37, 20);
            this.lblPersonID.TabIndex = 4;
            this.lblPersonID.Text = "N/A";
            // 
            // crtlAddPerson1
            // 
            this.crtlAddPerson1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crtlAddPerson1.Location = new System.Drawing.Point(17, 87);
            this.crtlAddPerson1.Name = "crtlAddPerson1";
            this.crtlAddPerson1.Size = new System.Drawing.Size(1196, 399);
            this.crtlAddPerson1.TabIndex = 0;
            this.crtlAddPerson1.Load += new System.EventHandler(this.crtlAddPerson1_Load);
            // 
            // frmAddPersons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 523);
            this.Controls.Add(this.lblPersonID);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.crtlAddPerson1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddPersons";
            this.Text = "Add/Edite Person";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
    }
}
