using Kalman.Database;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Kalman.Studio
{
    public partial class DatabaseSettingForm : Form
    {
        DbConnDAL dal = new DbConnDAL();
        bool ConnectStringChanged = false;

        public DatabaseSettingForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var connectName = cbConnectStringName.Text.Trim();
            var providerName = cbProviderName.Text.Trim();
            var connectString = txtConnectString.Text.Trim();

            if (string.IsNullOrEmpty(connectName))
            {
                MsgBox.Show("请选择或输入连接名称！");
                return;
            }

            if (string.IsNullOrEmpty(providerName))
            {
                MsgBox.Show("请选择Provider名称！");
                return;
            }

            if (string.IsNullOrEmpty(connectString))
            {
                MsgBox.Show("请输入ConnectString内容！");
                return;
            }

            try
            {
                var model = dal.FindOne(connectName);
                if(model == null)
                {
                    model = new DbConn();
                    model.ConnectionString = connectString;
                    model.Name = connectName;
                    model.ProviderName = providerName;

                    dal.Insert(model);
                }
                else
                {
                    model.ConnectionString = connectString;
                    model.Name = connectName;
                    model.ProviderName = providerName;
                    dal.Update(model);
                }

                this.DialogResult = DialogResult.Yes;
                MsgBox.Show("保存成功！");
            }
            catch (Exception ex)
            {
                MsgBox.ShowExceptionMessage(ex);
                this.DialogResult = DialogResult.No;
            }
        }

        private void DatabaseSettingForm_Load(object sender, EventArgs e)
        {
            RefreshDatabase();
        }

        private void cbConnectStringName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = cbConnectStringName.Text;
            var model = dal.FindOne(item.ToString());
            if(model  != null) {
                ConnectStringChanged = true;
                txtConnectString.Text = model.ConnectionString;
                cbProviderName.SelectedItem = model.ProviderName;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var name = cbConnectStringName.Text;

            if (!string.IsNullOrEmpty(name))
            {
                var result = dal.Delete(name);
                this.DialogResult = DialogResult.Yes;
                MsgBox.Show("删除成功！");
            }
        }


        private void RefreshDatabase()
        {
            cbConnectStringName.Items.Clear();

            var list = dal.FindAll().ToList();
            foreach (var item in list)
            {
                if (item.IsActive)
                    cbConnectStringName.Items.Add(item.Name);
            }
        }

        private void cbProviderName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ConnectStringChanged)
            {
                ConnectStringChanged = false;
                return;
            }

            cbConnectStringName.Text = string.Empty;

            switch (cbProviderName.Text)
            {
                case "System.Data.SqlClient":
                    txtConnectString.Text = "server=.;database=loamen;uid=sa;pwd=sa;";
                    break;
                case "MySql.Data.MySqlClient":
                    txtConnectString.Text = "server=localhost;user id=root;password=root;persistsecurityinfo=True;port=3306;database=loamen;SslMode=none";
                    break;
                case "System.Data.SQLite":
                    txtConnectString.Text = @"Data Source=D:\data\sqlite3\loamen.s3db;Version=3;";
                    break;
                case "System.Data.Odbc":
                    txtConnectString.Text = @"Driver={SQL Server};Server=(local);Trusted_Connection=Yes;Database=loamen;";
                    break;
                case "System.Data.OleDb":
                    txtConnectString.Text = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=d:\loamnen.mdb;User Id=admin;Password=;";
                    break;
                case "Devart.Data.Oracle":
                    txtConnectString.Text = "Data Source=orcl;User ID=sa;Password=sa;";
                    break;
                case "Oracle.ManagedDataAccess.Client":
                    txtConnectString.Text = "User Id=root ;Password=root;Data Source=loamen";
                    break;
                case "System.Data.OracleClient":
                    txtConnectString.Text = "Data Source=Oracle8i;Integrated Security=yes";
                    break;
                case "DDTek.Oracle":
                    txtConnectString.Text = "Host=127.0.0.1;Port=1521;User ID=root;Password=root;Service Name=loamen";
                    break;
                case "IBM.Data.DB2":
                    txtConnectString.Text = "Server=localhost:8081;Database=loamen;UID=root;PWD=root;";
                    break;
                case "FirebirdSql.Data.FirebirdClient":
                    txtConnectString.Text = "User=SYSDBA;Password=masterkey;Database=SampleDatabase.fdb;DataSource=localhost;Port=3050;Dialect=3;Charset=NONE;Role=;Connection lifetime=15;Pooling=true;MinPoolSize=0;MaxPoolSize=50;Packet Size=8192;ServerType=0;";
                    break;
                default:
                    txtConnectString.Text = "";
                    break;
            }
        }
    }
}
