using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class frmShowPersonDetails : Form
    {
        int _PersonID;
       
        public frmShowPersonDetails(int ID)
        {
            InitializeComponent();
            _PersonID = ID;
        }

        private void frmShowPersonDetails_Load(object sender, EventArgs e)
        {
            ctrlPersonal_Details1.LoadPersonInfo(_PersonID);
        }

        
    }
}
