using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerLib;

namespace BusinessLayer
{

    public class clsPerson1
    {
        public enum enMode
        {
            eAdd = 1,
            eUpdate,
            eDelete,
            eEmpty
        }

        enum enGender { Male  , Female }

        //public enGender _eGender;

        private int _ID;

        private string _FName;

        private string _LName;
        private short _GenderNO;
        private string _SecondName;
        private string _ThirdName;
        public string FullName { get { return _FName + _SecondName + _ThirdName + _LName; } }

        private string _Email;                
        
        private string _NationalNO;                

        private string _PhoneNumber;           
                                               
        private string _Gender;

        private string _Address;

        private int _CountryID;

        private DateTime _DateOfBirth;

        private string _ImagePath;

        private enMode eMode;
        private static short _ConvertStringToInt(string sGender)
        {

            return (sGender == "Male") ? (short)enGender.Male 
                                        : (short)enGender.Female;
        }

        private static string _ConvertIntToString(short  GenderNO)
        {
            return (GenderNO == (short)enGender.Male) ? "Male" : "Femal";
        }

        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        public string FName
        {
            get
            {
                return _FName;
            }
            set
            {
                _FName = value;
            }
        }

        public string LName
        {
            get
            {
                return _LName;
            }
            set
            {
                _LName = value;
            }
        }
        
        public string ThirdName
        {
            get
            {
                return _ThirdName;
            }
            set
            {
                _ThirdName = value;
            }
        }

        public string SecondName
        {
            get
            {
                return _SecondName;
            }
            set
            {
                _SecondName = value;
            }
        }

        public string NationalNO
        {
            get { return _NationalNO; }
            set { _NationalNO = value; }
        }
        
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return _PhoneNumber;
            }
            set
            {
                _PhoneNumber = value;
            }
        }

        public string Gender
        {
            get
            {
                return _Gender;
            }
            set
            {
                _Gender = value;
            }
        }
        public short GenderNO
        {
            get { return _GenderNO; }
            set { _GenderNO = value; }
        }
        public string Adrress
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }

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

        public DateTime DateOfBirth
        {
            get
            {
                return _DateOfBirth;
            }
            set
            {
                _DateOfBirth = value;
            }
        }

        public string ImagePath
        {
            get
            {
                return _ImagePath;
            }
            set
            {
                _ImagePath = value;
            }
        }


        public clsPerson1(int iD, string fName, string lName, string secondName, string thirdName, string email, string phoneNumber, string gender, string address, int countryID, DateTime dateOfBirth, string imagePath, enMode eMode ,string nationalNO)
        {
            _ID = iD;
            _FName = fName;
            _LName = lName;
            _SecondName = secondName;
            _ThirdName = thirdName;
            _Email = email;
            _NationalNO = nationalNO;
            _PhoneNumber = phoneNumber;
            _Gender = gender;
            _Address = address;
            _CountryID = countryID;
            _DateOfBirth = dateOfBirth;
            _ImagePath = imagePath;
            this.eMode = eMode;
            
        }

        private clsPerson1()
        {
            _ID = -1;
            _FName = "";
            _LName = "";
            _SecondName = "";
            _Address = "";
            _PhoneNumber = "";
            _Email = "";
            _Gender = "";
            _Address = "";
            _ImagePath = "";
            _DateOfBirth = DateTime.Now;
            _CountryID = 0;
            eMode = enMode.eAdd;
        }

        public static clsPerson1 AddNewPerson()
        {
            return new clsPerson1();
        }
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
                case enMode.eEmpty:
                    return false;
                case enMode.eUpdate:
                    if (Update())
                    {
                        return true;
                    }

                    break;
            }

            return false;
        }
        private bool _Add()
        {
            _GenderNO = _ConvertStringToInt(_Gender);

            _ID = clsDAPeople.AddNewPerson(_FName,_SecondName,_ThirdName, _LName, _Email, _PhoneNumber, _Address, _DateOfBirth, _CountryID, _ImagePath, _GenderNO,_NationalNO);
            return _ID != 0;
        }

        public bool Update()
        {
            _GenderNO = _ConvertStringToInt(_Gender);
            return clsDAPeople.UpdatePerson(_ID,_FName, _SecondName, _ThirdName, _LName, _Email, _PhoneNumber, _Address, _DateOfBirth, _CountryID, _ImagePath, _GenderNO, _NationalNO);
        }

        public bool Delete()
        {
            return clsDAPeople.DeletePerson(_ID);
        }

        public static DataTable GetAllPeople()
        {
            return clsDAPeople.GetAllPeople();
        }

        public static clsPerson1 Find(int PersonID)
        {
            string FirstName = "";
            string LastName = "";
            string SecondName = "";
            string ThirdName = "";
            string Phon = "";
            string Email = "";
            string Gender = "";
            short GenderNO = 0;
            string Address = "";
            int CountryID = 0;
            DateTime DateOfBirth = DateTime.Now;
            string ImagePath = "";
            string NationalNO = "";
            if (clsDAPeople.GetPersonInfoByID(PersonID, ref FirstName, ref SecondName,ref ThirdName, ref LastName, ref Email, ref Phon, ref Address, ref DateOfBirth, ref CountryID, ref ImagePath, ref GenderNO, ref NationalNO))
            {
                Gender = _ConvertIntToString(GenderNO);
                return new clsPerson1(PersonID, FirstName, LastName, SecondName, ThirdName,  Email, Phon,Gender, Address, CountryID, DateOfBirth, ImagePath,enMode.eUpdate,NationalNO);
            }

            return null;
        }

        public static clsPerson1 Find(string NationalNO)
        {
            string FirstName = "";
            string LastName = "";
            string Phon = "";
            string Email = "";
            string Gender = "";
            short GenderN = 0;
            string Address = "";
            int CountryID = 0;
            DateTime DateOfBirth = DateTime.Now;
            string ImagePath = "";
            string SecondName = "";
            string ThirdName = "";
            int PersonID = 0;
            if (clsDAPeople.GetPersonInfoByNationalNumber(NationalNO,ref PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref Email, ref Phon, ref Address, ref DateOfBirth, ref CountryID, ref ImagePath, ref GenderN))
            {
                Gender = _ConvertIntToString(GenderN);
                return new clsPerson1(PersonID, FirstName, LastName, SecondName, ThirdName, Email, Gender, Phon, Address, CountryID, DateOfBirth, ImagePath, enMode.eUpdate, NationalNO);
            }

            return null;
        }
        public static clsPerson1 FindByName(string FirstName)
        {
            string NationalNO = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            short GenderNO = 0;
            string Phon = "";
            string Email = "";
            string Gender = "";

            string Address = "";
            int CountryID = 0;
            DateTime DateOfBirth = DateTime.Now;
            string ImagePath = "";
            int PersonID = 0;
            if (clsDAPeople.GetPersonInfoByName(FirstName, ref PersonID, ref SecondName, ref ThirdName, ref LastName, ref Email, ref Phon, ref Address, ref DateOfBirth, ref CountryID, ref ImagePath, ref GenderNO, ref NationalNO))
            {
                Gender = _ConvertIntToString(GenderNO);
                return new clsPerson1(PersonID, FirstName, LastName, SecondName, ThirdName, Email, Gender, Phon, Address, CountryID, DateOfBirth, ImagePath, enMode.eUpdate, NationalNO);
            }

            return null;
        }

        public static bool IsPersonExists(string NationalNO)
        {
            if (!string.IsNullOrEmpty(NationalNO))
            { 
                 return clsDAPeople.IsPersonExist(NationalNO);
            }
            return false;
        }
    }

}