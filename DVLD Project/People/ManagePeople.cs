using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DVLD_BusinessLayer;
namespace DVLD_Project
{
    public partial class ManagePeople : Form
    {
        public ManagePeople()
        {
            //dgvPeopleInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            InitializeComponent();
            
        }

        
        private void _RefreshePeopleTableInfo()
        {
            DataTable dt = clsPerson1.GetAllPeople();

            if (dt != null)
            {

                dgvPeopleInfo.DataSource = dt;
                //dgvPeopleInfo.ClearSelection();
            }
        }
        private void _RefresheInfo( )
        {
            
                _RefreshePeopleTableInfo();
            

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            _RefreshePeopleTableInfo();
        }
        private void ManagePeople_Load(object sender, EventArgs e)
        {
        }

        private void lbllkShowInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Form  frm = new frmAddPersons();
            //frm .ShowDialog();
        }
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddNewPerson frm = new frmAddNewPerson();
            
            frm.ShowDialog();

            _RefresheInfo();

        }
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frm = new frmShowPersonDetails(_GetSelelctedPersonID()); frm.ShowDialog();

        }
        private void AddNewPeresonP_Click(object sender, EventArgs e)
        {
            frmAddNewPerson frm = new frmAddNewPerson();
            //frm.RefreshDataPeople += _RefresheInfo;
            frm.ShowDialog();
            _RefreshePeopleTableInfo();

        }
        private void TSMIEditePersonInfo_Click(object sender, EventArgs e)
        {
            frmAddNewPerson frm = new frmAddNewPerson(_GetSelelctedPersonID());
           // frm.RefreshDataPeople += _RefresheInfo;
            frm.ShowDialog();

            _RefreshePeopleTableInfo();

        }
        bool _DeletePerson(int PersonID)
        {
            clsPerson1 Person = clsPerson1.Find(PersonID);

            if (Person != null)
            {
                Person.Delete();
                return Person.Save();
            }

            return false;
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you Sure Delete This _Person", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                if (!_DeletePerson(_GetSelelctedPersonID()))
                {
                    _RefreshePeopleTableInfo();
                    MessageBox.Show("Deleted Successfully <3. ", "", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show("Deleted Fail this _Person Has Relations with other parts ", "", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }



        }
        private  int _GetSelelctedPersonID()
        {
            
            if(dgvPeopleInfo.Rows.Count > 0)
            {
             
                
                DataGridViewRow SelectedRow = dgvPeopleInfo.SelectedRows[0];
           
                if (SelectedRow != null)
                {
                     return   Convert.ToInt32(SelectedRow.Cells["PersonID"].Value);
                }
            
            }
            return -1;
        }
        private void dgvPeopleInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Send Email Method will be here .", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ;
        }
        private void sendSMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Send Email Method will be here .", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


        }

        
    }
}
