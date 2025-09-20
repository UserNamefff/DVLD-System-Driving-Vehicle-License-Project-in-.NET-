namespace DVLD_Project
{
    partial class ManagePeople
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnAddPerson = new Guna.UI.WinForms.GunaButton();
            this.gunaButton1 = new Guna.UI.WinForms.GunaButton();
            this.lbllkShowInfo = new System.Windows.Forms.LinkLabel();
            this.lblNameScreen = new System.Windows.Forms.Label();
            this.dgvPeopleInfo = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeopleInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.lblFilter);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.btnAddPerson);
            this.panel1.Controls.Add(this.gunaButton1);
            this.panel1.Controls.Add(this.lbllkShowInfo);
            this.panel1.Controls.Add(this.lblNameScreen);
            this.panel1.Controls.Add(this.dgvPeopleInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1226, 677);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.Location = new System.Drawing.Point(281, 224);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(54, 21);
            this.lblFilter.TabIndex = 9;
            this.lblFilter.Text = "Filter";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(30, 218);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(245, 32);
            this.comboBox1.TabIndex = 8;
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.AnimationHoverSpeed = 0.07F;
            this.btnAddPerson.AnimationSpeed = 0.03F;
            this.btnAddPerson.BackColor = System.Drawing.Color.Transparent;
            this.btnAddPerson.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btnAddPerson.BorderColor = System.Drawing.Color.Black;
            this.btnAddPerson.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAddPerson.FocusedColor = System.Drawing.Color.Empty;
            this.btnAddPerson.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddPerson.ForeColor = System.Drawing.Color.White;
            this.btnAddPerson.Image = null;
            this.btnAddPerson.ImageSize = new System.Drawing.Size(20, 20);
            this.btnAddPerson.Location = new System.Drawing.Point(1117, 208);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnAddPerson.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnAddPerson.OnHoverForeColor = System.Drawing.Color.White;
            this.btnAddPerson.OnHoverImage = null;
            this.btnAddPerson.OnPressedColor = System.Drawing.Color.Black;
            this.btnAddPerson.Radius = 10;
            this.btnAddPerson.Size = new System.Drawing.Size(82, 42);
            this.btnAddPerson.TabIndex = 7;
            this.btnAddPerson.Text = "Add";
            this.btnAddPerson.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gunaButton1
            // 
            this.gunaButton1.AnimationHoverSpeed = 0.07F;
            this.gunaButton1.AnimationSpeed = 0.03F;
            this.gunaButton1.BackColor = System.Drawing.Color.Transparent;
            this.gunaButton1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gunaButton1.BorderColor = System.Drawing.Color.Black;
            this.gunaButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaButton1.ForeColor = System.Drawing.Color.White;
            this.gunaButton1.Image = null;
            this.gunaButton1.ImageSize = new System.Drawing.Size(20, 20);
            this.gunaButton1.Location = new System.Drawing.Point(1137, 636);
            this.gunaButton1.Name = "gunaButton1";
            this.gunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.gunaButton1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaButton1.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaButton1.OnHoverImage = null;
            this.gunaButton1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaButton1.Radius = 10;
            this.gunaButton1.Size = new System.Drawing.Size(65, 29);
            this.gunaButton1.TabIndex = 6;
            this.gunaButton1.Text = "Close";
            this.gunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbllkShowInfo
            // 
            this.lbllkShowInfo.AutoSize = true;
            this.lbllkShowInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lbllkShowInfo.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbllkShowInfo.Location = new System.Drawing.Point(26, 636);
            this.lbllkShowInfo.Name = "lbllkShowInfo";
            this.lbllkShowInfo.Size = new System.Drawing.Size(102, 24);
            this.lbllkShowInfo.TabIndex = 3;
            this.lbllkShowInfo.TabStop = true;
            this.lbllkShowInfo.Text = "Show Info";
            this.lbllkShowInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbllkShowInfo_LinkClicked);
            // 
            // lblNameScreen
            // 
            this.lblNameScreen.AutoSize = true;
            this.lblNameScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameScreen.ForeColor = System.Drawing.Color.Red;
            this.lblNameScreen.Location = new System.Drawing.Point(491, 9);
            this.lblNameScreen.Name = "lblNameScreen";
            this.lblNameScreen.Size = new System.Drawing.Size(236, 36);
            this.lblNameScreen.TabIndex = 2;
            this.lblNameScreen.Text = "Manage People";
            // 
            // dgvPeopleInfo
            // 
            this.dgvPeopleInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeopleInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvPeopleInfo.Location = new System.Drawing.Point(30, 259);
            this.dgvPeopleInfo.Name = "dgvPeopleInfo";
            this.dgvPeopleInfo.RowHeadersWidth = 51;
            this.dgvPeopleInfo.RowTemplate.Height = 26;
            this.dgvPeopleInfo.Size = new System.Drawing.Size(1169, 362);
            this.dgvPeopleInfo.TabIndex = 1;
            // 
            // ManagePeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 677);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ManagePeople";
            this.Text = "ManagePeople";
            this.Load += new System.EventHandler(this.ManagePeople_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeopleInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel lbllkShowInfo;
        private System.Windows.Forms.Label lblNameScreen;
        private System.Windows.Forms.DataGridView dgvPeopleInfo;
        private Guna.UI.WinForms.GunaButton gunaButton1;
        private System.Windows.Forms.ComboBox comboBox1;
        private Guna.UI.WinForms.GunaButton btnAddPerson;
        private System.Windows.Forms.Label lblFilter;
    }
}