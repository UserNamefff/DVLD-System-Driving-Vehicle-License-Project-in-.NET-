
using DVLD_BusinessLayer;
using DVLD_Project.Properties;
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
    public partial class frmTakeTest : Form
    {


        int _AppointmentID;
        clsTests _TakeTest;
        byte _TestType;
        clsTestAppointments _AppointmentTest;

        public delegate void SendDataBack(int AppointmentID);

        public event SendDataBack dlg_SendDataBack;
        public frmTakeTest(int AppointmentID)
        {
            InitializeComponent();

            _AppointmentID = AppointmentID;
            _TakeTest = new clsTests();
            _AppointmentTest = clsTestAppointments.Find(AppointmentID);
            
            _TestType = (byte)_AppointmentTest.TestTypes.TestTypeID;

           // sTestType = new string { "Vision", "Writen", "Street" };
        }

        //string[] sTestType;//= new string { "Vision", "Writen", "Street" };
        string sTestType()
        {
            switch (_TestType)
            {
                case 1:
                    {
                        pkbTestType.Image = Resources.Vision_512;
                        return "Vision Test";
                    }
                case 2:
                    {
                        pkbTestType.Image = Resources.Written_Test_512;
                        return "Writen Test";
                    }
                case 3:
                    {
                        pkbTestType.Image = Resources.Street_Test_32;

                        return "Street Test";
                    }

            }
            return "";
        }

        private void _FillData()
        {
            lblDate.Text = _AppointmentTest.AppointmentDate.Date.ToString();
            lblDClass.Text = _AppointmentTest.LocalDrivingLicenseAppliaction.LicenseClasses.ClassName;
            lblFees.Text = _AppointmentTest.TestTypes.TestFees.ToString();
            lblFullName.Text = _AppointmentTest.LocalDrivingLicenseAppliaction.ApplicationData.Person.FullName;
            lblLDAppID.Text = _AppointmentID.ToString();
            lblSchedualCount.Text = clsTestAppointments.GetNumberOfTestsFail(_AppointmentTest.LocalDrivingLicenseAppliaction.LocalDrivingLicenseApplicationID).ToString();

            lblTestType.Text = "Schedual" + " " + sTestType();
            gbTest.Text = sTestType();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TestResult(object sender, EventArgs e)
        {
            RadioButton result = (RadioButton)sender;
            
            _TakeTest.TestResult = result.Checked;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //  ---------- Plan ----------
            // Later Make : 
            //1- Go to Build clsTests class in business and DataAccess Layers
            //2- test info saving Here ...
            //3- after test do -->> clsTestAppointments.UpdateLockedApoointment();


            _TakeTest.Notes = (string.IsNullOrEmpty(rtxtNotes.Text)) ?"": rtxtNotes.Text;
            _TakeTest.TestAppointmentID = _AppointmentID;
            _TakeTest.CreatedByUserID = clsGlobleUser.UserID ;

            
            if (_TakeTest.Save())
            {
                lblTestID.Text = _TakeTest.TestID.ToString(); //we will Get After Save appointment 
                clsTestAppointments.LockedTestAppointment(_AppointmentID, true);
                if (MessageBox.Show("Test result saved successfully :-)| ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show($"Error : during Save Test :-( ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            _FillData();

        }



    }
}
