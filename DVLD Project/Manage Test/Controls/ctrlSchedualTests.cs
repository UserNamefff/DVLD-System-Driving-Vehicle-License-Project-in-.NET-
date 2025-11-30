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
    public partial class ctrlSchedualTests : UserControl
    {
        //Delegation 


        public event Action<int> SendBackData;

        protected void GetAppointmentID(int ID)
        {
            Action<int> Handling = SendBackData;

            if(Handling != null)
            {
                Handling(ID);
            }
        }

        public ctrlSchedualTests()
        {
            InitializeComponent();
        }

        private void _Fill()
        {
            lblDClass.Text = string.Empty;
            lblFees.Text = string.Empty;
            lblFullName.Text = string.Empty;
            lblLDAppID.Text = string.Empty;
            lblSchedualCount.Text = string.Empty;
            lblTestAppID.Text = string.Empty;
            lblTestFees.Text = string.Empty;
            lblTotalFees.Text = string.Empty;

        }
        public void LoadSchedualTestData(int ID)
        {
            // Fill Controls will be here ...
        }




    }
}
