using DVLD_BusinessLayer;
using DVLD_Project.Properties;
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

        
        private int _PersonID  = -1;
        public ctrlPersonal_Details(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;

        }
        public ctrlPersonal_Details()
        {
            InitializeComponent();

            _PersonID = -1;
        }

        public int PersonID
        {
            get { return _PersonID; } 
        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void gbxpersonInfo_Enter(object sender, EventArgs e)
        {

        }
        clsPerson1 _Person;
        public clsPerson1 Person
        {
            get { return _Person; }
        }
        private void ctrlPersonal_Details_Load(object sender, EventArgs e)
        {

            _Person = clsPerson1.Find(_PersonID);
            if (_Person != null)
            {
                lblAddress.Text = _Person.Adrress;
                lblBirthOfDate.Text = _Person.DateOfBirth.ToString();
                lblName.Text = _Person.FName + _Person.SecondName + _Person.ThirdName + _Person.LName;
                lblGender.Text = _Person.Gender;
                lblCountry.Text = clsCountry.Find(_Person.CountryID).CountryName;
                lblEmail.Text = _Person.Email;
                lblPhone.Text = _Person.PhoneNumber;
                //pkiPersonImage.Image = Image.FromFile((_Person.ImagePath));
                lblID.Text = _Person.ID.ToString();

            }
        }

        //string PathImage = @"C:\Image For DVLD Project\";

        private void _FillPersonInfo()
        {
            _PersonID = _Person.ID;
            lblAddress.Text = _Person.Adrress;
            lblBirthOfDate.Text = _Person.DateOfBirth.ToString();
            lblName.Text = _Person.FName + ' ' + _Person.SecondName + ' ' + _Person.ThirdName + ' ' + _Person.LName;
            lblGender.Text = _Person.Gender;
            lblCountry.Text = clsCountry.Find(_Person.CountryID).CountryName;
            lblEmail.Text = _Person.Email;
            lblNationalNO.Text = _Person.NationalNO;
            lblPhone.Text = _Person.PhoneNumber;
            lblID.Text = _PersonID.ToString();


            try
            {
                pkiPersonImage.Image = Image.FromFile((_Person.ImagePath));

            }
            catch (Exception e)
            {

            }

        }
        public  void LoadPersonInfo(int PersonID)
        {
            
            _Person = clsPerson1.Find(PersonID);

            if (_Person == null)
            {
                MessageBox.Show("No Person with PersonID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }

        private int LoadPersonInfo1(string FirstName)
        {
            
            _Person = clsPerson1.FindByName(FirstName);

            if (_Person != null)
            {
               // string s = "Image1.png";
                _PersonID = _Person.ID;
                lblAddress.Text = _Person.Adrress;
                lblBirthOfDate.Text = _Person.DateOfBirth.ToString();
                lblName.Text = _Person.FName + ' ' + _Person.SecondName + ' ' + _Person.ThirdName + ' ' + _Person.LName;
                lblGender.Text = _Person.Gender;
                lblCountry.Text = clsCountry.Find(_Person.CountryID).CountryName;
                lblEmail.Text = _Person.Email;
                lblNationalNO.Text = _Person.NationalNO;
                lblPhone.Text = _Person.PhoneNumber;
                lblID.Text = _PersonID.ToString();

                try
                {
                    pkiPersonImage.Image = Image.FromFile((_Person.ImagePath));

                }
                catch (Exception e)
                {

                }
                return _PersonID;
            }
            return _PersonID;
        }
        public void LoadPersonInfo(string NationalNO)
        {
            
            _Person = clsPerson1.Find(NationalNO);

            if (_Person == null)
            {
                MessageBox.Show("No _Person with National Number = " + NationalNO, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();

        }
        private void llblEditeImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           /* if (opfdEditingImage.ShowDialog() == DialogResult.OK)
            {
                _Person.ImagePath = Path.GetFileName(opfdEditingImage.FileName);

                if (MessageBox.Show("Changed Image Successfully ", "InFo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    _Person.Save();
                    pkiPersonImage.Image = Image.FromFile(_Person.ImagePath);
                }
            }*/

            frmAddNewPerson frm = new frmAddNewPerson(_Person.ID);
            frm.ShowDialog();

            //Refresh
            LoadPersonInfo(_Person.ID);
        }
        private void gbxpersonInfo_Enter_1(object sender, EventArgs e)
        {

        }
        public void ResetPersonInfo()
        {
            _PersonID = -1;
            lblID.Text = "[????]";
            lblNationalNO.Text = "[????]";
            lblName.Text = "[????]";
            pkiPersonImage.Image = Resources.Man_32;
            lblGender.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";
            lblBirthOfDate.Text = "[????]";
            lblCountry.Text = "[????]";
            lblAddress.Text = "[????]";
            

        }


    }
}
