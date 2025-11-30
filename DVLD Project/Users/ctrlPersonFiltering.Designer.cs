namespace DVLD_Project
{
    partial class ctrlPersonFiltering
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
            this.label1 = new System.Windows.Forms.Label();
            this.gbxFiltering = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtbFilterBy = new System.Windows.Forms.TextBox();
            this.cmbxFilterKey = new System.Windows.Forms.ComboBox();
            this.gbxFiltering.SuspendLayout();
            this.SuspendLayout();
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
            // gbxFiltering
            // 
            this.gbxFiltering.Controls.Add(this.btnAdd);
            this.gbxFiltering.Controls.Add(this.btnSearch);
            this.gbxFiltering.Controls.Add(this.txtbFilterBy);
            this.gbxFiltering.Controls.Add(this.cmbxFilterKey);
            this.gbxFiltering.Controls.Add(this.label1);
            this.gbxFiltering.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxFiltering.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gbxFiltering.Location = new System.Drawing.Point(0, 0);
            this.gbxFiltering.Name = "gbxFiltering";
            this.gbxFiltering.Size = new System.Drawing.Size(895, 79);
            this.gbxFiltering.TabIndex = 1;
            this.gbxFiltering.TabStop = false;
            this.gbxFiltering.Text = "Filter";
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Image = global::DVLD_Project.Properties.Resources.Add_Person_40;
            this.btnAdd.Location = new System.Drawing.Point(815, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(58, 48);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::DVLD_Project.Properties.Resources.SearchPerson;
            this.btnSearch.Location = new System.Drawing.Point(751, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(58, 48);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // txtbFilterBy
            // 
            this.txtbFilterBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.txtbFilterBy.Location = new System.Drawing.Point(350, 29);
            this.txtbFilterBy.Name = "txtbFilterBy";
            this.txtbFilterBy.Size = new System.Drawing.Size(255, 26);
            this.txtbFilterBy.TabIndex = 2;
            this.txtbFilterBy.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtbFilterBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbFilterBy_KeyPress);
            // 
            // cmbxFilterKey
            // 
            this.cmbxFilterKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.cmbxFilterKey.FormattingEnabled = true;
            this.cmbxFilterKey.Items.AddRange(new object[] {
            "PersonID",
            "National Number",
            "First Name"});
            this.cmbxFilterKey.Location = new System.Drawing.Point(76, 29);
            this.cmbxFilterKey.Name = "cmbxFilterKey";
            this.cmbxFilterKey.Size = new System.Drawing.Size(255, 28);
            this.cmbxFilterKey.TabIndex = 1;
            this.cmbxFilterKey.SelectedIndexChanged += new System.EventHandler(this.cmbxFilterKey_SelectedIndexChanged);
            // 
            // ctrlPersonFiltering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbxFiltering);
            this.Name = "ctrlPersonFiltering";
            this.Size = new System.Drawing.Size(895, 79);
            this.gbxFiltering.ResumeLayout(false);
            this.gbxFiltering.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbxFiltering;
        private System.Windows.Forms.TextBox txtbFilterBy;
        private System.Windows.Forms.ComboBox cmbxFilterKey;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSearch;
    }
}
