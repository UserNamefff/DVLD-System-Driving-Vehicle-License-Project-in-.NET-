using DataAccessLayerLib;
using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsTestAppointments
    {

        protected enum enMode { eAdd, eDelete, eUpdate }
        enMode _eMode;

        int _LocalDrivingLicenseApplicationID;
        int _TestAppointmentID;
        int _TestTypeID;
        DateTime _AppointmentDate;
        double _PaidFees;
        int _CreatedByUserID;
        bool _IsLocked;

        clsTestTypes _TestTypes;


        //Appointment must be has clsLocalDrivingLicenseAppliaction 
        //     and the Appointment must depends to clsLocalDrivingLicenseAppliaction
        private clsLocalDrivingLicenseAppliaction _LocalDrivingLicenseAppliaction;

        private clsTestAppointments()
        {

            _TestAppointmentID = 0;
            _TestTypeID = 0;
            _LocalDrivingLicenseApplicationID = 0;
            _TestAppointmentID = 0;
            _AppointmentDate = DateTime.Now;
            _IsLocked = false;
            _CreatedByUserID = 0;

        }

        public clsTestAppointments(int TestTypeID)
        {

            _TestAppointmentID = 0;
            _TestTypeID = TestTypeID;
            _LocalDrivingLicenseApplicationID = 0;
            _TestAppointmentID = 0;
            _AppointmentDate = DateTime.Now;
            _IsLocked = false;
            _CreatedByUserID = 0;

            _TestTypes = clsTestTypes.Find(TestTypeID);


        }

        public clsTestAppointments(int TestAppointmentID, int localDrivingLicenseApplicationID, int testTypeID, DateTime appointmentDate, double paidFees, int createdByUserID, bool isLocked)
        {
            _TestAppointmentID = TestAppointmentID;
            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            _TestTypeID = testTypeID;
            _AppointmentDate = appointmentDate;
            _PaidFees = paidFees;
            _CreatedByUserID = createdByUserID;
            _IsLocked = isLocked;

            _TestTypes = clsTestTypes.Find(TestTypeID);
            _LocalDrivingLicenseAppliaction = clsLocalDrivingLicenseAppliaction.Find(localDrivingLicenseApplicationID);
        }


        public clsLocalDrivingLicenseAppliaction LocalDrivingLicenseAppliaction { get => _LocalDrivingLicenseAppliaction; }
        public clsTestTypes TestTypes { get => _TestTypes; }
        public int TestAppointmentID { get => _TestAppointmentID; }
        public int LocalDrivingLicenseApplicationID { get => _LocalDrivingLicenseApplicationID; set => _LocalDrivingLicenseApplicationID = value; }
        public int TestTypeID { get => _TestTypeID; set => _TestTypeID = value; }
        public DateTime AppointmentDate { get => _AppointmentDate; set => _AppointmentDate = value; }
        public double PaidFees { get => _PaidFees; set => _PaidFees = value; }
        public int CreatedByUserID { get => _CreatedByUserID; set => _CreatedByUserID = value; }
        public bool IsLocked { get => _IsLocked; set => _IsLocked = value; }


      
        private bool _Add()
        {
            _TestAppointmentID = clsDALTestAppointments.AddNewTestAppointment(_LocalDrivingLicenseApplicationID, _TestTypeID, _AppointmentDate, PaidFees, _CreatedByUserID, IsLocked); ;

            return _TestAppointmentID > 0;
        }

        private bool _Update()
        {
            return clsDALTestAppointments.UpdateTestAppointment(_TestAppointmentID, _LocalDrivingLicenseApplicationID, _TestTypeID, _AppointmentDate, PaidFees, _CreatedByUserID, IsLocked);
        }

        private bool _Delete()
        {

            return clsDALTestAppointments.DeleteTestAppointment(_TestAppointmentID);
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
                        _eMode |= enMode.eUpdate;
                        return true;
                    }
                    break;

                default:
                    break;
            }
            return false;
        }

        public static clsTestAppointments Find(int TestAppointmentID)
        {
            //int TestAppointmentID = 0;

            int TestTypeID = 0;
            double PaidFees = 0.0;
            int LocalDrivingLicenseApplicationID = 0;
            DateTime AppointmentDate = DateTime.Now;
            bool IsLocked = false;
            int CreatedByUserID = 0;


            if (clsDALTestAppointments.GetTestAppointmentByID(TestAppointmentID, ref LocalDrivingLicenseApplicationID,
                ref TestTypeID, ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked))
            {
                return new clsTestAppointments(TestAppointmentID, LocalDrivingLicenseApplicationID,
                 TestTypeID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked);
            }

            return null;
        }
        public static DataTable GetAllTestAppointments(int LocalDrivingLicenseApplicationID,byte TestTypeID)
        {
            return clsDALTestAppointments.GetAllTestAppointments(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static int GetNumberOfTestsSuccessfull(int LocalDrivingLicenseApplicationID)
        {
            return clsDALTestAppointments.GetNumberOfTestsSuccessfull(LocalDrivingLicenseApplicationID);
        }
        public static int GetNumberOfTestsFail(int LocalDrivingLicenseApplicationID)
        {
            return clsDALTestAppointments.GetNumberOfTestsFail(LocalDrivingLicenseApplicationID);
        }

        public static bool IsAppointmentLocked(int AppointmentID)
        {
            return clsDALTestAppointments.IsAppointmentLocked(AppointmentID);
        }
        public static bool IsTest(int AppointmentID)
        {
            return clsDALTestAppointments.IsTested(AppointmentID);
        }
        public static bool LockedTestAppointment(int AppointmentID,bool IsLocked)
        {
            return clsDALTestAppointments.LockedTestAppointment(AppointmentID, IsLocked);
        }

    }
}
