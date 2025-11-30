using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Project
{
    public static class clsGlobleUser
    {
        public static clsUsers CurrentUser ;

        public static int UserID
        {
            get
            {

                if (CurrentUser == null)
                {
                    return 1;
                }
                return CurrentUser.UserID;
            }

        } 
        public static string UserName
        {
            get
            {

                if (CurrentUser == null)
                {
                    return "User Not Found";
                }
                return CurrentUser.UserName;
            }

        } 
    }
}
