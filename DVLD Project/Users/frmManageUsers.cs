using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DVLD_BusinessLayer;

namespace DVLD_Project
{
    public partial class frmManageUsers : Form
    {
        clsUsers User;
        public frmManageUsers()
        {
            InitializeComponent();
        }
        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _Refresh();
        }
        
        private void _Refresh()
        {
            dgvUsers.DataSource = clsUsers.GetAllUsers();
        }
        private void showDetailsOfUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = 0;
            if((UserID=_GetSelelctedUserID() )> 0)
            {
                frmShowUserInfo frm = new frmShowUserInfo(UserID);
                frm.ShowDialog();

            }
        }
        private void AddNewOfUser_Click(object sender, EventArgs e)
        {
            frmAddNewUser frm = new frmAddNewUser();
            frm.Refresh += _Refresh;
            frm.ShowDialog();
        }
        private void EditeUserInfo_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword();
            frm.RefreshTable += _Refresh;
            
            frm.ShowDialog();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteUser(_GetSelelctedUserID());
            _Refresh();
        }
        bool DeleteUser(int userId)
        {
            User = clsUsers.Find(userId);

            // !if (_User.HasRelations(_User.UserID))
            if (User != null)
            {
                if (!User.HasRelations(User.UserID))
                {
                    return false;

                }
            }
            return User.Save();
        }
        private int _GetSelelctedUserID()
        {

            if (dgvUsers.Rows.Count > 0)
            {


                //DataGridViewRow SelectedRow = dgvUsers.SelectedRows[0];

                if (dgvUsers != null)
                {
                    
                    return Convert.ToInt32((int)dgvUsers.CurrentRow.Cells[0].Value);
                }

            }
            return -1;
        }
        private void editeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewUser frm = new frmAddNewUser(_GetSelelctedUserID());
            frm.Refresh += _Refresh;
            frm.ShowDialog();
            this._Refresh();

        }
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddNewUser frm = new frmAddNewUser();
            frm.Refresh += _Refresh;
            frm.ShowDialog();
        }


    }
}
