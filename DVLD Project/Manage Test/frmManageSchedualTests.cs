using DVLD_BusinessLayer ;
using DVLD_Project;
using DVLD_Project.Manage_Test;
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
    public partial class frmManageSchedualTests : Form
    {
       public enum enSchedualMode { eVision=1,eWritten,eStreet}
        int _L_D_ApplicationID ;
        int _AppointmentID;
        enSchedualMode _eMode;
        public frmManageSchedualTests(int L_ApplicationID)
        {
            InitializeComponent();
            _L_D_ApplicationID = L_ApplicationID;
        }
        public frmManageSchedualTests(int L_ApplicationID, enSchedualMode eMode)
        {
            InitializeComponent();
            _L_D_ApplicationID = L_ApplicationID;
            _eMode = eMode;

        }

        string sTestType()
        {
            switch (_eMode)
            {
                case enSchedualMode.eVision:
                    {
                        pbxTestType.Image = Resources.Vision_Test_Schdule;
                        return "Vision Test";
                    }
                case enSchedualMode.eWritten:
                    {
                        pbxTestType.Image = Resources.Written_Test_32_Sechdule;
                        return "Writen Test";
                    }
                case enSchedualMode.eStreet:
                    {
                        pbxTestType.Image = Resources.Street_Test_32;

                        return "Street Test";
                    }

            }
            return "";
        }


        public enSchedualMode eMode { get; set; }
        private void frmVisionTest_Load(object sender, EventArgs e)
        {
            ctrlLocalDrivingLicenseApplicationDetails1.LoadLocalDrivingApplicationData(_L_D_ApplicationID);
            lblTypeTestName.Text = sTestType();
            _Refresh();
        }
        
        private void _Refresh()
        {
            try
            {
                DataTable dt = clsTestAppointments.GetAllTestAppointments(_L_D_ApplicationID,(byte)_eMode);
                if (dt != null)
                {
                    dgvTests.DataSource = dt;
                    lblRecordsNum.Text = dt.Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {

            }

            
            
        }
        private int GetAppointmentID()
        {
           
            if (dgvTests.Rows.Count > 0)
            {
                return _AppointmentID = (int)dgvTests.CurrentRow.Cells[0].Value;

            }
            return -1;
        }
        
        bool IsAppointmentLocked()
        {
            if (dgvTests != null)
            {
                if (clsTestAppointments.IsAppointmentLocked(GetAppointmentID()))
                {
                    return true;
                }

            }
            return false;
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            // Schedual Take/Retake Test will be here ....
            
            if(IsAppointmentLocked())
            {
                MessageBox.Show($"Error : this appointment is locked :-( ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(clsTestAppointments.IsTest(GetAppointmentID()))
            {
                MessageBox.Show($"Error : this appointment already tested :-( ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            frmSchedualAppointmentTests frm = new frmSchedualAppointmentTests(_L_D_ApplicationID,(byte)_eMode);
            frm .ShowDialog();
            
            _Refresh();
            //MessageBox.Show("Schedual Take/Retake Test will be here", "");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //later:
            //When Pass check if attemt Test anthore time 
            if (clsTestAppointments.IsTest(_AppointmentID))
            {
                MessageBox.Show($"Error : this appointment is already Pass in Test :-( ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!IsAppointmentLocked())
            {
                MessageBox.Show($"Error : this appointment is locked :-( ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmTakeTest frm = new frmTakeTest(_AppointmentID);
            frm.ShowDialog();

            _Refresh();
        }
        

    }
}
