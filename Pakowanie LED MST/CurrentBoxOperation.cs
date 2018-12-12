using Pakowanie_LED_MST.Data_structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pakowanie_LED_MST
{
    class CurrentBoxOperation
    {
        public static void AddPcbToBox(string serial, ref CurrentBox currentBox)
        {
            Dictionary<string, string> testResult = TestResults.CheckTestResult(new string[] { serial });
            Dictionary<string, string> viResult = TestResults.CheckViResult(new string[] { serial });

            string pcbTestResult = "";
            if (!testResult.TryGetValue(serial, out pcbTestResult)) pcbTestResult = "BrakDanych";

            string pcbViResult = "";
            if (!viResult.TryGetValue(serial, out pcbViResult)) pcbViResult = "BrakDanych";

            currentBox.LedsInBox.Add(serial, new LedsInCurrentBoxStruct(DateTime.Now, serial, "", pcbTestResult, pcbViResult, true));
            currentBox.NewResultsAdded = true;
        }
    }
}
