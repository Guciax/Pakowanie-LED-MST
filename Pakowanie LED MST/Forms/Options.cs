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
    public partial class Options : Form
    {
        private readonly bool optionTest;
        private readonly bool optionVi;

        public  bool outputOptionTest = true;
        public  bool outputOptionVi = true;

        public Options(bool optionTest, bool optionVi)
        {
            InitializeComponent();
            this.optionTest = optionTest;
            this.optionVi = optionVi;
        }

        private void Options_Load(object sender, EventArgs e)
        {
            checkBoxTest.Checked = optionTest;
            checkBoxVi.Checked = optionVi;
        }

        private void checkBoxTest_CheckedChanged(object sender, EventArgs e)
        {
            outputOptionTest = checkBoxTest.Checked;
            outputOptionVi = checkBoxVi.Checked;
        }

        private void checkBoxVi_CheckedChanged(object sender, EventArgs e)
        {
            outputOptionTest = checkBoxTest.Checked;
            outputOptionVi = checkBoxVi.Checked;
        }
    }
}
