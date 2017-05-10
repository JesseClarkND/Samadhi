using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samadhi.History.Data.Results
{
    public class ExhaustedURLFindResult
    {
        public List<ExhaustedURL> Items = new List<ExhaustedURL>();
        public bool Error = false;
        public string Message = "";
    }
}