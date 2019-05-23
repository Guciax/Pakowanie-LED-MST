using Pakowanie_LED_MST.Data_structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pakowanie_LED_MST
{
    class TestResults
    {
        public struct TestResultsStructure
        {
            public string testTesult;
            public string viTesult;
        }

        public static bool CheckResultsForBox(ref CurrentBox currentBox, bool checkTest, bool checkVi)
        {
            bool newResultsFound = false;
            if (currentBox != null)
            {
                List<string> pcbWithoutTest = new List<string>();
                List<string> pcbWithoutVi = new List<string>();

                foreach (var pcbEntry in currentBox.LedsInBox)
                {
                    if (pcbEntry.Value.TestResult != "OK")
                    {
                        if (checkTest)
                        {
                            pcbWithoutTest.Add(pcbEntry.Key);
                        }
                    }

                    if ( pcbEntry.Value.ViResult != "OK")
                    {
                        if (checkVi)
                        {
                            pcbWithoutVi.Add(pcbEntry.Key);
                        }
                    }
                }

                if (pcbWithoutTest.Count > 0) 
                {
                    Dictionary<string, SqlOperations.TestResultStructure> testTes = SqlOperations.CheckTestResultsForPcbsMeasurementsCount_View(pcbWithoutTest.ToArray());
                    foreach (var pcb in pcbWithoutTest)
                    {
                        if (!testTes.ContainsKey(pcb)) continue;
                        if(currentBox.LedsInBox[pcb].TestResult != testTes[pcb].result)
                        {
                            currentBox.LedsInBox[pcb].TestResult = testTes[pcb].result;
                            currentBox.LedsInBox[pcb].TestDate = testTes[pcb].testDate;
                            currentBox.LedsInBox[pcb].UpdateMe = true;
                            newResultsFound=true;
                        }
                    }
                }

                if (pcbWithoutVi.Count > 0)
                {
                    Dictionary<string, SqlOperations.ViResultStructure> viRes = SqlOperations.CheckViResultsNgTrackingTable(pcbWithoutVi.ToArray());
                    foreach (var pcb in pcbWithoutVi)
                    {
                        if (!viRes.ContainsKey(pcb)) continue;
                        string checkCurBox = currentBox.LedsInBox[pcb].ViResult = viRes[pcb].result + currentBox.LedsInBox[pcb].ReworkNfo.ReworkResult + currentBox.LedsInBox[pcb].ReworkNfo.ReworkDate + currentBox.LedsInBox[pcb].ReworkNfo.PostReworkViResult + currentBox.LedsInBox[pcb].ReworkNfo.OqaResult;
                        string checkUpdated = viRes[pcb].result+viRes[pcb].reworkResult+ viRes[pcb].rewokDate+ viRes[pcb].postReworkViResult+ viRes[pcb].OqaResult;
                        if (checkCurBox != checkUpdated)
                        {
                            currentBox.LedsInBox[pcb].ViResult = viRes[pcb].result;
                            currentBox.LedsInBox[pcb].ReworkNfo.ReworkResult = viRes[pcb].reworkResult;
                            currentBox.LedsInBox[pcb].ReworkNfo.ReworkDate = viRes[pcb].rewokDate;
                            currentBox.LedsInBox[pcb].ReworkNfo.PostReworkViResult = viRes[pcb].postReworkViResult;
                            currentBox.LedsInBox[pcb].ReworkNfo.OqaResult = viRes[pcb].OqaResult;
                            currentBox.LedsInBox[pcb].UpdateMe = true;
                            newResultsFound = true;
                        }
                    }
                }
            }
            return newResultsFound;
        }

    }
}
