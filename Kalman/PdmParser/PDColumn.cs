using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kalman.PdmParser
{
    [Serializable]
    public class PDColumn : PDObject
    {
        /// <summary>
        /// 所属包对象
        /// </summary>
        public PDPackage Package { get; set; }

        /// <summary>
        /// 所属表对象
        /// </summary>
        public PDTable Table { get; set; }

        /// <summary>
        /// 列的数据类型，如"varchar(50)"
        /// </summary>
        public string DataType { get; set; }
        /// <summary>
        /// 列长度
        /// </summary>
        public int Length { get; set; }
        /// <summary>
        /// 精度
        /// </summary>
        public int Precision { get; set; }
        /// <summary>
        /// 是否强制不能为空
        /// </summary>
        public bool Mandatory { get; set; }
        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }
        public bool Identity { get; set; }
        /// <summary>
        /// 是否主键
        /// </summary>
        public bool IsPK
        {
            get
            {
                //判断该列是否属于一个Key
                foreach (PDKey key in this.Table.KeyList)
                {
                    //判断该Key是表的主键Key，并且该列是主键Key的列
                    if (key.Table.PrimaryKeyID == key.ID&& key.ColumnIDList != null && key.ColumnIDList.Contains(this.ID)) return true;
                }
                return false;
            }
        }
        /// <summary>
        /// 是否外键
        /// </summary>
        public bool IsFK
        {
            get
            {
                foreach (PDReference reference in base.Model.ReferenceList)
                {
                    if (reference.JoinList == null) continue;
                    foreach (ReferenceJoin join in reference.JoinList)
                    {
                        if (join.ChildColumnID == this.ID) return true;
                    }
                }
                return false;
            }
        }
    }
}
