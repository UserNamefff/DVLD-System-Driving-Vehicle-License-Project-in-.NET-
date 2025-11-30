using DVLD_DataAccessLayerLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_BusinessLayer.clsApplicationData;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_BusinessLayer
{
    public class clsLocalDrivingLicenseAppliaction : clsApplicationData
    {
        
        private int _LocalDrivingLicenseApplicationID;
        //private int _ApplicationID;
        private int _LicenseClassID;

        clsApplicationData _ApplicationData;
        clsLicenseClasses  _LicenseClasses;

        private clsLocalDrivingLicenseAppliaction(int localDrivingLicenseApplicationID, int applicationID, int licenseClassID)
        {
            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            _ApplicationID = applicationID;
            _LicenseClassID = licenseClassID;
            _eMode = enMode.eUpdate;

            //Later on using asynchronouns programming
            
            _LicenseClasses = clsLicenseClasses.Find(licenseClassID);
        }

        public clsLocalDrivingLicenseAppliaction()
        {
            _LocalDrivingLicenseApplicationID = 0;
            _ApplicationID = 0;
            _LicenseClassID = 0;
            _eMode = enMode.eAdd;
            _ApplicationData = new clsApplicationData();
            

        }
        private clsLocalDrivingLicenseAppliaction(int LocalDrivingLicenseApplicationID,int ApplicationID) : base(ApplicationID) 
        {
            _LocalDrivingLicenseApplicationID = 0;
            _ApplicationID = 0;
            _LicenseClassID = 0;
            
            
        }

        // inhertance because validation to person don't have new or completed Application to same licenseClass
        // And
        // Save Application before to Parent Appliactions Table in database...
        private clsLocalDrivingLicenseAppliaction( int licenseClassID,int applicantPersonID, int applicationTypeID, float paidFees, int createdByUserID) 
            
        {
            this.ApplicantPersonID = applicantPersonID;
            this.ApplicationTypeID = applicationTypeID;
            this.PaidFees = paidFees;
            this.CreatedByUserID = createdByUserID;

            this._LicenseClassID = licenseClassID;
            this._eMode = enMode.eAdd;

            _LocalDrivingLicenseApplicationID = 0;
            
            
           // _ApplicationData = new clsApplicationData();
        }


        // Fill base clase and this class when want to Find any LocalApplication 
        private clsLocalDrivingLicenseAppliaction(int LocalDrivingLicenseApplicationID, int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate, int ApplicationTypeID,
             enApplicationsStatus ApplicationStatus, DateTime LastStatusDate,
             float PaidFees, int CreatedByUserID, int LicenseClassID)

        {

            this._LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID; ;
            this._ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = (int)ApplicationTypeID;
            this.ApplicationStatus = (byte)ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.LicenseClassID = LicenseClassID;
            
            this._LicenseClasses = clsLicenseClasses.Find(LicenseClassID);
            _eMode = enMode.eUpdate;

        }


        public int LocalDrivingLicenseApplicationID { get => _LocalDrivingLicenseApplicationID; }
        public int ApplicationID1 { get => _ApplicationID; set => _ApplicationID = value; }
        public int LicenseClassID { get => _LicenseClassID; set => _LicenseClassID = value; }
        public clsApplicationData ApplicationData { get { return _ApplicationData = clsApplicationData.Find(ApplicationID); } }
        public clsLicenseClasses LicenseClasses { get => _LicenseClasses;  }

        private bool _Add()
        {

            if (!clsApplicationData.DoesPersonHaveActiveApplicationToSameLDLicenseClass(base.ApplicantPersonID,base.ApplicationTypeID,this._LicenseClassID))
            {
                if (base.Save())
                {
                    _ApplicationID =base.ApplicationID;
                    _LocalDrivingLicenseApplicationID = clsDALocaleDrivingLicense.AddNewLocalDrivingLicenseApplication(_ApplicationID, this._LicenseClassID);
                
                    return _LocalDrivingLicenseApplicationID != -1;
                }
            }
            return false;
        }
        private bool _Update()
        {
            return clsDALocaleDrivingLicense.UpdateLocalDrivingLicenseApplication(_LocalDrivingLicenseApplicationID,_ApplicationID,_LicenseClassID);
        }
        private bool _Delete()
        {
            
            if(!base.Delete())
            {
                return false;
            }
                return clsDALocaleDrivingLicense.DeleteLocalDrivingLicenseApplication(_LocalDrivingLicenseApplicationID);
        }
        public bool Delete()
        {
            bool IsValidate = this.ApplicationID != 0;
            _eMode = enMode.eDelete;

            if (IsValidate)
            {
                return this.Save();
            }
            return false;
        }
        public bool Save()
        {
            

            switch (_eMode)
            {
                case enMode.eUpdate:

                    if (_Update())
                    {
                        _eMode = enMode.eUpdate;
                        return true;
                    }
                    break;
                case enMode.eDelete:

                    if (_Delete())
                    {
                        _eMode = enMode.eUpdate;
                        return true;
                    }
                    break;

                case enMode.eAdd:

                    if (_Add())
                    {
                        _eMode = enMode.eUpdate;
                        return true;
                    }
                    break;

                default:
                    break;
            }
            return false;
        }

        public new static clsLocalDrivingLicenseAppliaction Find(int LocalDrivingLicenseApplicationID) 
        {
           
            int ApplicationID = 0;
            int LicenseClassID=0;


            if(clsDALocaleDrivingLicense.GetLocalDrivingLicenseApplicationByID(LocalDrivingLicenseApplicationID,ref ApplicationID,ref LicenseClassID))
            {
                clsApplicationData Application = clsApplicationData.Find(ApplicationID);

                return new clsLocalDrivingLicenseAppliaction
                    (
                        LocalDrivingLicenseApplicationID,
                        Application.ApplicationID,
                        Application.ApplicantPersonID,
                        Application.ApplicationDate,
                        Application.ApplicationTypeID,
                        (enApplicationsStatus)Application.ApplicationStatus, 
                        Application.LastStatusDate,
                        Application.PaidFees, Application.CreatedByUserID, 
                        LicenseClassID
                    );
                 
            }
            return null;
        }
            
        public static DataTable GetAllLocalDrivingLicenseApplicationRecordes()
        {
            return clsDALocaleDrivingLicense.GetAllLocalDrivingLicenseApplication();
        }

        public static bool DeleteLocalDrivingApplication(int LocalDrivingLicenseApplicationID,int ApplicationID)
        {
            return clsDALocaleDrivingLicense.DeleteLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID,ApplicationID);
        }
        

    }
}
