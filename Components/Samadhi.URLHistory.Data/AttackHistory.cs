using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samadhi.History.Data
{
    public class AttackHistory
    {
        public int AttackHistoryId = 0;
        public string URL = "";
        public string Payload = "";
        public string Verification = "";
        public string Type = "";
        public int Priority = 0;
        public bool Tested = false;
        public string AttackedParameter = "";
    }
}