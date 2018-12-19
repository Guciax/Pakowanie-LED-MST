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

        public static void CheckResultsForBox(ref CurrentBox currentBox, bool checkTest, bool checkVi)
        {
            if (currentBox != null)
            {
                List<string> pcbWithoutTest = new List<string>();
                List<string> pcbWithoutVi = new List<string>();

                foreach (var pcb in currentBox.LedsInBox)
                {
                    if (pcb.Value.TestResult == "BrakDanych" || pcb.Value.TestResult == "NG")
                    {
                        if (checkTest)
                        {
                            pcbWithoutTest.Add(pcb.Value.Serial);
                        }
                    }

                    if ( pcb.Value.ViResult == "BrakDanych" || pcb.Value.ViResult == "NG")
                    {
                        if (checkVi)
                        {
                            pcbWithoutVi.Add(pcb.Value.Serial);
                        }
                    }

                }

                if (pcbWithoutTest.Count > 0)
                {
                    Dictionary<string, string> testResult = CheckTestResult(pcbWithoutTest.ToArray());
                    foreach (var pcb in pcbWithoutTest)
                    {
                        string result = "";
                        if(!testResult.TryGetValue(pcb,out result))
                        {
                            result = "BrakDanych";
                        }
                        currentBox.LedsInBox[pcb].TestResult = result;
                    }
                    if (pcbWithoutTest.Count > 0)
                    {
                        currentBox.NewResultsAdded = true;
                    }
                }

                if (pcbWithoutVi.Count > 0)
                {
                    Dictionary<string, string> testResult = CheckViResult(pcbWithoutVi.ToArray());
                    foreach (var pcb in pcbWithoutVi)
                    {
                        string result = "";
                        if (!testResult.TryGetValue(pcb, out result))
                        {
                            result = "BrakDanych";
                        }
                        currentBox.LedsInBox[pcb].ViResult = result;
                    }
                    if (pcbWithoutTest.Count > 0)
                    {
                        currentBox.NewResultsAdded = true;
                    }
                }
            }
        }

        public static Dictionary<string,string> CheckViResult(string[] serialNo)
        {
            Dictionary<string, string> result = SqlOperations.CheckViResultsForPcbs(serialNo);



            foreach (var pcb in serialNo)
            {
                if (result.ContainsKey(pcb)) continue;
                result.Add(pcb, "OK");
            }

            return result;
        }

        public static Dictionary<string, string> CheckTestResult(string[] serialNo)
        {
            Dictionary<string, string> result = SqlOperations.CheckTestResultsForPcbs(serialNo);
            
            return result;
        }
    }
}
