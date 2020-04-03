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
    public partial class ContactMenu : Form
    {
        public ContactMenu()
        {
            InitializeComponent();
        }

        private void btn_Personal_Click(object sender, EventArgs e)
        {
            PersonalEditor personal = new PersonalEditor();
            personal.Show();
        }

        private void btnBusinessContact_Click(object sender, EventArgs e)
        {
            BusinessEditor business = new BusinessEditor();
            business.Show();
        }
    }
}
