using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samadhi.History.Data.Results
{
    public class AttackHistoryUpdateResult
    {
        public int RowsAffected = 0;
        public int AttackHistoryId = 0;
        public bool Error = false;
        public string Messaage = "";
    }
}