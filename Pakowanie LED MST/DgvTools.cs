using Pakowanie_LED_MST.Data_structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pakowanie_LED_MST
{
    class DgvTools
    {
        public static void ShowHideColumns(bool testOption, bool viOption, DataGridView grid)
        {
            if (testOption)
            {
                grid.Columns["TestResult"].Visible = true;
            }
            else
            {
                grid.Columns["TestResult"].Visible = false;
            }

            if (viOption)
            {
                grid.Columns["ViResult"].Visible = true;
            }
            else
            {
                grid.Columns["ViResult"].Visible = false;
            }
        }

        public static void CheckTests(DataGridView grid, ref CurrentBox currentBox)
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
                if (grid.Columns["TestResult"].Visible)
                {
                    row.Cells["TestResult"].Value = currentBox.LedsInBox[serial].TestResult;
                }
                else
                {
                    row.Cells["TestResult"].Value = "Wyłączone";
                }
                if (grid.Columns["ViResult"].Visible)
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

        private static int SetCellResultStatus(string value)
        {
            if (value == "Sprawdzam...") return 0;
            if (value == "OK") return 1;
            if (value == "BrakDanych") return 2;
            return 3;
        }

        public static void ColorGridRows(DataGridView grid)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.Cells["TestResult"].Value == null) continue;
                if (row.Cells["ViResult"].Value == null) continue;

                //columns status:   0-don't change
                //                  1-OK lime
                //                  2-unknown yellow
                //                  3-NG red

                int testStatus = 0;
                if (grid.Columns["TestResult"].Visible)
                {
                    testStatus=SetCellResultStatus(row.Cells["TestResult"].Value.ToString());
                }
                int viStatus = 0;
                if (grid.Columns["ViResult"].Visible)
                {
                    viStatus = SetCellResultStatus(row.Cells["ViResult"].Value.ToString());
                }

                //Debug.WriteLine("test: " + row.Cells["TestResult"].Value.ToString() + " - " + testStatus);
               // Debug.WriteLine("vi  : " + row.Cells["ViResult"].Value.ToString() + " - " + testStatus);

                int rowStatus = Math.Max(testStatus, viStatus);

                if (rowStatus > 0)
                {
                    System.Drawing.Color rowBackColor = System.Drawing.Color.White;
                    System.Drawing.Color rowForeColor = System.Drawing.Color.Black;

                    switch (rowStatus)
                    {
                        case 1:
                            {
                                rowBackColor = System.Drawing.Color.Lime;
                                rowForeColor = System.Drawing.Color.Black;
                                break;
                            }
                        case 2:
                            {
                                rowBackColor = System.Drawing.Color.LightYellow;
                                rowForeColor = System.Drawing.Color.Black;
                                break;
                            }
                        case 3:
                            {
                                rowBackColor = System.Drawing.Color.Red;
                                rowForeColor = System.Drawing.Color.White;
                                break;
                            }
                    }

                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Style.BackColor = rowBackColor;
                        cell.Style.ForeColor = rowForeColor;
                    }
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
