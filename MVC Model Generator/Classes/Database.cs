#region Usings

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

#endregion

namespace MVC_Model_Generator
{
    internal class Database
    {
        private DataLayer _dl;
        public Database(string connectionString)
        {
            ConnectionString = connectionString;
            _dl = new DataLayer(ConnectionString);
        }

        public static string ConnectionString { get; set; }

        public List<string> GetTables()
        {
            return _dl.GetTables();
        }

        public DataTable GetFields(string tablename)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var sSQL = string.Format(@"select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_Name='{0}' order by ORDINAL_POSITION", tablename);
                return _dl.GetDataTable(sSQL);
            }
        }

        public DataTable GetSqlTypesByTable(string tablename)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var sSQL = string.Format(@"select * from {0}", tablename);
                return _dl.GetSchemaDataTable(sSQL);
            }
        }

        public string GetPrimaryKey(string tableName)
        {
            return _dl.GetPrimaryKey(tableName);
        }
    }
}