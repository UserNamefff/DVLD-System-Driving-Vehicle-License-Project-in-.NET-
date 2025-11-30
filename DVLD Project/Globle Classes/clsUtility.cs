using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Project
{
    public  class clsUtility
    {

        private static string _RandomName()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }

        static string  _DestenationImage = @"C:\\Image For DVLD Project\\";
        public static bool CopyFileToNewDiroctory(ref string ImageLocation)
        {
            FileInfo fileinfo = new FileInfo(ImageLocation);

            if (Directory.Exists(_DestenationImage))
            {
                Directory.CreateDirectory(_DestenationImage);
            }

            if (fileinfo.Exists)
            {
                ImageLocation = _ReplacementFile(fileinfo.Extension);
                
                fileinfo.CopyTo(ImageLocation);

                return true;
            }
            

            return false;
        }

        private static string _ReplacementFile(string ExtentionImage) 
        {
            return _DestenationImage + _RandomName() + ExtentionImage;

        }

    }
}
