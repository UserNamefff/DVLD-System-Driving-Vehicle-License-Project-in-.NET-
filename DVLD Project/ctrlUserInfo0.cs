using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class ctrlUserInfo0 : UserControl
    {

        int _UserID;
        public ctrlUserInfo0()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            //FillUserInfo(_UserID);
        }

        public void LoadUserInfo(int UserId)
        {
            this._UserID = UserId;

        }

        private void FillUserInfo(int UserId)
        {
            clsUsers User = clsUsers.Find(UserId);

            if (User != null)
            {
                //lblPassword.Text = _User.Password;
                lblUserName.Text = User.UserName;
                lblUserID.Text = _UserID.ToString();
                lblIsActive.Text = (User.IsActive!= true) ? "Not Active":"Active";
                //lblPermissions.Text = _User.Permissoins.ToString();
            }
        }

        public void FillUserInfo(clsUsers User)
        {
             

            if (User != null)
            {
                //lblPassword.Text = _User.Password;
                lblUserName.Text = User.UserName;
                lblUserID.Text = _UserID.ToString();
                lblIsActive.Text = (User.IsActive != true) ? "Not Active" : "Active";
                //lblPermissions.Text = _User.Permissoins.ToString();
            }


        }

        private void ctrlUserInfo0_Load(object sender, EventArgs e)
        {

        }
    }
}
