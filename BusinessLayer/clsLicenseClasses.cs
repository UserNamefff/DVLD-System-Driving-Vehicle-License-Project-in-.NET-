using DVLD_DataAccessLayerLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsLicenseClasses
    {
        enum enMode { eAdd, eUpdate, Delete }
        enMode _eMode;

        private int    _LicenseClassID;
        private string _ClassName;
        private string _ClassDescription;
        private int    _MinimumAllowedAge;
        private int    _DefaultValidityLength;
        private double _ClassFees;

        public clsLicenseClasses()
        {
            _LicenseClassID = 0;
            _ClassName = "";
            _ClassDescription = "";
            _MinimumAllowedAge = 0;
            _DefaultValidityLength = 0;
            _ClassFees = 0.0;
            _eMode = enMode.eAdd;
        }

        public clsLicenseClasses(int licenseClassID, string className, string classDescription, int minimumAllowedAge, int defaultValidityLength, double classFees)
        {
            _LicenseClassID         = licenseClassID;
            _ClassName              = className;
            _ClassDescription       = classDescription;
            _MinimumAllowedAge      = minimumAllowedAge;
            _DefaultValidityLength  = defaultValidityLength;
            _ClassFees              = classFees;
            _eMode = enMode.eUpdate;
        }
        public int LicenseClassID { set { _LicenseClassID = value; } get { return _LicenseClassID; } }
        public int MinimumAllowedAge { set { _MinimumAllowedAge = value; } get { return _MinimumAllowedAge; } }
        public int DefaultValidityLength { set { _DefaultValidityLength = value; } get { return _DefaultValidityLength; } }
        public string ClassName { set { _ClassName = value; } get { return _ClassName; } }
        public double ClassFees { set { _ClassFees = value; } get { return _ClassFees; } }
        public string ClassDescription { set { _ClassDescription = value; } get { return _ClassDescription; } }




        private bool _Update()
        {
            return clsDALLincenseClasses.UpdateLicenseClass(_LicenseClassID, _ClassName, _ClassDescription, _MinimumAllowedAge, _DefaultValidityLength, _ClassFees);
        }

        private bool _Add()
        {
            _LicenseClassID = clsDALLincenseClasses .AddNewLicenseClass(_ClassName, _ClassDescription,_MinimumAllowedAge,_DefaultValidityLength, _ClassFees);
            return _LicenseClassID > 0;
        }

        private bool Delete()
        {
            return false;

        }


        public bool Save()
        {
            switch (_eMode)
            {
                case enMode.eUpdate:
                    if (!_Update())
                    {
                        return false;
                    }

                    return true;

                case enMode.eAdd:
                    if (!_Add())
                    {
                        return false;
                    }
                    return true;
                default: return false;
            }

            return false;
        }


        public static clsLicenseClasses Find(int ClassID)
        {
            string ClassName = "";
            string LicenseClassDescription = "";
            double ClassFee = 0.0;
            int MinimumAllowedAge = 0;
            int defaultValidityLength=0;
            double ClassFees = 0;

            if (clsDALLincenseClasses.GetLicenseClassByID(ClassID, ref ClassName, ref LicenseClassDescription,ref MinimumAllowedAge,ref defaultValidityLength, ref ClassFee))
            {
                return new clsLicenseClasses(ClassID, ClassName, LicenseClassDescription,MinimumAllowedAge,defaultValidityLength, ClassFee);
            }
            return null;

        }
        public static clsLicenseClasses Find(string ClassName )
        {
            int ClassID = 0;
            //string ClassName = "";
            string LicenseClassDescription = "";
            double ClassFee = 0.0;
            int MinimumAllowedAge = 0;
            int defaultValidityLength=0;
            double ClassFees = 0;

            if (clsDALLincenseClasses.GetLicenseClassByClassName(ClassName, ref  ClassID, ref LicenseClassDescription,ref MinimumAllowedAge,ref defaultValidityLength, ref ClassFee))
            {
                return new clsLicenseClasses(ClassID, ClassName, LicenseClassDescription,MinimumAllowedAge,defaultValidityLength, ClassFee);
            }
            return null;

        }

        public static DataTable GetAllLicenseClasses()
        {
            return clsDALLincenseClasses.GetAllLicenseClasses();
        }


    }
}
