using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kalman.PdmParser
{
    [Serializable]
    public class PDTable : PDObject
    {
        /// <summary>
        /// 所属包对象
        /// </summary>
        public PDPackage Package { get; set; }

        IList<PDColumn> _ColumnList = new List<PDColumn>();
        public IList<PDColumn> ColumnList { get { return _ColumnList; } set { _ColumnList = value; } }
        public void AddColumn(PDColumn column) { _ColumnList.Add(column); }

        public PDColumn GetColumn(string columnID)
        {
            foreach (PDColumn column in _ColumnList)
            {
                if (column.ID == columnID) return column;
            }
            return null;
        }

        IList<PDKey> _KeyList = new List<PDKey>();
        public IList<PDKey> KeyList { get { return _KeyList; } set { _KeyList = value; } }
        public void AddKey(PDKey key) { _KeyList.Add(key); }

        public PDKey GetKey(string keyID)
        {
            foreach (PDKey key in _KeyList)
            {
                if (key.ID == keyID) return key;
            }
            return null;
        }

        IList<PDIndex> _IndexList = new List<PDIndex>();
        public IList<PDIndex> IndexList { get { return _IndexList; } set { _IndexList = value; } }
        public void AddIndex(PDIndex index) { _IndexList.Add(index); }

        public PDIndex GetIndex(string indexID)
        {
            foreach (PDIndex index in _IndexList)
            {
                if (index.ID == indexID) return index;
            }
            return null;
        }

        /// <summary>
        /// 表所属的用户ID
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// 表所属的用户对象
        /// </summary>
        public PDUser User
        {
            get
            {
                IList<PDUser> userList = base.Model.UserList;
                foreach (PDUser user in userList)
                {
                    if (user.ID == this.UserID) return user;
                }
                return null;
            }
        }

        /// <summary>
        /// 主键所属的KeyID
        /// </summary>
        public string PrimaryKeyID { get; set; }

        /// <summary>
        /// 获取主键列列表
        /// </summary>
        public IList<PDColumn> PKColumnList
        {
            get
            {
                IList<PDColumn> list = new List<PDColumn>();
                PDKey key = GetKey(PrimaryKeyID);

                foreach (string columnID in key.ColumnIDList)
                {
                    PDColumn column = GetColumn(columnID);
                    if (column != null) list.Add(column);
                }

                return list;
            }
        }

        /// <summary>
        /// 聚集对象ID（可以是Key和Index对象），一个表只能有一个聚集对象，注意：有些数据库不支持聚集对象
        /// </summary>
        public string ClusterObjectID { get; set; }

        /// <summary>
        /// 获取聚集对象列列表
        /// </summary>
        public IList<PDColumn> ClusterObjectColumnList
        {
            get
            {
                IList<PDColumn> list = new List<PDColumn>();
                if (string.IsNullOrEmpty(ClusterObjectID)) return list;

                PDKey key = GetKey(ClusterObjectID);
                PDIndex index = GetIndex(ClusterObjectID);

                if (key != null)
                {
                    foreach (string columnID in key.ColumnIDList)
                    {
                        PDColumn column = GetColumn(columnID);
                        if (column != null) list.Add(column);
                    }
                }
                else if(index != null)
                {
                    foreach (string columnID in index.ColumnIDList)
                    {
                        PDColumn column = GetColumn(columnID);
                        if (column != null) list.Add(column);
                    }
                }
                
                return list;
            }
        }
    }
}
