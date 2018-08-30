using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Kalman.IISLogParser;
using System.Threading;
using System.Configuration;

namespace Kalman.Studio
{
    public partial class IISLogExportToDB : Form
    {
        IList<LogRecord> logList;
        int total = 0;
        int batch = 10;

        public IISLogExportToDB(IList<LogRecord> list)
        {
            InitializeComponent();
            logList = list;
            total = list.Count;
        }

        private void IISLogExportToDB_Load(object sender, EventArgs e)
        {
            try
            {
                txtConnectionString.Text = ConfigurationManager.ConnectionStrings["IISLog"].ConnectionString;
            }
            catch { }
        }

        public void Export()
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void DoExport()
        {
            string sql = string.Empty;
            try
            {
                using (SqlConnection cn = new SqlConnection(txtConnectionString.Text.Trim()))
                {
                    cn.Open();

                    int n = 0;
                    int remainder = total % batch;
                    if (remainder != 0) n = total / batch + 1;
                    else n = total / batch;

                    for (int i = 0; i < n; i++)
                    {
                        IList<LogRecord> temp = new List<LogRecord>();
                        int begin = i * batch;
                        int end = (i + 1) * batch;
                        if (i == n - 1) end = total;

                        for (; begin < end; begin++)
                        {
                            temp.Add(logList[begin]);
                        }

                        sql = GetBatchInsertSql(temp);
                        //ExcuteBatchInsertSql(sql);

                        int p = (i + 1) * 100 / n;
                        backgroundWorker1.ReportProgress(p);


                        SqlCommand cmd = new SqlCommand(sql, cn);
                        cmd.ExecuteNonQuery();

                        Thread.Sleep(1);
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowExceptionDialog(ex, sql);
            }

        }

        string GetBatchInsertSql(IList<LogRecord> list)
        {
            StringBuilder sb = new StringBuilder();
            string tableName = txtTableName.Text.Trim();
            foreach (LogRecord lr in list)
            {
                string s = string.Format(@"INSERT INTO {0} ([LogTime],[Method],[ClientIP],[ClientIPLocation],[Status],[SubStatus],[Win32Status],[ReceiveBytes],[SendBytes],[UriStem],[Referer],[UriStemAlias],[RefererAlias],[UserAgentAlias],[UserAgent]) VALUES ('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}');",
                                 tableName, lr.LogTime, lr.Method, lr.ClientIP, lr.ClientIPLocation, lr.Status, lr.SubStatus, lr.Win32Status, lr.ReceiveBytes, lr.SendBytes, lr.UriStem, lr.Referer, lr.UriStemAlias, lr.RefererAlias, lr.UserAgentAlias, lr.UserAgent);
                sb.AppendLine(s);
            }
            return sb.ToString();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            DoExport();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lblMsg.Text = string.Format("正在导出数据，已完成：{0}%", e.ProgressPercentage);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MsgBox.Show("数据导入完成");
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
