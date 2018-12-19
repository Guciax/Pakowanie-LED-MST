using Pakowanie_LED_MST.Data_structure;
using Pakowanie_LED_MST.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pakowanie_LED_MST
{
    public partial class Form1 : Form
    {
        public static CurrentBox currentBox = null;
        public static bool optionCheckTest = true;
        public static bool optionCheckVi = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBoxAddPcb;
            AppSettingsOperations.CheckAppSettingsKeys();
            optionCheckTest = AppSettingsOperations.GetSettings("CheckLedTest")=="1";
            optionCheckVi = AppSettingsOperations.GetSettings("CheckViTest")=="1";
            DgvTools.ShowHideColumns(optionCheckTest, optionCheckVi, dgvCurrentBox);
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            this.Text +=" ver."+ version;
            
        }

        private void textBoxAddPcb_Enter(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.BackColor = Color.ForestGreen;
            tb.ForeColor = Color.White;
        }

        private void textBoxAddPcb_Leave(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.BackColor = Color.White;
            tb.ForeColor = Color.Black;
        }


        private void buttonNewBox_Click(object sender, EventArgs e)
        {
            using (NewBox newBoxForm = new NewBox())
            {
                newBoxForm.ShowDialog();
                if (newBoxForm.boxId.Trim() != "")
                {
                    CreateNewBox(newBoxForm.boxId, FilesOperations.CheckIfBoxExist(newBoxForm.boxId));
                    labelCurrentBoxId.Text = "Aktualne opakowanie ID: " + Environment.NewLine + newBoxForm.boxId;
                }
            }
        }

        private void CreateNewBox(string boxId, bool loadExistingPcb)
        {
            dgvCurrentBox.Rows.Clear();
            currentBox = new CurrentBox(boxId, "", "", new Dictionary<string, LedsInCurrentBoxStruct>(),false, 0,0,0,0);
            if (loadExistingPcb)
            {
                currentBox.LedsInBox = FilesOperations.LoadBoxFromFile(boxId);
                currentBox.NewResultsAdded = true;
                DgvTools.AutoColumnSize(dgvCurrentBox, DataGridViewAutoSizeColumnMode.AllCells);
            }
        }

        private void timerCheckDgvForTestResults_Tick(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void textBoxAddPcb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                string serial = ShortenPcbSerial(textBoxAddPcb.Text.Trim());

                if (!currentBox.LedsInBox.ContainsKey(serial))
                {
                    CurrentBoxOperation.AddPcbToBox(serial, ref currentBox);
                    FilesOperations.SaveBoxFile(currentBox);
                    DgvTools.AutoColumnSize(dgvCurrentBox, DataGridViewAutoSizeColumnMode.AllCells);
                    lastRowColor = dgvCurrentBox.Rows[0].Cells[0].Style.BackColor;
                    timerBlinkThePanel.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Ten panel został już dodany do tego opakowania!");
                }
                textBoxAddPcb.Text = "";
                CountPanels();
            }
        }

        Color lastRowColor;
        Stopwatch blinkStoper = new Stopwatch();
        private void timerBlinkThePanel_Tick(object sender, EventArgs e)
        {
            if (!blinkStoper.IsRunning)
            {
                blinkStoper.Start();
            }

            if (blinkStoper.ElapsedMilliseconds>2000)
            {
                timerBlinkThePanel.Enabled = false;
                blinkStoper.Stop();
                blinkStoper.Reset();
                panel3.BackColor = Color.LightSteelBlue;
            }
            else
            {
                if (panel3.BackColor == Color.LightSteelBlue)
                {
                    panel3.BackColor = lastRowColor;
                }
                else
                {
                    panel3.BackColor = Color.LightSteelBlue;
                }
            }
        }

        internal static string ShortenPcbSerial(string inputId)
        {
            if (!inputId.Contains("_")) return inputId;
            if (inputId.Length <= 50) return inputId;

            string[] split = inputId.Split('_');
            return $"{split[split.Length - 2]}_{split[split.Length - 1]}";
        }

        private void CountPanels()
        {
            int okPcb = 0, ngPcb = 0, unknownPcb = 0;
           
            foreach (DataGridViewRow row in dgvCurrentBox.Rows)
            {
                if (row.Cells[0].Style.BackColor == Color.Lime)
                {
                    okPcb++;
                    continue;
                }
                if (row.Cells[0].Style.BackColor == Color.Red)
                {
                    ngPcb++;
                    continue;
                }
                unknownPcb++;
            }
            labelAllQty.Text = (okPcb + ngPcb + unknownPcb).ToString();
            label3.Text = labelAllQty.Text;
            labelGoodQty.Text = okPcb.ToString();
            labelNgCount.Text = ngPcb.ToString();
            labelUnknownCount.Text = unknownPcb.ToString();
            if (labelNgCount.Text != "0")
            {
                timerFlashNg.Enabled = true;
            }
            else
            {
                timerFlashNg.Enabled = false;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            TestResults.CheckResultsForBox(ref currentBox, optionCheckTest, optionCheckVi);
        }

        private void timerTestResultsToGrid_Tick(object sender, EventArgs e)
        {
            if (currentBox != null)
            {
                if (currentBox.NewResultsAdded)
                {
                    DgvTools.CheckTests(dgvCurrentBox, ref currentBox);
                }
                CountPanels();
            }
            if (backgroundWorker1.IsBusy)
            {
                foreach (DataGridViewRow row in dgvCurrentBox.Rows)
                {
                    if (row.Cells["TestResult"].Value.ToString()=="BrakDanych")
                    {
                        row.Cells["TestResult"].Value = "Sprawdzam...";
                    }
                    if (row.Cells["ViResult"].Value.ToString() == "BrakDanych")
                    {
                        row.Cells["ViResult"].Value = "Sprawdzam...";
                    }
                }
            }
        }

        private void textBoxAddPcb_Leave_1(object sender, EventArgs e)
        {
            this.ActiveControl = textBoxAddPcb;
        }

        private void dgvCurrentBox_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DgvTools.ColorGridRows(dgvCurrentBox);
        }

        private void dgvCurrentBox_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (senderGrid.Rows[e.RowIndex].Cells["PCB"].Value!=null)
                {
                    string serial = senderGrid.Rows[e.RowIndex].Cells["PCB"].Value.ToString();
                    DgvTools.DeletePcb(serial, ref currentBox, senderGrid);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (NewBox newBoxForm = new NewBox())
            {
                newBoxForm.ShowDialog();
                if (newBoxForm.boxId.Trim() != "")
                {
                    DgvTools.DeletePcb(newBoxForm.boxId,ref currentBox, dgvCurrentBox);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Options optionForm = new Options(optionCheckTest, optionCheckVi))
            {
                if (optionForm.ShowDialog() == DialogResult.OK)
                {
                    optionCheckTest = optionForm.outputOptionTest;
                    optionCheckVi = optionForm.outputOptionVi;
                    SaveSettings();
                    DgvTools.ShowHideColumns(optionCheckTest, optionCheckVi, dgvCurrentBox);
                }
            }
        }

        private void SaveSettings()
        {
            AppSettingsOperations.AddOrUpdateAppSettings("CheckLedTest", optionCheckTest ? "1" : "0");
            AppSettingsOperations.AddOrUpdateAppSettings("CheckViTest", optionCheckVi ? "1" : "0");
        }

        private void labelAllQty_TextChanged(object sender, EventArgs e)
        {
            
        }

        
    }
}
