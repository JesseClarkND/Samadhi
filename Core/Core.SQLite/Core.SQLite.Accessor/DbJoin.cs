using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SQLite.Accessor
{
    public class DbJoin
    {
        public string Table = "";
        public JoinType JoinType;
        public string Criteria = "";
    }

    public enum JoinType
    {
        LeftJoin,
        RightJoin,
        FullJoin
    }
}
