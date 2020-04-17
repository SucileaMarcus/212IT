﻿using System;
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
    /// <summary>
    /// Business Editor class inherits from Form class
    /// It contains all the methods needed to implement CRUD
    /// </summary>
    public partial class BusinessEditor : Form
    {
        // dbConn object instance of the class DbConn //
        DbConn dbConn = new DbConn();

        // Initialize BusinessEditor class//
        public BusinessEditor()
        {
            InitializeComponent();
        }

        // This method populates the dGVBusinessRecords data grid view when BusinessEditor class loads //
        private void BusinessEditor_Load(object sender, EventArgs e)
        {
            dGVBusinessRecords.DataSource = dbConn.GetAllBusiness();
        }

        // This method Refreshes the dGVBusinessRecords data grid view //
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dGVBusinessRecords.DataSource = dbConn.GetAllBusiness();
        }

        // This method disables all the buttons but btnSaveNew //
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
            btnAddNew.Enabled = false;
            btnDelete.Enabled = false;
            btnSaveNew.Enabled = true;
            // text boxes emptied //
            tbFname.Text = String.Empty;
            tbLname.Text = String.Empty;
            tbEmail.Text = String.Empty;
            tbAddress1.Text = String.Empty;
            tbAddress2.Text = String.Empty;
            tbCity.Text = String.Empty;
            tbPostCode.Text = String.Empty;
            tbTelNumber.Text = String.Empty;
        }

        // This method selects the clicked cell data from the specific row 
        // and populates the text boxes with the selected 
        // values from the data grid view//
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

        // This method calls the InsertBusiness() method from DbConn class adding new values to the table // 
        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            // businessContact object instance of the class BusinessContact to populate the class fields //
            BusinessContact businessContact = new BusinessContact();
            businessContact.ContactFname = tbFname.Text;
            businessContact.ContactLname = tbLname.Text;
            businessContact.ContactEmail = tbEmail.Text;
            businessContact.ContactAddr1 = tbAddress1.Text;
            businessContact.ContactAddr2 = tbAddress2.Text;
            businessContact.ContactCity = tbCity.Text;
            businessContact.ContactPostCode = tbPostCode.Text;
            businessContact.BusinessTel = tbTelNumber.Text;
            // InsertBusiness() method called with the populated fields from BusinessContact clas
            dbConn.InsertBusiness(businessContact);
            // datagridview repopulated with the new data from SQL table //
            dGVBusinessRecords.DataSource = dbConn.GetAllBusiness();
            tbFname.Enabled = false;
            tbLname.Enabled = false;
            tbEmail.Enabled = false;
            tbAddress1.Enabled = false;
            tbAddress2.Enabled = false;
            tbCity.Enabled = false;
            tbPostCode.Enabled = false;
            tbTelNumber.Enabled = false;
            // text boxes emptied
            tbFname.Text = String.Empty;
            tbLname.Text = String.Empty;
            tbEmail.Text = String.Empty;
            tbAddress1.Text = String.Empty;
            tbAddress2.Text = String.Empty;
            tbCity.Text = String.Empty;
            tbPostCode.Text = String.Empty;
            tbTelNumber.Text = String.Empty;
            btnSave.Enabled = false;
            btnAddNew.Enabled = true;
            btnSaveNew.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            
        }

        // This method disables all buttons but btnCancel and btnSaveSelected //
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

        // This method calls the UpdateBusiness() method from DbConn class updating values to the table // 
        private void btnSave_Click(object sender, EventArgs e)
        {   
            int index = Int32.Parse(dGVBusinessRecords.SelectedCells[0].Value.ToString());
            // businessContact object instance of the class BusinessContact to populate the class fields //
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
            // UpdateBuiness method called from DbConn class with the parameter businessContact and its populated fields //
            dbConn.UpdateBusiness(businessContact);
            // Repopulate datagridview by calling the GetAllBusiness() method from DbConn class
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

        //This method deletes entry based on the selected ID//
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
                // Repopulates datagridview by calling the GetAllBusiness() method //
                dGVBusinessRecords.DataSource = dbConn.GetAllBusiness();

            }
        }

        //This method disables btnSave and btnUpdate //
        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            btnAddNew.Enabled = true;
            btnSaveNew.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            // text boxes emptied
            tbFname.Text = String.Empty;
            tbLname.Text = String.Empty;
            tbEmail.Text = String.Empty;
            tbAddress1.Text = String.Empty;
            tbAddress2.Text = String.Empty;
            tbCity.Text = String.Empty;
            tbPostCode.Text = String.Empty;
            tbTelNumber.Text = String.Empty;
            //text boxes disabled
            tbFname.Enabled = false;
            tbLname.Enabled = false;
            tbEmail.Enabled = false;
            tbAddress1.Enabled = false;
            tbAddress2.Enabled = false;
            tbCity.Enabled = false;
            tbPostCode.Enabled = false;
            tbTelNumber.Enabled = false;
        }

        // This method closes the BusinessEditor.cs class and opens the ContactMenu class //
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            // contactMenu object instance of the class ContactMenu.cs //
            ContactMenu contactMenu = new ContactMenu();
            this.Close();
            contactMenu.Show();
        }
    }
}
