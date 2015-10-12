using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kalman.PdmParser
{
    /// <summary>
    /// 对象之间的关系实体
    /// </summary>
    [Serializable]
    public class PDReference : PDObject
    {
        /// <summary>
        /// 获取或设置所属包对象
        /// </summary>
        public PDPackage Package { get; set; }

        /// <summary>
        /// 获取或设置基数（如0..n,1..n）
        /// </summary>
        public string Cardinality { get; set; }

        /// <summary>
        /// 获取或设置是否强制更新标志
        /// </summary>
        public bool UpdateConstraint { get; set; }

        /// <summary>
        /// 获取或设置是否强制删除标志
        /// </summary>
        public bool DeleteConstraint { get; set; }

        /// <summary>
        /// 获取或设置父表ID
        /// </summary>
        public string ParentTableID { get; set; }

        /// <summary>
        /// 获取父表对象
        /// </summary>
        public PDTable ParentTable
        {
            get
            {
                return base.Model.GetTable(ParentTableID);
            }
        }

        /// <summary>
        /// 获取或设置子表ID
        /// </summary>
        public string ChildTableID { get; set; }

        /// <summary>
        /// 获取子表对象
        /// </summary>
        public PDTable ChildTable
        {
            get
            {
                return base.Model.GetTable(ChildTableID);
            }
        }

        /// <summary>
        /// 获取或设置父表的键ID
        /// </summary>
        public string ParentKeyID { get; set; }

        /// <summary>
        /// 获取父表的键对象
        /// </summary>
        public PDKey ParentKey
        {
            get
            {
                return base.Model.GetKey(ParentKeyID);
            }
        }

        /// <summary>
        /// 用来查找外键字段，ReferenceJoin对象的ChildColumnID为外键列ID
        /// </summary>
        public IList<ReferenceJoin> JoinList { get; set; }
    }
}
