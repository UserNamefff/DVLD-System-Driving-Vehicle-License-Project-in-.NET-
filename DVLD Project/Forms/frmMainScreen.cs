using DVLD_Project;
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
    public partial class frmMainScreen : Form
    {
        public frmMainScreen()
        {
            InitializeComponent();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(" Manage _User Will be he ");

            frmManageUsers frm = new frmManageUsers();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Manage drivers Will be he ");
        }

        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" account Settings Will be he ");

        }

        private void localDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddLocalDrivingLicenseApplication frm = new frmAddLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagePeople frm = new ManagePeople();
            frm.ShowDialog();
        }

        private void localDrivingLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmManageLocalDrivingLicense frm = new frmManageLocalDrivingLicense();
            frm.ShowDialog();
        }
    }
}
