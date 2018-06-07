using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using Kalman.Logging.Formatters;
using Kalman.Extensions;
using Kalman.Utilities;

namespace Kalman.Logging.Targets
{
    public class DbTarget : ITarget
    {
        public DbTarget(IFormatter formatter)
        {
            CheckUtil.ArgumentNotNull(formatter, "formatter");

            Formatter = formatter;
        }

        #region ITarget 成员

        public void LoadConfig(TargetConfig config)
        {
            CheckUtil.ArgumentNotNull(config, "config");

            Name = config.Name;
            foreach (XmlNode node in config.ChildConfig)
            {
                try
                {
                    if (node.ChildNodes.Count != 1)
                        throw new ConfigurationErrorsException("DbTarget子元素 " + node.Name + "只能为单值元素");

                    switch (node.Name)
                    {
                        case "connectionStringName":
                            ConnectionStringName = node.FirstChild.Value;
                            break;
                        case "commandText":
                            CommandText = node.FirstChild.Value;
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    throw new ConfigurationErrorsException("解析DbTarget子元素值 '" + node.FirstChild.Value + "'失败", ex);
                }
            }
        }

        public string Name { get; private set; }

        public IFormatter Formatter { get; set; }

        /// <summary>
        /// 连接字符串名称，必须配置connectionStrings节
        /// </summary>
        public string ConnectionStringName { get; set; }

        /// <summary>
        /// 将日志写入数据库的Sql语句
        /// </summary>
        public string CommandText { get; set; }

        public void Write(LogEntry logEntry)
        {
            ConnectionStringSettings css = ConfigurationManager.ConnectionStrings[ConnectionStringName];
            DbProviderFactory factory = SqlClientFactory.Instance;
            if (css.ProviderName != string.Empty) factory = DbProviderFactories.GetFactory(css.ProviderName);

            using (DbConnection cn = factory.CreateConnection())
            {
                cn.ConnectionString = css.ConnectionString;
                cn.Open();
                DbCommand cmd = cn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = this.CommandText;

                //@Level        日志级别
                if (this.CommandText.Contains("@Level"))
                {
                    DbParameter p1 = factory.CreateParameter();
                    p1.ParameterName = "Level";
                    p1.DbType = System.Data.DbType.String;
                    p1.Size = 10;
                    p1.Value = logEntry.Level.ToString();

                    cmd.Parameters.Add(p1);
                }

                //@Message      日志消息
                if (this.CommandText.Contains("@Message"))
                {
                    DbParameter p2 = factory.CreateParameter();
                    p2.ParameterName = "Message";
                    p2.DbType = System.Data.DbType.String;
                    p2.Size = 1000;
                    p2.Value = logEntry.Message.CutString(0, 1000);

                    cmd.Parameters.Add(p2);
                }

                //@CreatedAt    创建时间
                if (this.CommandText.Contains("@CreatedAt"))
                {
                    DbParameter p3 = factory.CreateParameter();
                    p3.ParameterName = "CreatedAt";
                    p3.DbType = System.Data.DbType.DateTime;
                    p3.Value = logEntry.CreatedAt;

                    cmd.Parameters.Add(p3);
                }

                //@ThreadID     线程ID
                if (this.CommandText.Contains("@ThreadID"))
                {
                    DbParameter p4 = factory.CreateParameter();
                    p4.ParameterName = "ThreadID";
                    p4.DbType = System.Data.DbType.Int32;
                    p4.Value = logEntry.ThreadID;

                    cmd.Parameters.Add(p4);
                }

                //@StackFrames  堆栈帧集合（描述方法的调用关系）
                if (this.CommandText.Contains("@StackFrames"))
                {
                    DbParameter p5 = factory.CreateParameter();
                    p5.ParameterName = "StackFrames";
                    p5.DbType = System.Data.DbType.String;
                    p5.Size = 200;
                    p5.Value = new StackTraceFormatter().Format(logEntry).CutString(0, 200);

                    cmd.Parameters.Add(p5);
                }

                //@Exception    异常信息，暂时只记录堆栈跟踪信息
                if (this.CommandText.Contains("@Exception"))
                {
                    DbParameter p6 = factory.CreateParameter();
                    p6.ParameterName = "Exception";
                    p6.DbType = System.Data.DbType.String;
                    p6.Size = 2000;
                    p6.Value = logEntry.Exception.StackTrace.CutString(0, 2000);

                    cmd.Parameters.Add(p6);
                }

                //@LogText      使用格式化器格式化后的日志文本
                if (this.CommandText.Contains("@LogText"))
                {
                    DbParameter p7 = factory.CreateParameter();
                    p7.ParameterName = "LogText";
                    p7.DbType = System.Data.DbType.String;
                    p7.Size = 2000;

                    if (this.Formatter != null)
                        p7.Value = Formatter.Format(logEntry).CutString(0, 2000);
                    else
                        p7.Value = logEntry.Message;

                    cmd.Parameters.Add(p7);
                }

                //@Logger       日志记录器名称
                if (this.CommandText.Contains("@Logger"))
                {
                    DbParameter p8 = factory.CreateParameter();
                    p8.ParameterName = "Logger";
                    p8.DbType = System.Data.DbType.String;
                    p8.Size = 50;
                    p8.Value = logEntry.Logger.Name.CutString(0, 50);

                    cmd.Parameters.Add(p8);
                }

                cmd.ExecuteNonQuery();
            }
        }

        #endregion
    }
}
