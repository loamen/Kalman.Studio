using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Kalman.PdmParser
{
    /// <summary>
    /// PowerDesigner物理模型对象
    /// </summary>
    [Serializable]
    public class PDModel : PDObject
    {
        public PDDbms DBMS { get; set; }

        IList<PDUser> _UserList = new List<PDUser>();
        public IList<PDUser> UserList { get { return _UserList; } set { _UserList = value; } }
        public void AddUser(PDUser user) { _UserList.Add(user); }

        public PDUser GetUser(string userID)
        {
            foreach (PDUser user in _UserList)
            {
                if (user.ID == userID) return user;
            }
            return null;
        }

        IList<PDPackage> _PackageList = new List<PDPackage>();
        public IList<PDPackage> PackageList { get { return _PackageList; } set { _PackageList = value; } }
        public void AddPackage(PDPackage package) { _PackageList.Add(package); }

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

        /// <summary>
        /// 获取该模型所有的包对象
        /// </summary>
        public IList<PDPackage> AllPackageList
        {
            get
            {
                IList<PDPackage> list = new List<PDPackage>();

                foreach (PDPackage package in _PackageList)
                {
                    list.Add(package);
                    ParseChildPackageList(list, package);
                }

                return list;
            }
        }

        void ParseChildPackageList(IList<PDPackage> list , PDPackage package)
        {
            if (list == null) return;
            foreach (PDPackage item in package.ChildrenList)
            {
                list.Add(item);
                ParseChildPackageList(list, item);
            }
        }

        /// <summary>
        /// 获取该模型所有的表对象
        /// </summary>
        public IList<PDTable> AllTableList
        {
            get
            {
                IList<PDTable> list = new List<PDTable>();

                foreach (PDTable table in _TableList)
                {
                    list.Add(table);
                }

                foreach (PDPackage package in this.AllPackageList)
                {
                    foreach (PDTable table in package.TableList)
                    {
                        list.Add(table);
                    }
                }

                return list;
            }
        }

        public PDTable GetTable(string tableID)
        {
            foreach (PDTable table in this.AllTableList)
            {
                if (table.ID == tableID) return table;
            }
            return null;
        }

        public IList<PDColumn> AllColumnList
        {
            get
            {
                IList<PDColumn> list = new List<PDColumn>();
                foreach (PDTable table in AllTableList)
                {
                    foreach (PDColumn column in table.ColumnList)
                    {
                        list.Add(column);
                    }
                }
                return list;
            }
        }

        public PDColumn GetColumn(string columnID)
        {
            foreach (PDColumn column in AllColumnList)
            {
                if (column.ID == columnID) return column;
            }
            return null;
        }

        public IList<PDKey> AllKeyList
        {
            get
            {
                IList<PDKey> list = new List<PDKey>();
                foreach (PDTable table in AllTableList)
                {
                    foreach (PDKey key in table.KeyList)
                    {
                        list.Add(key);
                    }
                }
                return list;
            }
        }

        public PDKey GetKey(string keyID)
        {
            foreach (PDKey key in AllKeyList)
            {
                if (key.ID == keyID) return key;
            }
            return null;
        }

        public IList<PDIndex> AllIndexList
        {
            get
            {
                IList<PDIndex> list = new List<PDIndex>();
                foreach (PDTable table in AllTableList)
                {
                    foreach (PDIndex index in table.IndexList)
                    {
                        list.Add(index);
                    }
                }
                return list;
            }
        }

        public PDIndex GetIndex(string indexID)
        {
            foreach (PDIndex index in AllIndexList)
            {
                if (index.ID == indexID) return index;
            }
            return null;
        }

        public IList<PDView> AllViewList
        {
            get
            {
                IList<PDView> list = new List<PDView>();

                foreach (PDView view in _ViewList)
                {
                    list.Add(view);
                }

                foreach (PDPackage package in this.AllPackageList)
                {
                    foreach (PDView view in package.ViewList)
                    {
                        list.Add(view);
                    }
                }

                return list;
            }
        }

        public PDView GetView(string viewID)
        {
            foreach (PDView view in this.AllViewList)
            {
                if (view.ID == viewID) return view;
            }
            return null;
        }

        public IList<PDProcedure> AllProcedureList
        {
            get
            {
                IList<PDProcedure> list = new List<PDProcedure>();

                foreach (PDProcedure procedure in _ProcedureList)
                {
                    list.Add(procedure);
                }

                foreach (PDPackage package in this.AllPackageList)
                {
                    foreach (PDProcedure procedure in package.ProcedureList)
                    {
                        list.Add(procedure);
                    }
                }

                return list;
            }
        }

        public PDProcedure GetProcedure(string procedureID)
        {
            foreach (PDProcedure procedure in this.AllProcedureList)
            {
                if (procedure.ID == procedureID) return procedure;
            }
            return null;
        }
    }
}
