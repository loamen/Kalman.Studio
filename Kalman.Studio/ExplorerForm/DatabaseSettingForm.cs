using Kalman.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kalman.Studio
{
    public partial class DatabaseSettingForm : Form
    {
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
                MessageBox.Show("请选择或输入连接名称！");
                return;
            }

            if (string.IsNullOrEmpty(providerName))
            {
                MessageBox.Show("请选择Provider名称！");
                return;
            }

            if (string.IsNullOrEmpty(connectString))
            {
                MessageBox.Show("请输入ConnectString内容！");
                return;
            }

            try
            {
                ConnectionStringUtil.UpdateConnectionString(connectName, connectString, providerName);

                this.DialogResult = DialogResult.Yes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            var connectString = ConnectionStringUtil.GetConnectionString(item.ToString());

            txtConnectString.Text = connectString;

            var providerName = ConnectionStringUtil.GetProviderName(item.ToString());
            cbProviderName.SelectedItem = providerName;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var name = cbConnectStringName.Text;

            if (!string.IsNullOrEmpty(name))
            {
                ConnectionStringUtil.RemoveConnectionString(name);
                RefreshDatabase();
            }
        }


        private void RefreshDatabase()
        {
            cbConnectStringName.Items.Clear();
            foreach (ConnectionStringSettings css in ConfigurationManager.ConnectionStrings)
            {
                cbConnectStringName.Items.Add(css.Name);
            }
        }
    }
}
