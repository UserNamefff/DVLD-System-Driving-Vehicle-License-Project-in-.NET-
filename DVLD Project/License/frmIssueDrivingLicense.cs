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
    public partial class frmIssueDrivingLicenseForTheFirstTime : Form
    {
        int _LocalApplicationID;
        clsLocalDrivingLicenseAppliaction _LocalDrivingLicenseAppliaction;
        clsLicenses _Licenses;
        clsDrivers  _Drivers;
        public frmIssueDrivingLicenseForTheFirstTime(int LocalApplicationID)
        {
            InitializeComponent();
            _LocalApplicationID = LocalApplicationID;
            _Licenses = new clsLicenses();
        }
        
        public int LocalApplicationID { get => _LocalApplicationID;}
        
        public clsLicenses Licenses { get => _Licenses; }
        
        private void _Load()
        {
            ctrlLocalDrivingLicenseApplicationDetails1.LoadLocalDrivingApplicationData(_LocalApplicationID);
            _LocalDrivingLicenseAppliaction = ctrlLocalDrivingLicenseApplicationDetails1.LocalDrivingLicenseAppliaction;
        }
        
        private void frmIssueDrivingLicenseForTheFirstTime_Load(object sender, EventArgs e)
        {
            _Load();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_LocalDrivingLicenseAppliaction != null)
            {
                int PersonID = _LocalDrivingLicenseAppliaction.ApplicationData.Person.ID;
                
                int DriverID = -1;
                if ((DriverID = clsDrivers.IsThisPersonIsADriver(PersonID)) != -1)
                {
                    _Licenses.DriverID = DriverID;
                }
                // _Drivers _LocalDrivingLicenseAppliaction.ApplicationData.Person.ID;

                else
                {
                    _Drivers = new clsDrivers();
                    _Drivers.PersonID = PersonID;
                    _Drivers.CreatedByUserID = clsGlobleUser.UserID;
                    _Drivers.CreatedDate = DateTime.Now;
                    _Drivers.Save();
                }
                

            }

            _Licenses.IssueDate = DateTime.Now;
            _Licenses.ExpirationDate = DateTime.Now.AddYears(_LocalDrivingLicenseAppliaction.LicenseClasses.DefaultValidityLength).Date;
            _Licenses.LicenseClassID = _LocalDrivingLicenseAppliaction.LicenseClasses.LicenseClassID;
            _Licenses.IssueReason = Convert.ToByte(_LocalDrivingLicenseAppliaction.ApplicationData.ApplicationTypes1.ApplicationTypeID);
            _Licenses.ApplicationID = _LocalDrivingLicenseAppliaction.ApplicationData.ApplicationID;
            _Licenses.CreatedByUserID = clsGlobleUser.UserID;
            _Licenses.PaidFees = _LocalDrivingLicenseAppliaction.LicenseClasses.ClassFees;
            _Licenses.Notes = string.IsNullOrWhiteSpace(rtxtNotes.Text)?"": rtxtNotes.Text;
            _Licenses.DriverID = _Drivers.DriverID;
            
            if (_Licenses.Save())
            {
                MessageBox.Show("License Issued Successfully -:) ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Failed Issued License -:( ...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }


    }
}
