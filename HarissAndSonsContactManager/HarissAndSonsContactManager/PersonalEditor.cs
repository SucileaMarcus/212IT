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
    }
}
