using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SQLite.Accessor
{
    public class DbUpdater
    {
        private String _sql = "";
        private List<DbField> _fields = new List<DbField>();
        private List<DbField> _parameters = new List<DbField>();

        public String SQL
        {
            set { _sql = value; }
            get { return _sql; }
        }

        public void BindParameter(string name, DbType type, object value)
        {
            DbField field = new DbField();
            field.Name = name;
            field.Type = type;
            if (type == DbType.Boolean)
            {
                field.Value = (bool)value ? 1 : 0;
            }
            else
            {
                field.Value = value;
            }

            _fields.Add(field);
        }

        public void BindCriteriaParameter(string name, DbType type, object value)
        {
            DbField field = new DbField();
            field.Name = name;
            field.Type = type;
            if (type == DbType.Boolean)
            {
                field.Value = (bool)value ? 1 : 0;
            }
            else
            {
                field.Value = value;
            }

            _parameters.Add(field);
        }

        public int ExecuteSQL(String sqlQuery)
        {
            SQLiteConnection conn = DatabaseManager.GetConnection();
            conn.Open();

            try
            {
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.CommandText = sqlQuery;
                cmd.CommandType = CommandType.Text;

                if (_parameters != null && _parameters.Count > 0)
                    BindParameterList(cmd);

                int rowsAffected = ExecuteNonQuery(cmd);// cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                _parameters.Clear();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        private void ExecuteScalarCommand(SQLiteCommand cmd)
        {
            while(true)
            {
                try
                {
                    cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("database is locked"))
                    {
                        continue;
                    }
                    else
                        throw;
                }
                break;
            }
        }

        private int  ExecuteNonQuery(SQLiteCommand cmd)
        {
            int id = 0;
            while (true)
            {
                try
                {
                    id = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("database is locked"))
                    {
                        continue;
                    }
                    else
                        throw;
                }
                break;
            }
            return id;
        }

        public int Insert(string table)//, string keyField, string sequence)
        {

            SQLiteConnection conn = DatabaseManager.GetConnection();
            conn.Open();
            try
            {
                //int identity = DatabaseManager.GetIdentity(sequence, conn);
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO " + table + " " + BuildFieldListForInsert();// (keyField);
                cmd.CommandType = CommandType.Text;

                BindFieldList(cmd);
                
                //cmd.ExecuteScalar();
                ExecuteScalarCommand(cmd);
                cmd.Parameters.Clear();
                return (int)conn.LastInsertRowId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        #region Update By Id
        public int Update(string table, string keyField, int keyValue)
        {
            SQLiteConnection conn = DatabaseManager.GetConnection();
            conn.Open();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE " + table + " SET " + BuildFieldListForUpdate() + " WHERE " + keyField + " = :KEYVAL";
                cmd.CommandType = CommandType.Text;

                BindFieldList(cmd);

                //cmd.Parameters.Add(":KEYVAL", keyValue);

                SQLiteParameter parameter = new SQLiteParameter();
                parameter.DbType = DbType.Int32;
                parameter.ParameterName = ":KEYVAL";
                parameter.Value = keyValue;
                cmd.Parameters.Add(parameter);

                return ExecuteNonQuery(cmd);// cmd.ExecuteNonQuery();
                // Return the number of rows that were affected.
                //return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public int UpdateWhere(string table, string keyField, int keyValue, string whereClause)
        {
            SQLiteConnection conn = DatabaseManager.GetConnection();
            conn.Open();
            try
            {
                //"UPDATE settings SET id = :id, name = :name, value = :value WHERE id = :KEYVAL AND name=:name"
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE " + table + " SET " + BuildFieldListForUpdate() + " WHERE " + keyField + " = :KEYVAL";
                cmd.CommandType = CommandType.Text;

                if (!String.IsNullOrEmpty(whereClause))
                    cmd.CommandText += " AND " + whereClause;

                BindFieldList(cmd);

                SQLiteParameter parameter = new SQLiteParameter();
                parameter.DbType = DbType.Int32;
                parameter.ParameterName = ":KEYVAL";
                parameter.Value = keyValue;
                cmd.Parameters.Add(parameter);

                BindParameterList(cmd);
                return ExecuteNonQuery(cmd);// cmd.ExecuteNonQuery();
                // Return the number of rows that were affected.
                //return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region Delete By Id
        public int Delete(string table, string keyField, int keyValue)
        {
            SQLiteConnection conn = DatabaseManager.GetConnection();
            conn.Open();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM " + table + " WHERE " + keyField + " = :KEYVAL";
                cmd.CommandType = CommandType.Text;

                //cmd.Parameters.Add(":KEYVAL", keyValue);
                SQLiteParameter parameter = new SQLiteParameter();
                //parameter.DbType = DbType.Int32;
                parameter.ParameterName = ":KEYVAL";
                parameter.Value = keyValue;
                cmd.Parameters.Add(parameter);

                return ExecuteNonQuery(cmd);// cmd.ExecuteNonQuery();
                // Return the number of rows that were affected.
                //return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public int DeleteWhere(string table, string keyField, int keyValue, string whereClause)
        {
            SQLiteConnection conn = DatabaseManager.GetConnection();
            conn.Open();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM " + table + " WHERE " + keyField + " = :KEYVAL";
                cmd.CommandType = CommandType.Text;

                //cmd.Parameters.Add(":KEYVAL", keyValue);

                SQLiteParameter parameter = new SQLiteParameter();
                //parameter.DbType = DbType.Int32;
                parameter.ParameterName = ":KEYVAL";
                parameter.Value = keyValue;
                cmd.Parameters.Add(parameter);

                if (!String.IsNullOrEmpty(whereClause))
                {
                    cmd.CommandText += " AND " + whereClause;
                    BindParameterList(cmd);
                }

                return ExecuteNonQuery(cmd);// cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }


        public int DeleteWhere(string table, string whereClause)
        {
            SQLiteConnection conn = DatabaseManager.GetConnection();
            conn.Open();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM " + table + " WHERE " + whereClause;
                cmd.CommandType = CommandType.Text;
                BindParameterList(cmd);

                return ExecuteNonQuery(cmd);// cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        #endregion

        private String BuildFieldListForInsert()//string keyField)
        {
            String list = "(";// +keyField;
            bool first = true;
            foreach (DbField f in _fields)
            {
                if(!first)
                    list += ", ";
                list += f.Name;
                first = false;
            }
            list += ") VALUES (";
           // list += ":" + keyField;
            first = true;
            foreach (DbField f in _fields)
            {
                if (!first)
                    list += ", ";
                list += ":" + f.Name;
                first = false;
            }
            list += ")";
            return list;
        }

        private String BuildFieldListForUpdate()
        {
            String list = "";
            bool first = true;
            foreach (DbField f in _fields)
            {
                if (first)
                    first = false;
                else
                    list += ", ";

                list += f.Name + " = " + ":" + f.Name;
            }
            return list;
        }

        private void BindFieldList(SQLiteCommand cmd)
        {
            foreach (DbField f in _fields)
            {
                object val = f.Value;
                if (val == null)
                    val = System.DBNull.Value;
                //cmd.Parameters.Add(":" + f.Name, val);
                SQLiteParameter parameter = new SQLiteParameter();
                parameter.DbType = (System.Data.DbType)f.Type;
                parameter.ParameterName = ":"+f.Name;
                parameter.Value = val;
                cmd.Parameters.Add(parameter);
            }
        }

        public void BindParameterList(SQLiteCommand cmd)
        {
            foreach (DbField parameter in _parameters)
            {
                object val = parameter.Value;
                if (val == null)
                    val = System.DBNull.Value;
                //cmd.Parameters.Add(":" + parameter.Name, val);
                SQLiteParameter sqlLiteParameter = new SQLiteParameter();
                sqlLiteParameter.DbType = (System.Data.DbType)parameter.Type;
                sqlLiteParameter.ParameterName = ":" + parameter.Name;
                sqlLiteParameter.Value = val;
                cmd.Parameters.Add(sqlLiteParameter);
            }

        }
    }
}
