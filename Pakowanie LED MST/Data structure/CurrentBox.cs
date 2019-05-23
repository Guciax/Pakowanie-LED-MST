using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Pakowanie_LED_MST.Data_structure
{
    public class CurrentBox
    {
        public CurrentBox(string boxId, string modelName, Dictionary<string, LedsInCurrentBoxStruct> ledsInBox, bool newResultsAdded, int totalQty, int ngQty, int unknownTestQty, int goodQty, string firstModule12Nc)
        {
            BoxId = boxId;
            ModelName = modelName;
            LedsInBox = ledsInBox;
            NewResultsAdded = newResultsAdded;
            TotalQty = totalQty;
            NgQty = ngQty;
            UnknownTestQty = unknownTestQty;
            GoodQty = goodQty;
            FirstModule12Nc = firstModule12Nc;
        }

        public string BoxId { get; set; }
        public string ModelId { get; set; }
        public string ModelName { get; set; }
        public Dictionary<string, LedsInCurrentBoxStruct> LedsInBox { get; set; }
        
        public bool NewResultsAdded { get; set; }
        public int TotalQty
        {
            get
            {
                return LedsInBox.Count;
            }
            set
            { }
        }
        public int NgQty
        {
            get
            {
                int ng = 0;
                foreach (var pcbEntry in LedsInBox)
                {
                    if (pcbEntry.Value.TestResult=="NG" || pcbEntry.Value.ViResult == "NG")
                    {
                        ng++;
                    }
                }
                return ng;
            }
            set { }
        }
        public int UnknownTestQty
        {
            get
            {
                int counter = 0;
                foreach (var pcbEntry in LedsInBox)
                {
                    if (pcbEntry.Value.TestResult == "BrakDanych" & pcbEntry.Value.ViResult == "BrakDanych")
                    {
                        counter++;
                    }
                }
                return counter;
            }
            set { }
        }
        public int GoodQty
        { get
            {
                return TotalQty - NgQty - UnknownTestQty;
            }
            set
            {}
        }

        public string FirstModule12Nc { get; set; }
    }
}
