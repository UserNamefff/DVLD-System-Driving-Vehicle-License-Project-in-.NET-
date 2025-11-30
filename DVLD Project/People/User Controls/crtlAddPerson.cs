using DVLD_BusinessLayer;
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

        clsPerson1 _EditePerson ;
        enum enMode { eEdite,eAdd}
        enMode eMode;

        //int Id=0;
        int _PersonID=0;
        string _PathImage;
        string _DestenationImage;
        short GenderID;



        //Delegations 
        public event Action<int> OnReadPersonID;

        public delegate void dltRefresh(object Sender,bool IsClose);
        public event dltRefresh DataRefresh;

        public event Action<int> OnClose;

        protected virtual void OnCloseGetPersonID(int PersonID)
        {
             Action< int> Handler = OnClose; 

            if (Handler != null)
            {
                Handler(PersonID);
                
            }
            
        }


        //Implimentaion Delegate
        protected virtual void ReadPersonID(int ID)
        {
            Action<int> Handler = OnReadPersonID;

            if (Handler != null)
                Handler(ID);
            
        }


        public crtlAddPerson()
        {
            InitializeComponent();

            _PathImage = "";
            _DestenationImage = @"C:\\Image For DVLD Project\\";
            GenderID = 0;
            eMode = enMode.eAdd;
        }
       

        void _FillCountries()
        {
            DataTable dtcountries = clsCountry.GetAllCountries();

            if (dtcountries!=null)
            { 
                foreach (DataRow dtcountry in dtcountries.Rows)
                {
                    cbxCountries.Items.Add(dtcountry["CountryName"]);
                }
                cbxCountries.SelectedIndex = 0;
            }

        }

        private void crtlAddPerson_Load(object sender, EventArgs e)
        {
            _FillCountries();
            
           
        }

        private void txtFName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //DataRefresh?.Invoke (this,true);
            OnCloseGetPersonID(_PersonID);
            ReadPersonID(_PersonID);
        }

        private void rbtnMale_CheckedChanged(object sender, EventArgs e)
        {
            pbxPersonImage.Image = Resources.Male_512;
            //GenderID = Convert.ToInt16(rdbFemal.Tag);
        }

        private void rdbFemal_CheckedChanged(object sender, EventArgs e)
        {
            pbxPersonImage.Image = Resources.Female_512;
            //GenderID = Convert.ToInt16(rbtnMale.Tag);
        }

        byte CheckGender(string Gender)
        {   
            if(Gender =="Male")
            {
                rbtnMale.Checked = true;
                rdbFemal.Checked = false;
                pbxPersonImage.Image = Resources.Male_512;

                return 0;
            }
            else
            {
                pbxPersonImage.Image = Resources.Male_512;
                rdbFemal.Checked = true;
                rbtnMale.Checked = false;
            }
            return 1;
        }

        bool _IsImagPatheExists(string ImagePath)
        {
            try
            {
                if (!string.IsNullOrEmpty(ImagePath) && File.Exists(ImagePath))
                {

                    return true;

                }
            }catch(Exception ex)
            {

            }
            
            return false; ;
        }

        int CountrySelectedIndex (string CountryName)
        {
            if(cbxCountries != null)
            {
                cbxCountries.SelectedIndex = cbxCountries.FindString(CountryName);
                return cbxCountries.SelectedIndex;
            }
            return -1;
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

        private void _AddPerson(clsPerson1 Person)
        {
            Person.FName = txtFName.Text;
            Person.LName = txtLName.Text;
            Person.SecondName = txtSName.Text;
            Person.ThirdName = txtTHName.Text;
            Person.Adrress = txtAddress.Text;
            Person.Gender = GenderID.ToString();
            Person.CountryID = clsCountry.Find(cbxCountries.Text).CountryID;
            Person.Email = txtEmail.Text;
            Person.DateOfBirth = dtbBirthOfDate.Value;
            Person.ImagePath = _PathImage;
            Person.PhoneNumber = txtPhone.Text;
            Person.NationalNO = txtNationalNO.Text;
            

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsPerson1 Person = clsPerson1.AddNewPerson();
            _AddPerson(Person);
            
            if (Person.Save())
            {
                MessageBox.Show("_Person Added successfully <3 ");
                _PersonID = Person.ID;
                ReadPersonID(Person.ID);
              
            }


        }

        private void Clear()
        {
            txtFName.Clear(); txtLName.Clear();
            txtSName.Clear();
            txtTHName.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtNationalNO.Clear();
            pbxPersonImage.Image = Resources.Male_512;
            rbtnMale.Checked = true;
            dtbBirthOfDate.Value = dtbBirthOfDate.MaxDate;
            
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
                     File.Copy(SourcePathImage, _DestenationImage + _PathImage, true);
                    _PathImage = _DestenationImage + _PathImage;
                }



            }


        }

        private void _FillDataIntoEditting(clsPerson1 Person )
        {
            string s = "Image1.png";
            txtAddress.Text = Person.Adrress;
            //txtBirthOfDate.Text = _Person.DateOfBirth.ToString();
            txtFName.Text = Person.FName;
            txtSName.Text = Person.SecondName;
            txtTHName.Text = Person.ThirdName;
            txtLName.Text = Person.LName;
            _FillCountries();

            cbxCountries.SelectedItem = (clsCountry.Find(Person.CountryID).CountryName);
            dtbBirthOfDate.Value = Person.DateOfBirth;
            txtEmail.Text = (string.IsNullOrEmpty( Person.Email)) ? "" : Person.Email;
            txtNationalNO.Text = Person.NationalNO;
            txtPhone.Text = Person.PhoneNumber;

            CheckGender(Person.Gender);

            if (_IsImagPatheExists(Person.ImagePath))
            {
                pbxPersonImage.Image = Image.FromFile((Person.ImagePath));
            }


        }

        public bool UpdatePersonInfo(int ID)
        {
            //clsPerson1 _Person = clsPerson1.Find(ID);

            if (_EditePerson != null)
            {
                if (_EditePerson.Save())
                {
                    return true;
                }
                
            }

            return false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_EditePerson != null)
            {
                _AddPerson(_EditePerson);
                if (_EditePerson.Save())
                {
                    MessageBox.Show("Updated Successfully .", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Enabled = false;
                    //this.Clear();
                }
            }
            else
            {
                MessageBox.Show("_Person was not Update ,try change Data .", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Update(int ID)
        {
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            _EditePerson = clsPerson1.Find(ID);
            
            if (_EditePerson != null)
            {
                _FillDataIntoEditting(_EditePerson);
            }

        }
    }
}
