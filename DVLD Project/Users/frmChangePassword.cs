using DVLD_BusinessLayer;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_Project
{
    public partial class frmChangePassword : Form
    {
        clsUsers User;
        public int _UserID;

        public  delegate void Refresh();
        public Refresh RefreshTable;

        public int UserID
        {
            get { return _UserID; }
        }
        public frmChangePassword()
        {
            InitializeComponent();
        }
        
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            
            this._UserID = UserID;

        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            ctrlShowUserInfo11.GetUserInf(1/*this._UserID*/);
            User = ctrlShowUserInfo11.User;
            
        }


        // التحقق من TextBox الأول - نستخدم Validating
        public bool ValidateOldPasssword()
        {
            bool isValid = txtOldPassword.Text == User.Password;
            //txtOldPassword.Focus();
            errorProvider1.SetError(txtOldPassword, isValid ? "" : "القيمة غير متطابقة مع قاعدة البيانات");
            return isValid;
        }

        // التحقق من TextBox الثاني - نستخدم TextChanged للتحقق الفوري
        public bool ValidateNewPassword()
        {
            bool isValid = txtNewPassword.Text.Length >= 4;
            
            errorProvider2.SetError(txtNewPassword, isValid ? "" : "يجب إدخال 4 أحرف على الأقل");
            return isValid;
        }

        // التحقق من TextBox الثالث - نستخدم TextChanged للتحقق الفوري
        public bool ValidateConfirmPassword()
        {
            bool isValid = txtConfirmPassword.Text == txtNewPassword.Text && !string.IsNullOrEmpty(txtOldPassword.Text);
           // txtConfirmPassword.Focus();
            errorProvider3.SetError(txtConfirmPassword, isValid ? "" : "القيمة غير متطابقة مع الحقل الثاني");
            return isValid;
        }

        // التحقق النهائي لكل الحقول
        public bool IsFormValid()
        {
            return ValidateOldPasssword() &&
                    ValidateConfirmPassword() &&
                    ValidateNewPassword();
        }


        private void FocuseUserInput()
        {
            txtConfirmPassword.Focus();
            txtNewPassword.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            if(IsFormValid())
            {
                User.Password = txtNewPassword.Text;

                if (User.Save())
                {
                    RefreshTable?.Invoke();
                    MessageBox.Show("Edited _User Password Successfully ...","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(" Occure error while edite user password ...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Ensure Confirm Password ...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }



        private void Clear()
        {
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();
            txtOldPassword.Clear();
           
        }
            
        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {

            User = ctrlShowUserInfo11.User;
            
            if (User != null)
            {
                ValidateNewPassword();
            }

        }

        private void txtOldPassword_Validating(object sender, CancelEventArgs e)
        {
            clsUsers User = ctrlShowUserInfo11.User;
            if (User != null)
            {
                ValidateOldPasssword();

            }


        
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            ValidateConfirmPassword();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtOldPassword_TextChanged(object sender, EventArgs e)
        {
            ValidateOldPasssword();
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            ValidateNewPassword();
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            ValidateConfirmPassword();
        }



    }
}






