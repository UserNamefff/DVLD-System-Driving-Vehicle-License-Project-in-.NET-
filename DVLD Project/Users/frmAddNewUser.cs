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
using static DVLD_Project.frmChangePassword;

namespace DVLD_Project
{
    public partial class frmAddNewUser : Form
    {
        private int _PerosnID;
        private clsUsers _User;

        public delegate void _Refresh();
        public event _Refresh Refresh;

        enum enMode { eAdd,eUpdate}
        enMode _eMode ;

        public frmAddNewUser()
        {
            InitializeComponent();
            //btnUpdateUserInfo.Enabled = false;
            //btnUpdateUserInfo.Visible = false;
            _eMode = enMode.eAdd;
            _User = clsUsers.AddNewUser();
            ctrlAssignPersonToUser1.FilterEnable = true;
        }
        public frmAddNewUser(int PersonID)
        {
            InitializeComponent();


            _PerosnID = PersonID;
            _eMode = enMode.eUpdate;
            InitialToEditeUserInfo();
            
        }

        private void InitialToEditeUserInfo()
        {
            
            ctrlAssignPersonToUser1.LoadPersonInfo(_PerosnID);
            ctrlAssignPersonToUser1.FilterEnable = false;

            _User = clsUsers.FindByPersonID(_PerosnID);

            if (_User == null)
            {
                MessageBox.Show("No _User with ID = " + _User, "_User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            btnSave.Visible = false;
            _eMode = enMode.eUpdate;
            _FillUserInfoToEdite();

            //btnNext.Visible = false;
            //btnUpdateUserInfo.Visible = true;

        }

        private void _FillUserInfoToEdite()
        {
            lblUserID.Text = _User.UserID.ToString();
            txtUserName.Text = _User.UserName;
            txtConfirmPassword.Text = _User.Password;
            chbIsActive.Checked = _User.IsActive;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            btnSave.Enabled = true;
            //if (!btnUpdateUserInfo.Visible)
            //{
            //    btnSave.Enabled = true;
            //    btnUpdateUserInfo.Visible = false;
            //}
        }
        private void ctrlAssignPersonToUser1_GetPersonIDToUser(int obj)
        {
            _PerosnID = obj;

            if (clsUsers.IsPersonExists(_PerosnID))
            {
                MessageBox.Show($"This Perosn with is already exists \n Enter ano:-( ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            
        }

        private bool _IsEmpty()
        {
            return (string.IsNullOrEmpty(txtPassword.Text) &&
                 string.IsNullOrEmpty(txtUserName.Text)
                 && string.IsNullOrEmpty(txtConfirmPassword.Text));
        }          
            
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Fill _User Name and Password .","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            _User.PersonID = _PerosnID;
            _User.UserName = txtUserName.Text;
            _User.Password = txtConfirmPassword.Text;
            _User.IsActive = chbIsActive.Checked;

            if (_User.Save())
            {
                lblUserID.Text = _User.UserID.ToString();
                Refresh?.Invoke();
                _Clear();
                _eMode = enMode.eUpdate;
                MessageBox.Show("User Added Successfully -:) ","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Failed added _User  -:( ...", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            string UserName = txtUserName.Text;

            if (string.IsNullOrEmpty(UserName))
            {
                erpValidatingUserName.SetError(txtUserName, "this Fielde is required ");
                e.Cancel = true;

            }

            if (clsUsers.IsUserNameExists(UserName))
            {

                erpValidatingUserName.SetError(txtUserName, "_User Name is exists ");
                e.Cancel = true;

            }

            else
            {
                e.Cancel = false;

                erpValidatingUserName.Clear();
            }


        }

        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            btnSave .Enabled = false;
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Refresh?.Invoke();
            this.Close();
        }

        private void _Clear()
        {
            
            txtUserName.Clear();
            txtConfirmPassword.Clear();
            txtPassword.Clear();
        }

        private void btnUpdateUserInfo_Click(object sender, EventArgs e)
        {
            //if (IsFormValid())
            //{
            //    MessageBox.Show("Fill _User Name and Password .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            
            //}


            _User.PersonID = _PerosnID;
            _User.UserName = txtUserName.Text;
            _User.Password = txtConfirmPassword.Text;
            _User.IsActive = chbIsActive.Checked;


            if (_User.Save())
            {
               
                Refresh?.Invoke();
                _Clear();
                MessageBox.Show("_User Added Successfully -:) ...");
            }

            else
            {
                MessageBox.Show("Failed added _User  -:( ...", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }

        private void ctrlAssignPersonToUser1_Load(object sender, EventArgs e)
        {

        }

     
        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            //ValidateUserName();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            //ValidatePassword();
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            //ValidateConfirmPassword();
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            //ValidateConfirmPassword();
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            //ValidatePassword();
        }
    }
}
