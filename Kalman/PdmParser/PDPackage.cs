using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kalman.PdmParser
{
    [Serializable]
    public class PDPackage : PDObject
    {
        /// <summary>
        /// 父包对象
        /// </summary>
        public PDPackage Parent { get; set; }

        IList<PDPackage> _ChildrenList = new List<PDPackage>();
        /// <summary>
        /// 子包列表
        /// </summary>
        public IList<PDPackage> ChildrenList { get { return _ChildrenList; } set { _ChildrenList = value; } }
        public void AddPackage(PDPackage package) { _ChildrenList.Add(package); }

        IList<PDTable> _TableList = new List<PDTable>();
        public IList<PDTable> TableList { get { return _TableList; } set { _TableList = value; } }
        public void AddTable(PDTable table) { _TableList.Add(table); }

        IList<PDView> _ViewList = new List<PDView>();
        public IList<PDView> ViewList { get { return _ViewList; } set { _ViewList = value; } }
        public void AddView(PDView view) { _ViewList.Add(view); }

        IList<PDProcedure> _ProcedureList = new List<PDProcedure>();
        public IList<PDProcedure> ProcedureList { get { return _ProcedureList; } set { _ProcedureList = value; } }
        public void AddProcedure(PDProcedure procedure) { _ProcedureList.Add(procedure); }

        IList<PDReference> _ReferenceList = new List<PDReference>();
        public IList<PDReference> ReferenceList { get { return _ReferenceList; } set { _ReferenceList = value; } }
        public void AddReference(PDReference Reference) { _ReferenceList.Add(Reference); }
    }
}
