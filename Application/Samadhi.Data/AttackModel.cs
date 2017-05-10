using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samadhi.Data
{
    public class AttackModel
    {
        public string Payload = "";
        public string Verification = "";
        public int Priority = 0;
        public string Type = "";
        public bool Confirmed;
        public string AttackedParameter = "";

        public AttackModel(string payload, int priority, string type)
        {
            Payload = payload;
            Priority = priority;
            Type = type;
        }

        public AttackModel(string payload, string verification, int priority, string type)
        {
            Payload = payload;
            Verification = verification;
            Priority = priority;
            Type = type;
        }
    }
}