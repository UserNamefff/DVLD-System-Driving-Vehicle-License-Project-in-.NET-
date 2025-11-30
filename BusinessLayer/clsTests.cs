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
    public class clsTests
    {

        int _TestAppointmentID;
        int _TestID;
        bool _TestResult;
        string _Notes; 
        int _CreatedByUserID;

        clsTestAppointments _TestAppointments;
        public clsTests(int testID,int testAppointmentID,  bool testResult, string notes, int createdByUserID)
        {
            _TestAppointmentID = testAppointmentID;
            _TestID = testID;
            _TestResult = testResult;
            _Notes = notes;
            _CreatedByUserID = createdByUserID;

            _TestAppointments = clsTestAppointments.Find(testAppointmentID);
        }
        public clsTests()
        {
            _TestAppointmentID = 0;
            _TestID = 0;
            _TestResult = false;
            _Notes = "";
            _CreatedByUserID = 0;

            //_TestAppointments = clsTestAppointments.Find(testAppointmentID);
        }

        public clsTestAppointments TestAppointments { get => _TestAppointments; }
        public int CreatedByUserID { get => _CreatedByUserID; set => _CreatedByUserID = value; }
        public int TestAppointmentID { get => _TestAppointmentID; set => _TestAppointmentID = value; }
        public int TestID { get => _TestID; set => _TestID = value; }
        public bool TestResult { get => _TestResult; set => _TestResult = value; }
        public string Notes { get => _Notes; set => _Notes = value; }
        private bool _Add()
        {
           _TestID = clsDALTests.AddNewTest(_TestAppointmentID,_TestResult,_Notes,_CreatedByUserID);

            return _TestID > 0;
        }
        private bool _Update()
        {
           
            return clsDALTests.UpdateTest(_TestID,TestAppointmentID,_TestResult,_Notes,_CreatedByUserID);
        }
        private bool _Delete()
        {

            return false;// clsDALTests.Delete(_TestID,TestAppointmentID,_TestResult,_Notes,_CreatedByUserID);
        }
        public bool Save()
        {
            if(this != null)
            {
                return _Add();
            }
            return false;
        }
        public static clsTests Find(int testID)
        {
            int testAppointmentID = 0;
            bool testResult = false;
            string notes = "";
            int createdByUserID = 0;

            if(clsDALTests.GetTestInfoByID(testID,ref testAppointmentID,ref testResult,ref notes,ref createdByUserID))
            {
                return new clsTests(testID, testAppointmentID, testResult, notes, createdByUserID);
            }

            return null;
        }
        public static bool IsTested(int AppointmentTestID)
        {
            return clsDALTests.IsTested(AppointmentTestID);
        }



    }
}
