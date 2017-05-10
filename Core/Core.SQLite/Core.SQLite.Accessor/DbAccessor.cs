using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SQLite.Accessor
{
    public class DbAccessor
    {
        private Dictionary<string, DbField> _fields = new Dictionary<string, DbField>();

        public string _whereClause = "";
        private List<DbField> _parameters = new List<DbField>();
        private List<OrderByField> _orderByFields = new List<OrderByField>();

        public void Select(string field, DbType type)
        {
            DbField f = new DbField();
            f.Name = field;
            f.Type = type;
            _fields.Add(field, f);
        }

        public void SetWhereClause(string clause, List<DbField> parameters)
        {
            _whereClause = clause;
            _parameters = parameters;
        }

        public void AddOrderBy(string fieldName, OrderByDirection direction)
        {
            OrderByField orderByField = new OrderByField();
            orderByField.FieldName = fieldName;
            orderByField.Direction = direction;
            _orderByFields.Add(orderByField);
        }

        public DataView FindWhere(List<String> tables, List<DbJoin> joins = null)
        {
            string sqlString = "";
            DataView dv = new DataView();
            SQLiteConnection conn = DatabaseManager.GetConnection();
            SQLiteDataAdapter listAdapter = new SQLiteDataAdapter();
             
            conn.Open();

            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = conn;

            string tableList = "";
            foreach (string table in tables)
            {
                if (!String.IsNullOrEmpty(tableList))
                    tableList += ", ";

                tableList += table;
            }

            sqlString = "SELECT " + BuildFieldValues() + " FROM " + tableList;

            if (joins != null)
            {
                foreach (DbJoin join in joins)
                {
                    switch (join.JoinType)
                    {
                        case JoinType.LeftJoin:
                            sqlString += " left join ";
                            break;
                        case JoinType.RightJoin:
                            sqlString += " right join ";
                            break;
                        case JoinType.FullJoin:
                            sqlString += " full join ";
                            break;
                    }

                    sqlString += join.Table + " on " + join.Criteria;
                }
            }

            if (!String.IsNullOrEmpty(_whereClause))
                sqlString += " WHERE " + _whereClause;

            if (_parameters != null && _parameters.Count > 0)
                BindParameterList(cmd);

            if (_orderByFields != null && _orderByFields.Count > 0)
                sqlString += " ORDER BY " + BuildOrderBy();


            cmd.CommandText = sqlString;
            cmd.CommandType = CommandType.Text;

            try
            {
                listAdapter.SelectCommand = cmd;

                DataTable dataTable = new DataTable();
                listAdapter.Fill(dataTable);
                dv = new DataView(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return dv;
        }

        public void SetUpTable(string creationString)
        {
            SQLiteConnection conn = DatabaseManager.GetConnection();
            conn.Open();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.CommandText = creationString;
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteReader();
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

        public Dictionary<string, object> FindById(string table, string keyField, int keyValue)
        {
            SQLiteConnection conn = DatabaseManager.GetConnection();
            SQLiteDataReader dr = null;
            conn.Open();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT " + BuildFieldValues() + " FROM " + table + " WHERE " + keyField + " = :" + keyField;
                cmd.CommandType = CommandType.Text;

                //cmd.Parameters.Add(":" + keyField, keyValue);

                SQLiteParameter parameter = new SQLiteParameter();
                parameter.DbType = DbType.Int32;
                //sqlLiteParameter.DbType = (System.Data.DbType)parameter.Type;
                parameter.ParameterName = ":" + keyField;
                parameter.Value = keyValue;
                cmd.Parameters.Add(parameter);


                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Dictionary<String, object> vals = new Dictionary<string, object>();
                    int i = 0;
                    foreach (string s in _fields.Keys)
                    {
                        DbField f = (DbField)_fields[s];

                        switch (f.Type)
                        {
                            case DbType.Int32:
                                try { vals.Add(s, dr.GetDecimal(i)); }
                                catch { vals.Add(s, 0); }
                                break;
                            case DbType.String:
                                try { vals.Add(s, dr.GetString(i)); }
                                catch { vals.Add(s, ""); }
                                break;
                            //case DbTypes.Varchar:
                            //    try { vals.Add(s, dr.GetString(i)); }
                            //    catch { vals.Add(s, ""); }
                            //    break;
                            case DbType.DateTime:
                                try { vals.Add(s, dr.GetDateTime(i)); }
                                catch { vals.Add(s, null); }
                                break;
                            case DbType.Binary:
                                try { vals.Add(s, dr.GetValue(i)); }
                                catch { vals.Add(s, null); }
                                break;
                            case DbType.Boolean:
                                try { vals.Add(s, dr.GetValue(i)); }
                                catch { vals.Add(s, ""); }
                                break;
                            case DbType.Double:
                                try { vals.Add(s, dr.GetValue(i)); }
                                catch { vals.Add(s, 0); }
                                break;
                        }
                        i++;
                    }
                    return vals;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (dr != null)
                    dr.Dispose();

                conn.Close();
            }
            return null;
        }

        private string BuildFieldValues()
        {
            string list = "";
            bool first = true;
            foreach (string s in _fields.Keys)
            {
                if (first)
                    first = false;
                else
                    list += ", ";

                list += s;
            }
            return list;
        }

        private string BuildOrderBy()
        {
            bool start = true;
            string orderString = "";
            foreach (OrderByField orderByField in _orderByFields)
            {
                if (!start)
                    orderString += ", ";

                orderString += orderByField.FieldName;

                if (orderByField.Direction == OrderByDirection.Descending)
                    orderString += " DESC";
                else
                    orderString += " ASC";

                start = false;
            }
            return orderString;
        }

        public DbField BindParameter(string name, DbType type, object value)
        {
            DbField field = new DbField();
            field.Name = name;
            field.Type = type;
            field.Value = value;
            return field;
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
