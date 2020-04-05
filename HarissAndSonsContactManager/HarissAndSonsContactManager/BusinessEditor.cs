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
    public partial class BusinessEditor : Form
    {

        DbConn dbConn = new DbConn();

        public BusinessEditor()
        {
            InitializeComponent();
        }

        private void BusinessEditor_Load(object sender, EventArgs e)
        {
            dGVBusinessRecords.DataSource = dbConn.GetAllBusiness();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dGVBusinessRecords.DataSource = dbConn.GetAllBusiness();
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

        private void dGVBusinessRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = Int32.Parse(dGVBusinessRecords.SelectedCells[0].Value.ToString());
            tbFname.Text = dGVBusinessRecords.SelectedCells[1].Value.ToString();
            tbLname.Text = dGVBusinessRecords.SelectedCells[2].Value.ToString();
            tbEmail.Text = dGVBusinessRecords.SelectedCells[3].Value.ToString();
            tbAddress1.Text = dGVBusinessRecords.SelectedCells[4].Value.ToString();
            tbAddress2.Text = dGVBusinessRecords.SelectedCells[5].Value.ToString();
            tbCity.Text = dGVBusinessRecords.SelectedCells[6].Value.ToString();
            tbPostCode.Text = dGVBusinessRecords.SelectedCells[7].Value.ToString();
            tbTelNumber.Text = dGVBusinessRecords.SelectedCells[8].Value.ToString();
        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            BusinessContact businessContact = new BusinessContact();
            businessContact.ContactFname = tbFname.Text;
            businessContact.ContactLname = tbLname.Text;
            businessContact.ContactEmail = tbEmail.Text;
            businessContact.ContactAddr1 = tbAddress1.Text;
            businessContact.ContactAddr2 = tbAddress2.Text;
            businessContact.ContactCity = tbCity.Text;
            businessContact.ContactPostCode = tbPostCode.Text;
            businessContact.BusinessTel = tbTelNumber.Text;
            dbConn.InsertBusiness(businessContact);
            dGVBusinessRecords.DataSource = dbConn.GetAllBusiness();
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
            int index = Int32.Parse(dGVBusinessRecords.SelectedCells[0].Value.ToString());
            BusinessContact businessContact = new BusinessContact();
            businessContact.ContactID = index;
            businessContact.ContactFname = tbFname.Text;
            businessContact.ContactLname = tbLname.Text;
            businessContact.ContactEmail = tbEmail.Text;
            businessContact.ContactAddr1 = tbAddress1.Text;
            businessContact.ContactAddr2 = tbAddress2.Text;
            businessContact.ContactCity = tbCity.Text;
            businessContact.ContactPostCode = tbPostCode.Text;
            businessContact.BusinessTel = tbTelNumber.Text;
            dbConn.UpdateBusiness(businessContact);
            dGVBusinessRecords.DataSource = dbConn.GetAllBusiness();
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
            string caption = "Do you want to delete the contact with the record ID of" + Int32.Parse(dGVBusinessRecords.SelectedCells[0].Value.ToString());
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);

            if (result == DialogResult.Yes)
            {
                dbConn.DeleteBusiness(Int32.Parse(dGVBusinessRecords.SelectedCells[0].Value.ToString()));
                dGVBusinessRecords.DataSource = dbConn.GetAllBusiness();

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            btnAddNew.Enabled = true;
            btnSaveNew.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            tbFname.Text = String.Empty;
            tbLname.Text = String.Empty;
            tbEmail.Text = String.Empty;
            tbAddress1.Text = String.Empty;
            tbAddress2.Text = String.Empty;
            tbCity.Text = String.Empty;
            tbPostCode.Text = String.Empty;
            tbTelNumber.Text = String.Empty;
            tbFname.Enabled = false;
            tbLname.Enabled = false;
            tbEmail.Enabled = false;
            tbAddress1.Enabled = false;
            tbAddress2.Enabled = false;
            tbCity.Enabled = false;
            tbPostCode.Enabled = false;
            tbTelNumber.Enabled = false;
        }
    }
}
