using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using Kalman.Extensions;

namespace Kalman.Data.SchemaObject
{
    /// <summary>
    /// 表架构对象
    /// </summary>
    [Serializable]
    public class SOTable : SOTableViewBase
    {
        public SOTable()
        {

        }

        /// <summary>
        /// 以视图对象为原型创建一个表对象实例
        /// </summary>
        /// <param name="view"></param>
        public SOTable(SOView view)
        {
            this.ColumnList = view.ColumnList;
            this.Comment = view.Comment ?? string.Empty;
            this.Name = view.Name;
            this.Owner = view.Owner;
            this.Parent = view.Parent;
            this.SchemaName = view.SchemaName;
            this.SqlText = view.SqlText;
        }

        /// <summary>
        /// 获取完整名称
        /// </summary>
        public override string FullName
        {
            get
            {
                DbCommandBuilder cmdBuilder = Parent.Parent.DbProvider.DbProviderFactory.CreateCommandBuilder();
                string prifix = Owner;
                if (string.IsNullOrEmpty(SchemaName) == false) prifix = SchemaName;

                string quotePrifix = string.Concat(cmdBuilder.QuotePrefix, prifix, cmdBuilder.QuoteSuffix);
                string quoteName = string.Concat(cmdBuilder.QuotePrefix, this.Name, cmdBuilder.QuoteSuffix);

                if (string.IsNullOrEmpty(prifix))
                {
                    return quoteName;
                }
                else
                {
                    return string.Format("{0}.{1}", quotePrifix, quoteName);
                }
            }
        }

        /// <summary>
        /// 获取或设置所属架构名称，SqlServer2005+特有属性
        /// </summary>
        public string SchemaName { get; set; }

        List<SOColumn> _ColumnList;
        /// <summary>
        /// 获取或设置列列表
        /// </summary>
        public override List<SOColumn> ColumnList
        {
            get
            {
                if (_ColumnList == null && Parent != null && Parent.Parent != null)
                {
                    _ColumnList = Parent.Parent.GetTableColumnList(this);
                }
                return _ColumnList;
            }
            set { _ColumnList = value; }
        }

        List<SOIndex> _IndexList;
        /// <summary>
        /// 获取或设置视图列表
        /// </summary>
        public override List<SOIndex> IndexList
        {
            get
            {
                if (_IndexList == null && Parent != null && Parent.Parent != null)
                {
                    _IndexList = Parent.Parent.GetTableIndexList(this);
                }
                return _IndexList;
            }
            set { _IndexList = value; }
        }

        string _SqlText = string.Empty;
        /// <summary>
        /// 获取或设置表Sql脚本
        /// </summary>
        public override string SqlText
        {
            get
            {
                if (string.IsNullOrEmpty(_SqlText) && Parent != null && Parent.Parent != null)
                {
                    _SqlText = Parent.Parent.GetTableSqlText(this);
                }
                return _SqlText;
            }
            set { _SqlText = value; }
        }

        List<SOColumn> _PrimaryKeys = new List<SOColumn>();

        /// <summary>
        /// 获取或设置表的主键列
        /// </summary>
        public List<SOColumn> PrimaryKeys
        {
            get
            {
                if (_PrimaryKeys.Count ==0)
                {
                    List<SOColumn> list = this.ColumnList;
                    foreach (var item in list)
                    {
                        if (item.PrimaryKey && !_PrimaryKeys.Contains(item))
                        {
                            _PrimaryKeys.Add(item);
                        }
                    }
                }

                return _PrimaryKeys;
            }
            set
            {
                _PrimaryKeys = value;
            }
        }

        public SOColumn PrimaryKey
        {
            get
            {
                if (PrimaryKeys == null || PrimaryKeys.Count == 0) return null;
                return PrimaryKeys[0];
            }
        }

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="columnName">列名</param>
        /// <returns></returns>
        public SOColumn this[string columnName]
        {
            get
            {
                var col = ColumnList.Find(p => p.Name == columnName);
                return col;
            }
        }

        /// <summary>
        /// 是否存在列
        /// </summary>
        /// <param name="columnName">列名</param>
        /// <returns>存在返回true，否则返回false</returns>
        public bool IsExistColumn(string columnName)
        {
            var col = this.ColumnList.Find(p => p.Name == columnName);
            return col != null;
        }

        /// <summary>
        /// 主键字段是否是自增列（主键字段为一个的情况下），暂时不支持oracle
        /// </summary>
        /// <returns></returns>
        public bool IsAutoID()
        {
            if (PrimaryKeys.Count != 1) return false;

            return PrimaryKeys[0].Identify;
        }

        public DataTable Query(List<string> columnList, string where = "")
        {
            string cmdText = string.Empty;
            IDbSchema dbSchema = this.Database.Parent;
            StringBuilder sb = new StringBuilder();

            columnList.ForEach(s => sb.AppendFormat("{0},", dbSchema.QuoteIdentifier(s)));

            if (!string.IsNullOrEmpty(where))
            {
                cmdText = string.Format("SELECT {0} FROM {0} WHERE {2}", sb.ToString().TrimEnd(','), this.Name, where);
            }
            else
            {
                cmdText = string.Format("SELECT {0} FROM {0}", sb.ToString().TrimEnd(','), this.Name);
            }

            DataTable dt = dbSchema.ExecuteQuery(this.Database, cmdText).Tables[0];
            return dt;
        }

       
    }
}
