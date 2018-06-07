using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kalman.PdmParser
{
    [Serializable]
    public class ReferenceJoin
    {
        public string ID { get; set; }

        /// <summary>
        /// 父表列ID
        /// </summary>
        public string ParentColumnID { get; set; }

        /// <summary>
        /// 子表列ID，该列为外键列
        /// </summary>
        public string ChildColumnID { get; set; }
    }
}
