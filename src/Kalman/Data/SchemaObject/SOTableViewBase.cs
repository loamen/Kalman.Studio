using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kalman.Data.SchemaObject
{
    [Serializable]
    public abstract class SOTableViewBase : SOBase
    {
        /// <summary>
        /// 获取所属数据库对象
        /// </summary>
        public override SODatabase Database
        {
            get
            {
                return this.Parent;
            }
        }

        /// <summary>
        /// 获取或设置父对象
        /// </summary>
        public SODatabase Parent { get; set; }

        /// <summary>
        /// 获取或设置对象所有者
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// 获取列列表
        /// </summary>
        public abstract List<SOColumn> ColumnList { get; set; }

        /// <summary>
        /// 获取索引列表
        /// </summary>
        public abstract List<SOIndex> IndexList { get; set; }

        /// <summary>
        /// 获取Sql脚本
        /// </summary>
        public abstract string SqlText { get; set; }
    }
}
