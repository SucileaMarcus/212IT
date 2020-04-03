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

        private void dGVPersonalRecords_SelectionChanged(object sender, EventArgs e)
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
    }
}
