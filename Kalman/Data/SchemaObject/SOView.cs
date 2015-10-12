using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace Kalman.Data.SchemaObject
{
    /// <summary>
    /// 视图架构对象
    /// </summary>
    [Serializable]
    public class SOView : SOTableViewBase
    {
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
                    return Parent.Parent.GetViewColumnList(this);
                }
                else
                {
                    return _ColumnList;
                }
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
                    return Parent.Parent.GetViewIndexList(this);
                }
                else
                {
                    return _IndexList;
                }
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
                    return Parent.Parent.GetViewSqlText(this);
                }
                else
                {
                    return _SqlText;
                }
            }
            set { _SqlText = value; }
        }
    }
}
