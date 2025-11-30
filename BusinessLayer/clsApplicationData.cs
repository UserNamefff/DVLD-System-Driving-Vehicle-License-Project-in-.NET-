using DVLD_DataAccessLayerLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsApplicationData
    {
        protected enum enMode { eAdd,eDelete,eUpdate}
        public enum enApplicationsStatus { eNew=1,eCanceled,eCompleted}

        public enum enApplicationType
        {
            NewLocalDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
        };
        

        public enApplicationsStatus eStatus;
        protected enMode _eMode;

        private int _ApplicantPersonID; 
        private DateTime _ApplicationDate; 
        private int _ApplicationTypeID;
        private byte _ApplicationStatus; 
        private DateTime _LastStatusDate;
        private float _PaidFees;
        private int _CreatedByUserID;
        public int _ApplicationID;
        
        private  clsApplicationTypes applicationTypes1;
        private clsPerson1 _Person1;

        public clsApplicationData()
        {
            _ApplicationID  = 0;
            _ApplicationStatus = 1;
            _ApplicantPersonID = 0;
            _ApplicationTypeID = 0;
            _PaidFees = 0;
            _CreatedByUserID = 0;
            _ApplicationDate =DateTime.Now;
            _LastStatusDate = DateTime.Now;
            _eMode = enMode.eAdd;
            eStatus = enApplicationsStatus.eNew;
            
        }
        // intial to delete Application
        public clsApplicationData(int ApplicationID)
        {
            _ApplicationID = ApplicationID;
            _eMode = enMode.eDelete;

        }

        private clsApplicationData(int ApplicationID ,int applicantPersonID, DateTime applicationDate, int applicationTypeID, 
                                    byte applicationStatus, DateTime lastStatusDate, 
                                    float paidFees, int createdByUserID)
        {
            _ApplicantPersonID   = applicantPersonID;
            _ApplicationID = ApplicationID;
            _ApplicationDate     = applicationDate;
            _ApplicationTypeID   = applicationTypeID;
            _ApplicationStatus   = applicationStatus;
            _LastStatusDate      = lastStatusDate;
            _PaidFees            = paidFees;
            _CreatedByUserID     = createdByUserID;
            applicationTypes1 = clsApplicationTypes.Find(applicationTypeID);
            _Person1 = clsPerson1.Find(applicantPersonID);
            _eMode = enMode.eUpdate;
        }

        public clsApplicationData(int applicantPersonID,  int applicationTypeID, float paidFees, int createdByUserID)
        {
            _ApplicationID = 0;
            _ApplicationStatus = 0;
            _ApplicantPersonID = applicantPersonID;
            _ApplicationTypeID = applicationTypeID;
            _PaidFees = paidFees;
            _CreatedByUserID = createdByUserID;
            _ApplicationDate = DateTime.Now;
            _LastStatusDate = DateTime.Now;
            _eMode = enMode.eAdd;
            eStatus = enApplicationsStatus.eNew;
            applicationTypes1 = clsApplicationTypes.Find(applicationTypeID);
            _Person1 = clsPerson1.Find(applicantPersonID);

        }

        clsApplicationTypes ApplicationTypes
        {
            get { return ApplicationTypes1; }

        }

        public clsPerson1 Person { get => _Person1; }
        public int ApplicationID
        {
            get { return _ApplicationID;}
        }
        public int ApplicantPersonID
        {
            get { return _ApplicantPersonID; }
            set { _ApplicantPersonID = value; }
        }
        public DateTime ApplicationDate
        {
            get { return _ApplicationDate; }
            set { _ApplicationDate = value; }
            
        }
        public int ApplicationTypeID
        {
            get { return _ApplicationTypeID; }
            set { _ApplicationTypeID = value; }
        }
        public byte ApplicationStatus
        {
            get { return _ApplicationStatus; }
            set { _ApplicationStatus = value; }
        }
        public DateTime LastStatusDate
        {
            get { return _LastStatusDate; }
            set { _LastStatusDate = value; }
        }
        public float PaidFees
        {
            get { return _PaidFees; }
            set { _PaidFees = value; }
        }
        public int CreatedByUserID
        {
            get { return (int) _CreatedByUserID; }
            set { _CreatedByUserID = value; }
        }

        public  clsApplicationTypes ApplicationTypes1 { get => applicationTypes1;  }

        private bool _Add()
        {
            _ApplicationID = clsDAApplicationData.AddNewApplication(_ApplicantPersonID, _ApplicationDate, ApplicationTypeID, (byte)eStatus, _LastStatusDate, _PaidFees, _CreatedByUserID);
          return _ApplicationID >0;
        }
        private bool _Update()
        {
            return clsDAApplicationData.UpdateApplication(_ApplicationID, _ApplicantPersonID, _ApplicationDate, _ApplicationTypeID, _ApplicationStatus, _LastStatusDate, _PaidFees, _CreatedByUserID);
        }
        private bool _Delete()
        {
            return clsDAApplicationData.DeleteApplication(_ApplicationID);
        }
        public  bool Delete()
        {
            _eMode = enMode.eDelete;
            return Save();
        }
        public  bool Save()
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
                
                    if(_Delete()) 
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
        private static byte _ChooseStatus(byte status)
        {
            switch (status)
            {
                case 1:
                    {
                        return (byte)enApplicationsStatus.eNew;
                    }
                case 2:
                    {
                        return (byte)enApplicationsStatus.eCanceled;
                    }
                case 3:
                    {
                        return (byte)enApplicationsStatus.eCompleted;
                    }
                default:
                    break;

            }
            return 0;
        }
        public static bool UpdateStatus(int ApplicationID,byte Status)
        {
            return clsDAApplicationData.UpdateStatus(ApplicationID, _ChooseStatus(Status));
        }
        public static clsApplicationData Find(int ApplicationID)
        {
            //int ApplicationID = 0;
            int ApplicantPersonID = 0;
            DateTime ApplicationDate = DateTime.Now;
            int ApplicationTypeID = 0;
            byte ApplicationStatus = 0;
            DateTime LastStatusDate = DateTime.Now;
            float PaidFees = 0;
            int CreatedByUserID = 0;

            if(clsDAApplicationData.GetApplicationInfoByID (ApplicationID,ref ApplicantPersonID,ref ApplicationDate ,ref ApplicationTypeID,ref ApplicationStatus,ref LastStatusDate,ref PaidFees,ref CreatedByUserID))
            {
                return new clsApplicationData(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            }
            return null;
        }
        public DataTable GetAllApplicationData()
        {
            return clsDAApplicationData.GetAllApplications();
        }
        public static int GetActiveApplicationIDForLicenseClass(int ApplicationPersonID,int ApplicationTypeID,int LicenseClassID)
        {
            return clsDAApplicationData.GetActiveApplicationIDForLicenseClass(ApplicationPersonID, ApplicationTypeID, LicenseClassID);
        }
        public static bool DoesPersonHaveActiveApplicationToSameLDLicenseClass(int ApplicationPersonID, int ApplicationTypeID, int LicenseClassID)
        {
            return GetActiveApplicationIDForLicenseClass(ApplicationPersonID, ApplicationTypeID, LicenseClassID)> - 1;
        }
        public static bool IsActiveApplication(int ApplicationID) 
        {
            return clsDAApplicationData.IsApplicationExist(ApplicationID);
        }
        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {
            return clsDAApplicationData.DoesPersonHaveActiveApplication(PersonID, ApplicationTypeID);
        }

        public static bool IsApplicationComplited(int ApplicationID)
        {
            return clsDAApplicationData.IsApplicationComplited(ApplicationID);
        }


    }
}
