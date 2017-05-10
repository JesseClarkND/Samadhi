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
    public class AttackHistoryController
    {
        public AttackHistoryController()
        {}

        public void CreateTable()
        {
            string createQuery = @"CREATE TABLE IF NOT EXISTS
                                      [attack_history] (
                                      [id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                      [url] NVARCHAR(2048) NULL,
                                      [payload] NVARCHAR(2048) NULL,
                                      [verification] NVARCHAR(2048) NULL,
                                      [type] NVARCHAR(50) NULL,
                                      [priority] INTEGER NULL,
                                      [tested] NVARCHAR(1) NULL)";

            DbAccessor connection = new DbAccessor();
            connection.SetUpTable(createQuery);
        }

        public AttackHistoryUpdateResult Insert(AttackHistory history)
        {
            AttackHistoryUpdateResult result = new AttackHistoryUpdateResult();

            try
            {
                DbUpdater updater = new DbUpdater();
                BindUpdateParameters(history, updater, false);
                result.AttackHistoryId = updater.Insert("attack_history");//, "id", "id");//test
            }
            catch (Exception ex)
            {
                result.Error = true;
                result.Messaage = ex.Message;
            }

            return result;
        }

        public AttackHistoryUpdateResult SetAsTested(AttackHistory history)
        {
            AttackHistoryUpdateResult result = new AttackHistoryUpdateResult();
            DbUpdater updater = new DbUpdater();
            history.Tested = true;
            BindUpdateParameters(history, updater);

            string whereClause = "id=:id";
            updater.BindCriteriaParameter("id", DbType.Int32, history.AttackHistoryId);
            result.AttackHistoryId = updater.UpdateWhere("attack_history", "id", history.AttackHistoryId, whereClause);
            return result;

            //string insertQuery = @"UPDATE attack_history SET "+
            //                      "tested = 'T' " +
            //                      "WHERE id = '" + id + "'";
            //using (System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand(_connection))
            //{
            //    try
            //    {
            //        _connection.Open();
            //        cmd.CommandText = insertQuery;
            //        result.RowsAffected = cmd.ExecuteNonQuery();
            //        result.AttackHistoryId = (int)_connection.LastInsertRowId;
            //    }
            //    finally
            //    {
            //        _connection.Close();
            //    }
            //}

            return result;
        }

        public AttackHistoryFindResult FindUntested()
        {
            string criteria = "tested<>:tested";
            List<DbField> parameters = new List<DbField>();
            parameters.Add(new DbField("tested", DbType.String, "T"));
            return GenericFind(criteria, parameters);
        }

        public AttackHistoryFindResult FindAll()
        {
            return GenericFind("",null);
        }

        public AttackHistoryFindResult FindByType(string type)
        {
            //string criteria = "type = " + type;
            //return GenericFind(criteria);
            string criteria = "type=:type";
            List<DbField> parameters = new List<DbField>();
            parameters.Add(new DbField("type", DbType.String, type));
            return GenericFind(criteria, parameters);
        }

        private AttackHistoryFindResult GenericFind(string whereClause, List<DbField> parameters)
        {
            AttackHistoryFindResult result = new AttackHistoryFindResult();
            try
            {
                DbAccessor connection = new DbAccessor();
                AddAcessorSelectors(connection);

                if (!String.IsNullOrEmpty(whereClause))
                {
                    connection.SetWhereClause(whereClause, parameters);
                }
                List<string> tables = new List<string>();
                tables.Add("attack_history");

                DataView dataView = connection.FindWhere(tables);

                foreach (DataRowView row in dataView)
                {
                    AttackHistory attackHistory = DataRowToAttackHistory(row);
                    result.Items.Add(attackHistory);
                }
            }
            catch (Exception ex)
            {
                result.Error = true;
                result.Message = ex.Message;
            }
            //string selectQuery = @"SELECT id, url, payload, verification, type, priority, tested FROM attack_history";

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
            //                AttackHistory history = new AttackHistory();
            //                history.AttackHistoryId = (int)reader["id"];
            //                history.URL = reader["url"].ToString();
            //                history.Payload = reader["payload"].ToString();
            //                history.Verification = reader["verification"].ToString();
            //                history.Type = reader["type"].ToString();
            //                history.Priority = (int)reader["priority"];
            //                history.Tested = reader["tested"].ToString() == "T";
            //                result.Items.Add(history);
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
        private static void BindUpdateParameters(AttackHistory history, DbUpdater updater, bool includeId = true)
        {
            if (includeId)
                updater.BindParameter("id", DbType.Int32, history.AttackHistoryId);
            updater.BindParameter("url", DbType.String, history.URL);
            updater.BindParameter("payload", DbType.String, history.Payload);
            updater.BindParameter("verification", DbType.String, history.Verification);
            updater.BindParameter("type", DbType.String, history.Type);
            updater.BindParameter("priority", DbType.Int32, history.Priority);
            updater.BindParameter("tested", DbType.Boolean, history.Tested);
        }

        private static AttackHistory DataRowToAttackHistory(DataRowView row)
        {
            AttackHistory history = new AttackHistory();
            history.AttackHistoryId = DatabaseUtilities.SafeMapToInt32(row["id"], "id");
            history.URL = DatabaseUtilities.SafeMapToString(row["url"]);
            history.Payload = DatabaseUtilities.SafeMapToString(row["payload"]);
            history.Verification = DatabaseUtilities.SafeMapToString(row["verification"]);
            history.Type = DatabaseUtilities.SafeMapToString(row["type"]);
            history.Priority = DatabaseUtilities.SafeMapToInt32(row["priority"], "priority");
            history.Tested = DatabaseUtilities.SafeMapToBoolean(row["tested"]);
            return history;
        }

        private static AttackHistory DictionaryToAttackHistory(Dictionary<string, Object> vals)
        {
            AttackHistory history = new AttackHistory();
            history.AttackHistoryId = DatabaseUtilities.SafeMapToInt32(vals, "id");
            history.URL = DatabaseUtilities.SafeMapToString(vals, "url");
            history.Payload = DatabaseUtilities.SafeMapToString(vals, "payload");
            history.Verification = DatabaseUtilities.SafeMapToString(vals, "verification");
            history.Type = DatabaseUtilities.SafeMapToString(vals, "type");
            history.Priority = DatabaseUtilities.SafeMapToInt32(vals, "priority");
            history.Tested = DatabaseUtilities.SafeMapToBoolean(vals, "tested");
            return history;
        }

        private static void AddAcessorSelectors(DbAccessor connection)
        {
            connection.Select("id", DbType.Int32);
            connection.Select("url", DbType.String);
            connection.Select("payload", DbType.String);
            connection.Select("verification", DbType.String);
            connection.Select("type", DbType.String);
            connection.Select("priority", DbType.String);
            connection.Select("tested", DbType.String);
        }
        #endregion
    }
}