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
    public partial class frmShowUserInfo : Form
    {
        public int UserID;

        public frmShowUserInfo()
        {
            InitializeComponent();
        }

        public frmShowUserInfo(int UserID)
        {
            InitializeComponent();
            
            this.UserID = UserID;

        }

        private void frmShowUserInfo_Load(object sender, EventArgs e)
        {
            ctrlShowUserInfo11.GetUserInf(UserID);
        }
    }
}
