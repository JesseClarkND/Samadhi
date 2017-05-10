using Core.SQLite.Accessor;
using Samadhi.History.Data;
using Samadhi.History.Data.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samadhi.History.Controller.Controllers
{
    public class ExhaustedURLController
    {
        public ExhaustedURLController()
        {}

        public void CreateTable()
        {
            string createQuery = @"CREATE TABLE IF NOT EXISTS
                                      [exhausted_url] (
                                      [id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                      [url] NVARCHAR(2048) NULL,
                                      [url_hash] NVARCHAR(2048) NULL)";

            DbAccessor connection = new DbAccessor();
            connection.SetUpTable(createQuery);
        }

        public ExhaustedURLUpdateResult Insert(ExhaustedURL url)
        {
            ExhaustedURLUpdateResult result = new ExhaustedURLUpdateResult();
            try
            {
                DbUpdater updater = new DbUpdater();
                BindUpdateParameters(url, updater, false);
                result.ExhaustedURLId = updater.Insert("exhausted_url");//, "id", "id");//test
            }
            catch (Exception ex)
            {
                result.Error = true;
                result.Messaage = ex.Message;
            }
            return result;
        }

        private void RemoveByURL(string url)
        {
            DbUpdater updater = new DbUpdater();

            string whereClause = "";

            whereClause = "url=:url";
            updater.BindCriteriaParameter("url", DbType.String, url);

            updater.DeleteWhere("exhausted_url", whereClause);

            //string deleteQuery = "DELETE FROM exhausted_url WHERE url='" + url.Replace("'", "''") + "'";

            //using (System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand(_connection))
            //{
            //    try
            //    {
            //        _connection.Open();
            //        cmd.CommandText = deleteQuery;
            //        cmd.ExecuteNonQuery();
            //   }
            //    finally
            //    {
            //        _connection.Close();
            //    }
            //}
        }

        //public bool IsURLExhausted(string url)
        //{
        //    string criteria = "url = '" + url.Replace("'", "''") + "'";
        //    ExhaustedURLFindResult result = GenericFind(criteria);
        //    if (result.Items.Count == 0)
        //        return false;
        //    return true;
        //}

        public ExhaustedURLFindResult FindAll()
        {
            return GenericFind("", null);
        }

        private ExhaustedURLFindResult GenericFind(string whereClause, List<DbField> parameters)
        {
            ExhaustedURLFindResult result = new ExhaustedURLFindResult();

            try
            {
                DbAccessor connection = new DbAccessor();
                AddAcessorSelectors(connection);

                if (!String.IsNullOrEmpty(whereClause))
                {
                    connection.SetWhereClause(whereClause, parameters);
                }
                List<string> tables = new List<string>();
                tables.Add("exhausted_url");

                DataView dataView = connection.FindWhere(tables);

                foreach (DataRowView row in dataView)
                {
                    ExhaustedURL exhaustedURL = DataRowToExhaustedURL(row);
                    result.Items.Add(exhaustedURL);
                }
            }
            catch (Exception ex)
            {
                result.Error = true;
                result.Message = ex.Message;
            }

            //ExhaustedURLFindResult result = new ExhaustedURLFindResult();

            //string selectQuery = @"SELECT id, url, url_hash FROM exhausted_url";

            //if (!String.IsNullOrEmpty(criteria))
            //    selectQuery += " WHERE " + criteria;

            //try
            //{
            //    _connection.Open();
            //    using (System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand(_connection))
            //    {
            //        cmd.CommandText = selectQuery;
            //        using (System.Data.SQLite.SQLiteDataReader reader = cmd.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                ExhaustedURL url = new ExhaustedURL();
            //                url.URL = reader["url"].ToString();
            //                url.URLHash = reader["url_hash"].ToString();
            //                url.ExhaustedURLId = int.Parse(reader["id"].ToString());
            //                result.Items.Add(url);
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    result.Error = true;
            //    result.Message = ex.Message;
            //}
            //finally
            //{
            //    _connection.Close();
            //}

            return result;
        }


        #region Private
        private static void BindUpdateParameters(ExhaustedURL history, DbUpdater updater, bool includeId = true)
        {
            if (includeId)
                updater.BindParameter("id", DbType.Int32, history.ExhaustedURLId);
            updater.BindParameter("url", DbType.String, history.URL);
            updater.BindParameter("url_hash", DbType.String, history.URLHash);
        }

        private static ExhaustedURL DataRowToExhaustedURL(DataRowView row)
        {
            ExhaustedURL history = new ExhaustedURL();
            history.ExhaustedURLId = DatabaseUtilities.SafeMapToInt32(row["id"], "id");
            history.URL = DatabaseUtilities.SafeMapToString(row["url"]);
            history.URLHash = DatabaseUtilities.SafeMapToString(row["url_hash"]);
            return history;
        }

        private static ExhaustedURL DictionaryToExhaustedURL(Dictionary<string, Object> vals)
        {
            ExhaustedURL history = new ExhaustedURL();
            history.ExhaustedURLId = DatabaseUtilities.SafeMapToInt32(vals, "id");
            history.URL = DatabaseUtilities.SafeMapToString(vals, "url");
            history.URLHash = DatabaseUtilities.SafeMapToString(vals, "url_hash");
            return history;
        }

        private static void AddAcessorSelectors(DbAccessor connection)
        {
            connection.Select("id", DbType.Int32);
            connection.Select("url", DbType.String);
            connection.Select("url_hash", DbType.String);
        }
        #endregion
    }
}