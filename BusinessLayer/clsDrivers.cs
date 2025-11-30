//using DataAccessLayerLib;
using DVLD_BusinessLayer;
using DVLD_DataAccessLayerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsDrivers
    {
        public enum enMode
        {
            eAdd = 1,
            eUpdate,
            eDelete,
            eEmpty
        }

        static enMode eMode;
        //Create Drivers DataAccess

        int _DriverID;
        int _PersonID;
        int _CreatedByUserID;
        DateTime _CreatedDate;
        clsUsers _User;
        clsPerson1 _Person;
        public clsDrivers() 
        {
            _DriverID =0 ;
            _PersonID = 0;
            _CreatedByUserID = 0 ;
            _CreatedDate = DateTime.Now;
            eMode = enMode.eAdd;
        }

        public clsDrivers(int driverID, int personID, int createdByUserID, DateTime createdDate)
        {
            _DriverID = driverID;
            _PersonID = personID;
            _CreatedByUserID = createdByUserID;
            _CreatedDate = createdDate;

            _Person = clsPerson1.Find(personID);
            _User = clsUsers.Find(createdByUserID);
            eMode = enMode.eUpdate;
        }

        public int DriverID { get => _DriverID; set => _DriverID = value; }
        public int PersonID { get => _PersonID; set => _PersonID = value; }
        public int CreatedByUserID { get => _CreatedByUserID; set => _CreatedByUserID = value; }
        public DateTime CreatedDate { get => _CreatedDate; set => _CreatedDate = value; }
        public clsUsers User { get => _User; }
        public clsPerson1 Person { get => _Person; }

        public bool Save()
        {
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
            _DriverID = clsDALDrivers.AddNewDriver( _PersonID, _CreatedByUserID, _CreatedDate);
            return _DriverID != -1;
        }

        private bool _Update()
        {
            return clsDALDrivers.UpdateDriver(_DriverID, _PersonID, _CreatedByUserID, _CreatedDate);
        }

        public bool Delete()
        {
            eMode = enMode.eDelete;
            return clsDALDrivers.DeleteDriver(_DriverID);
        }

        public static clsDrivers Find(int DriverID)
        {

            int PersonID = 0;
            int CreatedByUserID = 0;
            DateTime CreatedDate = DateTime.Now;

            if(clsDALDrivers.GetDriverByID(DriverID,ref PersonID,ref CreatedByUserID,ref CreatedDate))
            {
                return new clsDrivers(DriverID, PersonID, CreatedByUserID, CreatedDate);
            }

            return null;
        }

        public static int IsThisPersonIsADriver(int PersonID)
        {
            int num = clsDALDrivers.IsThisPersonIsADriver(PersonID);
            

            return num;
        }



    }
}
