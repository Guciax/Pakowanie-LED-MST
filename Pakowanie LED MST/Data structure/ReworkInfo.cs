using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pakowanie_LED_MST.Data_structure
{
    public class ReworkInfo
    {
        public ReworkInfo(string reworkResult, DateTime reworkDate, string postReworkViResult, string OqaResult)
        {
            ReworkResult = reworkResult;
            ReworkDate = reworkDate;
            PostReworkViResult = postReworkViResult;
            this.OqaResult = OqaResult;
        }

        public string ReworkResult { get; set; }
        public DateTime ReworkDate { get; set; }
        public string PostReworkViResult { get; set; }
        public string OqaResult { get; set; }
    }
}
