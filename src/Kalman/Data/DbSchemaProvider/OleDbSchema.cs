using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;
using Kalman.Data.SchemaObject;
using Kalman.Utilities;

namespace Kalman.Data.DbSchemaProvider
{
    public class OleDbSchema : DbSchema
    {
        public OleDbSchema()
        {
        }

        public OleDbSchema(Database db)
        {
            base.DbProvider = db;
        }

        public override string MetaDataCollectionName_Databases
        {
            get { return "Catalogs"; }
        }

        public override DataSet ExecuteQuery(SODatabase db, string cmdText)
        {
            DataSet ds = new DataSet();
            using (DbConnection cn = base.DbProvider.DbProviderFactory.CreateConnection())
            {
                cn.ConnectionString = base.DbProvider.ConnectionString;
                cn.Open();

                DbCommand cmd = base.DbProvider.DbProviderFactory.CreateCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = cmdText;

                DbDataAdapter adapter = base.DbProvider.DbProviderFactory.CreateDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds, 0, 100000, "temp");
            }

            return ds;
        }

        public override List<SODatabase> GetDatabaseList()
        {
            return new List<SODatabase>
            {
                new SODatabase
                {
                    //Name = "Main",
                    Parent = this,
                    //Comment = "Main"
                }
            };
        }

        /// <summary>
        /// 获取表列表
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public override List<SOTable> GetTableList(SODatabase db)
        {
            List<SOTable> list = new List<SOTable>();

            string[] restrictions = new string[4];
            restrictions[0] = db.Name;
            DataTable dt = GetSchema(MetaDataCollectionName_Tables, restrictions);

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["TABLE_TYPE"].ToString() != "TABLE") continue;   //排除系统表

                SOTable table = new SOTable();
                table.Name = dr["table_name"].ToString();
                table.Comment = table.Name;
                table.Parent = db;

                list.Add(table);
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
            List<SOColumn> list = new List<SOColumn>();

            string[] restrictions = new string[4];
            restrictions[0] = table.Database.Name;
            restrictions[2] = table.Name;
            DataTable dt = GetSchema(MetaDataCollectionName_Columns, restrictions);

            List<SOIndex> indexList = this.GetTableIndexList(table);

            foreach (DataRow dr in dt.Rows)
            {
                SOColumn c = new SOColumn();
                c.Name = dr["column_name"].ToString();
                c.Comment = dr["DESCRIPTION"].ToString();
                c.Parent = table;

                if (dr["COLUMN_HASDEFAULT"].ToString().ToLower() != "false")
                {
                    c.DefaultValue = ConvertUtil.ToString(dr["COLUMN_DEFAULT"]);
                }

                c.Nullable = dr["IS_NULLABLE"].ToString().ToLower() == "true" ? true : false;
                c.NativeType = dr["DATA_TYPE"].ToString();
                c.Length = ConvertUtil.ToInt32(dr["CHARACTER_MAXIMUM_LENGTH"], -1);
                c.Precision = ConvertUtil.ToInt32(dr["NUMERIC_PRECISION"], -1);
                c.Scale = ConvertUtil.ToInt32(dr["NUMERIC_SCALE"], -1);

                c.DataType = this.GetDbType(c.NativeType);
                c.PrimaryKey = IndexColumnIsPrimary(indexList, c.Name);
                c.Identify = IndexColumnIsIdentity(indexList, c.Name);

                list.Add(c);
            }

            return list;
        }

        //判断是否主键，从索引列里面判断
        bool IndexColumnIsPrimary(List<SOIndex> list, string columnName)
        {
            foreach (var item in list)
            {
                if (item.IndexColumnName == columnName && item.IsPrimaryKey) return true;
            }

            return false;
        }

        //判断是否标识列，从索引列里面判断
        bool IndexColumnIsIdentity(List<SOIndex> list, string columnName)
        {
            foreach (var item in list)
            {
                if (item.IndexColumnName == columnName && item.IsIdentity) return true;
            }

            return false;
        }

        public override List<SOCommand> GetCommandList(SODatabase db)
        {
            return new List<SOCommand>();
        }

        public override List<SOCommandParameter> GetCommandParameterList(SOCommand command)
        {
            return new List<SOCommandParameter>();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取存储过程的Sql脚本
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public override string GetCommandSqlText(SOCommand command)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取.Net Framework数据类型
        /// </summary>
        /// <param name="nativeType"></param>
        /// <returns></returns>
        public override DbType GetDbType(string nativeType)
        {
            return TypeUtil.OleDbADataType2DbType(nativeType);
        }
    }
}
