using DVLD_BusinessLayer;
using DVLD_Project.Manage_Test.Test_Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.TestTypes
{
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void _Refresh()
        {
            dgTestTypes.DataSource =  clsTestTypes.GetAllTestTypes();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _Refresh();
        }

       

        private void showApplicationInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private int _GetSelelctedApplicationTypeID()
        {

            if (dgTestTypes.Rows.Count > 0)
            {


                DataGridViewRow SelectedRow = dgTestTypes.SelectedRows[0];

                if (SelectedRow != null)
                {
                    return Convert.ToInt32(SelectedRow.Cells["TestTypeID"].Value);
                }

            }
            return -1;
        }


        private void eiteApplicationFeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditeTestTypeFees frm = new frmEditeTestTypeFees(_GetSelelctedApplicationTypeID());
            
            frm.ShowDialog();
        }


    }
}
