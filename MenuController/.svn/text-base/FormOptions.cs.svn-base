using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MenuController
{
    public partial class FormOptions : Form
    {
        public FormOptions()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Settings.Default.Save(); 
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Settings.Default.Reload();
            this.Hide();
        }
    }
}
