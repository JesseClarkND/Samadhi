using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samadhi.History.Data.Results
{
    public class URLHistoryFindResult
    {
        public List<URLHistory> Items = new List<URLHistory>();
        public bool Error = false;
        public string Message = "";
    }
}
