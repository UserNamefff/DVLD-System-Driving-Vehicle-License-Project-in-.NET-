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
    public partial class ctrlShowUserInfo1 : UserControl
    {
        public clsUsers User;
        public ctrlShowUserInfo1()
        {
            InitializeComponent();
        }

        public clsUsers GetUserInf(int UserID)
        {
            User = clsUsers.Find(UserID);
            if (User != null)
            {
                lblUserID.Text= UserID.ToString();
                lblUserName.Text= User.UserName;
                lblIsActive.Text = (User.IsActive) ? "Yes" : "No";
                ctrlPersonal_Details1.LoadPersonInfo(User.PersonID);

                return User;
            }
            return null;
        }



    }
}
