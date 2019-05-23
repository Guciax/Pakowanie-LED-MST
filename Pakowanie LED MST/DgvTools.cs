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

        public static void UpdateTestsToGrid(DataGridView grid, ref CurrentBox currentBox)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.Cells["PCB"].Value == null) continue;
                string serial = row.Cells["PCB"].Value.ToString();
                if (!currentBox.LedsInBox[serial].UpdateMe) continue;

                row.Cells["TestResult"].Value = currentBox.LedsInBox[serial].TestResult;
                row.Cells["ViResult"].Value = CurrentBoxOperation.GetFinalViInspectionResult(currentBox.LedsInBox[serial]);
                currentBox.LedsInBox[serial].UpdateMe = false;
            }

        }

        private static int SetCellResultStatus(string value)
        {
            if (value == "Sprawdzam...") return 0;
            if (value == "OK") return 1;
            if (value == "BrakDanych") return 2;
            return 3;
        }

        public static string[] CheckMixed12NC(DataGridView grid)
        {
            List<string> nc12InBox = new List<string>();
            if (grid.Rows.Count > 0)
            {
                string firstPcbSerial = grid.Rows[grid.Rows.Count - 1].Cells["PCB"].Value.ToString();
                string firstPcb12NC = "";

                if (firstPcbSerial.Split('_').Length == 3)
                {
                    firstPcb12NC = firstPcbSerial.Split('_')[0].Replace(" ","");

                    nc12InBox.Add(firstPcb12NC);
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        string[] serialNo = row.Cells["PCB"].Value.ToString().Split('_');
                        if (serialNo.Length != 3) continue;
                        string nc12 = serialNo[0].Replace(" ", "");
                        if (nc12InBox.Contains(nc12)) continue;
                        nc12InBox.Add(nc12);
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            cell.Style.BackColor = System.Drawing.Color.Orange;
                            cell.Style.ForeColor = System.Drawing.Color.White;
                        }
                    }
                }
            }
            return nc12InBox.ToArray();
        }

        public static void ColorGridRows(DataGridView grid)
        {
            if (grid.Rows.Count > 0)
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
                    testStatus = SetCellResultStatus(row.Cells["TestResult"].Value.ToString());

                    int viStatus = 0;
                    viStatus = SetCellResultStatus(row.Cells["ViResult"].Value.ToString());


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
        }

        public static void DeletePcb(string serial, ref CurrentBox currentBox, DataGridView grid, int rowIndex)
        {
            if (SqlOperations.DeletePcbFromBoxSqlTable(serial))
            {
                grid.Rows.RemoveAt(rowIndex);
                currentBox.LedsInBox.Remove(serial);
            }
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
