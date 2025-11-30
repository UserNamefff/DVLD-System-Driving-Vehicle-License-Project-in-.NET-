using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLD_Project.Globle_Classes
{
    public class clsValidatoin
    {

        public static bool IsEmailMatch(string Email) 
        {
            //string Pattern = @"^[a-zA-Z0-9.!=+-%_(|)\`/{|}~]+@[^@\s]+\.[^@\s]+$";

            string pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9]+)*$ ";

            Regex reg = new Regex(pattern);

            return reg.IsMatch(Email);
        }




    }
}
