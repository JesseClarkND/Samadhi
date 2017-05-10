using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SQLite.Accessor
{
    public class OrderByField
    {
        public string FieldName = "";
        public OrderByDirection Direction = OrderByDirection.Ascending;
    }
}