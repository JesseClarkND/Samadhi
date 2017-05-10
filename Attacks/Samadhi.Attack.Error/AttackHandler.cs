using Samadhi.Attack.Common;
using Samadhi.Data;
using Samadhi.History.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samadhi.Attack.Error
{
    public class AttackHandler : ParentAttackHandler
    {
        public List<string> VerificationStrings = new List<string>();

        public override bool Validate(AttackHistory attack, Request request)
        {
            foreach(string verfication in VerificationStrings)
            {
                if (request.Response.Body.Contains(verfication))
                {
                    attack.Verification = verfication;
                    return true;
                }
            }
            return false;
        }

        public AttackHandler()
        {
            Attacks.Add(new AttackModel("'", 3, "Error"));
            Attacks.Add(new AttackModel("'--", 3, "Error"));

            VerificationStrings.Add("The following MySQLi query produced an error");
            VerificationStrings.Add("You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax");
            VerificationStrings.Add("java.lang.NullPointerException");
            VerificationStrings.Add("Error Message : Error loading required libraries.");
            VerificationStrings.Add("Warning: mysql_query()");
            VerificationStrings.Add("Warning: Failed opening");
        }
    }
}