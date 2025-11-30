namespace DVLD_Project
{
    partial class frmManageSchedualTests
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
            this.lblTypeTestName = new System.Windows.Forms.Label();
            this.dgvTests = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRecordsNum = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddAppointment = new System.Windows.Forms.Button();
            this.pbxTestType = new System.Windows.Forms.PictureBox();
            this.ctrlLocalDrivingLicenseApplicationDetails1 = new DVLD_Project.ctrlLocalDrivingLicenseApplicationDetails();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTests)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTestType)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTypeTestName
            // 
            this.lblTypeTestName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeTestName.ForeColor = System.Drawing.Color.Red;
            this.lblTypeTestName.Location = new System.Drawing.Point(7, 97);
            this.lblTypeTestName.Name = "lblTypeTestName";
            this.lblTypeTestName.Size = new System.Drawing.Size(954, 36);
            this.lblTypeTestName.TabIndex = 1;
            this.lblTypeTestName.Text = "Vision Test Appointment";
            this.lblTypeTestName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvTests
            // 
            this.dgvTests.AllowUserToAddRows = false;
            this.dgvTests.AllowUserToDeleteRows = false;
            this.dgvTests.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTests.BackgroundColor = System.Drawing.Color.White;
            this.dgvTests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTests.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvTests.Location = new System.Drawing.Point(22, 611);
            this.dgvTests.Name = "dgvTests";
            this.dgvTests.RowHeadersWidth = 51;
            this.dgvTests.RowTemplate.Height = 26;
            this.dgvTests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTests.Size = new System.Drawing.Size(916, 175);
            this.dgvTests.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editeToolStripMenuItem,
            this.testToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 96);
            // 
            // editeToolStripMenuItem
            // 
            this.editeToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.edit_32;
            this.editeToolStripMenuItem.Name = "editeToolStripMenuItem";
            this.editeToolStripMenuItem.Size = new System.Drawing.Size(136, 46);
            this.editeToolStripMenuItem.Text = "Edite";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.Test_32;
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(136, 46);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 796);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 22);
            this.label2.TabIndex = 8;
            this.label2.Text = "#Records :";
            // 
            // lblRecordsNum
            // 
            this.lblRecordsNum.AutoSize = true;
            this.lblRecordsNum.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsNum.Location = new System.Drawing.Point(111, 796);
            this.lblRecordsNum.Name = "lblRecordsNum";
            this.lblRecordsNum.Size = new System.Drawing.Size(20, 22);
            this.lblRecordsNum.TabIndex = 9;
            this.lblRecordsNum.Text = "#";
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_Project.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(842, 787);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 42);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddAppointment
            // 
            this.btnAddAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAppointment.Image = global::DVLD_Project.Properties.Resources.AddAppointment_32;
            this.btnAddAppointment.Location = new System.Drawing.Point(888, 558);
            this.btnAddAppointment.Name = "btnAddAppointment";
            this.btnAddAppointment.Size = new System.Drawing.Size(51, 47);
            this.btnAddAppointment.TabIndex = 4;
            this.btnAddAppointment.UseVisualStyleBackColor = true;
            this.btnAddAppointment.Click += new System.EventHandler(this.btnAddAppointment_Click);
            // 
            // pbxTestType
            // 
            this.pbxTestType.Image = global::DVLD_Project.Properties.Resources.Vision_512;
            this.pbxTestType.Location = new System.Drawing.Point(404, 3);
            this.pbxTestType.Name = "pbxTestType";
            this.pbxTestType.Size = new System.Drawing.Size(124, 89);
            this.pbxTestType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxTestType.TabIndex = 0;
            this.pbxTestType.TabStop = false;
            // 
            // ctrlLocalDrivingLicenseApplicationDetails1
            // 
            this.ctrlLocalDrivingLicenseApplicationDetails1.Location = new System.Drawing.Point(7, 134);
            this.ctrlLocalDrivingLicenseApplicationDetails1.Name = "ctrlLocalDrivingLicenseApplicationDetails1";
            this.ctrlLocalDrivingLicenseApplicationDetails1.Size = new System.Drawing.Size(939, 418);
            this.ctrlLocalDrivingLicenseApplicationDetails1.TabIndex = 2;
            // 
            // frmManageSchedualTests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 839);
            this.Controls.Add(this.lblRecordsNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddAppointment);
            this.Controls.Add(this.dgvTests);
            this.Controls.Add(this.ctrlLocalDrivingLicenseApplicationDetails1);
            this.Controls.Add(this.lblTypeTestName);
            this.Controls.Add(this.pbxTestType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageSchedualTests";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vision Test";
            this.Load += new System.EventHandler(this.frmVisionTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTests)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxTestType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxTestType;
        private System.Windows.Forms.Label lblTypeTestName;
        private ctrlLocalDrivingLicenseApplicationDetails ctrlLocalDrivingLicenseApplicationDetails1;
        private System.Windows.Forms.DataGridView dgvTests;
        private System.Windows.Forms.Button btnAddAppointment;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRecordsNum;
    }
}