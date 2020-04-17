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

    /// <summary>
    /// Personal Editor class inherits from Form class
    /// It contains all the methods needed to implement CRUD
    /// </summary>
    public partial class PersonalEditor : Form
    {
        // dbConn object of the class DbConn //
        DbConn dbConn = new DbConn();

        // Initialize PersonalEditor class//
        public PersonalEditor()
        {

            InitializeComponent();
        }

        // This method populates the dGVBusinessRecords data grid view when PersonalEditor class loads //
        private void PersonalEditor_Load(object sender, EventArgs e)
        {
            dGVPersonalRecords.DataSource = dbConn.GetAllPersonal();
        }

        // This method Refreshes the dGVBusinessRecords data grid view //
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dGVPersonalRecords.DataSource = dbConn.GetAllPersonal();
        }

        // This Method disables all the buttons but btnSaveNew //
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
            btnAddNew.Enabled = false;
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

        // This method selects the clicked cell data from the specific row 
        // and populates the text boxes with the selected 
        // values from the data grid view//
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

        // This method calls the InsertPersonal() method from DbConn class adding new values to the table // 
        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            // personalContact object of the class PersonalContact to populate the class fields //
            PersonalContact personalContact = new PersonalContact();
            personalContact.ContactFname = tbFname.Text;
            personalContact.ContactLname = tbLname.Text;
            personalContact.ContactEmail = tbEmail.Text;
            personalContact.ContactAddr1 = tbAddress1.Text;
            personalContact.ContactAddr2 = tbAddress2.Text;
            personalContact.ContactCity = tbCity.Text;
            personalContact.ContactPostCode = tbPostCode.Text;
            personalContact.PersonalTel = tbTelNumber.Text;
            // InsertPersonal() method called with the populated fields from BusinessContact clas
            dbConn.InsertPersonal(personalContact);
            // datagridview repopulated with the new data from SQL table //
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

        // This method calls the UpdatePersonal() method from DbConn class updating values to the table // 
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
            // UpdatePersonal method called from DbConn class with the parameter businessContact //
            dbConn.UpdatePersonal(personalContact);
            // repopulate datagridview by calling the GetAllPersonal() method from DbConn
            dGVPersonalRecords.DataSource = dbConn.GetAllPersonal();
            //text boxes disabled //
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
            string caption = "Do you want to delete the contact with the record ID of" + Int32.Parse(dGVPersonalRecords.SelectedCells[0].Value.ToString());
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);

            if (result == DialogResult.Yes)
            {
                dbConn.DeletePersonal(Int32.Parse(dGVPersonalRecords.SelectedCells[0].Value.ToString()));
                // repopulates datagridview by calling the GetAllPersonal() method //
                dGVPersonalRecords.DataSource = dbConn.GetAllPersonal();

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
            // text boxes emptied //
            tbFname.Text = String.Empty;
            tbLname.Text = String.Empty;
            tbEmail.Text = String.Empty;
            tbAddress1.Text = String.Empty;
            tbAddress2.Text = String.Empty;
            tbCity.Text = String.Empty;
            tbPostCode.Text = String.Empty;
            tbTelNumber.Text = String.Empty;
            // text boxes disabled //
            tbFname.Enabled = false;
            tbLname.Enabled = false;
            tbEmail.Enabled = false;
            tbAddress1.Enabled = false;
            tbAddress2.Enabled = false;
            tbCity.Enabled = false;
            tbPostCode.Enabled = false;
            tbTelNumber.Enabled = false;
        }

        // This method closes the PersonalEditor.cs class and opens the ContactMenu class //
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            // contactMenu object of the class ContactMenu.cs //
            ContactMenu contactMenu = new ContactMenu();
            this.Close();
            contactMenu.Show();
        }
    }
}
