using BusinessLayer;
using DVLD_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security;

namespace DVLD_Project
{
    public partial class crtlAddPerson : UserControl
    {

        //Devolopment : if The Destnation Path delete where i get Image when get data from database ?   


        public event Action<int> OnReadPersonID;
       
        string _PathImage;
        string _DestenationImage ;
        short GenderID;


        protected virtual void ReadPersonID(int ID)
        {
            Action<int> Handler = OnReadPersonID;

            if (Handler != null)
            {
                Handler(ID);
            }
        }


        public crtlAddPerson()
        {
            InitializeComponent();
            _PathImage = "";
            _DestenationImage = @"C:\\Image For DVLD Project\\";
            GenderID = 0; 
        }
       
        private void crtlAddPerson_Load(object sender, EventArgs e)
        {

        }

        private void txtFName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void rbtnMale_CheckedChanged(object sender, EventArgs e)
        {
            pbxPersonImage.Image = Resources.Male_512;
            GenderID = (short)pbxPersonImage.Tag;
        }

        private void rdbFemal_CheckedChanged(object sender, EventArgs e)
        {
            pbxPersonImage.Image = Resources.Female_512;
            GenderID = (short)rbtnMale.Tag;
        }

        private void txtFName_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtbx = (TextBox)sender;

            if (string.IsNullOrEmpty(txtbx.Text))
            {
                errorProvider1.SetError(txtbx, "this Fielde is required ");
                e.Cancel = true;
            }

            else
            {
                e.Cancel = false;

                errorProvider1.Clear();
            }
        }

        private void txtNationalNO_Validating(object sender, CancelEventArgs e)
        {
            // Is NationalNO valide 

            string NationalNO = txtNationalNO.Text;
            
            if (string.IsNullOrEmpty(NationalNO) )
            {
                errorProvider1.SetError(txtNationalNO, "this Fielde is required ");
                e.Cancel = true;
                
            }

            if(clsPerson1.IsPersonExists(NationalNO))
            {

                errorProvider1.SetError(txtNationalNO, "National Number is exists");
                e.Cancel = true;

            }

            else
            {
                e.Cancel = false;

                errorProvider1.Clear();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsPerson1 Person = clsPerson1.AddNewPerson();
            
            Person.FName = txtFName.Text;
            Person.LName = txtLName.Text;
            Person.SecondName = txtSName.Text;
            Person.ThirdName = txtTHName.Text;
            Person.Adrress = txtAddress.Text;
            Person.Gender = GenderID.ToString();
            Person.CountryID = 1;//clsCountry.Find(1).CountryID;
            Person.Email = txtEmail.Text;
            Person.DateOfBirth = dtbBirthOfDate.Value;
            Person.ImagePath = _PathImage;

            if(Person.Save())
            {
                MessageBox.Show("Person Added successfully <3 ");
            }


        }

        private void llblRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (rdbFemal.Checked)
            {
                pbxPersonImage.Image = Resources.Female_512;
            }
            else
            {
                pbxPersonImage.Image = Resources.Male_512;
            }

            _PathImage = "";

        }

        private void llblsetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            opfImage.Filter = "Image Files|*.jpg;*.png;*.bmf;*.bmp;*.gif|All Files |*.*";
            string SourcePathImage = "";

            if (opfImage.ShowDialog() == DialogResult.OK)
            {
                SourcePathImage = opfImage.FileName;
                _PathImage += Path.GetFileName(SourcePathImage);
                
                pbxPersonImage.Image = Image.FromFile(SourcePathImage);

                if (File.Exists(SourcePathImage) && !File.Exists(_DestenationImage))
                {
                     File.Copy(SourcePathImage, _DestenationImage+ _PathImage, false);
                }

            }


        }






    }
}
