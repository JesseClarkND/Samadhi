using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SQLite.Accessor
{
    public class DbField
    {
        public string Name = "";
        public DbType Type;
        public object Value = null;

        public DbField()
        { }

        public DbField(string name, DbType type, object value)
        {
            Name = name;
            Type = type;
            Value = value;
        }
    }
}