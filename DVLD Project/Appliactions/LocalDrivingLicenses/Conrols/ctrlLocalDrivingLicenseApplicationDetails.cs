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
    public partial class ctrlLocalDrivingLicenseApplicationDetails : UserControl
    {
        int _LocalAppID = 0;

        clsLocalDrivingLicenseAppliaction _LocalDrivingLicenseAppliaction;


        public ctrlLocalDrivingLicenseApplicationDetails()
        {
            InitializeComponent();

        }
        public clsLocalDrivingLicenseAppliaction LocalDrivingLicenseAppliaction { get { return (_LocalDrivingLicenseAppliaction != null)? _LocalDrivingLicenseAppliaction:null; } }

        private string _GetStatus()
        {
            switch (_LocalDrivingLicenseAppliaction.ApplicationData.ApplicationStatus)
            {
                case 1:
                    {
                        return "New";
                    }
                case 2:
                    {
                        return "Canceled";
                    }
                case 3:
                    {
                        return "Completed";
                    }
                default:
                    break;
            }

            return "No things";
        }
        private void _FillData()
        {
            _LocalDrivingLicenseAppliaction = clsLocalDrivingLicenseAppliaction.Find(_LocalAppID);

            if(_LocalDrivingLicenseAppliaction!= null)
            {
                lblLDApplication.Text= _LocalDrivingLicenseAppliaction.LocalDrivingLicenseApplicationID.ToString();
                lblAppliedForLicense.Text = _LocalDrivingLicenseAppliaction.LicenseClasses.ClassName; //clsLicenseClasses.Find(_LocalDrivingLicenseAppliaction.LicenseClassID).ClassName;
                lblBaseAppID.Text = _LocalDrivingLicenseAppliaction.ApplicationData.ApplicationID.ToString();
                lblDate.Text = _LocalDrivingLicenseAppliaction.ApplicationData.ApplicationDate.ToString();
                lblStatusDate.Text = _LocalDrivingLicenseAppliaction.ApplicationData.LastStatusDate.ToString();
                lblType.Text = _LocalDrivingLicenseAppliaction.ApplicationData.ApplicationTypes1.ApplicationTypeTitle;
                lblPassedTests.Text = "3/" + "";
                lblFees.Text = _LocalDrivingLicenseAppliaction.ApplicationData.PaidFees.ToString();
                lblStatus.Text = _GetStatus();
                lblApplicant.Text = _LocalDrivingLicenseAppliaction.ApplicationData.Person.FullName;
                lblCreateByUser.Text = "Hafed";
            }
            llblShowLicense.Enabled = false;
        }
        public void LoadLocalDrivingApplicationData(int LocalAppID)
        {
            _LocalAppID = LocalAppID;
            _FillData();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void lblViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonDetails frm = new frmShowPersonDetails(_LocalDrivingLicenseAppliaction.ApplicationData.Person.ID);
            frm.ShowDialog();
        }

        private void llblShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }
    }
}
