using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HarissAndSonsContactManager
{

    


    public partial class PersonalEditor : Form
    {
        DbConn dbConn = new DbConn();

        public PersonalEditor()
        {
            InitializeComponent();
        }

        private void PersonalEditor_Load(object sender, EventArgs e)
        {
            dGVPersonalRecords.DataSource = dbConn.GetAllPersonal();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dGVPersonalRecords.DataSource = dbConn.GetAllPersonal();
        }

    

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            tbFname.Enabled = true;
            tbLname.Enabled = true;
            tbEmail.Enabled = true;
            tbAddress1.Enabled = true;
            tbAddress2.Enabled = true;
            tbCity.Enabled = true;
            tbPostCode.Enabled = true;
            tbTelNumber.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSaveNew.Enabled = true;
            tbFname.Text = String.Empty;
            tbLname.Text = String.Empty;
            tbEmail.Text = String.Empty;
            tbAddress1.Text = String.Empty;
            tbAddress2.Text = String.Empty;
            tbCity.Text = String.Empty;
            tbPostCode.Text = String.Empty;
            tbTelNumber.Text = String.Empty;
        }

        private void dGVPersonalRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = Int32.Parse(dGVPersonalRecords.SelectedCells[0].Value.ToString());
            tbFname.Text = dGVPersonalRecords.SelectedCells[1].Value.ToString();
            tbLname.Text = dGVPersonalRecords.SelectedCells[2].Value.ToString();
            tbEmail.Text = dGVPersonalRecords.SelectedCells[3].Value.ToString();
            tbAddress1.Text = dGVPersonalRecords.SelectedCells[4].Value.ToString();
            tbAddress2.Text = dGVPersonalRecords.SelectedCells[5].Value.ToString();
            tbCity.Text = dGVPersonalRecords.SelectedCells[6].Value.ToString();
            tbPostCode.Text = dGVPersonalRecords.SelectedCells[7].Value.ToString();
            tbTelNumber.Text = dGVPersonalRecords.SelectedCells[8].Value.ToString();
            
        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            PersonalContact personalContact = new PersonalContact();
            personalContact.ContactFname = tbFname.Text;
            personalContact.ContactLname = tbLname.Text;
            personalContact.ContactEmail = tbEmail.Text;
            personalContact.ContactAddr1 = tbAddress1.Text;
            personalContact.ContactAddr2 = tbAddress2.Text;
            personalContact.ContactCity = tbCity.Text;
            personalContact.ContactPostCode = tbPostCode.Text;
            personalContact.PersonalTel = tbTelNumber.Text;
            dbConn.InsertPersonal(personalContact);
            tbFname.Enabled = false;
            tbLname.Enabled = false;
            tbEmail.Enabled = false;
            tbAddress1.Enabled = false;
            tbAddress2.Enabled = false;
            tbCity.Enabled = false;
            tbPostCode.Enabled = false;
            tbTelNumber.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSaveNew.Enabled = false;
            tbFname.Text = String.Empty;
            tbLname.Text = String.Empty;
            tbEmail.Text = String.Empty;
            tbAddress1.Text = String.Empty;
            tbAddress2.Text = String.Empty;
            tbCity.Text = String.Empty;
            tbPostCode.Text = String.Empty;
            tbTelNumber.Text = String.Empty;
            dGVPersonalRecords.DataSource = dbConn.GetAllPersonal();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            tbFname.Enabled = true;
            tbLname.Enabled = true;
            tbEmail.Enabled = true;
            tbAddress1.Enabled = true;
            tbAddress2.Enabled = true;
            tbCity.Enabled = true;
            tbPostCode.Enabled = true;
            tbTelNumber.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnAddNew.Enabled = false;
            btnSave.Enabled = true;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int index = Int32.Parse(dGVPersonalRecords.SelectedCells[0].Value.ToString());
            PersonalContact personalContact = new PersonalContact();
            personalContact.ContactID = index;
            personalContact.ContactFname = tbFname.Text;
            personalContact.ContactLname = tbLname.Text;
            personalContact.ContactEmail = tbEmail.Text;
            personalContact.ContactAddr1 = tbAddress1.Text;
            personalContact.ContactAddr2 = tbAddress2.Text;
            personalContact.ContactCity = tbCity.Text;
            personalContact.ContactPostCode = tbPostCode.Text;
            personalContact.PersonalTel = tbTelNumber.Text;
            dbConn.UpdatePersonal(personalContact);
            dGVPersonalRecords.DataSource = dbConn.GetAllPersonal();
            tbFname.Enabled = false;
            tbLname.Enabled = false;
            tbEmail.Enabled = false;
            tbAddress1.Enabled = false;
            tbAddress2.Enabled = false;
            tbCity.Enabled = false;
            tbPostCode.Enabled = false;
            tbTelNumber.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnAddNew.Enabled = true;
            btnSave.Enabled = false;


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to delete?";
            string caption = "Do you want to delete the contact with the record ID of" + Int32.Parse(dGVPersonalRecords.SelectedCells[0].Value.ToString());
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);

            if (result == DialogResult.Yes)
            {
                dbConn.DeletePersonal(Int32.Parse(dGVPersonalRecords.SelectedCells[0].Value.ToString()));
                dGVPersonalRecords.DataSource = dbConn.GetAllPersonal();

            }
        }
    }
}
