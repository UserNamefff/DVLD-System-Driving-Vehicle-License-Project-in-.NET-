
using DVLD_BusinessLayer;
using DVLD_DataAccessLayerLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_BusinessLayer
{
    public class clsLicenses
    {
        public enum enMode
        {
            eAdd = 1,
            eUpdate,
            eDelete,
            eEmpty
        }
        enMode eMode;
        enum enIssueReason { FirstTime=1, Renew, ReplacementForDamaged,  ReplacementForLost }

        int _LicenseID, _ApplicationID, _DriverID, _LicenseClassID;
        DateTime _IssueDate, _ExpirationDate;
        string _Notes;
        double _PaidFees;
        bool _IsActive;
        byte _IssueReason;
        int _CreatedByUserID;
        clsDrivers _Drivers;
        clsLicenseClasses _LicenseClasses;
        clsApplicationData _ApplicationData;
        

        
        enIssueReason eIssueReason;

        public clsLicenses(int licenseID, int applicationID, int driverID, int licenseClassID,
                        DateTime issueDate, DateTime expirationDate, string notes, 
                        double paidFees, bool isActive, byte issueReason, int createdByUserID)
        {
            _LicenseID = licenseID;
            _ApplicationID = applicationID;
            _DriverID = driverID;
            _LicenseClassID = licenseClassID;
            _IssueDate = issueDate;
            _ExpirationDate = expirationDate;
            _Notes = notes;
            _PaidFees = paidFees;
            _IsActive = isActive;
            _IssueReason = issueReason;
            _CreatedByUserID = createdByUserID;
        }

        public clsLicenses()
        {
            _LicenseID = 0;
            _ApplicationID = 0;
            _DriverID = 0;
            _LicenseClassID = 0;
            _IssueDate = DateTime.Now;
            _ExpirationDate = DateTime.Now; ;
            _Notes = "";
            _PaidFees = 0.0;
            _IsActive = false;
            _IssueReason = 0;
            _CreatedByUserID = 0;

            eMode = enMode.eAdd;
        }
        public int LicenseID { get => _LicenseID; set => _LicenseID = value; }
        public int ApplicationID { get => _ApplicationID; set => _ApplicationID = value; }
        public int DriverID { get => _DriverID; set => _DriverID = value; }
        public int LicenseClassID { get => _LicenseClassID; set => _LicenseClassID = value; }
        public DateTime IssueDate { get => _IssueDate; set => _IssueDate = value; }
        public DateTime ExpirationDate { get => _ExpirationDate; set => _ExpirationDate = value; }
        public string Notes { get => _Notes; set => _Notes = value; }
        public double PaidFees { get => _PaidFees; set => _PaidFees = value; }
        public bool IsActive { get => _IsActive; set => _IsActive = value; }
        public byte IssueReason { get => _IssueReason; set => _IssueReason = value; }
        public int CreatedByUserID { get => _CreatedByUserID; set => _CreatedByUserID = value; }
        public clsDrivers Drivers { get => _Drivers;}
        public clsLicenseClasses LicenseClasses { get => _LicenseClasses; }
        public clsApplicationData ApplicationData { get => _ApplicationData; }

        public static clsLicenses AddNewLicense()
        {
            return new clsLicenses();
        }
        public bool Save()
        {
            //eMode = enMode.eAdd;
            switch (eMode)
            {
                case enMode.eAdd:
                    if (_Add())
                    {
                        eMode = enMode.eUpdate;
                        return true;
                    }

                    break;

                case enMode.eDelete:
                    {
                        if (Delete())
                        {
                            return true;
                        }
                    }
                    break;

                case enMode.eEmpty:
                    {
                        return false;
                    }
                    break;

                case enMode.eUpdate:
                    {
                        if (_Update())
                        {
                            return true;
                        }
                    }
                    break;
            }

            return false;
        }


        private bool _Add()
        {
            _LicenseID = clsDALLicenses.AddNewLicense( _ApplicationID, _DriverID, _LicenseClassID,_IssueDate,_ExpirationDate,_Notes,_PaidFees,_IsActive,_IssueReason,_CreatedByUserID);
            return _LicenseID != -1;
        }

        private bool _Update()
        {
             
            return clsDALLicenses.UpdateLicense(_LicenseID,_ApplicationID, _DriverID, _LicenseClassID, _IssueDate, _ExpirationDate, _Notes, _PaidFees, _IsActive, _IssueReason, _CreatedByUserID);
        }

        
        public bool Delete()
        {
            eMode = enMode.eDelete;
            return clsDAPeople.DeletePerson(_LicenseID);
        }

        public static DataTable GetAllLicenseForPerson(int PersonID)
        {
            return clsDALLicenses.GetAllLicenseForPerson(PersonID);
        }

        
        public static clsLicenses Find(int LicenseID)
        {
           int ApplicationID = 0, DriverID = 0, LicenseClassID = 0;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = "";
            double PaidFees = 0.0;
            bool IsActive = false;
            byte IssueReason = 0;
            int CreatedByUserID = 0;

            if (clsDALLicenses.GetLicenseByID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClassID, ref IssueDate,  ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive,ref IssueReason, ref CreatedByUserID))
            {
                
                return new clsLicenses(LicenseID,  ApplicationID,  DriverID,  LicenseClassID,  IssueDate,  ExpirationDate,  Notes,  PaidFees,  IsActive,  IssueReason,  CreatedByUserID);
            }

            return null;
        }

        public static bool IsIssuedLicenseByApplication(int ApplicationID)
        {
            return clsDALLicenses.IsIssuedLicenseByApplication(ApplicationID);
        }

    }
}
