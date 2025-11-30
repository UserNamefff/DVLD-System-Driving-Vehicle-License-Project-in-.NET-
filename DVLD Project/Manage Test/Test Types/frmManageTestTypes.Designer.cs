namespace DVLD_Project.TestTypes
{
    partial class frmManageTestTypes
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
            this.dgTestTypes = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eiteApplicationFeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cbxFilter = new System.Windows.Forms.ComboBox();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.lblNameScreen = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgTestTypes)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            this.SuspendLayout();
            // 
            // dgTestTypes
            // 
            this.dgTestTypes.AllowUserToAddRows = false;
            this.dgTestTypes.AllowUserToDeleteRows = false;
            this.dgTestTypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgTestTypes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgTestTypes.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgTestTypes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgTestTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTestTypes.ContextMenuStrip = this.contextMenuStrip1;
            this.dgTestTypes.Location = new System.Drawing.Point(12, 261);
            this.dgTestTypes.Name = "dgTestTypes";
            this.dgTestTypes.ReadOnly = true;
            this.dgTestTypes.RowHeadersWidth = 51;
            this.dgTestTypes.RowTemplate.Height = 26;
            this.dgTestTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTestTypes.Size = new System.Drawing.Size(711, 276);
            this.dgTestTypes.TabIndex = 109;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationInfoToolStripMenuItem,
            this.eiteApplicationFeesToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(270, 92);
            // 
            // showApplicationInfoToolStripMenuItem
            // 
            this.showApplicationInfoToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.Application_Types_64;
            this.showApplicationInfoToolStripMenuItem.Name = "showApplicationInfoToolStripMenuItem";
            this.showApplicationInfoToolStripMenuItem.Size = new System.Drawing.Size(269, 30);
            this.showApplicationInfoToolStripMenuItem.Text = "Show Test Type Info";
            this.showApplicationInfoToolStripMenuItem.Click += new System.EventHandler(this.showApplicationInfoToolStripMenuItem_Click);
            // 
            // eiteApplicationFeesToolStripMenuItem
            // 
            this.eiteApplicationFeesToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.edit_32;
            this.eiteApplicationFeesToolStripMenuItem.Name = "eiteApplicationFeesToolStripMenuItem";
            this.eiteApplicationFeesToolStripMenuItem.Size = new System.Drawing.Size(269, 30);
            this.eiteApplicationFeesToolStripMenuItem.Text = "Eite Test Type Fees";
            this.eiteApplicationFeesToolStripMenuItem.Click += new System.EventHandler(this.eiteApplicationFeesToolStripMenuItem_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilter.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtFilter.Location = new System.Drawing.Point(272, 221);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(134, 32);
            this.txtFilter.TabIndex = 108;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.Location = new System.Drawing.Point(211, 227);
            this.lblFilter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(54, 21);
            this.lblFilter.TabIndex = 107;
            this.lblFilter.Text = "Filter";
            // 
            // cbxFilter
            // 
            this.cbxFilter.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cbxFilter.FormattingEnabled = true;
            this.cbxFilter.Location = new System.Drawing.Point(12, 221);
            this.cbxFilter.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cbxFilter.Name = "cbxFilter";
            this.cbxFilter.Size = new System.Drawing.Size(190, 32);
            this.cbxFilter.TabIndex = 106;
            // 
            // pictureBox15
            // 
            this.pictureBox15.Image = global::DVLD_Project.Properties.Resources.Applications;
            this.pictureBox15.Location = new System.Drawing.Point(294, 49);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(183, 134);
            this.pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox15.TabIndex = 105;
            this.pictureBox15.TabStop = false;
            // 
            // lblNameScreen
            // 
            this.lblNameScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameScreen.ForeColor = System.Drawing.Color.Red;
            this.lblNameScreen.Location = new System.Drawing.Point(26, 10);
            this.lblNameScreen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNameScreen.Name = "lblNameScreen";
            this.lblNameScreen.Size = new System.Drawing.Size(697, 36);
            this.lblNameScreen.TabIndex = 104;
            this.lblNameScreen.Text = "Manage Test Types";
            this.lblNameScreen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmManageTestTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 547);
            this.Controls.Add(this.dgTestTypes);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.cbxFilter);
            this.Controls.Add(this.pictureBox15);
            this.Controls.Add(this.lblNameScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageTestTypes";
            this.Text = "Manage Test Types";
            this.Load += new System.EventHandler(this.frmManageTestTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgTestTypes)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgTestTypes;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showApplicationInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eiteApplicationFeesToolStripMenuItem;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cbxFilter;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.Label lblNameScreen;
    }
}