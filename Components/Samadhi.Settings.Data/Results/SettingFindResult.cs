using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samadhi.Common.Data.Results
{
    public class SettingFindResult
    {
        List<Setting> Items = new List<Setting>();
        public bool Error = false;
        public string Message = "";
    }
}
