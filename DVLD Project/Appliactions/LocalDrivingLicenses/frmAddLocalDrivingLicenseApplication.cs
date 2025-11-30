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
    public partial class frmAddLocalDrivingLicenseApplication : Form
    {
        enum enMode { eAdd,Edite}
        enMode _eMode ;
        int _LocalLicenseApplicationID = 0;
        int _PersonAppID = 0;
        double ApplicationFees = 0;
        int ClassID = 0;
        clsLicenseClasses _LicenseClasses;
        clsApplicationTypes _ApplicationTypes;
        clsLocalDrivingLicenseAppliaction _LicenseAppliaction;
           
        public frmAddLocalDrivingLicenseApplication()
        {
            InitializeComponent();

            //clsLocalDrivingLicenseAppliaction.Find("");
            _LicenseAppliaction = new clsLocalDrivingLicenseAppliaction();
            
            _eMode = enMode.eAdd;
        }

        //To Update
        public frmAddLocalDrivingLicenseApplication(int LocalLicenseApplicationID)
        {
            InitializeComponent();
            lblNameScreen.Text = "Edite Local Driving License Application";
            _LocalLicenseApplicationID = LocalLicenseApplicationID;
            _eMode = enMode.Edite;
        }
        private void FillCombox()
        {
            DataTable dt = clsLicenseClasses.GetAllLicenseClasses();

            foreach (DataRow dr in dt.Rows)
            {
                cmbLicenseClasses.Items.Add(dr["ClassName"].ToString());
            }
            cmbLicenseClasses.SelectedIndex = 0;
        }
        private void Initially()
        {


            //lblCreatedby.Text = clsGlobleUser.CurrentUser.UserName;

            if (_eMode == enMode.Edite)
            {
                _LicenseAppliaction = clsLocalDrivingLicenseAppliaction.Find(_LocalLicenseApplicationID);
                _LicenseClasses = clsLicenseClasses.Find(_LicenseAppliaction.LicenseClassID);
                cmbLicenseClasses.SelectedIndex = cmbLicenseClasses.FindString(_LicenseClasses.ClassName);
                ctrlAssignPersonToUser1.Enabled = false;

                ctrlAssignPersonToUser1.LoadPersonInfo(_LicenseAppliaction.ApplicationData.ApplicantPersonID);
                
            }
            else
            {
                _LicenseClasses = clsLicenseClasses.Find(cmbLicenseClasses.Text.ToString());
                tpApplicationInfo.Enabled = false;
                btnSave.Enabled = false;
            }

            
            

            _ApplicationTypes = clsApplicationTypes.Find((int)clsApplicationData.enApplicationType.NewLocalDrivingLicense);
            lblApplicationFees.Text = _ApplicationTypes.ApplicationFees.ToString();
            lblApplicationDate.Text = DateTime.Now.Date.ToString();
            

        }
        private void frmAddLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            FillCombox();
            Initially();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmbLicenseClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LicenseClasses = clsLicenseClasses.Find(cmbLicenseClasses.Text.ToString());

        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            /*
            //_LicenseAppliaction = new clsLocalDrivingLicenseAppliaction
            //    (
            //        _LicenseClasses.LicenseClassID,_PersonAppID,
            //        _ApplicationTypes.ApplicationTypeID,
            //        (float)_ApplicationTypes.ApplicationFees, 1
                
            //    );
            //_LicenseAppliaction.ApplicationData = clsApplicationData.Find(_LicenseAppliaction.ApplicationID1 );
            */

            
            _LicenseAppliaction.LicenseClassID = _LicenseClasses.LicenseClassID;
            _LicenseAppliaction.ApplicantPersonID = _PersonAppID;
            _LicenseAppliaction.ApplicationTypeID= _ApplicationTypes.ApplicationTypeID;
            _LicenseAppliaction.PaidFees= (float)_ApplicationTypes.ApplicationFees;
            _LicenseAppliaction.CreatedByUserID = clsGlobleUser.UserID;

            

            if (_LicenseAppliaction.Save())
            {
                lblApplicationID.Text = _LicenseAppliaction.ApplicantPersonID.ToString();   
                MessageBox.Show("Application saved successfully :-)| ","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"This Person already has the same class :-(|' {_LicenseClasses.ClassName} ' Application ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnNext_Click_1(object sender, EventArgs e)
        {
            if(_PersonAppID != 0)
            {
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
            }
            tbcLocalApplication.SelectedTab = tpApplicationInfo;

            //tbcLocalApplication.TabIndex = 2;


        }
        private void ctrlAssignPersonToUser1_GetPersonIDToUser(int obj)
        {
            _PersonAppID = obj;


        }

       
    }
}
