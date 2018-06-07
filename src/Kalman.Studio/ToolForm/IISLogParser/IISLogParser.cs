using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kalman.IISLogParser;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Globalization;
using Aspose.Cells;

namespace Kalman.Studio
{
    public partial class IISLogParser : DockableForm
    {
        Main main = null;
        LogParser parser = null;
        LogParseFilter filter = null;

        public IISLogParser()
        {
            InitializeComponent();
        }

        private void IISLogParser_Load(object sender, EventArgs e)
        {
            main = this.ParentForm as Main;
            cbCategory.SelectedIndex = 0;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataError += new DataGridViewDataErrorEventHandler(dataGridView1_DataError);
        }

        void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            main.AppendOutputLine(e.Exception.ToString());
        }

        public void ParseLog(LogParseFilter logParseFilter)
        {
            filter = logParseFilter;
            cbCategory.SelectedIndex = 0;
            listBox1.Items.Clear();

            dataGridView1.DataSource = null;
            gbGrid.Text = "日志数据";

            Thread t1 = new Thread(DoParse);
            t1.Start();

            Thread t2 = new Thread(CheckParseProgress);
            t2.Start();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (parser != null) parser.Clear();
            this.Dispose();
            base.OnClosing(e);
        }

        //开始解析日志文件
        void DoParse()
        {
            parser = new LogParser(filter);
            parser.LoadIPData(Path.Combine(Application.StartupPath, "data\\qqwry.dat"));
            parser.DoParser();
        }

        delegate void ParsingEventHandler(int num);
        delegate void ParsedEventHandler();

        //检查解析进度
        void CheckParseProgress()
        {
            while (true)
            {
                Thread.Sleep(100);
                if (parser != null)
                {
                    if (parser.IsParseFinish)
                    {
                        this.Invoke(new ParsedEventHandler(ShowParsedStatus));
                        return;
                    }
                    else
                    {
                        this.Invoke(new ParsingEventHandler(ShowParsingStatus), parser.LogRecordNum);
                    }
                }
            }
        }

        void ShowParsingStatus(int num)
        {
            gbGrid.Text = string.Format("正在分析日志，已处理[{0}]条记录", num);
        }

        void ShowParsedStatus()
        {
            //btnDoParse.Enabled = true;
            bindingSource1.DataSource = parser.RecordList;
            dataGridView1.DataSource = bindingSource1.DataSource;
            gbGrid.Text = string.Format("日志数据解析完成，记录总数[{0}]", dataGridView1.Rows.Count);
        }

        #region 

        private void ShowUserAgentList()
        {
            if (parser == null) return;
            listBox1.Items.Clear();
            foreach (KeyValuePair<string,int> kvp in parser.UserAgentStat)
            {
                listBox1.Items.Add(kvp);
            }
            if (listBox1.Items.Count > 0)
            {
                dataGridView1.DataSource = StatByUserAgent(((KeyValuePair<string, int>)listBox1.Items[0]).Key);
            }
        }

        private void ShowUserAgentAliasList()
        {
            if (parser == null) return;
            listBox1.Items.Clear();
            foreach (KeyValuePair<string, int> kvp in parser.UserAgentAliasStat)
            {
                listBox1.Items.Add(kvp);
            }
            if (listBox1.Items.Count > 0)
            {
                dataGridView1.DataSource = StatByUserAgentAlias(((KeyValuePair<string, int>)listBox1.Items[0]).Key);
            }
        }

        private void ShowUriStemAliasList()
        {
            if (parser == null) return;
            listBox1.Items.Clear();
            foreach (KeyValuePair<string, int> kvp in parser.UriStemAliasStat)
            {
                listBox1.Items.Add(kvp);
            }
            if (listBox1.Items.Count > 0)
            {
                dataGridView1.DataSource = StatByUriStemAlias(((KeyValuePair<string, int>)listBox1.Items[0]).Key);
            }
        }

        private void ShowClientIPList()
        {
            if (parser == null) return;
            listBox1.Items.Clear();
            foreach (KeyValuePair<string, int> kvp in parser.ClientIPStat)
            {
                listBox1.Items.Add(kvp);
            }
            if (listBox1.Items.Count > 0)
            {
                dataGridView1.DataSource = StatByClientIP(((KeyValuePair<string, int>)listBox1.Items[0]).Key);
            }
        }

        private void ShowClientIPLocationList()
        {
            if (parser == null) return;
            listBox1.Items.Clear();
            foreach (KeyValuePair<string, int> kvp in parser.ClientIPLocationStat)
            {
                listBox1.Items.Add(kvp);
            }
            if (listBox1.Items.Count > 0)
            {
                dataGridView1.DataSource = StatByClientIPLocation(((KeyValuePair<string, int>)listBox1.Items[0]).Key);
            }
        }

        private void ShowTimeList()
        {
            if (parser == null) return;
            listBox1.Items.Clear();
            foreach (KeyValuePair<string, int> kvp in parser.TimeStat)
            {
                listBox1.Items.Add(kvp);
            }
            if (listBox1.Items.Count > 0)
            {
                dataGridView1.DataSource = StatByTime(((KeyValuePair<string, int>)listBox1.Items[0]).Key);
            }
        }

        void ShowRefererList()
        {
            if (parser == null) return;
            listBox1.Items.Clear();
            foreach (KeyValuePair<string, int> kvp in parser.RefererStat)
            {
                listBox1.Items.Add(kvp);
            }
            if (listBox1.Items.Count > 0)
            {
                dataGridView1.DataSource = StatByReferer(((KeyValuePair<string, int>)listBox1.Items[0]).Key);
            }
        }

        void ShowRefererAliasList()
        {
            if (parser == null) return;
            listBox1.Items.Clear();
            foreach (KeyValuePair<string, int> kvp in parser.RefererAliasStat)
            {
                listBox1.Items.Add(kvp);
            }
            if (listBox1.Items.Count > 0)
            {
                dataGridView1.DataSource = StatByRefererAlias(((KeyValuePair<string, int>)listBox1.Items[0]).Key);
            }
        }

        private IList<LogRecord> StatByUserAgent(string userAgent)
        {
            IList<LogRecord> list = parser.RecordList;
            IList<LogRecord> result = new List<LogRecord>();

            foreach (LogRecord item in list)
            {
                if (item.UserAgent == userAgent) result.Add(item);
            }

            return result;
        }

        private IList<LogRecord> StatByUserAgentAlias(string userAgentAlias)
        {
            IList<LogRecord> list = parser.RecordList;
            IList<LogRecord> result = new List<LogRecord>();

            foreach (LogRecord item in list)
            {
                if (item.UserAgentAliasList.Contains(userAgentAlias)) result.Add(item);
            }

            return result;
        }

        private IList<LogRecord> StatByUriStemAlias(string uriStemAlias)
        {
            IList<LogRecord> list = parser.RecordList;
            IList<LogRecord> result = new List<LogRecord>();

            foreach (LogRecord item in list)
            {
                if (item.UriStemAlias == uriStemAlias) result.Add(item);
            }

            return result;
        }

        private IList<LogRecord> StatByClientIP(string ip)
        {
            IList<LogRecord> list = parser.RecordList;
            IList<LogRecord> result = new List<LogRecord>();

            foreach (LogRecord item in list)
            {
                if (item.ClientIP == ip) result.Add(item);
            }

            return result;
        }

        private IList<LogRecord> StatByClientIPLocation(string ipLocation)
        {
            IList<LogRecord> list = parser.RecordList;
            IList<LogRecord> result = new List<LogRecord>();

            foreach (LogRecord item in list)
            {
                if (item.ClientIPLocation == ipLocation) result.Add(item);
            }

            return result;
        }

        private IList<LogRecord> StatByTime(string time)
        {
            IList<LogRecord> list = parser.RecordList;
            IList<LogRecord> result = new List<LogRecord>();

            foreach (LogRecord item in list)
            {
                if (item.LogTime.ToString("yyyy-MM-dd HH") == time) result.Add(item);
            }

            return result;
        }

        private IList<LogRecord> StatByReferer(string referer)
        {
            IList<LogRecord> list = parser.RecordList;
            IList<LogRecord> result = new List<LogRecord>();

            foreach (LogRecord item in list)
            {
                if (item.Referer == referer) result.Add(item);
            }

            return result;
        }

        private IList<LogRecord> StatByRefererAlias(string refererAlias)
        {
            IList<LogRecord> list = parser.RecordList;
            IList<LogRecord> result = new List<LogRecord>();

            foreach (LogRecord item in list)
            {
                if (item.RefererAlias == refererAlias) result.Add(item);
            }

            return result;
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = cbCategory.SelectedItem.ToString();
            switch (s)
            {
                case "显示全部数据":
                    if (parser != null)
                    {
                        listBox1.Items.Clear();
                        dataGridView1.DataSource = parser.RecordList;
                        gbGrid.Text = string.Format("显示全部日志数据，记录总数[{0}]", dataGridView1.Rows.Count);
                    }
                    break;
                case "按用户代理汇总":
                    ShowUserAgentList();
                    break;
                case "按用户代理别名汇总":
                    ShowUserAgentAliasList();
                    break;
                case "按请求地址别名汇总":
                    ShowUriStemAliasList();
                    break;
                case "按客户端IP汇总":
                    ShowClientIPList();
                    break;
                case "按时间汇总":
                    ShowTimeList();
                    break;
                case "按引用地址汇总":
                    ShowRefererList();
                    break;
                case "按引用地址别名汇总":
                    ShowRefererAliasList();
                    break;
                case "按客户端IP归属地汇总":
                    ShowClientIPLocationList();
                    break;
                default:
                    break;
            }
            if (listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = 0;
                gbGrid.Text = listBox1.SelectedItem.ToString();
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (parser == null) return;
            if (listBox1.SelectedItem == null) return;

            string s = cbCategory.SelectedItem.ToString();

            switch (s)
            {
                case "按用户代理汇总":
                    dataGridView1.DataSource = StatByUserAgent(((KeyValuePair<string, int>)listBox1.SelectedItem).Key);
                    break;
                case "按用户代理别名汇总":
                    dataGridView1.DataSource = StatByUserAgentAlias(((KeyValuePair<string, int>)listBox1.SelectedItem).Key);
                    break;
                case "按请求地址别名汇总":
                    dataGridView1.DataSource = StatByUriStemAlias(((KeyValuePair<string, int>)listBox1.SelectedItem).Key);
                    break;
                case "按客户端IP汇总":
                    dataGridView1.DataSource = StatByClientIP(((KeyValuePair<string, int>)listBox1.SelectedItem).Key);
                    break;
                case "按时间汇总":
                    dataGridView1.DataSource = StatByTime(((KeyValuePair<string, int>)listBox1.SelectedItem).Key);
                    break;
                case "按引用地址汇总":
                    dataGridView1.DataSource = StatByReferer(((KeyValuePair<string, int>)listBox1.SelectedItem).Key);
                    break;
                case "按引用地址别名汇总":
                    dataGridView1.DataSource = StatByRefererAlias(((KeyValuePair<string, int>)listBox1.SelectedItem).Key);
                    break;
                case "按客户端IP归属地汇总":
                    dataGridView1.DataSource = StatByClientIPLocation(((KeyValuePair<string, int>)listBox1.SelectedItem).Key);
                    break;
                default:
                    break;
            }
            if (listBox1.Items.Count > 0)
            {
                gbGrid.Text = listBox1.SelectedItem.ToString();
            }
        }

        #endregion

        private void menuItemCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(dataGridView1.GetClipboardContent().GetText(), TextDataFormat.UnicodeText);
        }

        private void menuItemExport_Click(object sender, EventArgs e)
        {
            //Export.DataGridViewToExcel(dataGridView1);
            int colCount = dataGridView1.Columns.Count;
            int rowCount = dataGridView1.Rows.Count;
            int recordCount = 50000;         //限制每个Worksheet做多能写的记录数
            int remainder = rowCount % recordCount;
            int sheetCount = 1;             //需要将数据写入多少个Worksheet

            if (remainder != 0) sheetCount = rowCount / recordCount + 1;
            else sheetCount = rowCount / recordCount;

            Workbook wb = new Workbook();

            for (int sheetIndex = 0; sheetIndex < sheetCount; sheetIndex++)
            {
                if (sheetIndex > 0) wb.Worksheets.Add();
                Worksheet ws = wb.Worksheets[sheetIndex];

                //for (int ci = 0; ci < colCount; ci++)
                //{
                //    int width = dataGridView1.Columns[ci].Width;
                //    ws.Cells.SetColumnWidth(ci, width / 7); 
                //    ws.Cells[0, ci].PutValue(dataGridView1.Columns[ci].HeaderText);

                //    for (int ri = 0; ri < rowCount; ri++)
                //    {
                //        ws.Cells[ri + 1, ci].PutValue(dataGridView1.Rows[ri].Cells[ci].Value);
                //    }
                //}

                //写列标题文本及设置列宽度
                for (int ci = 0; ci < colCount; ci++)
                {
                    int width = dataGridView1.Columns[ci].Width;
                    ws.Cells.SetColumnWidth(ci, width / 7);
                    ws.Cells[0, ci].PutValue(dataGridView1.Columns[ci].HeaderText);
                }

                int beginRowIndex = sheetIndex * recordCount;
                int endRowIndex = (sheetIndex + 1) * recordCount;
                if (sheetIndex == sheetCount - 1) endRowIndex = rowCount;

                for (; beginRowIndex < endRowIndex; beginRowIndex++)
                {
                    for (int ci = 0; ci < colCount; ci++)
                    {
                        int ri = beginRowIndex + 1 - sheetIndex * recordCount;
                        ws.Cells[ri, ci].PutValue(dataGridView1.Rows[beginRowIndex].Cells[ci].Value);
                    }
                }
            }

            string dicName = Path.Combine(Application.StartupPath, "IISLogExport");
            if(Directory.Exists(dicName) == false)Directory.CreateDirectory(dicName);

            string fileName = Path.Combine(dicName, string.Format("{0}.xls", Guid.NewGuid().ToString()));
            wb.Save(fileName, SaveFormat.Excel97To2003);
            RunExcel(fileName);
        }

        private void RunExcel1(string filename)
        {
            try
            {
                System.Diagnostics.Process.Start("Excel", string.Concat("\"", filename, "\""));
            }
            catch// (Exception ex)
            {
                RunExcel(filename);
            }
        }

        private void RunExcel(string filename)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(filename);
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
        }


        private void menuItemSelectAll_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectAll();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(), dataGridView1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 5);
        }

        private void menuItemExportToDB_Click(object sender, EventArgs e)
        {
            IList<LogRecord> list = dataGridView1.DataSource as IList<LogRecord>;
            if (list == null || list.Count == 0) return;

            //DataTable dt = new DataTable("IISLogData");
            //dt.Columns.Add("LogTime", typeof(string));
            //dt.Columns.Add("Method", typeof(string));
            //dt.Columns.Add("ClientIP", typeof(string));
            //dt.Columns.Add("ClientIPLocation", typeof(string));
            //dt.Columns.Add("Status", typeof(string));
            //dt.Columns.Add("SubStatus", typeof(string));
            //dt.Columns.Add("Win32Status", typeof(string));
            //dt.Columns.Add("ReceiveBytes", typeof(string));
            //dt.Columns.Add("SendBytes", typeof(string));
            //dt.Columns.Add("UriStem", typeof(string));
            //dt.Columns.Add("Referer", typeof(string));
            //dt.Columns.Add("UriStemAlias", typeof(string));
            //dt.Columns.Add("RefererAlias", typeof(string));
            //dt.Columns.Add("UserAgentAlias", typeof(string));
            //dt.Columns.Add("UserAgent", typeof(string));

            //foreach (LogRecord lr in list)
            //{
            //    DataRow row = dt.NewRow();

            //    row["LogTime"] = lr.LogTime.ToString();
            //    row["Method"] = lr.Method;
            //    row["ClientIP"] = lr.ClientIP;
            //    row["ClientIPLocation"] = lr.ClientIPLocation;
            //    row["Status"] = lr.Status;
            //    row["SubStatus"] = lr.SubStatus;
            //    row["Win32Status"] = lr.Win32Status;
            //    row["ReceiveBytes"] = lr.ReceiveBytes;
            //    row["SendBytes"] = lr.SendBytes;
            //    row["UriStem"] = lr.UriStem;
            //    row["Referer"] = lr.Referer;
            //    row["UriStemAlias"] = lr.UriStemAlias;
            //    row["RefererAlias"] = lr.RefererAlias;
            //    row["UserAgentAlias"] = lr.UserAgentAlias;
            //    row["UserAgent"] = lr.UserAgent;

            //    dt.Rows.Add(row);
            //}

            //IISLogExportToDB exporter = new IISLogExportToDB(dt);
            IISLogExportToDB exporter = new IISLogExportToDB(list);
            exporter.ShowDialog();
        }

    }
}
