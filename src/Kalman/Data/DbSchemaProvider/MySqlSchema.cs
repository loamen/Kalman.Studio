using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kalman.Data.SchemaObject;
using System.Data.Common;
using System.Data;
using Kalman.Utilities;

/* MySql元数据信息架构参考：http://dev.mysql.com/doc/refman/5.1/zh/information-schema.html */

namespace Kalman.Data.DbSchemaProvider
{
    public class MySqlSchema : DbSchema
    {
        public MySqlSchema(Database db)
        {
            base.DbProvider = db;
        }

        /// <summary>
        /// 获取数据库列表
        /// </summary>
        /// <returns></returns>
        public override List<SODatabase> GetDatabaseList()
        {
            string cmdText = "SELECT SCHEMA_NAME AS `Database` FROM INFORMATION_SCHEMA.SCHEMATA;";
            //string cmdText = "SHOW  DATABASES;";

            List<SODatabase> dbList = new List<SODatabase>();
            DataTable dt = this.DbProvider.ExecuteDataSet(System.Data.CommandType.Text, cmdText).Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                SODatabase db = new SODatabase { Parent = this, Name = row[0].ToString() };
                db.Comment = db.Name;
                if (db.Name.ToLower() == "information_schema" || db.Name.ToLower() == "mysql") continue;

                dbList.Add(db);
            }

            return dbList;
        }

        /// <summary>
        /// 获取表列表
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public override List<SOTable> GetTableList(SODatabase db)
        {
            string cmdText = string.Format("SELECT table_name,table_type,table_comment FROM INFORMATION_SCHEMA.`TABLES` WHERE table_schema='{0}' AND table_type='BASE TABLE';", db.Name);
            List<SOTable> tableList = new List<SOTable>();
            DataTable dt = this.DbProvider.ExecuteDataSet(System.Data.CommandType.Text, cmdText).Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                SOTable table = new SOTable { Parent = db, Name = row["table_name"].ToString(),Comment = row["table_comment"].ToString() };
                tableList.Add(table);
            }

            return tableList;
        }

        /// <summary>
        /// 获取表所拥有的列列表
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public override List<SOColumn> GetTableColumnList(SOTable table)
        {
            string cmdText = string.Format(@"SELECT *  
                FROM INFORMATION_SCHEMA.`COLUMNS` 
                WHERE table_schema='{0}' AND table_name='{1}' 
                ORDER BY ordinal_position;", table.Database.Name,table.Name);

            List<SOColumn> columnList = new List<SOColumn>();
            DataTable dt = this.DbProvider.ExecuteDataSet(System.Data.CommandType.Text, cmdText).Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                SOColumn column = new SOColumn
                {
                    Parent = table,
                    Name = row["column_name"].ToString(),
                    DefaultValue = row["column_default"].ToString(),
                    Nullable = row["is_nullable"].ToString().ToUpper() == "YES",
                    NativeType = row["data_type"].ToString(),
                    Identify = row["extra"].ToString().IndexOf("auto_increment") != -1,
                    //ForeignKey
                    Length = ConvertUtil.ToInt32(row["character_maximum_length"], -1),
                    Precision = ConvertUtil.ToInt32(row["numeric_precision"], -1),
                    PrimaryKey = row["column_key"].ToString() == "PRI",
                    Scale = ConvertUtil.ToInt32(row["numeric_scale"], -1),
                    Comment = row["column_comment"].ToString()
                };

                column.DataType = this.GetDbType(column.NativeType);
                columnList.Add(column);
            }

            return columnList;
        }

        /// <summary>
        /// 获取表所拥有的索引列表
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public override List<SOIndex> GetTableIndexList(SOTable table)
        {
            string cmdText = string.Format(@"SELECT *  
                FROM INFORMATION_SCHEMA.`constraints` 
                WHERE table_schema='{0}' AND table_name='{1}';", table.Database.Name, table.Name);

            List<SOIndex> indexList = new List<SOIndex>();
            List<SOColumn> columnList = GetTableColumnList(table);
            DataTable dt = this.DbProvider.ExecuteDataSet(System.Data.CommandType.Text, cmdText).Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                SOIndex index = new SOIndex
                {
                    Parent = table,
                    Name = row["constraint_name"].ToString(),
                    Comment = row["constraint_name"].ToString(),
                    IsCluster = false,
                    IsFullText = row["constraint_type"].ToString() == "Full Text",
                    IsPrimaryKey = row["constraint_type"].ToString() == "PRIMARY KEY",
                    IsUnique = row["constraint_type"].ToString() == "UNIQUE"
                };
                indexList.Add(index);

                string cmdText2 = string.Format(@"SELECT column_name  
                FROM INFORMATION_SCHEMA.`statistics` 
                WHERE table_schema='{0}' AND table_name='{1}';", table.Database.Name, table.Name);

                DataTable dt2 = this.DbProvider.ExecuteDataSet(CommandType.Text, cmdText2).Tables[0];
                index.Columns = new List<SOColumn>();
                foreach (DataRow row2 in dt2.Rows)
                {
                    foreach (SOColumn column in columnList)
                    {
                        if (row2[0].ToString() == column.Name) index.Columns.Add(column);
                    }
                }
            }

            return indexList;
        }

        /// <summary>
        /// 获取视图列表
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public override List<SOView> GetViewList(SODatabase db)
        {
            string cmdText = string.Format("SELECT table_name,table_type,table_comment FROM INFORMATION_SCHEMA.`TABLES` WHERE table_schema='{0}' AND table_type='VIEW';", db.Name);
            List<SOView> viewList = new List<SOView>();
            DataTable dt = this.DbProvider.ExecuteDataSet(System.Data.CommandType.Text, cmdText).Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                SOView view = new SOView { Parent = db, Name = row["table_name"].ToString(), Comment = row["table_comment"].ToString() };
                viewList.Add(view);
            }

            return viewList;
        }

        /// <summary>
        /// 获取视图所拥有的列列表
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public override List<SOColumn> GetViewColumnList(SOView view)
        {
            string cmdText = string.Format(@"SELECT *  
                FROM INFORMATION_SCHEMA.`COLUMNS` 
                WHERE table_schema='{0}' AND table_name='{1}' 
                ORDER BY ordinal_position;", view.Database.Name, view.Name);

            List<SOColumn> columnList = new List<SOColumn>();
            DataTable dt = this.DbProvider.ExecuteDataSet(System.Data.CommandType.Text, cmdText).Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                SOColumn column = new SOColumn
                {
                    Parent = view,
                    Name = row["column_name"].ToString(),
                    DefaultValue = row["column_default"].ToString(),
                    Nullable = row["is_nullable"].ToString().ToUpper() == "YES",
                    NativeType = row["data_type"].ToString(),
                    Identify = row["extra"].ToString().IndexOf("auto_increment") != -1,
                    //ForeignKey
                    Length = ConvertUtil.ToInt32(row["character_maximum_length"], -1),
                    Precision = ConvertUtil.ToInt32(row["numeric_precision"], -1),
                    PrimaryKey = row["column_key"].ToString() == "PRI",
                    Scale = ConvertUtil.ToInt32(row["numeric_scale"], -1),
                    Comment = row["column_comment"].ToString()
                };

                column.DataType = this.GetDbType(column.NativeType);
                columnList.Add(column);
            }

            return columnList;
        }

        /// <summary>
        /// 获取视图所拥有的索引列表
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public override List<SOIndex> GetViewIndexList(SOView view)
        {
            string cmdText = string.Format(@"SELECT *  
                FROM INFORMATION_SCHEMA.`constraints` 
                WHERE table_schema='{0}' AND table_name='{1}';", view.Database.Name, view.Name);

            List<SOIndex> indexList = new List<SOIndex>();
            List<SOColumn> columnList = GetViewColumnList(view);
            DataTable dt = this.DbProvider.ExecuteDataSet(System.Data.CommandType.Text, cmdText).Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                SOIndex index = new SOIndex
                {
                    Parent = view,
                    Name = row["constraint_name"].ToString(),
                    Comment = row["constraint_name"].ToString(),
                    IsCluster = false,
                    IsFullText = row["constraint_type"].ToString() == "Full Text",
                    IsPrimaryKey = row["constraint_type"].ToString() == "PRIMARY KEY",
                    IsUnique = row["constraint_type"].ToString() == "UNIQUE"
                };
                indexList.Add(index);

                string cmdText2 = string.Format(@"SELECT column_name  
                FROM INFORMATION_SCHEMA.`statistics` 
                WHERE table_schema='{0}' AND table_name='{1}';", view.Database.Name, view.Name);

                DataTable dt2 = this.DbProvider.ExecuteDataSet(CommandType.Text, cmdText2).Tables[0];
                index.Columns = new List<SOColumn>();
                foreach (DataRow row2 in dt2.Rows)
                {
                    foreach (SOColumn column in columnList)
                    {
                        if (row2[0].ToString() == column.Name) index.Columns.Add(column);
                    }
                }
            }

            return indexList;
        }

        /// <summary>
        /// 获取存储过程列表
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public override List<SOCommand> GetCommandList(SODatabase db)
        {
            string cmdText = string.Format(@"SELECT routine_name,routine_comment 
                FROM INFORMATION_SCHEMA.`ROUTINES` 
                WHERE routine_schema='{0}' AND routine_type='PROCEDURE';", db.Name);

            List<SOCommand> commandList = new List<SOCommand>();
            DataTable dt = this.DbProvider.ExecuteDataSet(System.Data.CommandType.Text, cmdText).Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                SOCommand command = new SOCommand { Parent = db, Name = row["routine_name"].ToString(), Comment = row["routine_comment"].ToString() };
                commandList.Add(command);
            }

            return commandList;
        }

        /// <summary>
        /// 获取存储过程参数列表
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public override List<SOCommandParameter> GetCommandParameterList(SOCommand command)
        {
            //在information_schema数据库中没有找到存储存储过程参数的表，可以考虑从存储过程DDL脚本解析出来
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取表的Sql脚本
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public override string GetTableSqlText(SOTable table)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取视图的Sql脚本
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public override string GetViewSqlText(SOView view)
        {
            string cmdText = string.Format("SELECT VIEW_DEFINITION FROM INFORMATION_SCHEMA.`VIEWS` WHERE table_schema='{0}' AND table_name='{1}';", view.Database.Name, view.Name);
            string text = this.DbProvider.ExecuteScalar(System.Data.CommandType.Text, cmdText).ToString();
            return text;
        }

        /// <summary>
        /// 获取存储过程的Sql脚本
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public override string GetCommandSqlText(SOCommand command)
        {
            string cmdText = string.Format(@"SELECT routine_definition
                FROM INFORMATION_SCHEMA.`ROUTINES` 
                WHERE routine_schema='{0}' AND routine_type='PROCEDURE' AND routine_name='{1}';", command.Database.Name, command.Name);

            string text = this.DbProvider.ExecuteScalar(System.Data.CommandType.Text, cmdText).ToString();
            return text;
        }

        /// <summary>
        /// 获取.Net Framework数据类型
        /// </summary>
        /// <param name="nativeType"></param>
        /// <returns></returns>
        public override DbType GetDbType(string nativeType)
        {
            return TypeUtil.MySqlDataType2DbType(nativeType);
        }
    }
}

