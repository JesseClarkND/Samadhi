using Samadhi.Application.Crawler;
using Samadhi.Attack.Common;
using Samadhi.Data;
using Samadhi.History.Data;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Samadhi.Application.Utility
{
    public class AttackURLGenerator
    {
        public static List<AttackHistory> CreateAttackURL(string url, ParentAttackHandler attackHandler)
        {
            url = HttpUtility.HtmlDecode(url);
            List<AttackHistory> garbles = new List<AttackHistory>();
            string baseurl = url.Split('?')[0];
            if (baseurl.Equals(url))
                return garbles;

            List<UrlParameters> parameters = new List<UrlParameters>();
            NameValueCollection nvc = HttpUtility.ParseQueryString(url.Split('?')[1]);

            var items = nvc.AllKeys.SelectMany(nvc.GetValues, (k, v) => new { key = k, value = v });
            foreach (var item in items)
            {
                if (item.key == null)
                    continue;

                int index = parameters.FindIndex(z => z.Name.Equals(item.key));
                if (index < 0)
                {
                    parameters.Add(new UrlParameters(item.key, item.value));
                }
            }

            foreach (AttackModel attack in attackHandler.Attacks)
            {
                for (int x = 0; x < parameters.Count; x++)
                {
                    AttackHistory morphedRequest = new AttackHistory();
                    morphedRequest.Payload = attack.Payload;
                    morphedRequest.Priority = attack.Priority;
                    morphedRequest.Type = attack.Type;
                    morphedRequest.Verification = attack.Verification;
                    morphedRequest.Tested = false;
                    string gqueryString = "";

                    int counter = 0;
                    foreach (UrlParameters parm in parameters)
                    {
                        if (counter != 0)
                            gqueryString += "&";
                        if (x == counter && !CrawlerContext.IgnoreVariable.Contains(parameters[x].Name))
                        {
                            gqueryString += parameters[x].Name + "=" + attack.Payload;
                            morphedRequest.AttackedParameter = parameters[x].Name;
                        }
                        else
                        {
                            gqueryString += parm.Name + "=" + parm.Value;
                        }
                        counter++;
                    }
                    //morphedRequest.Attack = attack;
                    morphedRequest.URL = baseurl + "?" + gqueryString;
                    garbles.Add(morphedRequest);
                }
            }
            return garbles;
        }
    }

    class UrlParameters
    {
        public string Name = "";
        public string Value = "";

        public UrlParameters(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
