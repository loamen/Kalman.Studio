using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kalman.Data.SchemaObject;
using System.Data;
using Kalman.Utilities;
using System.Collections.Specialized;

namespace Kalman.Data.DbSchemaProvider
{
    public class OracleSchema : DbSchema
    {
        public bool IsDBA
        {
            get; set;
        }
        public OracleSchema()
        {
            init();
        }

        public OracleSchema(Database db)
        {
            base.DbProvider = db;
            init();
        }

        public void init()
        {
            string result = this.DbProvider.ExecuteScalar<string>(CommandType.Text, "select userenv('ISDBA') from dual");
            IsDBA = (result != "FALSE");
        }

        public override List<SODatabase> GetDatabaseList()
        {
            List<SODatabase> list = new List<SODatabase>();

            string cmdText = "select * from dba_users";
            if (!IsDBA)
            {
                cmdText = "select * from user_users";
            }
            try
            {
                DataTable dt = this.DbProvider.ExecuteDataSet(System.Data.CommandType.Text, cmdText).Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    SODatabase db = new SODatabase();
                    db.Name = row["USERNAME"].ToString();
                    db.Comment = db.Name;
                    db.Parent = this;

                    list.Add(db);
                }
            }
            catch (Exception)
            {
            }
            return list;
        }

        /// <summary>
        /// 获取表列表
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public override List<SOTable> GetTableList(SODatabase db)
        {
            SortedDictionary<string, SOTable> dic = new SortedDictionary<string, SOTable>();
            string cmdText = string.Format(@"select t.OWNER,t.TABLE_NAME,t.NUM_ROWS,c.TABLE_TYPE,c.COMMENTS from dba_tables t left join dba_tab_comments c on t.TABLE_NAME = c.TABLE_NAME where t.owner='{0}'", db.Name);
            if (!IsDBA)
            {
                cmdText = string.Format(@"select t.TABLE_NAME,t.NUM_ROWS,c.TABLE_TYPE,c.COMMENTS from user_tables t left join user_tab_comments c on t.TABLE_NAME = c.TABLE_NAME");
                // cmdText = @"select a.TABLE_NAME,b.COMMENTS,a.NUM_ROWS,b.table_type from user_tables a,user_tab_comments b WHERE a.TABLE_NAME=b.TABLE_NAME order by TABLE_NAME";
            }
            DataTable dt = this.DbProvider.ExecuteDataSet(System.Data.CommandType.Text, cmdText).Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                //if (row["TABLE_TYPE"].ToString() != "TABLE") continue;
                if (row["TABLE_NAME"].ToString().StartsWith("BIN$")) continue;

                SOTable table = new SOTable { Parent = db, Name = row["TABLE_NAME"].ToString(), Owner = IsDBA ? row["OWNER"].ToString() : db.Name, Comment = row["COMMENTS"].ToString() };
                table.SchemaName = table.Owner;
                if (!dic.ContainsKey(table.Name)) dic.Add(table.Name, table);
            }

            return dic.Values.ToList<SOTable>();
        }

        //获取表的主键列
        List<string> GetPrimaryKeys(SOTable table)
        {
            string cmdText = string.Format(@"select c.owner,c.constraint_name,c.table_name,cc.column_name,cc.position 
                from dba_constraints c inner join dba_cons_columns cc on c.constraint_name = cc.constraint_name 
                where c.owner='{0}' and c.constraint_type='P' and c.table_name='{1}'", table.Database.Name, table.Name);

            if (!IsDBA)
            {
                cmdText = string.Format(@"select c.owner,c.constraint_name,c.table_name,cc.column_name,cc.position 
                from user_constraints c inner join user_cons_columns cc on c.constraint_name = cc.constraint_name 
                where c.owner='{0}' and c.constraint_type='P' and c.table_name='{1}'", table.Database.Name, table.Name);
            }

            List<string> list = new List<string>();
            DataTable dt = this.DbProvider.ExecuteDataSet(System.Data.CommandType.Text, cmdText).Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["column_name"].ToString());
            }

            return list;
        }

        /// <summary>
        /// 获取表所拥有的列列表
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public override List<SOColumn> GetTableColumnList(SOTable table)
        {
            string cmdText = string.Format(@"select c.COLUMN_ID,c.COLUMN_NAME,c.DATA_TYPE,c.DATA_LENGTH,c.DATA_PRECISION,c.DATA_SCALE,c.NULLABLE,c.DATA_DEFAULT,c.CHAR_COL_DECL_LENGTH,c.CHAR_LENGTH,cc.COMMENTS 
                from dba_tab_columns c left join dba_col_comments cc on c.table_name=cc.table_name and c.column_name=cc.column_name 
                where c.owner='{0}' and cc.owner='{0}' and c.table_name='{1}' order by c.column_id", table.Database.Name, table.Name);
            if (!IsDBA)
            {
                cmdText = string.Format(@"select c.COLUMN_ID,c.COLUMN_NAME,c.DATA_TYPE,c.DATA_LENGTH,c.DATA_PRECISION,c.DATA_SCALE,c.NULLABLE,c.DATA_DEFAULT,c.CHAR_COL_DECL_LENGTH,c.CHAR_LENGTH,cc.COMMENTS
                from user_tab_columns c left join user_col_comments cc on c.table_name = cc.table_name and c.column_name = cc.column_name
                where c.table_name='{0}' order by c.column_id", table.Name);
            }
            List<SOColumn> columnList = new List<SOColumn>();
            List<string> pkList = GetPrimaryKeys(table);
            DataTable dt = this.DbProvider.ExecuteDataSet(System.Data.CommandType.Text, cmdText).Tables[0];

            StringCollection sc = new StringCollection();
            foreach (DataRow row in dt.Rows)
            {
                SOColumn column = new SOColumn
                {
                    Parent = table,
                    Name = row["COLUMN_NAME"].ToString(),
                    DefaultValue = row["DATA_LENGTH"].ToString(),
                    Nullable = row["NULLABLE"].ToString().ToUpper() == "Y",
                    NativeType = row["DATA_TYPE"].ToString().Replace(" identity", ""),
                    //Identify = row["type_name"].ToString().IndexOf("identity") != -1,
                    Identify = false,
                    //ForeignKey
                    Length = ConvertUtil.ToInt32(row["CHAR_LENGTH"], 0),
                    Precision = ConvertUtil.ToInt32(row["DATA_PRECISION"], 0),
                    Scale = ConvertUtil.ToInt32(row["DATA_SCALE"], 0),
                    Comment = row["COMMENTS"].ToString()
                };

                column.PrimaryKey = pkList.Contains(column.Name);
                column.DataType = this.GetDbType(column.NativeType, column.Precision, column.Scale);

                if (!sc.Contains(column.Name))
                {
                    columnList.Add(column);
                }

                sc.Add(column.Name);
            }

            return columnList;
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
        /// 获取视图列表
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public override List<SOView> GetViewList(SODatabase db)
        {
            string cmdText = string.Format("select VIEW_NAME,TEXT from dba_views where owner='{0}'", db.Name);
            if (!IsDBA)
            {
                cmdText = string.Format("select VIEW_NAME,TEXT from user_views");
            }
            SortedDictionary<string, SOView> dic = new SortedDictionary<string, SOView>();
            DataTable dt = this.DbProvider.ExecuteDataSet(System.Data.CommandType.Text, cmdText).Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                SOView view = new SOView { Parent = db, Name = row["VIEW_NAME"].ToString(), SqlText = row["TEXT"].ToString(), Owner = db.Name };
                view.SchemaName = view.Owner;
                dic.Add(view.Name, view);
            }

            return dic.Values.ToList<SOView>();
        }

        /// <summary>
        /// 获取视图的Sql脚本
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public override string GetViewSqlText(SOView view)
        {
            return view.SqlText;
        }

        /// <summary>
        /// 获取存储过程列表
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public override List<SOCommand> GetCommandList(SODatabase db)
        {
            string cmdText = string.Format(@"select PROCEDURE_NAME from dba_procedures where owner='{0}'", db.Name);
            if (!IsDBA)
            {
                cmdText = string.Format(@"select PROCEDURE_NAME from user_procedures");
            }
            List<SOCommand> commandList = new List<SOCommand>();
            DataTable dt = this.DbProvider.ExecuteDataSet(System.Data.CommandType.Text, cmdText).Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                SOCommand command = new SOCommand { Parent = db, Name = row["PROCEDURE_NAME"].ToString(), Comment = row["PROCEDURE_NAME"].ToString() };
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
            string cmdText = string.Format(@"select * from all_arguments where owner='{0}' and package_name={1} order by position", command.Database.Name, command.Name);
            if (!IsDBA)
            {
                cmdText = string.Format(@"select * from all_arguments where owner='{0}' and package_name={1} order by position", command.Database.Name, command.Name);
            }
            List<SOCommandParameter> columnList = new List<SOCommandParameter>();
            DataTable dt = this.DbProvider.ExecuteDataSet(System.Data.CommandType.Text, cmdText).Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                ParameterDirection direction = ParameterDirection.ReturnValue;
                string pmode = row["IN_OUT"].ToString();
                if (pmode == "IN") direction = ParameterDirection.Input;
                if (pmode == "OUT") direction = ParameterDirection.Output;
                if (pmode == "IN/OUT") direction = ParameterDirection.InputOutput;

                SOCommandParameter param = new SOCommandParameter
                {
                    Parent = command,
                    Name = row["ARGUMENT_NAME"].ToString(),
                    Direction = direction,
                    NativeType = row["DATA_TYPE"].ToString(),
                    Length = ConvertUtil.ToInt32(row["CHAR_LENGTH"], 0),
                    Precision = ConvertUtil.ToInt32(row["DATA_PRECISION"], 0),
                    Scale = ConvertUtil.ToInt32(row["DATA_SCALE"], 0),
                };

                param.DataType = this.GetDbType(param.NativeType);
                columnList.Add(param);
            }

            return columnList;
        }

        /// <summary>
        /// 获取存储过程的Sql脚本
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public override string GetCommandSqlText(SOCommand command)
        {
            string cmdText = string.Format(@"select TEXT from dba_source where type='PROCEDURE' and owner='{0}' and name='{1}' order by line", command.Database.Name, command.Name);
            if (!IsDBA)
            {
                cmdText = string.Format(@"select TEXT from user_source where type='PROCEDURE' and owner='{0}' and name='{1}' order by line", command.Database.Name, command.Name);
            }
            DataTable dt = this.DbProvider.ExecuteDataSet(System.Data.CommandType.Text, cmdText).Tables[0];
            StringBuilder sb = new StringBuilder();
            foreach (DataRow row in dt.Rows)
            {
                sb.AppendLine(row["TEXT"].ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// 获取.Net Framework数据类型
        /// </summary>
        /// <param name="nativeType"></param>
        /// <returns></returns>
        public override DbType GetDbType(string nativeType)
        {
            return TypeUtil.OracleDataType2DbType(nativeType);
        }

        public DbType GetDbType(string nativeType, int precision = 0, int scale = 0)
        {
            return TypeUtil.OracleDataType2DbType(nativeType, precision, scale);
        }
    }
}
