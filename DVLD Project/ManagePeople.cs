using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BusinessLayer;
namespace DVLD_Project
{
    public partial class ManagePeople : Form
    {
        public ManagePeople()
        {
            InitializeComponent();
        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            dgvPeopleInfo.DataSource = clsPerson1.GetAllPeople();

        }

        private void ManagePeople_Load(object sender, EventArgs e)
        {
        }

        private void lbllkShowInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form  frm = new frmAddPersons();
            frm .ShowDialog();
        }
    }
}
