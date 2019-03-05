using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TempTestSSD_LOGINALONE.Models
{
    public class ReportOutputModel
    {

        public Dictionary<string, string> OutputDictionary { get; set; }
        public int Counter { get; set; }

        public ReportOutputModel()
        {
            OutputDictionary = new Dictionary<string, string>();
            Counter = 0;
        }
    }
}
