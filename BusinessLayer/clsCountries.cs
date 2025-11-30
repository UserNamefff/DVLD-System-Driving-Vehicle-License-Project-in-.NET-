using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DVLD_DataAccessLayerLib;

namespace DVLD_BusinessLayer
{
    public class clsCountry
    {
        public enum _enMode
        {
            EmptyMode,
            UpdateMode,
            AddedMode
        }
        
        public enum enSaveResulte
        {
            svFailedsaveResulte,
            svSuccessfulSaveResult,
            svAddedSuccussFully
        }

        private int _CountryID;

        private string _CountryName;

        private string _CountryCode;

        public _enMode _Mode;

        public int CountryID
        {
            get
            {
                return _CountryID;
            }
            set
            {
                _CountryID = value;
            }
        }

        public string CountryName
        {
            get
            {
                return _CountryName;
            }
            set
            {
                _CountryName = value;
            }
        }

        public string CountryCode
        {
            get
            {
                return _CountryCode;
            }
            set
            {
                _CountryCode = value;
            }
        }

        public clsCountry()
        {
            _CountryID = -1;
            _CountryName = "";
           // _CountryCode = "";
            _Mode = _enMode.AddedMode;
        }

        private clsCountry(_enMode Mode, int CountryID, string CountryName)
        {
            _CountryID = CountryID;
            _CountryName = CountryName;
           // _CountryCode = CountryCode;
            _Mode = Mode;
        }

        public bool IsEmpty()
        {
            return _Mode == _enMode.EmptyMode;
        }

        private bool _AddNew()
        {
            _CountryID = clsDACountries.AddNewCountry( _CountryName);
            return _CountryID != -1;
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case _enMode.UpdateMode:
                    _Update();
                    return true;
                case _enMode.AddedMode:
                    if (_AddNew())
                    {
                        _Mode = _enMode.UpdateMode;
                        return true;
                    }

                    break;
            }

            return false;
        }

        public static bool IsExistCountry(int CountryID)
        {
            return clsDACountries.IsExistCountry(CountryID);
        }

        private bool _Update()
        {
            return clsDACountries.UpdateCountry(_CountryID, _CountryName);
        }

        public void Delete()
        {
        }

        public static clsCountry Find(int CountryID)
        {
            _enMode enMode = _enMode.UpdateMode;
            string CountryName = "";
            string CountryCode = "";
            if (clsDACountries.GetCountryByID(CountryID,  ref CountryName))
            {
                return new clsCountry(_enMode.UpdateMode, CountryID,  CountryName);
            }

            return null;
        }

        public static clsCountry Find(string CountryName)
        {
            _enMode enMode = _enMode.UpdateMode;
            int ID = -1;
            string CountryCode = "";
            if (clsDACountries.GetCountryByID(CountryName, ref ID))
            {
                return new clsCountry(_enMode.UpdateMode, ID,  CountryName);
            }

            return null;
        }

        public static DataTable GetAllCountries()
        {
            DataTable allCountries = clsDACountries.GetAllCountries();
            if (allCountries != null)
            {
                return allCountries;
            }

            return null;
        }
    }
}
