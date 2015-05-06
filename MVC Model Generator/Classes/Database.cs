#region Usings

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public DataTable GetFields(string Tablename)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var sSQL = @"select * from INFORMATION_SCHEMA.COLUMNS where TABLE_Name='" + Tablename +
                           "' order by ORDINAL_POSITION";
                return _dl.GetDataTable(sSQL);
            }
        }

        public DataTable GetSqlTypesByTable(string Tablename)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var sSQL = @"select * from " + Tablename;
                return _dl.GetSchemaDataTable(sSQL);
            }
        }
    }
}