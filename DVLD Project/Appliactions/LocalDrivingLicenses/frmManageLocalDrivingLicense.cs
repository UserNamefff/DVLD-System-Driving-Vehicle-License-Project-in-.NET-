using DVLD_BusinessLayer;
using DVLD_Project;
using DVLD_Project;
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
    public partial class frmManageLocalDrivingLicense : Form
    {
        int _LDID = -1;
        int _Completed;
        clsApplicationData ApplicationData ;
        public frmManageLocalDrivingLicense()
        {
            InitializeComponent();
        }
        
        private void frmManageLocalDrivingLicense_Load(object sender, EventArgs e)
        {
         
            _Refresh();
        }
        
        private int _GetSelelctApplicationID()
        {

            

                if (dgvDVLDA.Rows.Count > 0)
            {
                //DataGridViewRow SelectedRow = dgvUsers.SelectedRows[0];

                if (dgvDVLDA != null)
                {
                    _LDID = (int)dgvDVLDA.CurrentRow.Cells[1].Value;
                    return Convert.ToInt32((int)dgvDVLDA.CurrentRow.Cells[0].Value);
                }

            }
            return -1;
        }
        private int _GetLocalDLAppID()
        {
            if (dgvDVLDA.Rows.Count > 0)
            {
                return _LDID = (int)dgvDVLDA.CurrentRow.Cells[1].Value;

            }
            return -1;
        }
        
        /// <summary>
        /// Later on I will build filter in this function .......
        /// </summary>
        private void _Refresh()
        {
            dgvDVLDA.DataSource = clsLocalDrivingLicenseAppliaction.GetAllLocalDrivingLicenseApplicationRecordes();
        }
        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(clsApplicationData.UpdateStatus(_GetSelelctApplicationID(),2))
            {
                MessageBox.Show("Cancel Successfully :-) ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Refresh();
            }
            else
            {
                MessageBox.Show("This Application is already Completed or Cancel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
                

        }
        
        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {
            frmAddLocalDrivingLicenseApplication frm = new frmAddLocalDrivingLicenseApplication();
            frm.ShowDialog();
            
            _Refresh();

        }

        private void editeApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Perform Add and refresh
            int AppID = _GetSelelctApplicationID();
            frmAddLocalDrivingLicenseApplication frm = new frmAddLocalDrivingLicenseApplication(_LDID);
            frm.ShowDialog();

            _Refresh();
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Perform Delele and refresh
            int AppID = _GetSelelctApplicationID();

            if (_LDID == -1)
            {
                MessageBox.Show("Cann't delete ; because Application List is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsLocalDrivingLicenseAppliaction.DeleteLocalDrivingApplication( _LDID, AppID))
            {
                MessageBox.Show("Delete Local Driving License Application successfully :-) ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Refresh();
            }
            
        }


        private void showApplicationInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _GetSelelctApplicationID();
            frmLocalDrivingLicenseApplicationInfo frm = new frmLocalDrivingLicenseApplicationInfo(_GetLocalDLAppID());
            frm.ShowDialog();
        }

        /// <summary>
        /// Chech Number of tests to enable show schedule Tests
        /// control 1 -> enable Vision Test --> WritenTest or all scheduals 
        /// </summary>
        void _HowManyTests()
        {

            int numTests = clsTestAppointments.GetNumberOfTestsSuccessfull(_LDID);

            if (numTests == 0)
            {
                //sdToolStripMenuItem.Enabled = false;
                visionTestToolStripMenuItem.Enabled = true;
                scheduleWritenTestToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = false;
                return;

            }
            if (numTests == 1)
            {
                //sdToolStripMenuItem.Enabled = true;
                visionTestToolStripMenuItem.Enabled = false;
                scheduleWritenTestToolStripMenuItem.Enabled = true;
                scheduleStreetTestToolStripMenuItem.Enabled = false;
                return;

            }

            if (numTests == 2)
            {
                //sdToolStripMenuItem.Enabled = true;
                visionTestToolStripMenuItem.Enabled = false;
                scheduleWritenTestToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = true;
                return;

            }

            else
            {
                if(!clsApplicationData.IsApplicationComplited(_GetSelelctApplicationID()) && _IsIssued)
                {
                    IssueDLicenseToolStripMenuItem.Enabled = true;
                }

                sdToolStripMenuItem.Enabled = false;
                visionTestToolStripMenuItem.Enabled = false;
                scheduleWritenTestToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = false;
                return;

            }

            //switch (numTests)
            //{

            //    case 3:
            //        sdToolStripMenuItem.Enabled = false;
            //        scheduleStreetTestToolStripMenuItem.Enabled = false;
            //        break;
            //    case 2:
            //        //scheduleStreetTestToolStripMenuItem.Enabled = false;
            //        visionTestToolStripMenuItem.Enabled = false;
            //        scheduleWritenTestToolStripMenuItem.Enabled = false;
            //        break;
            //    case 1:

            //        visionTestToolStripMenuItem.Enabled = false;
            //        break;

            //    default:
            //        sdToolStripMenuItem.Enabled = true;
            //        visionTestToolStripMenuItem.Enabled = true;
            //        scheduleWritenTestToolStripMenuItem.Enabled = true;
            //        scheduleStreetTestToolStripMenuItem.Enabled = true;
            //        break;
            //}

        }
        bool _IsIssued = false;

        /// <summary>
        ///review Later on 
        /// </summary>
        void IsCompletedApplication()
        {
            // when Application is Completed successful enable =false to (edite,delete,cancel,
            // and
            // (IssueLicense if don't have issued License) )



            if (dgvDVLDA.Rows.Count > 0)
            {
                int _IDApp = _GetSelelctApplicationID();

                ApplicationData = clsApplicationData.Find(_IDApp);

                if (ApplicationData != null)
                {
                    
                    if (ApplicationData.ApplicationStatus == 3)
                    {
                        _IsIssued  = !clsLicenses.IsIssuedLicenseByApplication(_IDApp);
                        showLicenseToolStripMenuItem.Enabled = !_IsIssued;
                        deleteApplicationToolStripMenuItem.Enabled = false;
                        editeApplicationToolStripMenuItem.Enabled = false;
                        cancelApplicationToolStripMenuItem.Enabled = false;
                        
                    }
                    else
                    {
                        deleteApplicationToolStripMenuItem.Enabled = true;
                        editeApplicationToolStripMenuItem.Enabled = true;
                        cancelApplicationToolStripMenuItem.Enabled = true;
                        IssueDLicenseToolStripMenuItem.Enabled = false;
                    }



                }
                _HowManyTests();
            }
        }
        
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            IsCompletedApplication();
        }

        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageSchedualTests frm = new frmManageSchedualTests(_GetLocalDLAppID(), frmManageSchedualTests.enSchedualMode.eVision);

            frm.ShowDialog();
            
        }

        private void scheduleWritenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageSchedualTests frm = new frmManageSchedualTests(_GetLocalDLAppID(), frmManageSchedualTests.enSchedualMode.eWritten);

            frm.ShowDialog();
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageSchedualTests frm = new frmManageSchedualTests(_GetLocalDLAppID(), frmManageSchedualTests.enSchedualMode.eStreet);

            frm.ShowDialog();
        }

        private void IssueDLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueDrivingLicenseForTheFirstTime frm = new frmIssueDrivingLicenseForTheFirstTime(_GetLocalDLAppID());
            frm.ShowDialog();
        }
    }
}
