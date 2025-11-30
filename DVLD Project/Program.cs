
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Project;

namespace DVLD_Project
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmAddNewPerson(1048));
            //Application.Run(new frmManageUsers());
            //Application.Run(new frmManageTestTypes());
            //Application.Run(new frmManageUsers());
            //Application.Run(new ManagePeople());
            //Application.Run(new frmManageLocalDrivingLicense());
            //Application.Run(new frmIssueDrivingLicenseForTheFirstTime(33));
            Application.Run(new frmMainScreen());
            //Application.Run(new frmManageLocalDrivingLicense());

        }
    }
}
