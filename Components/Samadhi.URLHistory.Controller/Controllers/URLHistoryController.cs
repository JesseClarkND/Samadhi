using Core.SQLite.Accessor;
using Samadhi.History.Data;
using Samadhi.History.Data.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samadhi.History.Controller.Controllers
{
    public class URLHistoryController
    {
        public URLHistoryController()
        {}

        public void CreateTable()
        {
            string createQuery = @"CREATE TABLE IF NOT EXISTS
                                      [url_history] (
                                      [id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                      [url] NVARCHAR(2048) NULL,
                                      [response_code] NVARCHAR(3) NULL,
                                      [length] INTEGER NULL,
                                      [priority] INTEGER NULL,
                                      [info] NVARCHAR(2048) NULL,
                                      [date] DATETIME NULL)";

            DbAccessor connection = new DbAccessor();
            connection.SetUpTable(createQuery);
        }

        public URLHistoryUpdateResult Insert(URLHistory history)
        {
            URLHistoryUpdateResult result = new URLHistoryUpdateResult();
            try
            {
                DbUpdater updater = new DbUpdater();
                BindUpdateParameters(history, updater, false);
                result.URLHistoryId = updater.Insert("url_history");//, "id", "id");//test
            }
            catch (Exception ex)
            {
                result.Error = true;
                result.Messaage = ex.Message;
            }

            return result;
        }

        public URLHistoryUpdateResult Update(Data.URLHistory history)
        {
            throw new NotImplementedException();
        }

        public URLHistoryFindResult FindByCode(string code)
        {
            string criteria = "code=:code";
            List<DbField> parameters = new List<DbField>();
            parameters.Add(new DbField("code", DbType.String, code));
            return GenericFind(criteria, parameters);
        }

        public URLHistoryFindResult FindAllBeyondId(int id)
        {
            string criteria = "id>:id";
            List<DbField> parameters = new List<DbField>();
            parameters.Add(new DbField("id", DbType.String, id));
            return GenericFind(criteria, parameters);
        }

        private URLHistoryFindResult FindByMinimumPriority(int priority)
        {
            throw new NotImplementedException();
            //string criteria = "priority >= " + priority;
            //return GenericFind(criteria);
        }

        private URLHistoryFindResult GenericFind(string whereClause = "", List<DbField> parameters = null)
        {
            URLHistoryFindResult result = new URLHistoryFindResult();

            try
            {
                DbAccessor connection = new DbAccessor();
                AddAcessorSelectors(connection);

                if (!String.IsNullOrEmpty(whereClause))
                {
                    connection.SetWhereClause(whereClause, parameters);
                }

                List<string> tables = new List<string>();
                tables.Add("url_history");

                DataView dataView = connection.FindWhere(tables);

                foreach (DataRowView row in dataView)
                {
                    URLHistory urlHistory = DataRowToURLHistory(row);
                    result.Items.Add(urlHistory);
                }
                //string selectQuery = @"SELECT id, url, response_code, length, priority, info, date FROM url_history";

                //if (!String.IsNullOrEmpty(criteria))
                //    selectQuery += " WHERE " + criteria;
                //_connection.Open();
                //using (System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand(_connection))
                //{
                //    cmd.CommandText = selectQuery;
                //    using (System.Data.SQLite.SQLiteDataReader reader = cmd.ExecuteReader())
                //    {
                //        while (reader.Read())
                //        {
                //            Data.URLHistory history = new Data.URLHistory();
                //            history.URLHistoryId = (int)reader["id"];
                //            history.URL = reader["url"].ToString();
                //            history.Length = (int)reader["length"];
                //            history.Priority = (int)reader["priority"];
                //            history.Info = reader["info"].ToString();
                //            history.EntryDate = DateTime.Parse(reader["date"].ToString());
                //            result.Items.Add(history);
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                result.Error = true;
                result.Message = ex.Message;
            }

            return result;
        }

        #region Private
        private static void BindUpdateParameters(URLHistory history, DbUpdater updater, bool includeId = true)
        {
            if (includeId)
                updater.BindParameter("id", DbType.Int32, history.URLHistoryId);
            updater.BindParameter("url", DbType.String, history.URL);
            updater.BindParameter("response_code", DbType.String, history.ResponseCode);
            updater.BindParameter("length", DbType.Int32, history.Length);
            updater.BindParameter("priority", DbType.Int32, history.Priority);
            updater.BindParameter("info", DbType.String, history.Info);
            updater.BindParameter("date", DbType.DateTime, history.EntryDate);
        }

        private static URLHistory DataRowToURLHistory(DataRowView row)
        {
            URLHistory history = new URLHistory();
            history.URLHistoryId = DatabaseUtilities.SafeMapToInt32(row["id"], "id");
            history.URL = DatabaseUtilities.SafeMapToString(row["url"]);
            history.ResponseCode = DatabaseUtilities.SafeMapToString(row["response_code"]);
            history.Length = DatabaseUtilities.SafeMapToInt32(row["length"], "length");
            history.Priority = DatabaseUtilities.SafeMapToInt32(row["priority"], "priority");
            history.Info = DatabaseUtilities.SafeMapToString(row["info"]);
            history.EntryDate = DatabaseUtilities.SafeMapToNullableDateTime(row["date"]);
            return history;
        }

        private static URLHistory DictionaryToURLHistory(Dictionary<string, Object> vals)
        {
            URLHistory history = new URLHistory();
            history.URLHistoryId = DatabaseUtilities.SafeMapToInt32(vals, "id");
            history.URL = DatabaseUtilities.SafeMapToString(vals, "url");
            history.ResponseCode = DatabaseUtilities.SafeMapToString(vals, "response_code");
            history.Length = DatabaseUtilities.SafeMapToInt32(vals, "length");
            history.Priority = DatabaseUtilities.SafeMapToInt32(vals, "priority");
            history.Info = DatabaseUtilities.SafeMapToString(vals, "info");
            history.EntryDate = DatabaseUtilities.SafeMapToNullableDateTime(vals, "date");
            return history;
        }

        private static void AddAcessorSelectors(DbAccessor connection)
        {
            connection.Select("id", DbType.Int32);
            connection.Select("url", DbType.String);
            connection.Select("response_code", DbType.String);
            connection.Select("length", DbType.Int32);
            connection.Select("priority", DbType.Int32);
            connection.Select("info", DbType.String);
            connection.Select("date", DbType.DateTime);
        }
        #endregion
    }
}