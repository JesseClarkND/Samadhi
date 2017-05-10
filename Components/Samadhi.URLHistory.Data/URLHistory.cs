using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samadhi.History.Data
{
    public class URLHistory
    {
        public int URLHistoryId = 0;
        public string URL = "";
        public string ResponseCode = "";
        public int Length = 0;
        public int Priority = 0;
        public string Info = "";
        public DateTime? EntryDate;
    }
}
