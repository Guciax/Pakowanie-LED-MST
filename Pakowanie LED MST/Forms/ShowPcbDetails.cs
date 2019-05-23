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
    public partial class ShowPcbDetails : Form
    {
        private readonly LedsInCurrentBoxStruct pcbInfo;

        public ShowPcbDetails(LedsInCurrentBoxStruct pcbInfo)
        {
            InitializeComponent();
            this.pcbInfo = pcbInfo;
        }

        private void ShowPcbDetails_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add("Kontrola wzrokowa", pcbInfo.ViResult);
            dataGridView1.Rows.Add("Test LED", pcbInfo.TestResult);
            dataGridView1.Rows.Add("Data testu LED", pcbInfo.TestDate);

            if (pcbInfo.ViResult!="OK")
            {
                dataGridView1.Rows.Add("Wynik naprawy", pcbInfo.ReworkNfo.ReworkResult);
                dataGridView1.Rows.Add("Data naprawy", pcbInfo.ReworkNfo.ReworkDate);
                dataGridView1.Rows.Add("Kontrola wz. po naprawie", pcbInfo.ReworkNfo.PostReworkViResult);
                string testAfterRework = "OK";
                if (pcbInfo.TestDate<pcbInfo.ReworkNfo.ReworkDate)
                {
                    testAfterRework = "BRAK";
                }
                dataGridView1.Rows.Add("Test LED po naprawie", testAfterRework);
                dataGridView1.Rows.Add("Czas wykonania testu LED", pcbInfo.TestDate);

                dataGridView1.Rows.Add("Kontrola OQA", pcbInfo.ReworkNfo.OqaResult);
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[1].Value.ToString().Trim() == "" || row.Cells[1].Value.ToString().Trim() == "BRAK" || row.Cells[1].Value.ToString().Trim() == "NG")
                {
                    row.Cells[1].Style.BackColor = Color.Red;
                    row.Cells[1].Style.ForeColor = Color.White;
                }
            }

            //DgvTools.AutoColumnSize(dataGridView1, DataGridViewAutoSizeColumnMode.AllCells);
            //Test  
            //VisualInspection
            //----
            //Rework
            //PostReworkTest
            //PostReworkVi
            //PostReworkOQA
        }
    }
}
