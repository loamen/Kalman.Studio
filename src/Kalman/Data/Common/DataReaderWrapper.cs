using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Globalization;

namespace Kalman.Data
{
    /// <summary>
    /// DataReader包装器，解决BindableEntity绑定DataReader时，实体属性名称在DataReader中不存在时引发的索引超出范围异常问题
    /// </summary>
    public class DataReaderWrapper : IDisposable
    {
        public static DataReaderWrapper New(IDataReader iReader)
        {
            return new DataReaderWrapper(iReader);
        }

        private IDataReader _InnerReader;
        public IDataReader InnerReader
        {
            get { return _InnerReader; }
        }

        private DataReaderWrapper(IDataReader reader)
        {
            _InnerReader = reader;

            _InnerReadMetaData();
        }

        #region IDataReader 成员

        private int _FieldCount = 0;
        public int FieldCount
        {
            get { return _FieldCount; }
        }

        public void Close()
        {
            InnerReader.Close();
        }

        public bool Read()
        {
            return InnerReader.Read();
        }

        /// <summary>
        /// 如果不存在,则返回Null
        /// </summary>
        public object this[string name]
        {
            get 
            {
                int i = IndexOf(name);

                if (i < 0)
                    return null;
                else
                    return InnerReader[i]; 
            }
        }

        public object this[int i]
        {
            get { return InnerReader[i]; }
        }
        
        #endregion

        #region IDataReader Ex 成员

        private string[] _MetaData;
        internal string[] MetaData
        {
            get
            {               
                return _MetaData;
            }
        }

        private void _InnerReadMetaData()
        {
            int count = InnerReader.FieldCount;
            _MetaData = new string[count];
            _FieldCount = InnerReader.FieldCount;

            for (int i = 0; i < count; i++)
                _MetaData[i] = InnerReader.GetName(i);
        }

        private static CompareInfo compare = CultureInfo.InvariantCulture.CompareInfo;
        public int IndexOf(string name)
        {
            for (int i = 0; i < FieldCount; i++)
            {
                if (compare.Compare(MetaData[i], name, CompareOptions.OrdinalIgnoreCase) == 0)
                    return i;
            }

            return -1;
        }

        public string GetName(int index)
        {
            return InnerReader.GetName(index);
        }

        #endregion


        #region IDisposable 成员

        public void Dispose()
        {
            InnerReader.Dispose();
            _MetaData = null;
        }

        #endregion
    }
}
