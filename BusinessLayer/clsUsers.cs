using DVLD_DataAccessLayerLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DVLD_BusinessLayer
{
    public class clsUsers
    {

        public enum enMode
        {
            eAdd = 1,
            eUpdate,
            eDelete,
            eEmpty
        }

         enMode eMode;
        private int _UserID;
        private int    _PersonID; 
        private string _UserName;
        private string _Password;
        private bool   _IsActive;
        private int    _Permissoins;


        public  clsPerson1 _Person;
        private clsUsers()
        {
            _PersonID = 0;
            _UserName="";
            _Password="";
            _IsActive=false;
            _Permissoins = 0;
            _Person = null;
            eMode = enMode.eAdd;
        }
        public clsUsers(int UserID,int personID, string userName, string password, bool isActive, int permissoins)
        {
            _UserID = UserID;
            _PersonID = personID;
            _UserName = userName;
            _Password = password;
            _IsActive = isActive;
            _Permissoins = permissoins;
            eMode = enMode.eUpdate;


        }
        public int PersonID
        {
            get { return _PersonID; }
            set { _PersonID = value; }

        }
        public int UserID
        {
            get { return _UserID; }
        }
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }

        }
        public bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
        public int Permissoins
        {
            get { return _Permissoins; }
            set { _Permissoins = value; }
        }
        public  clsPerson1 Person
        {
            get { return clsPerson1.Find(_PersonID); }
            set { _Person = value; }
        }
        private bool _Add()
        {

            _UserID = clsDALUsers.AddNewUser(_PersonID, _UserName, _Password,_IsActive,_Permissoins);
            return _UserID > 0;
        }
        public static clsUsers AddNewUser()
        {
            return new clsUsers();
        }
        private bool _Update()
        {
            return clsDALUsers.UpdateUser(_UserID,_PersonID, _UserName, _Password,_IsActive,_Permissoins);
        }
        private bool _Delete()
        {
            return clsDALUsers.DeleteUser(_UserID);
        }

        public bool HasRelations(int UserID)
        {
            eMode = enMode.eDelete;
            return true;
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

                case enMode.eDelete:
                    {
                        if (_Delete())
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
        public static clsUsers Find(int UserID)
        {
            int     PersonID = 0;
            string  Password = "";
            string  UserName  =  "";
            bool    IsActive = false;
            int     Permissoins = 0;

            if(clsDALUsers.GetUserInfoByUserID(UserID,ref PersonID ,ref UserName ,ref Password,ref IsActive ,ref Permissoins ))
            {
                return new clsUsers(UserID,  PersonID,  UserName,  Password,  IsActive,  Permissoins);
            }
            return null;
        }
        public static clsUsers Find(string UserName)
        {
            int UserID = 0;
            int     PersonID = 0;
            string  Password = "";
            //string  UserName  =  "";
            bool    IsActive = false;
            int     Permissoins = 0;

            if (clsDALUsers.GetUserInfoByUserName(UserName,  ref PersonID   , ref UserID, ref Password,ref IsActive ,ref Permissoins ))
            {
                return new clsUsers(UserID,  PersonID,  UserName,  Password,  IsActive,  Permissoins);
            }
            return null;
        }
        
        public static clsUsers FindByPersonID(int PersonID)
        {
             int     UserID = 0;
            string  Password = "";
            string  UserName  =  "";
            bool    IsActive = false;
            int     Permissoins = 0;

            if(clsDALUsers.GetUserInfoByPersonID(PersonID, ref UserID , ref UserName ,ref Password,ref IsActive ,ref Permissoins ))
            {
                return new clsUsers(UserID,  PersonID,  UserName,  Password,  IsActive,  Permissoins);
            }
            return null;
        }
        public static clsUsers ChechUserNameAndPassword(string UserName,string Password)
        {

            int UserID = 0;
            int PersonID = 0;
            //string Password = "";
            //string  UserName  =  "";
            bool IsActive = false;
            int Permissoins = 0;

            if (clsDALUsers.GetUserInfoByUserNameAndPassword(UserName, Password, ref PersonID, ref UserID, ref IsActive, ref Permissoins))
            {
                return new clsUsers(UserID, PersonID, UserName, Password, IsActive, Permissoins);
            }

            return null;
        }
        
        public static DataTable GetAllUsers()
        {
            return clsDALUsers.GetAllUsers();
        }

        public static bool IsUserNameExists(string UserName)
        {
            return clsDALUsers.IsUserExist(UserName);
        }
        public static bool IsPersonExists(int PersonID)
        {
            return clsDALUsers.IsUserExistByPersonID(PersonID);
        }

    }
}
