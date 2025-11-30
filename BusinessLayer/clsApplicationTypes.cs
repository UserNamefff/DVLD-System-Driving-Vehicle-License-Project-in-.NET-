using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayerLib;

namespace DVLD_BusinessLayer
{
    public class clsApplicationTypes
    {
        enum enMode {eAdd,eUpdate,Delete}
        enMode _eMode;
        private int    _ApplicationTypeID;
        private string _ApplicationTypeTitle;
        private double _ApplicationFees;

      public int    ApplicationTypeID { set { _ApplicationTypeID = value; } get { return _ApplicationTypeID; } }
      public string ApplicationTypeTitle { set { _ApplicationTypeTitle = value; } get { return _ApplicationTypeTitle; } }
      public double ApplicationFees { set { _ApplicationFees = value; } get { return _ApplicationFees; } }


        private clsApplicationTypes(int applicationTypeID, string applicationTypeTitle, double applicationFees)
        {
            _ApplicationTypeID = applicationTypeID;
            _ApplicationTypeTitle = applicationTypeTitle;
            _ApplicationFees = applicationFees;
            _eMode = enMode.eUpdate;
        }

        private clsApplicationTypes()
        {
            _ApplicationTypeID = 0;
            _ApplicationTypeTitle = "";
            _ApplicationFees = 0.0;
            _eMode = enMode.eAdd;
        }

        private bool _Update()
        {
            return clsDALApplicationTypes.UpdateApplicationType(_ApplicationTypeID,_ApplicationTypeTitle, _ApplicationFees);
        }

        private bool _Add()
        {

            _ApplicationTypeID = clsDALApplicationTypes.AddNewApplicationType(_ApplicationTypeTitle, _ApplicationFees);
            return _ApplicationTypeID > 0;
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


        public static clsApplicationTypes Find (int ApplicationTypeID)
        {
            string ApplicationTitle = "";
            double ApplicationTypeFee = 0.0;

            if(clsDALApplicationTypes.GetApplicationTypeByID(ApplicationTypeID, ref ApplicationTitle, ref ApplicationTypeFee))
            {
                return new clsApplicationTypes(ApplicationTypeID,  ApplicationTitle,  ApplicationTypeFee);
            }
            return null;

        }

        public static clsApplicationTypes Find (string ApplicationTypeTitle)
        {
            int ApplicationTypeID = 0;
            //string ApplicationTypeTitle = "";
            double ApplicationFees = 0.0;

            if(clsDALApplicationTypes.GetApplicationTypeByTitle(ApplicationTypeTitle ,ref ApplicationTypeID,ref ApplicationFees))
            {
                return new clsApplicationTypes(ApplicationTypeID, ApplicationTypeTitle, ApplicationFees);
            }

            return null;
        }
        public static DataTable GetAllApplicationTypes()
        {
            return clsDALApplicationTypes.GetAllApplicationTypes();
        }

    }
}
