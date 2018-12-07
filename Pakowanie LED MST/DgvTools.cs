using Pakowanie_LED_MST.Data_structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pakowanie_LED_MST
{
    class DgvTools
    {
        public static void CheckTests(DataGridView grid, ref CurrentBox currentBox, bool checkTest, bool checkVi)
        {

            foreach (var pcb in currentBox.LedsInBox)
            {
                if (pcb.Value.AddMeToGrid)
                {
                    grid.Rows.Insert(0,grid.Rows.Count+1,pcb.Value.Date, pcb.Value.Serial);
                    pcb.Value.AddMeToGrid = false;

                }
            }

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.Cells["PCB"].Value == null) continue;
                string serial = row.Cells["PCB"].Value.ToString();
                if (checkTest)
                {
                    row.Cells["TestResult"].Value = currentBox.LedsInBox[serial].TestResult;
                }
                else
                {
                    row.Cells["TestResult"].Value = "Wyłączone";
                }
                if (checkVi)
                {
                    row.Cells["ViResult"].Value = currentBox.LedsInBox[serial].ViResult;
                }
                else
                {
                    row.Cells["ViResult"].Value = "Wyłączone";
                }
            }
            currentBox.NewResultsAdded = false;
        }

        public static void ColorGridRows(DataGridView grid)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.Cells["TestResult"].Value == null) continue;
                if (row.Cells["ViResult"].Value == null) continue;

                System.Drawing.Color rowBackColor = System.Drawing.Color.Lime;
                System.Drawing.Color rowForeColor = System.Drawing.Color.Black;

                if (row.Cells["TestResult"].Value.ToString() == "NG" || row.Cells["ViResult"].Value.ToString() == "NG")
                {
                    rowBackColor = System.Drawing.Color.Red;
                    rowForeColor = System.Drawing.Color.White;
                }
                else if (row.Cells["TestResult"].Value.ToString() == "BrakDanych" || row.Cells["ViResult"].Value.ToString() == "BrakDanych")
                {
                    rowBackColor = System.Drawing.Color.Yellow;
                }
                else if (row.Cells["TestResult"].Value.ToString() == "Sprawdzam..." || row.Cells["ViResult"].Value.ToString() == "Sprawdzam...")
                {
                    rowBackColor = System.Drawing.Color.Yellow;
                }
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = rowBackColor;
                    cell.Style.ForeColor = rowForeColor;
                }
            }
        }

        public static bool DeletePcb(string serial, ref CurrentBox currentBox, DataGridView grid)
        {
            int rowIndex = -1;
            if (currentBox.LedsInBox.ContainsKey(serial))
            {
                currentBox.LedsInBox.Remove(serial);
            }
            else return false;

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.Cells["PCB"].Value!=null)
                {
                    if (row.Cells["PCB"].Value.ToString()==serial)
                    {
                        rowIndex = row.Index;
                    }
                }
            }
            if (rowIndex < 0) return false;

            grid.Rows.RemoveAt(rowIndex);
            FilesOperations.SaveBoxFile(currentBox);
            return true;
        }

        public static void AutoColumnSize(DataGridView grid, DataGridViewAutoSizeColumnMode adjustMode)
        {
            //foreach (DataGridViewColumn  col in grid.Columns)
            //{
            //    col.AutoSizeMode = adjustMode;
            //}
        }
    }
}
