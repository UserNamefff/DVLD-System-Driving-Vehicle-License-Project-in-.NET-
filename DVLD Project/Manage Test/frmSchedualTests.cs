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
    public partial class frmSchedualAppointmentTests : Form
    {
        int _Local_App_ID;
        int _TestTypeID;
        clsLocalDrivingLicenseAppliaction _LocalDrivingLicenseAppliactionData; // to fill Controls
        clsTestAppointments _TestAppointments;


        public frmSchedualAppointmentTests()
        {
            InitializeComponent();
        }
        public frmSchedualAppointmentTests(int L_App_ID,byte TestTypeID)
        {
            InitializeComponent();

            _Local_App_ID = L_App_ID;
            _TestTypeID = TestTypeID;

            
            _LocalDrivingLicenseAppliactionData = clsLocalDrivingLicenseAppliaction.Find(L_App_ID);
            
            _TestAppointments = new clsTestAppointments(TestTypeID);
        }



        private void _Fill()
        {
            lblDClass.Text = _LocalDrivingLicenseAppliactionData.LicenseClasses.ClassName;
            lblFees.Text = string.Empty;//TestType fees
            lblFullName.Text = _LocalDrivingLicenseAppliactionData.ApplicationData.Person.FullName;
            lblLDAppID.Text = _LocalDrivingLicenseAppliactionData.LocalDrivingLicenseApplicationID.ToString();
            lblSchedualCount.Text = "0";
            lblTestFees.Text = _TestAppointments.TestTypes.TestFees.ToString();
            
            lblTotalFees.Text = _TestAppointments.TestTypes.TestFees.ToString();

            txtDate.MaxDate= DateTime.Now.Date.AddYears(100);
            txtDate.MinDate= DateTime.Now.Date;
            txtDate.Value = txtDate.MinDate;
           

        }
        public void LoadSchedualTestData()
        {
            // Fill Controls will be here ...
            _Fill();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            
            
            _TestAppointments.AppointmentDate = txtDate.Value;
            _TestAppointments.PaidFees = Convert.ToDouble(lblTestFees.Text);
            _TestAppointments.CreatedByUserID = clsGlobleUser.UserID;//Globle.User.ID;
            _TestAppointments.IsLocked = false;
            _TestAppointments.LocalDrivingLicenseApplicationID = _Local_App_ID;


            if (_TestAppointments.Save())
            {
                lblTestAppID.Text = _TestAppointments.TestAppointmentID.ToString(); //we will Get After Save appointment 

                if(MessageBox.Show("Appointment saved successfully :-)| ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show($"Error : during Save appointment :-( ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmSchedualAppointmentTests_Load(object sender, EventArgs e)
        {
            LoadSchedualTestData();
        }
    }
}
