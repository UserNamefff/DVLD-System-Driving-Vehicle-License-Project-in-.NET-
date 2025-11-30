using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class ctrlPersonFiltering : UserControl
    {

        private string _FilterBy;
        public event Action<int>  dlGetUserID;
        private int _PersonID = 0;
        

        public event Action<string, string> dlGetPersonBy;

        protected virtual void GetPersonBy(string FilterValue,string FilterBy)
        {
            Action<string, string> Handler = dlGetPersonBy;

            if (Handler != null)
            {
                Handler(FilterValue, FilterBy);

            }


        }
        
        protected virtual void GetUserID(object sender,int ID)
        {
            Action<int> Handler = dlGetUserID;

            if (Handler != null)
            {
                _PersonID = ID;
                Handler(ID);
                

            }


        }
       
        public ctrlPersonFiltering()
        {
            InitializeComponent();
            cmbxFilterKey.SelectedIndex = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (cmbxFilterKey.SelectedItem.ToString() == "PersonID")
            {

                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }

            }

        }

       

        //Search _Person 
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            string SeachBy = cmbxFilterKey.SelectedItem.ToString();

            try
            {
                if (SeachBy == "PersonID" && !string.IsNullOrEmpty(txtbFilterBy.Text))
                {
                    //Fixing Later on 
                    //GetUserID(Convert.ToInt32(txtbFilterBy.Text));
                }

                else if (SeachBy == "National Number")
                {
                    GetPersonBy(txtbFilterBy.Text.ToString().Trim(), SeachBy);
                }
                else if (SeachBy == "First Name")
                {
                    GetPersonBy(txtbFilterBy.Text.ToString().Trim(), SeachBy);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(" Error , the Input either white space or wrong format ","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddNewPerson frmAdd = new frmAddNewPerson();
            frmAdd.SendPersonIDBack += GetUserID;
           
            frmAdd.ShowDialog();

            txtbFilterBy.Text = _PersonID.ToString();



        }

        private void cmbxFilterKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public void GetPersonID(int personID)
        {
            txtbFilterBy.Text = personID.ToString();
        }

    }
}
