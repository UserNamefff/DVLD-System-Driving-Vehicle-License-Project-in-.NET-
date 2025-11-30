namespace DVLD_Project
{
    partial class ctrlAssignPersonToUser
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbxFiltering = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtbFilterBy = new System.Windows.Forms.TextBox();
            this.cmbxFilterKey = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlPersonal_Details1 = new DVLD_Project.ctrlPersonal_Details();
            this.gbxFiltering.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxFiltering
            // 
            this.gbxFiltering.Controls.Add(this.btnAdd);
            this.gbxFiltering.Controls.Add(this.btnSearch);
            this.gbxFiltering.Controls.Add(this.txtbFilterBy);
            this.gbxFiltering.Controls.Add(this.cmbxFilterKey);
            this.gbxFiltering.Controls.Add(this.label1);
            this.gbxFiltering.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gbxFiltering.Location = new System.Drawing.Point(3, 3);
            this.gbxFiltering.Name = "gbxFiltering";
            this.gbxFiltering.Size = new System.Drawing.Size(1068, 79);
            this.gbxFiltering.TabIndex = 2;
            this.gbxFiltering.TabStop = false;
            this.gbxFiltering.Text = "Filter";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Control;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Image = global::DVLD_Project.Properties.Resources.AddPerson_32;
            this.btnAdd.Location = new System.Drawing.Point(697, 18);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(57, 48);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.AutoEllipsis = true;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::DVLD_Project.Properties.Resources.SearchPerson;
            this.btnSearch.Location = new System.Drawing.Point(634, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(57, 48);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtbFilterBy
            // 
            this.txtbFilterBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.txtbFilterBy.Location = new System.Drawing.Point(337, 30);
            this.txtbFilterBy.Name = "txtbFilterBy";
            this.txtbFilterBy.Size = new System.Drawing.Size(255, 26);
            this.txtbFilterBy.TabIndex = 2;
            this.txtbFilterBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbFilterBy_KeyPress);
            this.txtbFilterBy.Validating += new System.ComponentModel.CancelEventHandler(this.txtbFilterBy_Validating);
            // 
            // cmbxFilterKey
            // 
            this.cmbxFilterKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxFilterKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.cmbxFilterKey.FormattingEnabled = true;
            this.cmbxFilterKey.Items.AddRange(new object[] {
            "_Person ID",
            "National Number"});
            this.cmbxFilterKey.Location = new System.Drawing.Point(76, 29);
            this.cmbxFilterKey.Name = "cmbxFilterKey";
            this.cmbxFilterKey.Size = new System.Drawing.Size(255, 28);
            this.cmbxFilterKey.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find By";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlPersonal_Details1
            // 
            this.ctrlPersonal_Details1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ctrlPersonal_Details1.Location = new System.Drawing.Point(3, 88);
            this.ctrlPersonal_Details1.Name = "ctrlPersonal_Details1";
            this.ctrlPersonal_Details1.Size = new System.Drawing.Size(1068, 324);
            this.ctrlPersonal_Details1.TabIndex = 0;
            // 
            // ctrlAssignPersonToUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.gbxFiltering);
            this.Controls.Add(this.ctrlPersonal_Details1);
            this.Name = "ctrlAssignPersonToUser";
            this.Size = new System.Drawing.Size(1082, 415);
            this.Load += new System.EventHandler(this.ctrlAssignPersonToUser_Load);
            this.gbxFiltering.ResumeLayout(false);
            this.gbxFiltering.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }



        #endregion

        private ctrlPersonal_Details ctrlPersonal_Details1;
        private System.Windows.Forms.GroupBox gbxFiltering;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtbFilterBy;
        private System.Windows.Forms.ComboBox cmbxFilterKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnAdd;
    }
}
