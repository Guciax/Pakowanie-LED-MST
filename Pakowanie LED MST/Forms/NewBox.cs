using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pakowanie_LED_MST.Forms
{
    public partial class NewBox : Form
    {
        public string boxId = "";
        public NewBox()
        {
            InitializeComponent();
        }

        private void NewBox_Load(object sender, EventArgs e)
        {

        }

        private void textBoxNewBoxId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                boxId = textBoxNewBoxId.Text;
                this.Close();
            }
        }

        private void textBoxNewBoxId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
