using Pakowanie_LED_MST.Data_structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pakowanie_LED_MST
{
    public class LedsInCurrentBoxStruct
    {
        private string _serial;

        public LedsInCurrentBoxStruct(DateTime date, string testResult, DateTime testDate, string viResult, ReworkInfo reworkNfo, bool updateMe)
        {
            Date = date;
            TestResult = testResult;
            TestDate = testDate;
            ViResult = viResult;
            ReworkNfo = reworkNfo;
            UpdateMe = updateMe;
        }

        public DateTime Date { get; }
        public string OrderNo { get; set; }
        public string TestResult { get; set; }
        public DateTime TestDate { get; set; }
        public string ViResult { get; set; }
        public ReworkInfo ReworkNfo { get; }
        public bool UpdateMe { get; set; }
    }
}
