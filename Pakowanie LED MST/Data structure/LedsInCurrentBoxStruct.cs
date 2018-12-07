using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pakowanie_LED_MST
{
    public class LedsInCurrentBoxStruct
    {
        private string _serial;

        public LedsInCurrentBoxStruct(DateTime date, string serial, string orderNo, string testResult, string viResult, bool addMeToGrid=true)
        {
            Date = date;
            Serial = serial;
            OrderNo = orderNo;
            TestResult = testResult;
            ViResult = viResult;
            AddMeToGrid = addMeToGrid;
        }

        public DateTime Date { get; }
        public string Serial
        {
            get
            {
                return _serial;
            }
            set
            {
                _serial = value;

            }
        }
        public string OrderNo { get; set; }
        public string TestResult { get; set; }
        public string ViResult { get; set; }
        public bool AddMeToGrid { get; set; }
    }
}
