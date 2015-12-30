using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kalman.Data.SchemaObject
{
    /// <summary>
    /// 数据库架构对象
    /// </summary>
    [Serializable]
    public class SODatabase : SOBase
    {
        [NonSerialized]//避免生成代码出现序列化错误
        IDbSchema _Parent;

        /// <summary>
        /// 获取或设置父对象
        /// </summary>
        public IDbSchema Parent
        {
            get { return _Parent; }
            set { _Parent = value; }
        }

        bool _IsSystemDatabase = false;
        /// <summary>
        /// 是否是系统数据库
        /// </summary>
        public bool IsSystemDatabase
        {
            get { return _IsSystemDatabase; }
            set { _IsSystemDatabase = value; }
        }

        /// <summary>
        /// 获取所属数据库对象
        /// </summary>
        public override SODatabase Database { get { return this; } }

        List<SOTable> _TableList;
        /// <summary>
        /// 获取或设置表列表
        /// </summary>
        //public List<SOTable> TableList { get { return Parent == null ? null : Parent.GetTableList(this); } }
        public List<SOTable> TableList
        {
            get
            {
                if (_TableList == null && Parent != null)
                {
                    _TableList = Parent == null ? null : Parent.GetTableList(this);
                }
                return _TableList;
            }
            set
            {
                _TableList = value;
            }
        }

        List<SOView> _ViewList;
        /// <summary>
        /// 获取或设置视图列表
        /// </summary>
        //public List<SOView> ViewList { get { return Parent == null ? null : Parent.GetViewList(this); } }
        public List<SOView> ViewList
        {
            get
            {
                if (_ViewList == null && Parent != null)
                {
                    _ViewList = Parent == null ? null : Parent.GetViewList(this);
                }
                return _ViewList;
            }
            set
            {
                _ViewList = value;
            }
        }

        List<SOCommand> _CommandList;
        /// <summary>
        /// 获取或设置存储过程列表
        /// </summary>
        //public List<SOCommand> CommandList { get { return Parent == null ? null : Parent.GetCommandList(this); } }
        public List<SOCommand> CommandList
        {
            get
            {
                if (_CommandList == null && Parent != null)
                {
                    _CommandList = Parent == null ? null : Parent.GetCommandList(this);
                }
                return _CommandList;
            }
            set
            {
                _CommandList = value;
            }
        }

        public SOTable GetTable(string tableName)
        {
            List<SOTable> list = this.TableList;
            SOTable table = null;

            foreach (SOTable item in list)
            {
                if (item.Name == tableName)
                {
                    table = item;
                    break;
                }
            }

            return table;
        }

        public SOView GetView(string viewName)
        {
            List<SOView> list = this.ViewList;
            SOView view = null;

            foreach (SOView item in list)
            {
                if (item.Name == viewName)
                {
                    view = item;
                    break;
                }
            }

            return view;
        }

        public SOCommand GetSP(string spName)
        {
            List<SOCommand> list = this.CommandList;
            SOCommand sp = null;

            foreach (SOCommand item in list)
            {
                if (item.Name == spName)
                {
                    sp = item;
                    break;
                }
            }

            return sp;
        }

    }
}
