using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kalman.Utilities;
using Kalman.Data.SchemaObject;
using System.Data;
using System.Collections;

namespace Kalman.Data.DbSchemaProvider
{
    /// <summary>
    /// SqlServerSchema
    /// </summary>
    public class SqlServerSchema : DbSchema
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        public SqlServerSchema(Database db)
        {
            base.DbProvider = db;
        }

        Dictionary<string, string> dic = new Dictionary<string, string>();
        static object syncObject = new object();

        string GetDBComment(SODatabase db)
        {
            string cmdText = string.Format(@"use [{0}]; 
                                SELECT value as 'comment'
                                FROM fn_listextendedproperty(default, default, default, default, default, default, default); ",db.Name);

            return this.DbProvider.ExecuteScalar<string>(CommandType.Text, cmdText);
        }

        string GetTableComment(SOTable table)
        {
            string key = string.Format("{0}_{1}_{2}", table.Database.Name, table.Owner, table.Name);

            lock (syncObject)
            {
                if (dic.ContainsKey(key)) return dic[key];
                else
                {
                    string cmdText = string.Format(@"use [{0}]; 
                                SELECT objname as 'table_name', value as 'comment' 
                                FROM fn_listextendedproperty (NULL, 'schema', '{1}', 'table', default, NULL, NULL); ", table.Database.Name, table.Owner);
                    DataTable dt = this.DbProvider.ExecuteDataSet(CommandType.Text, cmdText).Tables[0];
                    foreach (DataRow row in dt.Rows)
                    {
                        string tempKey = string.Format("{0}_{1}_{2}", table.Database.Name, table.Owner, row["table_name"].ToString());
                        if (dic.ContainsKey(tempKey)) continue;
                        dic.Add(tempKey, row["comment"].ToString());
                    }
                }

                if (dic.ContainsKey(key)) return dic[key];
                else return table.Name;
            }
        }

        string GetColumnComment(SOColumn column)
        {
            string key = string.Format("{0}_{1}_{2}", column.Database.Name, column.Parent.Name, column.Name);

            lock (syncObject)
            {
                if (dic.ContainsKey(key)) return dic[key];
                else
                {
                    string cmdText = string.Format(@"use [{0}];
                                                    SELECT major_id, minor_id, t.name AS 'table_name', c.name AS 'column_name', value AS 'comment'
                                                    FROM sys.extended_properties AS ep
                                                    INNER JOIN sys.tables AS t ON ep.major_id = t.object_id 
                                                    INNER JOIN sys.columns AS c ON ep.major_id = c.object_id AND ep.minor_id = c.column_id
                                                    WHERE class = 1;", column.Database.Name);
                    DataTable dt = this.DbProvider.ExecuteDataSet(CommandType.Text, cmdText).Tables[0];
                    foreach (DataRow row in dt.Rows)
                    {
                        string tempKey = string.Format("{0}_{1}_{2}", column.Database.Name, row["table_name"].ToString(), row["column_name"].ToString());
                        if (dic.ContainsKey(tempKey)) continue;
                        dic.Add(tempKey, row["comment"].ToString());
                    }
                }

                if (dic.ContainsKey(key)) return dic[key];
                else return column.Name;
            }
        }

        //获取表的主键列
        List<string> GetPrimaryKeys(SOTable table)
        {
            string cmdText = string.Format(@"use [{2}];exec sp_pkeys '{0}','{1}','{2}';", table.Name, table.Owner, table.Database.Name);
            List<string> list = new List<string>();
            DataTable dt = this.DbProvider.ExecuteDataSet(System.Data.CommandType.Text, cmdText).Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["column_name"].ToString());
            }

            return list;
        }

        public override List<SODatabase> GetDatabaseList()
        {
            List<SODatabase> list = base.GetDatabaseList();
            SortedDictionary<string, SODatabase> dic = new SortedDictionary<string, SODatabase>();
            foreach (var item in list)
            {
                if (item.Name == "master" || item.Name == "model" || item.Name == "msdb" || item.Name == "tempdb") continue;
                dic.Add(item.Name,item);
            }
            return dic.Values.ToList<SODatabase>();
        }

        /// <summary>
        /// 获取表列表
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public override List<SOTable> GetTableList(SODatabase db)
        {
            string cmdText = string.Format("use [{0}];exec sp_tables;",db.Name);
            SortedDictionary<string, SOTable> dic = new SortedDictionary<string,SOTable>();
            DataTable dt = this.DbProvider.ExecuteDataSet(System.Data.CommandType.Text, cmdText).Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                if (row["TABLE_TYPE"].ToString() != "TABLE") continue;
                if (row["TABLE_OWNER"].ToString() == "sys") continue;
                SOTable table = new SOTable { Parent = db, Name = row["TABLE_NAME"].ToString(), Owner = row["TABLE_OWNER"].ToString() };
                table.SchemaName = table.Owner;
                table.Comment = GetTableComment(table);
                dic.Add(table.Name,table);
            }

            return dic.Values.ToList<SOTable>();
        }

        /// <summary>
        /// 获取表所拥有的列列表
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public override List<SOColumn> GetTableColumnList(SOTable table)
        {
            string cmdText = string.Format(@"use [{2}];exec sp_columns '{0}','{1}','{2}';", table.Name, table.Owner, table.Database.Name);

            List<SOColumn> columnList = new List<SOColumn>();
            List<string> pkList = GetPrimaryKeys(table);
            DataTable dt = this.DbProvider.ExecuteDataSet(System.Data.CommandType.Text, cmdText).Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                SOColumn column = new SOColumn
                {
                    Parent = table,
                    Name = row["column_name"].ToString(),
                    DefaultValue = row["column_def"].ToString(),
                    Nullable = row["is_nullable"].ToString().ToUpper() == "YES",
                    NativeType = row["type_name"].ToString().Replace(" identity",""),
                    Identify = row["type_name"].ToString().IndexOf("identity") != -1,
                    //ForeignKey
                    Length = ConvertUtil.ToInt32(row["length"], -1),
                    Precision = ConvertUtil.ToInt32(row["precision"], -1),
                    Scale = ConvertUtil.ToInt32(row["scale"], -1),
                };

                column.PrimaryKey = pkList.Contains(column.Name);
                column.DataType = this.GetDbType(column.NativeType);
                column.Comment = GetColumnComment(column);
                columnList.Add(column);
            }

            return columnList;
        }

//        /// <summary>
//        /// 获取表所拥有的索引列表
//        /// </summary>
//        /// <param name="table"></param>
//        /// <returns></returns>
//        public override List<SOIndex> GetTableIndexList(SOTable table)
//        {
//            string cmdText = string.Format(@"SELECT *  
//                FROM INFORMATION_SCHEMA.`constraints` 
//                WHERE table_schema='{0}' AND table_name='{1}';", table.Database.Name, table.Name);

//            List<SOIndex> indexList = new List<SOIndex>();
//            List<SOColumn> columnList = GetTableColumnList(table);
//            DataTable dt = this.DbProvider.ExecuteDataSet(System.Data.CommandType.Text, cmdText).Tables[0];

//            foreach (DataRow row in dt.Rows)
//            {
//                SOIndex index = new SOIndex
//                {
//                    Parent = table,
//                    Name = row["constraint_name"].ToString(),
//                    Comment = row["constraint_name"].ToString(),
//                    IsCluster = false,
//                    IsFullText = row["constraint_type"].ToString() == "Full Text",
//                    IsPrimaryKey = row["constraint_type"].ToString() == "PRIMARY KEY",
//                    IsUnique = row["constraint_type"].ToString() == "UNIQUE"
//                };
//                indexList.Add(index);

//                string cmdText2 = string.Format(@"SELECT column_name  
//                FROM INFORMATION_SCHEMA.`statistics` 
//                WHERE table_schema='{0}' AND table_name='{1}';", table.Database.Name, table.Name);

//                DataTable dt2 = this.DbProvider.ExecuteDataSet(CommandType.Text, cmdText2).Tables[0];
//                index.Columns = new List<SOColumn>();
//                foreach (DataRow row2 in dt2.Rows)
//                {
//                    foreach (SOColumn column in columnList)
//                    {
//                        if (row2[0].ToString() == column.Name) index.Columns.Add(column);
//                    }
//                }
//            }

//            return indexList;
//        }

        /// <summary>
        /// 获取视图列表
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public override List<SOView> GetViewList(SODatabase db)
        {
            string cmdText = string.Format("use [{0}];exec sp_tables;", db.Name);
            SortedDictionary<string, SOView> dic = new SortedDictionary<string, SOView>();
            DataTable dt = this.DbProvider.ExecuteDataSet(System.Data.CommandType.Text, cmdText).Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                if (row["TABLE_TYPE"].ToString() != "VIEW") continue;
                if (row["TABLE_OWNER"].ToString() == "sys" || row["TABLE_OWNER"].ToString() == "INFORMATION_SCHEMA") continue;
                SOView view = new SOView { Parent = db, Name = row["TABLE_NAME"].ToString(), Owner = row["TABLE_OWNER"].ToString() };
                view.SchemaName = view.Owner;
                dic.Add(view.Name, view);
            }

            return dic.Values.ToList<SOView>();
        }

        /// <summary>
        /// 获取视图所拥有的列列表
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public override List<SOColumn> GetViewColumnList(SOView view)
        {
            string cmdText = string.Format(@"use [{2}];exec sp_columns '{0}','{1}','{2}';", view.Name, view.Owner, view.Database.Name);

            List<SOColumn> columnList = new List<SOColumn>();
            DataTable dt = this.DbProvider.ExecuteDataSet(System.Data.CommandType.Text, cmdText).Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                SOColumn column = new SOColumn
                {
                    Parent = view,
                    Name = row["column_name"].ToString(),
                    DefaultValue = row["column_def"].ToString(),
                    Nullable = row["is_nullable"].ToString().ToUpper() == "YES",
                    NativeType = row["type_name"].ToString().Replace(" identity", ""),
                    Identify = row["type_name"].ToString().IndexOf("identity") != -1,
                    //ForeignKey
                    Length = ConvertUtil.ToInt32(row["length"], -1),
                    Precision = ConvertUtil.ToInt32(row["precision"], -1),
                    Scale = ConvertUtil.ToInt32(row["scale"], -1),
                };

                column.DataType = this.GetDbType(column.NativeType);
                column.Comment = GetColumnComment(column);
                columnList.Add(column);
            }

            return columnList;
        }

//        /// <summary>
//        /// 获取视图所拥有的索引列表
//        /// </summary>
//        /// <param name="view"></param>
//        /// <returns></returns>
//        public override List<SOIndex> GetViewIndexList(SOView view)
//        {
//            string cmdText = string.Format(@"SELECT *  
//                FROM INFORMATION_SCHEMA.`constraints` 
//                WHERE table_schema='{0}' AND table_name='{1}';", view.Database.Name, view.Name);

//            List<SOIndex> indexList = new List<SOIndex>();
//            List<SOColumn> columnList = GetViewColumnList(view);
//            DataTable dt = this.DbProvider.ExecuteDataSet(System.Data.CommandType.Text, cmdText).Tables[0];

//            foreach (DataRow row in dt.Rows)
//            {
//                SOIndex index = new SOIndex
//                {
//                    Parent = view,
//                    Name = row["constraint_name"].ToString(),
//                    Comment = row["constraint_name"].ToString(),
//                    IsCluster = false,
//                    IsFullText = row["constraint_type"].ToString() == "Full Text",
//                    IsPrimaryKey = row["constraint_type"].ToString() == "PRIMARY KEY",
//                    IsUnique = row["constraint_type"].ToString() == "UNIQUE"
//                };
//                indexList.Add(index);

//                string cmdText2 = string.Format(@"SELECT column_name  
//                FROM INFORMATION_SCHEMA.`statistics` 
//                WHERE table_schema='{0}' AND table_name='{1}';", view.Database.Name, view.Name);

//                DataTable dt2 = this.DbProvider.ExecuteDataSet(CommandType.Text, cmdText2).Tables[0];
//                index.Columns = new List<SOColumn>();
//                foreach (DataRow row2 in dt2.Rows)
//                {
//                    foreach (SOColumn column in columnList)
//                    {
//                        if (row2[0].ToString() == column.Name) index.Columns.Add(column);
//                    }
//                }
//            }

//            return indexList;
//        }

        /// <summary>
        /// 获取存储过程列表
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public override List<SOCommand> GetCommandList(SODatabase db)
        {
            string cmdText = string.Format(@"use [{0}];SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE routine_catalog='{0}' AND routine_type='PROCEDURE';", db.Name);

            List<SOCommand> commandList = new List<SOCommand>();
            DataTable dt = this.DbProvider.ExecuteDataSet(System.Data.CommandType.Text, cmdText).Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                SOCommand command = new SOCommand { Parent = db, Name = row["routine_name"].ToString(), Comment = row["routine_name"].ToString() };
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
            string cmdText = string.Format(@"USE [{1}];SELECT routine_definition FROM INFORMATION_SCHEMA.PARAMETERS 
                WHERE SPECIFIC_schema='{0}' AND SPECIFIC_type='PROCEDURE' AND SPECIFIC_catalog='{1}' AND SPECIFIC_name='{2}';",
                                                    command.Owner ?? "dbo", command.Database.Name, command.Name);

            List<SOCommandParameter> columnList = new List<SOCommandParameter>();
            DataTable dt = this.DbProvider.ExecuteDataSet(System.Data.CommandType.Text, cmdText).Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                ParameterDirection direction = ParameterDirection.ReturnValue;
                string pmode = row["PARAMETER_MODE"].ToString();
                if (pmode == "IN") direction = ParameterDirection.Input;
                if (pmode == "OUT") direction = ParameterDirection.Output;
                if (pmode == "INOUT") direction = ParameterDirection.InputOutput;

                SOCommandParameter param = new SOCommandParameter
                {
                    Parent = command,
                    Name = row["PARAMETER_NAME"].ToString(),
                    Direction = direction,
                    NativeType = row["DATA_TYPE"].ToString().Replace(" identity", ""),
                    Length = ConvertUtil.ToInt32(row["CHARACTER_OCTET_LENGTH"], -1),
                    Precision = ConvertUtil.ToInt32(row["NUMERIC_PRECISION"], -1),
                    Scale = ConvertUtil.ToInt32(row["NUMERIC_SCALE"], -1),
                };

                param.DataType = this.GetDbType(param.NativeType);
                columnList.Add(param);
            }

            return columnList;
        }

        ///// <summary>
        ///// 获取表的Sql脚本
        ///// </summary>
        ///// <param name="table"></param>
        ///// <returns></returns>
        //public override string GetTableSqlText(SOTable table)
        //{
        //    throw new NotImplementedException();
        //}

        /// <summary>
        /// 获取视图的Sql脚本
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public override string GetViewSqlText(SOView view)
        {
            string cmdText = string.Format("use [{0}];SELECT VIEW_DEFINITION FROM INFORMATION_SCHEMA.VIEWS WHERE table_schema='{1}' AND table_name='{2}';", view.Database.Name, view.Owner, view.Name);
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
            string cmdText = string.Format(@"USE [{1}];SELECT routine_definition FROM INFORMATION_SCHEMA.ROUTINES 
                WHERE routine_schema='{0}' AND routine_type='PROCEDURE' AND routine_catalog='{1}' AND routine_name='{2}';",
                                                    command.Owner ?? "dbo", command.Database.Name, command.Name);

            string text = this.DbProvider.ExecuteScalar(System.Data.CommandType.Text, cmdText).ToString();
            return text;
        }

        public override System.Data.DbType GetDbType(string nativeType)
        {
            return TypeUtil.SqlServerDataType2DbType(nativeType);
        }
    }
}
