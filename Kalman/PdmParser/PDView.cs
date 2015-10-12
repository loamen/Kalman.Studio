using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kalman.PdmParser
{
    [Serializable]
    public class PDView : PDObject
    {
        /// <summary>
        /// 所属包对象
        /// </summary>
        public PDPackage Package { get; set; }
    }
}
