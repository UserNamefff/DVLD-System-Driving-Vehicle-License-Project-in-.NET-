using DVLD_DataAccessLayerLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DVLD_BusinessLayer
{
    public class clsTestTypes
    {
       
            enum enMode { eAdd, eUpdate, Delete }
            enMode _eMode;
            private int _TestTypeID;
            private string _TestTypeTitle;
            private string _TestTypeDescription;
            private double _TestFees;

            public int TestTypeID { set { _TestTypeID = value; } get { return _TestTypeID; } }
            public string TestTypeTitle { set { _TestTypeTitle = value; } get { return _TestTypeTitle; } }
            public double TestFees { set { _TestFees = value; } get { return _TestFees; } }
            public string TestTypeDescription { set { _TestTypeDescription = value; } get { return _TestTypeDescription; } }


            private clsTestTypes(int TestTypeID, string TestTypeTitle,string TestTypeDescription, double TestFees)
            {
                _TestTypeID = TestTypeID;
                _TestTypeTitle = TestTypeTitle;
                _TestFees = TestFees;
                _TestTypeDescription = TestTypeDescription; 
                _eMode = enMode.eUpdate;
            }

            private clsTestTypes()
            {
                _TestTypeID = 0;
                _TestTypeTitle = "";
                _TestFees = 0.0;
            _TestTypeDescription = "";
                _eMode = enMode.eAdd;
            }

            private bool _Update()
            {
                return clsDALTestTypes.UpdateTestType(_TestTypeID, _TestTypeTitle, _TestTypeDescription, _TestFees);
            }

            private bool _Add()
            {

                _TestTypeID = clsDALTestTypes.AddNewTestType(_TestTypeTitle, _TestTypeDescription, _TestFees);
                return _TestTypeID > 0;
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


            public static clsTestTypes Find(int TestTypeID)
            {
                string TestTitle = "";
                string TestTypeDescription = "";
                double TestTypeFee = 0.0;

                if (clsDALTestTypes.GetTestTypeByID(TestTypeID, ref TestTitle,ref TestTypeDescription , ref TestTypeFee))
                {
                    return new clsTestTypes(TestTypeID, TestTitle, TestTypeDescription, TestTypeFee);
                }
                return null;

            }

            public static DataTable GetAllTestTypes()
            {
                return clsDALTestTypes.GetAllTestTypes();
            }
        

    }
}
