using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kalman.PdmParser
{
    [Serializable]
    public class PDKey : PDObject
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
        /// 主键Key
        /// </summary>
        public bool PrimaryKey
        {
            get
            {
                return Table.PrimaryKeyID == this.ID;
            }
        }

        /// <summary>
        /// 聚集对象
        /// </summary>
        public bool Cluster
        {
            get
            {
                return Table.ClusterObjectID == this.ID;
            }
        }

        /// <summary>
        /// 键所拥有的列的ID列表
        /// </summary>
        public IList<string> ColumnIDList { get; set; }

        public IList<PDColumn> ColumnList
        {
            get
            {
                IList<PDColumn> list = new List<PDColumn>();
                foreach (string columnID in ColumnIDList)
                {
                    PDColumn column = base.Model.GetColumn(columnID);
                    if (column != null) list.Add(column);
                }
                return list;
            }
        }
    }
}
