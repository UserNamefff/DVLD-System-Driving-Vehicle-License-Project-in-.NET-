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
    public partial class frmPersonDetails : Form
    {
        int _ID;
        public frmPersonDetails()
        {
            InitializeComponent();
        }
        public frmPersonDetails(int ID)
        {
            InitializeComponent();
            _ID = ID;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void ctrlPersonal_Details1_Load(object sender, EventArgs e)
        {

        }
    }
}
