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

namespace DVLD_Project.Manage_Test.Test_Types
{
    public partial class frmEditeTestTypeFees : Form
    {
        int _TestTypeID;
        clsTestTypes _TestType;
        public clsTestTypes TestType 
        {
            get { return _TestType; }
        }
        public int TestTypeID
        {
            get { return _TestTypeID; }
        }
        public frmEditeTestTypeFees(int TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
        }
        private void _FillTestInfo()
        {
           _TestType =  clsTestTypes.Find(_TestTypeID);

            if (_TestType == null)
            {
                MessageBox.Show("Error : Test type isn't found :-( ","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;

            }

            lblTestTypeID.Text = _TestTypeID.ToString();
            txtTestTypeDesc.Text = _TestType.TestTypeDescription;
            txtTestTypeFee.Text = _TestType.TestFees.ToString();
            txtTestTypeTitle.Text = _TestType.TestTypeTitle;

        }
        private void frmEditeTestTypeFees_Load(object sender, EventArgs e)
        {
            _FillTestInfo();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                MessageBox.Show("Error : Test type Fee Field is required ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _TestType.TestFees = Convert.ToDouble(txtTestTypeFee.Text);
            _TestType.TestTypeDescription = txtTestTypeDesc.Text;


            if (_TestType.Save())
            {
                MessageBox.Show("Application Type Fee Updated Successfully ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void txtTestTypeFee_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTestTypeFee.Text))
            {
                errorProvider1.SetError(txtTestTypeFee, "This field is requred ");
                e.Cancel = true;
            }

            if (int.Parse(txtTestTypeFee.Text) <= 0)
            {
                errorProvider1.SetError(txtTestTypeFee, "Fee value conn't less than Zero or equal ");
                e.Cancel = true;
            }

            else
            {
                errorProvider1.SetError(txtTestTypeFee, null);
                // e.Cancel = true;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    

    }
}
