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
    public partial class frmApplicationTypeInfo1 : Form
    {

        int _ApplicationTypeID = 0;
        clsApplicationTypes _ApplicationType;

        public frmApplicationTypeInfo1(int ApplicationTypeID)
        {
            InitializeComponent();

            _ApplicationTypeID  = ApplicationTypeID;

        }
        



        private void ApplicationTypeInfo1_Load(object sender, EventArgs e)
        {
            _ApplicationType = clsApplicationTypes.Find(_ApplicationTypeID);
            
            if(_ApplicationType == null)
            {
                return;

            }
            lblApplicationTitle.Text = _ApplicationType.ApplicationTypeTitle;
            lblApplicationType.Text = _ApplicationType.ApplicationFees.ToString();
            lblID.Text = _ApplicationTypeID.ToString();

        }
    }
}
