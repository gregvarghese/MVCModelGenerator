using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Model_Generator
{
    class CodeGenerator
    {
        /// <summary>
        /// Generates a class .
        /// </summary>
        /// <param name="sTableNameSingular">The table name singular.</param>
        /// <param name="dtFields">The datatable with the field names.</param>
        /// <param name="sNamespace">The optional namespace. If empty, generator omits it</param>
        /// <returns></returns>
        public string GenerateClass(string sTableNameSingular, DataTable dtFields, string sNamespace)
        {
            var sbClass = new StringBuilder();
            sbClass.AppendLine(@"using System;");
            sbClass.AppendLine(@"using System.Collections.Generic;");
            sbClass.AppendLine(@"using System.Linq;");
            sbClass.AppendLine(@"using System.Web;");
            sbClass.AppendLine(@"");

            if (!string.IsNullOrEmpty(sNamespace))
            {
                sbClass.AppendLine(@"namespace " + sNamespace);
                sbClass.AppendLine(@"{");
            }

            sbClass.AppendLine(@"    public class " + sTableNameSingular);
            sbClass.AppendLine(@"    {");
            sbClass.AppendLine(@"");

            foreach (DataRow row in dtFields.Rows)
            {
                string sFieldName = row[0].ToString();

                string sFieldType = row[12].ToString();
                //Convert to .NET C# Type
                Type sCLRFieldType = Type.GetType(row[12].ToString());
                var sSQLFieldType = row[13];

                sbClass.AppendLine(string.Format(@"        public {0} {1} {{ get; set; }}", sFieldType.Replace("System.", ""),
                    sFieldName));
            }

            sbClass.AppendLine(@"    }");
            if (!string.IsNullOrEmpty(sNamespace))
            {
                sbClass.AppendLine(@"}");
            }
            return sbClass.ToString();
        }


        /// <summary>
        /// Generates an Interface for stubbing out common CRUD code 
        /// </summary>
        /// <param name="sTableNameSingular">The table name singular.</param>
        /// <param name="sIdFieldType">DataType of the identifier field in database.</param>
        /// <returns></returns>
        public string GenerateInterface(string sTableNameSingular, string sIdFieldType)
        {
            var sbInterface = new StringBuilder();
            sbInterface.AppendLine(@"public interface I" + sTableNameSingular + "Repository");
            sbInterface.AppendLine(@"{");
            sbInterface.AppendLine(@"    List GetAll();");
            sbInterface.AppendLine(@"    " + sTableNameSingular + " Find(" + sIdFieldType + " id);");
            sbInterface.AppendLine(@"    " + sTableNameSingular + " Add(" + sTableNameSingular + " " + sTableNameSingular.ToLower() + ");");
            sbInterface.AppendLine(@"    " + sTableNameSingular + " Update(" + sTableNameSingular + " " + sTableNameSingular.ToLower() + ");");
            sbInterface.AppendLine(@"    void Remove(" + sIdFieldType + " id);");
            sbInterface.AppendLine(@"    " + sTableNameSingular + " Get" + sTableNameSingular + "Informatiom(" + sIdFieldType + " id);");
            sbInterface.AppendLine(@"}");
            return sbInterface.ToString();
        }

        /// <summary>
        /// Generates the CRUD functions using Dapper.
        /// </summary>
        /// <param name="sTableNameSingular">The singular table name.</param>
        /// <param name="sTableNamePlural">The plural table name.</param>
        /// <param name="sTableName">Name of the table.</param>
        /// <param name="sIdFieldType">DataType of the identifier field in database.</param>
        /// <returns></returns>
        public string GenerateCRUD(string sTableNameSingular, string sTableNamePlural, string sTableName, string sIDField, string sIdFieldType, string[] databasefields)
        {
            var sb = new System.Text.StringBuilder();
            //TODO: Finish making this dynamic.
            sb.AppendLine(string.Format(@"public class {0}Repository : I{0}Repository",sTableNameSingular));
            sb.AppendLine(@"    {");
            sb.AppendLine(@"        private IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings[""DefaultConnection""].ConnectionString);");
            sb.AppendLine(@"        public List<User> GetAll()");
            sb.AppendLine(@"        {");
            sb.AppendLine(string.Format(@"            return this._db.Query<{0}>(""SELECT * FROM " + sTableName + ").ToList();",sTableNameSingular));
            sb.AppendLine(@"        }");
            sb.AppendLine(@"");
            sb.AppendLine(@"        public User Find(" + sIdFieldType + "id)");
            sb.AppendLine(@"        {");
            sb.AppendLine(string.Format(@"            return this._db.Query<{0}>(""SELECT * FROM {1} WHERE {2} = @{2}, new {{ id }}).SingleOrDefault();", sTableNameSingular, sTableName,sIDField));
            sb.AppendLine(@"        }");
            sb.AppendLine(@"");
            sb.AppendLine(@"        public User Add(User user)");
            sb.AppendLine(@"        {");

            string sValues = databasefields.Select(x => "@" + x + ",").ToString();
            var sFields = string.Join(",", databasefields);
            sb.AppendLine(string.Format(@"var sqlQuery = ""INSERT INTO {0} ({1}) VALUES({2}); "" + ""SELECT CAST(SCOPE_IDENTITY() as {3})"";",sTableName,sFields,sValues,sIdFieldType));

            sb.AppendLine(string.Format(@"            var {1}Id = this._db.Query<{0}>(sqlQuery, {1}).Single();", sIdFieldType, sTableNameSingular, sIDField));
            sb.AppendLine(@"            user.UserID = userId;");
            sb.AppendLine(@"            return user;");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"");
            sb.AppendLine(@"        public User Update(" + sTableNameSingular + " " + sTableNameSingular.ToLower() + ")");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            var sqlQuery =");
            
            sb.AppendLine(@"                ""UPDATE " + sTableName + " SET");
            
            foreach (var databasefield in databasefields)
            {
                sb.AppendLine("                " + databasefield + "= @" + databasefield);
            }
            sb.AppendLine(string.Format("                WHERE {0} = @{0};\";",sIDField));
            sb.AppendLine(string.Format(@"            this._db.Execute(sqlQuery, {0});",sTableNameSingular));
            sb.AppendLine(@"            return user;");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"");
            sb.AppendLine(@"        public void Remove(" + sIdFieldType + "id)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            throw new NotImplementedException();");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"");
            sb.AppendLine(string.Format(@"        public User Get{0}Informatiom(" + sIdFieldType + "id)",sTableNameSingular));
            sb.AppendLine(@"        {");
            sb.AppendLine(string.Format("            using (var multipleResults = this._db.QueryMultiple(\"Get{0}ByID\", new {{ {1} = id }}, commandType: CommandType.StoredProcedure))",sTableNameSingular,sIDField));
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                var user = multipleResults.Read<User>().SingleOrDefault();");
            sb.AppendLine(@"");
            sb.AppendLine(@"                var addresses = multipleResults.Read<Address>().ToList();");
            sb.AppendLine(@"                if (user != null && addresses != null)");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    user.Address.AddRange(addresses);");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"");
            sb.AppendLine(@"                return user;");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"    }");


            return sb.ToString();
        }
    }
}
