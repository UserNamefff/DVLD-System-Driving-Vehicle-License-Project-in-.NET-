using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DVLD_Project
{
    public partial class ctrlPersonal_Details : UserControl
    {
        private int _PersonID;
        public ctrlPersonal_Details(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;

        }
        public ctrlPersonal_Details()
        {
            InitializeComponent();
            

        }

        public int PersonID
        {
            get { return _PersonID; } set { _PersonID = value; }
        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void gbxpersonInfo_Enter(object sender, EventArgs e)
        {

        }
        clsPerson1 Person;
        private void ctrlPersonal_Details_Load(object sender, EventArgs e)
        {

            Person = clsPerson1.Find(_PersonID);
            if (Person != null)
            {
                lblAddress.Text = Person.Adrress;
                lblBirthOfDate.Text = Person.DateOfBirth.ToString();
                lblName.Text = Person.FName + Person.SecondName + Person.ThirdName + Person.LName;
                lblGender.Text = Person.Gender;
                lblCountry.Text = clsCountry.Find(Person.CountryID).CountryName;
                lblEmail.Text = Person.Email;
                lblPhone.Text = Person.PhoneNumber;
                //pkiPersonImage.Image = Image.FromFile((Person.ImagePath));
                lblID.Text = Person.ID.ToString();

            }
        }

                string PathImage = @"C:\Image For DVLD Project\";
        public  void LoadPersonInfo(int PersonID)
        {
            _PersonID = PersonID;
            Person = clsPerson1.Find(_PersonID);

            if (Person != null)
            {
                string s = "Image1.png";
                lblAddress.Text = Person.Adrress;
                lblBirthOfDate.Text = Person.DateOfBirth.ToString();
                lblName.Text = Person.FName + Person.SecondName + Person.ThirdName + Person.LName;
                lblGender.Text = Person.Gender;
                lblCountry.Text = clsCountry.Find(Person.CountryID).CountryName;
                lblEmail.Text = Person.Email;
                lblNationalNO.Text = Person.NationalNO;
                lblPhone.Text = Person.PhoneNumber;
                lblID.Text = _PersonID.ToString();

                try
                {
                    pkiPersonImage.Image = Image.FromFile((PathImage +s));

                }
                catch(Exception e)
                {

                }
            }
        }

        private void llblEditeImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (opfdEditingImage.ShowDialog() == DialogResult.OK)
            {
                Person.ImagePath = Path.GetFileName(opfdEditingImage.FileName);

                if( MessageBox.Show("Changed Image Successfully ", "InFo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Person.Save();
                    pkiPersonImage.Image = Image.FromFile(PathImage+Person.ImagePath);
                }
            }
        }
    }
}
