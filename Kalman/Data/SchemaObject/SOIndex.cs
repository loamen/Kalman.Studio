using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kalman.Data.SchemaObject
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class SOIndex : SOBase
    {
        /// <summary>
        /// 父对象，所属表或视图
        /// </summary>
        public SOTableViewBase Parent { get; set; }

        /// <summary>
        /// 是否聚簇索引
        /// </summary>
        public bool IsCluster { get; set; }

        /// <summary>
        /// 是否主键
        /// </summary>
        public bool IsPrimaryKey { get; set; }

        /// <summary>
        /// 是否唯一键
        /// </summary>
        public bool IsUnique { get; set; }

        /// <summary>
        /// 该索引列是否标识列（目前只有Access（OleDb）用到）
        /// </summary>
        public bool IsIdentity { get; set; }

        /// <summary>
        /// 索引列表（目前只有Access（OleDb）用到）
        /// </summary>
        public string IndexColumnName { get; set; }

        /// <summary>
        /// 是否全文索引（MySQL专用）
        /// </summary>
        public bool IsFullText { get; set; }

        /// <summary>
        /// 索引成员列集合
        /// </summary>
        public List<SOColumn> Columns { get; set; }

        /// <summary>
        /// 获取所属数据库对象
        /// </summary>
        public override SODatabase Database
        {
            get { return Parent.Parent; }
        }
    }
}
