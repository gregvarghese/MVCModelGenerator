#region Usings

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

#endregion

namespace MVC_Model_Generator
{
    internal class DataLayer
    {
        public DataLayer(string connstring)
        {
            sqlCon.ConnectionString = connstring;
        }

        #region "SQL Connection"

        private readonly SqlConnection sqlCon = new SqlConnection();

        public void OpenConnection()
        {
            if (sqlCon.State != ConnectionState.Open)
            {
                sqlCon.Open();
            }
        }

        public void CloseConnection()
        {
            if (sqlCon.State != ConnectionState.Closed)
            {
                sqlCon.Close();
            }
        }

        #endregion

        public DataTable GetDataTable(string sSQL)
        {
            OpenConnection();
            try
            {
                using (var ds = new DataSet())
                {
                    using (var sc = new SqlCommand(sSQL, sqlCon))
                    {
                        var da = new SqlDataAdapter(sc);
                        da.Fill(ds);
                    }

                    CloseConnection();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateTable(string sql, List<SqlParameter> newcollect)
        {
            OpenConnection();

            using (var sc = new SqlCommand(sql, sqlCon))
            {
                sc.Parameters.AddRange(newcollect.ToArray());
                sc.ExecuteNonQuery();
            }

            CloseConnection();
        }

        public DataTable GetDataTable(string sSQL, List<SqlParameter> newcollect)
        {
            OpenConnection();

            using (var ds = new DataSet())
            {
                using (var sc = new SqlCommand(sSQL, sqlCon))
                {
                    var da = new SqlDataAdapter(sc);
                    sc.Parameters.AddRange(newcollect.ToArray());
                    da.Fill(ds);
                }

                CloseConnection();
                return ds.Tables[0];
            }
        }

        public DataTable GetSchemaDataTable(string sSQL)
        {
            OpenConnection();

            using (var ds = new DataSet())
            {
                DataTable tbl;
                using (var sc = new SqlCommand(sSQL, sqlCon))
                {
                    SqlDataReader rdr = sc.ExecuteReader(CommandBehavior.SchemaOnly);
                    tbl = rdr.GetSchemaTable();
                }

                CloseConnection();
                return tbl;
            }
        }

        public DataTable GetSchemaDataTable(string sSQL, List<SqlParameter> newcollect)
        {
            OpenConnection();

            using (var ds = new DataSet())
            {
                DataTable tbl;
                using (var sc = new SqlCommand(sSQL, sqlCon))
                {
                    sc.Parameters.AddRange(newcollect.ToArray());
                    var rdr = sc.ExecuteReader(CommandBehavior.SchemaOnly);
                    tbl = rdr.GetSchemaTable();
                }

                CloseConnection();
                return tbl;
            }
        }

        public SqlDataReader GetDataReader(string sSQL, List<SqlParameter> newCollect)
        {
            var sc = new SqlCommand(sSQL, sqlCon);
            sc.Parameters.AddRange(newCollect.ToArray());
            return sc.ExecuteReader();
        }

        public SqlDataReader GetDataReader(string sSQL)
        {
            OpenConnection();
            var sc = new SqlCommand(sSQL, sqlCon);
            return sc.ExecuteReader();
        }

        public string GetPrimaryKey(string tableName)
        {
            OpenConnection();
            string names,
            ID = "";
            // sp_pkeys is SQL Server default stored procedure. Pass the table name and it returns the primary key column
            using (var sc = new SqlCommand("sp_pkeys", sqlCon))
            {
                sc.CommandType = CommandType.StoredProcedure;
                sc.Parameters.Add("@table_name", SqlDbType.NVarChar).Value = tableName;
                var mReader = sc.ExecuteReader();
                while (mReader.Read())
                {
                    //the primary key column resides at index 4 
                    ID = mReader[3].ToString();
                }
            }
            CloseConnection();
            return ID;
        }


        public List<string> GetTables()
        {
            using (var connection = new SqlConnection(sqlCon.ConnectionString))
            {
                connection.Open();
                var schema = connection.GetSchema("Tables");
                var list = (from DataRow row in schema.Rows select row[2].ToString()).ToList();
                list.Sort();
                connection.Close();
                return list;
            }
        }

    }
}