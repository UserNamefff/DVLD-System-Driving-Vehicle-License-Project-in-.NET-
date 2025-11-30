using DVLD_BusinessLayer;
using DVLD_Project.Globle_Classes;
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
    internal partial class frmAddNewPerson : Form
    {
        public  delegate void SendDataBack(object sender,int PersonID);
        public event SendDataBack SendPersonIDBack;

        enum enGendor { Male,Female}
        enGendor eGendor;
        enum enMode { eAdd , eUpdate}
        enMode _eMode;

        
        int _PersonID = 0;
        string _PathImage;
        string _DestenationImage;
        short GenderID;

        clsPerson1 _Person;

        
        public frmAddNewPerson()
        {
            InitializeComponent();
            _Person = clsPerson1.AddNewPerson();

            llblRemoveImage.Visible = false;

            _eMode = enMode.eAdd;
        }
        public frmAddNewPerson(int ID)
        {
            InitializeComponent();


            _eMode = enMode.eUpdate;
            _PersonID=ID;
            _UpdateForm(_PersonID); 

        }
        private void frmAddNewPerson_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_eMode == enMode.eUpdate)
                _LoadData();
        }

        private void _UpdateForm(int ID)
        {
            lblNameScreen.Text = "Update _Person";
            //crtlAddPerson2.Update(ID);

            lblPersonID.Text = ID.ToString();

        }
        private void _ResetDefualtValues()
        {
            _FillCountriesIntoCombox();

            if(_eMode == enMode.eAdd)
                lblNameScreen.Text = "Add New _Person";
            else
                lblNameScreen.Text = "Update _Person Infomation";

            dtbBirthOfDate.MaxDate = DateTime.Now.AddYears(-20); 
            dtbBirthOfDate.MinDate = DateTime.Now.AddYears(-100);

            if (rbtnMale.Checked)
                pbxPersonImage.Image = Resources.Male_512;
            else
                pbxPersonImage.Image = Resources.Female_512;

            txtFName.Text = "";
            txtLName.Text = "";
            txtSName.Text = "";
            txtTHName.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtNationalNO.Text = "";
            rbtnMale.Checked = true;
            dtbBirthOfDate.Value = dtbBirthOfDate.MaxDate;

            //pbxPersonImage.Image = Resources.Male_512;

        }
        private void _LoadData()
        {
            _FillCountriesIntoCombox();

            _Person = clsPerson1.Find(_PersonID);
            if (_Person == null)
            {
                MessageBox.Show("No _Person with ID = " + _PersonID, "_Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            //the following code will not be executed if the person was not found
            txtAddress.Text = _Person.Adrress;
            txtFName.Text = _Person.FName;
            txtSName.Text = _Person.SecondName;
            txtTHName.Text = _Person.ThirdName;
            txtLName.Text = _Person.LName;
           

            cbxCountries.SelectedIndex = cbxCountries.FindString(_Person.Country.CountryName);
            dtbBirthOfDate.Value = _Person.DateOfBirth;
            txtEmail.Text = (string.IsNullOrEmpty(_Person.Email)) ? "" : _Person.Email;
            txtNationalNO.Text =        _Person.NationalNO;
            txtPhone.Text = _Person.PhoneNumber;

            if (_Person.GenderNO == 0)
                rbtnMale.Checked = true;
            else
                rdbFemal.Checked = true;

            //load person image incase it was set.
            if (_Person.ImagePath != "")
            {
                pbxPersonImage.ImageLocation = _Person.ImagePath;
            }

            //hide/show the remove linke incase there is no image for the person.
            llblRemoveImage.Visible = (_Person.ImagePath != "");

        }
        private void _FillCountriesIntoCombox()
        {
            DataTable dtcountries = clsCountry.GetAllCountries();

            if (dtcountries != null)
            {
                foreach (DataRow dtcountry in dtcountries.Rows)
                {
                    cbxCountries.Items.Add(dtcountry["CountryName"]);
                }
                cbxCountries.SelectedIndex = 0;
            }

        }
        private bool _HandelWithImage()
        {
            //this procedure will handle the person image,
            //it will take care of deleting the old image from the folder
            //in case the image changed. and it will rename the new image with guid and 
            // place it in the images folder.



            if (pbxPersonImage.ImageLocation != _Person.ImagePath)
            {

                if(_Person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                        //_Person.ImagePath = "";
                    }
                    catch (Exception ex) 
                    { 

                    }
                }
                

           

                if(pbxPersonImage.ImageLocation != null)
                {
                
                    string Source = pbxPersonImage.ImageLocation;

                    if(clsUtility.CopyFileToNewDiroctory(ref Source))
                    {
                        pbxPersonImage.ImageLocation = Source;
                   
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }


                }
            }
            return true;

        }
        private void ValidatingEmpty(object sender, CancelEventArgs e)
        {
            try
            {
                TextBox temp = (TextBox)sender;

                if (string.IsNullOrEmpty(temp.Text))
                {
                    errorProvider1.SetError(temp, "This fielde is required ");
                    e.Cancel = true;

                }
                else
                {
                    errorProvider1.SetError(temp, null);
                }
            }
            catch (Exception ex) 
            { 
                
            }
           

        }
        private void IsEmailValidating(object sender, CancelEventArgs e)
        {
            //no need to validate the email incase it's empty.
            if (txtEmail.Text.Trim() == "")
                return;

            if (clsValidatoin.IsEmailMatch(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, " Email Format doesn`t Match ");
                e.Cancel = true;
            }

            else
            {
                errorProvider1.SetError(txtEmail,null);
               // e.Cancel = false;
            }
        }
        private void txtNationalNO_Validating(object sender, CancelEventArgs e)
        {
            // Is NationalNO valide 

            string NationalNO = txtNationalNO.Text;

            if (clsPerson1.IsPersonExists(NationalNO))
            {

                errorProvider1.SetError(txtNationalNO, "National Number is exists");
                e.Cancel = true;

            }

            else
            {
                errorProvider1.SetError(txtNationalNO,null);
            }


        }
        private void rdbFemal_CheckedChanged(object sender, EventArgs e)
        {
            

            //change the defualt image to male incase there is no image set.
            if (pbxPersonImage.ImageLocation == null)
                pbxPersonImage.Image = Resources.Female_512 ;
        }
        private void rbtnMale_CheckedChanged(object sender, EventArgs e)
        {
           // GenderID = Convert.ToInt16(rbtnMale.Tag);

            //change the defualt image to male incase there is no image set.
            if (pbxPersonImage.ImageLocation == null)
                pbxPersonImage.Image = Resources.Male_512;
            
        }
        private void _AddPerson()
        {
            _Person.CountryID = clsCountry.Find(cbxCountries.Text.ToString()).CountryID;
            
            _Person.FName = txtFName.Text;
            _Person.LName = txtLName.Text;
            _Person.SecondName = txtSName.Text;
            _Person.ThirdName = txtTHName.Text;
            _Person.Adrress = txtAddress.Text;
            _Person.Gender = GenderID.ToString();
            //_Person.CountryID = 1;//clsCountry.Find(1).CountryID;
            _Person.Email = txtEmail.Text;
            _Person.DateOfBirth = dtbBirthOfDate.Value;
            _Person.ImagePath = pbxPersonImage.ImageLocation;
            _Person.PhoneNumber = txtPhone.Text;
            _Person.NationalNO = txtNationalNO.Text;

            if(rdbFemal.Checked)
                _Person.Gender = (rdbFemal.Tag).ToString();
            else
                _Person.Gender = (rbtnMale.Tag).ToString();

            
            if (pbxPersonImage.ImageLocation != null)
                _Person.ImagePath = pbxPersonImage.ImageLocation;
            else
                _Person.ImagePath = "";



        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if(!_HandelWithImage())
                return;

            //fill data of _Person Fieldes to _Person Object
            _AddPerson();

           
            if (_Person.Save())
            {
                _PersonID = _Person.ID;
                lblPersonID .Text = _PersonID.ToString();

                MessageBox.Show("_Person Saved successfully :-) ","Saved",MessageBoxButtons.OK,MessageBoxIcon.Information);
                
                _eMode= enMode.eUpdate;
                lblNameScreen.Text = "Update _Person";

                SendPersonIDBack?.Invoke(this,_Person.ID);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void llblsetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            opfImage.Filter = "Image Files|*.jpg;*.png;*.bmf;*.bmp;*.gif|All Files |*.*";
            string SourcePathImage = "";

            if (opfImage.ShowDialog() == DialogResult.OK)
            {
                SourcePathImage = opfImage.FileName;

                if (File.Exists(SourcePathImage))
                {
                    pbxPersonImage.Load(SourcePathImage);
                    llblRemoveImage.Visible = true;
                }
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
            

            if (rbtnMale.Checked)
                pbxPersonImage.Image = Resources.Male_512;
            else
                pbxPersonImage.Image = Resources.Female_512;

                llblRemoveImage.Visible = false;

        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            // to ensure txtAddress Before Clicking Update Or Save 
            try
            {
                

                if (string.IsNullOrEmpty(txtAddress.Text))
                {
                    errorProvider1.SetError(txtAddress, "This fielde is required ");
                    e.Cancel = true;

                }

                else
                {
                    errorProvider1.SetError(txtAddress, null);
                }
            }
            catch (Exception ex)
            {

            }

        }


    }
}


