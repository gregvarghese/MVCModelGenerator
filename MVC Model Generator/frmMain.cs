#region Usings

using System;
using System.Configuration;
using System.Data;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

#endregion

namespace MVC_Model_Generator
{
    public partial class frmMain : Form
    {
        private Database db;


        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtConnectionString.Text = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;
        }

        private void btnGenerateClass_Click(object sender, EventArgs e)
        {
            txtModel.Text = "";
            var generator = new CodeGenerator();
            var sTableName = cboTableName.Text;
            var sNamespace = txtNamespace.Text;
            var ps = PluralizationService.CreateService(CultureInfo.GetCultureInfo("en-us"));

            var sTableNameSingular = ps.Singularize(sTableName);
            var sTableNamePlural = ps.Pluralize(sTableName);
            var dtFields = db.GetSqlTypesByTable(sTableName);
            var sbClass = generator.GenerateClass(sTableNameSingular, dtFields, sNamespace);

            

            //Should check to see fields have ID specification.
            var sIDFieldType = dtFields.Rows[0][12].ToString().Replace("System.", "");
            var sbInterface = generator.GenerateInterface(sTableNameSingular, sIDFieldType);

            var sPrimaryKeyField = db.GetPrimaryKey(sTableName);
            var dtFieldNames = db.GetFields(sTableName);
            var stringArr = dtFieldNames.AsEnumerable().Select(r => r.Field<string>("COLUMN_NAME")).ToArray();
            var sCRUD = generator.GenerateCRUD(sTableNameSingular, sTableNamePlural, sTableName, sPrimaryKeyField, sIDFieldType, stringArr);

            txtModel.Text = sbClass;
            txtInterface.Text = sbInterface;
            txtCode.Text = sCRUD;


        }


        private void btnConnect_Click(object sender, EventArgs e)
        {

            db = new Database(txtConnectionString.Text);
            cboTableName.DataSource = db.GetTables();
            cboTableName.Enabled = true;
        }

        private void cboTableName_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnGenerateClass.Enabled = true;
        }
    }
}