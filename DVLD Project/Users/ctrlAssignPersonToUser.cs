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

namespace DVLD_Project
{
    public partial class ctrlAssignPersonToUser : UserControl
    {
        int _PersonID = -1;
        bool _FilterEnable;
        public bool FilterEnable 
        { 
            get {return _FilterEnable; } 
            set 
            {
                _FilterEnable = value;
                   
            } 
        }

        public int PersonID
        {
            get { return _PersonID; }
        }

        public event Action <int> GetPersonIDToUser;
        protected virtual void AssignPersonToUser(int PersonID)
        {
            Action<int> Handler  = GetPersonIDToUser;

            if (Handler != null)
            {
                Handler(PersonID);
            }

        }

        public event Action<string, string> dlGetPersonBy;
        private  void _DataBackEvent(object sender, int PersonID)
        {
            if (PersonID != -1)
            {
                _PersonID = PersonID;
                ctrlPersonal_Details1.LoadPersonInfo(_PersonID);
                txtbFilterBy.Text = _PersonID.ToString();
            }

        }

        public ctrlAssignPersonToUser()
        {
            InitializeComponent();
            btnAdd.Image = Resources.Add_Person_40;
        }

        public void LoadPersonInfo(int PersonID)
        {
            SendPersonID(PersonID);
            //LoadPersonInfo(PersonID);
            gbxFiltering.Enabled = _FilterEnable;
            ctrlPersonal_Details1.LoadPersonInfo(PersonID);
        }

       
        private void SendPersonID(int PersonID)
        {
            //ctrlPersonFiltering1.GetPersonID(PersonID);
            //ctrlPersonFiltering1.Enabled = false;
            cmbxFilterKey.SelectedIndex = 1;
            txtbFilterBy.Text = PersonID.ToString();
            
            gbxFiltering.Enabled = false;

        }
        
        private void ctrlPersonFiltering1_dlGetPersonBy(string arg1, string arg2)
        {
            
            //if (arg2 == "First Name")
            //{
            //    AssignPersonToUser(ctrlPersonal_Details1.LoadPersonInfo(arg1));
            //}
            

            //else
            //{
            //    AssignPersonToUser(ctrlPersonal_Details1.LoadPersonInfo(arg1));
            //}

        }

        private void FindNow()
        {
            switch (cmbxFilterKey.Text)
            {
                case "_Person ID":
                    ctrlPersonal_Details1.LoadPersonInfo(Convert.ToInt32(txtbFilterBy.Text));
                    AssignPersonToUser(ctrlPersonal_Details1.PersonID);
                    break;

                case "National Number":
                    ctrlPersonal_Details1.LoadPersonInfo(txtbFilterBy.Text);
                    AssignPersonToUser(ctrlPersonal_Details1.PersonID);
                    AssignPersonToUser(ctrlPersonal_Details1.PersonID);
                    break;

                default:
                    break;

            }
           


        }
        private void ctrlPersonFiltering1_dlGetUserID(int obj)
        {
            _PersonID = obj;
            ctrlPersonal_Details1.LoadPersonInfo(_PersonID);
            AssignPersonToUser(_PersonID);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           //My solution 
            /*string SeachBy = (cmbxFilterKey.SelectedItem.ToString());

            //try
            //{
            //    if (SeachBy == "PersonID" && !string.IsNullOrEmpty(txtbFilterBy.Text))
            //    {
            //        //Fixing Later on 
            //        //GetUserID(Convert.ToInt32(txtbFilterBy.Text));
                    
            //    }

            //    else if (SeachBy == "NationalNumber")
            //    {
            //        //AssignPersonToUser(ctrlPersonal_Details1.LoadPersonInfoByNationalNO(txtbFilterBy.Text));
            //        _DataBackEvent(txtbFilterBy.Text.ToString().Trim(), SeachBy);
            //    }
            //    else if (SeachBy == "FirstName")
            //    {
            //        _DataBackEvent(txtbFilterBy.Text.ToString().Trim(), SeachBy);
            //    }
            */

            //teacher sol 
                if (!this.ValidateChildren())
                {
                    //Here we dont continue becuase the form is not valid
                    MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                FindNow();

            
        }

        

        private void txtbFilterBy_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtbFilterBy.Text))
            {
                MessageBox.Show("Enter value that you want Find :-( ","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                e.Cancel = true;
                errorProvider1.SetError(txtbFilterBy, "This Field is requird!");
                return;
            }

            else
                errorProvider1.SetError(txtbFilterBy,null);


        }

        //if Person Id option Prevent _User Enter white space and charactors
        private void txtbFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {

                btnSearch.PerformClick();
            }

            //this will allow only digits if person id is selected
            if (cmbxFilterKey.Text == "_Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void ctrlAssignPersonToUser_Load(object sender, EventArgs e)
        {

            txtbFilterBy.Focus();
            cmbxFilterKey.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddNewPerson frmAdd = new frmAddNewPerson();
            frmAdd.SendPersonIDBack += _DataBackEvent;

            frmAdd.ShowDialog();
        }
    }
}
