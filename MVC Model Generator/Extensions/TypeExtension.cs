using System;
using System.Collections;
using System.Data;
using Microsoft.SqlServer.Server;
using MVC_Model_Generator.Annotations;

namespace Utility
{
    public static class TypeExtension
    {
        private static Hashtable dbTypeTable;

        public static SqlDbType ConvertToDbType(this Type t)
        {
            if (dbTypeTable == null)
            {
                dbTypeTable = new Hashtable();
                dbTypeTable.Add(typeof(System.Boolean), SqlDbType.Bit);
                dbTypeTable.Add(typeof(System.Int16), SqlDbType.SmallInt);
                dbTypeTable.Add(typeof(System.Int32), SqlDbType.Int);
                dbTypeTable.Add(typeof(System.Int64), SqlDbType.BigInt);
                dbTypeTable.Add(typeof(System.Double), SqlDbType.Float);
                dbTypeTable.Add(typeof(System.Decimal), SqlDbType.Decimal);
                dbTypeTable.Add(typeof(System.String), SqlDbType.VarChar);
                dbTypeTable.Add(typeof(System.DateTime), SqlDbType.DateTime);
                dbTypeTable.Add(typeof(System.Byte[]), SqlDbType.VarBinary);
                dbTypeTable.Add(typeof(System.Guid), SqlDbType.UniqueIdentifier);
            }
            SqlDbType dbtype;
            try
            {
                dbtype = (SqlDbType)dbTypeTable[t];
            }
            catch
            {
                dbtype = SqlDbType.Variant;
            }
            return dbtype;
        }


        public static Type ToClrType(SqlDbType sqlType)
        {
            switch (sqlType)
            {
                case SqlDbType.BigInt:
                    return typeof(long?);

                case SqlDbType.Binary:
                case SqlDbType.Image:
                case SqlDbType.Timestamp:
                case SqlDbType.VarBinary:
                    return typeof(byte[]);

                case SqlDbType.Bit:
                    return typeof(bool?);

                case SqlDbType.Char:
                case SqlDbType.NChar:
                case SqlDbType.NText:
                case SqlDbType.NVarChar:
                case SqlDbType.Text:
                case SqlDbType.VarChar:
                case SqlDbType.Xml:
                    return typeof(string);

                case SqlDbType.DateTime:
                case SqlDbType.SmallDateTime:
                case SqlDbType.Date:
                case SqlDbType.Time:
                case SqlDbType.DateTime2:
                    return typeof(DateTime?);

                case SqlDbType.Decimal:
                case SqlDbType.Money:
                case SqlDbType.SmallMoney:
                    return typeof(decimal?);

                case SqlDbType.Float:
                    return typeof(double?);

                case SqlDbType.Int:
                    return typeof(int?);

                case SqlDbType.Real:
                    return typeof(float?);

                case SqlDbType.UniqueIdentifier:
                    return typeof(Guid?);

                case SqlDbType.SmallInt:
                    return typeof(short?);

                case SqlDbType.TinyInt:
                    return typeof(byte?);

                case SqlDbType.Variant:
                case SqlDbType.Udt:
                    return typeof(object);

                case SqlDbType.Structured:
                    return typeof(DataTable);

                case SqlDbType.DateTimeOffset:
                    return typeof(DateTimeOffset?);

                default:
                    throw new ArgumentOutOfRangeException("sqlType");
            }
        }
    }
}