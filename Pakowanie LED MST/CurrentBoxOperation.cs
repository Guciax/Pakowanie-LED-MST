using Pakowanie_LED_MST.Data_structure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pakowanie_LED_MST
{
    class CurrentBoxOperation
    {
        public static void AddPcbToBox(Dictionary<string,DateTime> serials, ref CurrentBox currentBox, DataGridView grid)
        {
            Dictionary<string, SqlOperations.TestResultStructure> testResults = SqlOperations.CheckTestResultsForPcbsMeasurementsCount_View(serials.Select(key=>key.Key).ToArray());
            Dictionary<string, SqlOperations.ViResultStructure> viResults = SqlOperations.CheckViResultsNgTrackingTable(serials.Select(key => key.Key).ToArray());

            foreach (var pcbEntry in serials)
            {
                string testResult = "BrakDanych";
                DateTime testDate = new DateTime();
                
                if (testResults.ContainsKey(pcbEntry.Key))
                {
                    testResult = testResults[pcbEntry.Key].result;
                    testDate = testResults[pcbEntry.Key].testDate;
                }

                string viResult = "OK";
                string reworkResult = "";
                DateTime reworkDate = new DateTime();
                string postReworkVi = "";
                string oqaResult = "";
                ReworkInfo reworkInfo = null;

                if (viResults.ContainsKey(pcbEntry.Key))
                {
                    viResult = viResults[pcbEntry.Key].result;
                    reworkResult = viResults[pcbEntry.Key].reworkResult;
                    reworkDate = viResults[pcbEntry.Key].rewokDate;
                    postReworkVi = viResults[pcbEntry.Key].postReworkViResult;
                    oqaResult = viResults[pcbEntry.Key].OqaResult;
                    reworkInfo = new ReworkInfo(reworkResult, reworkDate, postReworkVi, oqaResult);
                }
                LedsInCurrentBoxStruct newPcb = new LedsInCurrentBoxStruct(pcbEntry.Value, testResult, testDate, viResult, reworkInfo, false);

                if (currentBox.LedsInBox.Count == 0)
                {
                    if (pcbEntry.Key.Split('_').Length == 3)
                    {
                        string nc12 = pcbEntry.Key.Split('_')[0].Replace(" ","");
                        currentBox.FirstModule12Nc = nc12;
                    }
                    else
                    {
                        currentBox.FirstModule12Nc = "";
                    }
                }

                currentBox.LedsInBox.Add(pcbEntry.Key, newPcb);

                string finalViResult = viResult;
                if (viResult!="OK" & reworkResult=="OK" & testResult == "OK" & testDate > reworkDate & postReworkVi == "OK" & oqaResult == "OK") 
                {
                    finalViResult = "OK";
                }

                grid.Rows.Insert(0, grid.Rows.Count + 1, pcbEntry.Value, pcbEntry.Key, testResult, finalViResult);
                DgvTools.ColorGridRows(grid);
            }
        }


        public static string GetFinalViInspectionResult(LedsInCurrentBoxStruct pcb)
        {
            string result = pcb.ViResult;

            if (pcb.ViResult=="NG")
            {
                if (pcb.ReworkNfo.ReworkResult=="OK" 
                    & pcb.ReworkNfo.PostReworkViResult=="OK"
                    & pcb.ReworkNfo.ReworkDate < pcb.TestDate)
                {
                    result = "OK";
                }
            }
            return result;
        }
    }
}
