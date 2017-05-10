using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SQLite.Accessor
{
    public class DatabaseManager
    {
        public static SQLiteConnection GetConnection()
        {
            string sqlitedb = Settings.ConnectionString;

            SQLiteConnection conn = new SQLiteConnection(sqlitedb);
            return conn;
        }

        ///This is for oracle and not for sqlite
        //public static int GetIdentity(string sequence, SQLiteConnection connection)
        //{
           
        //    SQLiteCommand selCmd = new SQLiteCommand();
        //    String sql = "select " + sequence + " .NEXTVAL from DUAL";
        //    selCmd.Connection = connection;
        //    selCmd.CommandText = sql;
        //    SQLiteDataReader dr = selCmd.ExecuteReader();

        //    int nextNum = 0;

        //    try
        //    {
        //        if (dr.Read())
        //        {
        //            Decimal d = dr.GetDecimal(0);
        //            nextNum = Convert.ToInt32(d);
        //        }
        //        else
        //            throw new Exception("Unable to generate identity value for " + sequence);

        //    }
        //    finally
        //    {
        //        dr.Dispose();
        //        selCmd.Dispose();
        //    }
        //    return nextNum;
        //}
    }
}
