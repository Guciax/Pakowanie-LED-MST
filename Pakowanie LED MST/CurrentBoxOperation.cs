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
            currentBox.LedsInBox.Add(serial, new LedsInCurrentBoxStruct(DateTime.Now, serial, "", "BrakDanych", "BrakDanych", true));
            currentBox.NewResultsAdded = true;
        }
    }
}
