using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace Kalman.Data.SchemaObject
{
    /// <summary>
    /// 存储过程架构对象
    /// </summary>
    [Serializable]
    public class SOCommand : SOBase
    {
        /// <summary>
        /// 获取或设置父对象
        /// </summary>
        public SODatabase Parent { get; set; }

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
        /// 获取或设置对象所有者
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// 所属架构名称，SqlServer2005+特有属性
        /// </summary>
        public string SchemaName { get; set; }

        List<SOCommandParameter> _ParameterList;
        /// <summary>
        /// 获取或设置参数列表
        /// </summary>
        public List<SOCommandParameter> ParameterList
        {
            get
            {
                if (_ParameterList == null && Parent != null && Parent.Parent != null)
                {
                    return Parent.Parent.GetCommandParameterList(this);
                }
                else
                {
                    return _ParameterList;
                }
            }
            set { _ParameterList = value; }
        }

        /// <summary>
        /// 获取所属数据库对象
        /// </summary>
        public override SODatabase Database
        {
            get { return Parent; }
        }

        string _SqlText = string.Empty;
        /// <summary>
        /// 获取或设置存储过程Sql脚本
        /// </summary>
        public string SqlText
        {
            get
            {
                if (string.IsNullOrEmpty(_SqlText) && Parent != null && Parent.Parent != null)
                {
                    return Parent.Parent.GetCommandSqlText(this);
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
