using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samadhi.History.Data.Results
{
    public class AttackHistoryFindResult
    {
        public List<AttackHistory> Items = new List<AttackHistory>();
        public bool Error = false;
        public string Message = "";
    }
}