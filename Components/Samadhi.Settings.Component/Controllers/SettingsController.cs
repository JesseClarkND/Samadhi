using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samadhi.Common.Data;
using Samadhi.Common.Data.Results;
using Core.SQLite.Accessor;
using System.Data;

namespace Samadhi.Common.Component.Controllers
{
    public class SettingsController
    {
        public SettingsController()
        { }

        public void CreateTable()
        {
            string createQuery = @"CREATE TABLE IF NOT EXISTS
                                      [settings] (
                                      [id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                      [name] NVARCHAR(2048) NULL,
                                      [value] NVARCHAR(2048) NULL)";

            DbAccessor connection = new DbAccessor();
            connection.SetUpTable(createQuery);
        }

        public string GetValue(string name)
        {
            List<Setting> returnList = new List<Setting>();

            DbAccessor connection = new DbAccessor();
            AddAcessorSelectors(connection);

            string whereClause = "settings.name=:name";
            List<DbField> parameters = new List<DbField>();
            parameters.Add(connection.BindParameter("name", DbType.String, name));

            connection.SetWhereClause(whereClause, parameters);

            List<string> tables = new List<string>();
            tables.Add("settings");

            DataView dataView = connection.FindWhere(tables);

            foreach (DataRowView row in dataView)
            {
                Setting setting = DataRowToSetting(row);
                returnList.Add(setting);
            }

            Setting foundSetting = returnList.FirstOrDefault();
            if (foundSetting == null)
                return "";
            return foundSetting.Value;

            //string selectQuery = @"SELECT value FROM settings WHERE name = '" + name.Replace("'", "''") + "'";
            //string value = "";
            //_connection.Open();
            //try
            //{
            //    using (System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand(_connection))
            //    {
            //        cmd.CommandText = selectQuery;
            //        using (System.Data.SQLite.SQLiteDataReader reader = cmd.ExecuteReader())
            //        {
            //            if (reader.Read())
            //                value=reader["value"].ToString();
            //        }
            //    }
            //}
            //finally
            //{
            //    _connection.Close();
            //}
            //return value;
        }

        public SettingUpdateResult UpdateSetting(Setting setting)
        {
            SettingUpdateResult result = new SettingUpdateResult();

            DbUpdater updater = new DbUpdater();
            BindUpdateParameters(setting, updater);

            string whereClause = "name=:name";
            updater.BindCriteriaParameter("name", DbType.String, setting.Name);
            result.SettingsId = updater.UpdateWhere("settings", "id", setting.SettingsId, whereClause);
            return result;
        }

        #region Private
        private static void BindUpdateParameters(Setting setting, DbUpdater updater, bool includeId = true)
        {
            if (includeId)
                updater.BindParameter("id", DbType.Int32, setting.SettingsId);
            updater.BindParameter("name", DbType.String, setting.Name);
            updater.BindParameter("value", DbType.String, setting.Value);
        }

        private static Setting DataRowToSetting(DataRowView row)
        {
            Setting setting = new Setting();
            setting.SettingsId = DatabaseUtilities.SafeMapToInt32(row["id"], "id");
            setting.Name = DatabaseUtilities.SafeMapToString(row["name"]);
            setting.Value = DatabaseUtilities.SafeMapToString(row["value"]);
            return setting;
        }

        private static Setting DictionaryToSetting(Dictionary<string, Object> vals)
        {
            Setting setting = new Setting();
            setting.SettingsId = DatabaseUtilities.SafeMapToInt32(vals, "id");
            setting.Name = DatabaseUtilities.SafeMapToString(vals, "name");
            setting.Value = DatabaseUtilities.SafeMapToString(vals, "value");
            return setting;
        }

        private static void AddAcessorSelectors(DbAccessor connection)
        {
            connection.Select("id", DbType.Int32);
            connection.Select("name", DbType.String);
            connection.Select("value", DbType.String);
        }
        #endregion
    }
}
