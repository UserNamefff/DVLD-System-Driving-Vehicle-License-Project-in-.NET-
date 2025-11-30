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
    public partial class frmEditApplicationTypeFee : Form
    {
        int _ApplicationTypeID;
        clsApplicationTypes _ApplicationType;
        public frmEditApplicationTypeFee(int ApplicationTypeID)
        {
            InitializeComponent();
             _ApplicationTypeID = ApplicationTypeID;
        }
        private void frmEditApplicationTypeFee_Load(object sender, EventArgs e)
        {
            _ApplicationType = clsApplicationTypes.Find(_ApplicationTypeID);

            if (_ApplicationType == null)
            {
                return;

            }
            txt.Text = _ApplicationType.ApplicationTypeTitle;
            txtFee.Text = _ApplicationType.ApplicationFees.ToString();
            lblApplicationTypeID.Text = _ApplicationTypeID.ToString();


        }
        private void txtFee_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFee.Text))
            {
                errorProvider1.SetError(txtFee, "This field is requred ");
                e.Cancel = true;
            }

            if(int.Parse( txtFee.Text) <= 0  )
            {
                errorProvider1.SetError(txtFee, "Fee value conn't less than Zero or equal ");
                e.Cancel = true;
            }

            else 
            {
                errorProvider1.SetError(txtFee, null);
               // e.Cancel = true;
            }
        }
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                return;
            }

            _ApplicationType.ApplicationFees = Convert.ToDouble(txtFee.Text);

            if (_ApplicationType.Save())
            {
                MessageBox.Show("Application Type Fee Updated Successfully ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Error Occured While Update Application Type Fee  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
    }
}
