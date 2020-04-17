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
    /// This class inherits the Form Class and it displays the methods needed to navigate to either 
    /// PersonalEditor or BusinessEditor classes
    /// </summary>
    public partial class ContactMenu : Form
    {
        // This method initializes the class ContactMenu.cs //
        public ContactMenu()
        {
            InitializeComponent();
        }

        // This method hides ContactMenu.cs and shows PersonalEditor.cs class //
        private void btn_Personal_Click(object sender, EventArgs e)
        {
            // personal object instance of the PersonalEditor.cs class //
            PersonalEditor personal = new PersonalEditor();   
            personal.Show();
            this.Hide();
        }

        // This Method hides ContactMenu.cs class and shows BusinessEditor.cs class //
        private void btnBusinessContact_Click(object sender, EventArgs e)
        {
            // business object instance of the Business Editor.cs class //
            BusinessEditor business = new BusinessEditor();        
            business.Show();
            this.Hide();
        }
    }
}
