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
    public partial class frmManageApplicationTypes : Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }
        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _Refresh();
        }
        void _Refresh()
        {
            dgApplicationTypes.DataSource = clsApplicationTypes.GetAllApplicationTypes();
        }
        private void showApplicationInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmApplicationTypeInfo1 frm = new frmApplicationTypeInfo1(_GetSelelctedApplicationTypeID());
            frm.ShowDialog();
        }
        private int _GetSelelctedApplicationTypeID()
        {

            if (dgApplicationTypes.Rows.Count > 0)
            {


                DataGridViewRow SelectedRow = dgApplicationTypes.SelectedRows[0];

                if (SelectedRow != null)
                {
                    return Convert.ToInt32(SelectedRow.Cells["ApplicationTypeID"].Value);
                }

            }
            return -1;
        }

        private void eiteApplicationFeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditApplicationTypeFee frm = new frmEditApplicationTypeFee(_GetSelelctedApplicationTypeID());
            frm.ShowDialog();
            _Refresh();
        }
    }
}
