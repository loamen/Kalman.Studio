using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Data; 
using System.Globalization;

namespace Kalman.Data.DbProvider
{
    /// <summary>
    /// 对OracleDataReader对象的包装
    /// </summary>
    public class OracleDataReaderWrapper : MarshalByRefObject, IDataReader, IEnumerable
    {
        private readonly OracleDataReader innerReader;

        internal OracleDataReaderWrapper(OracleDataReader reader)
        {
            this.innerReader = reader;
        }

        /// <summary>
        /// 获取指定索引所在列的值
        /// </summary>
        /// <param name="index">从零开始的索引</param>
        public object this[int index]
        {
            get { return InnerReader[index]; }
        }

        public object this[string name]
        {
            get { return InnerReader[name]; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)InnerReader).GetEnumerator();
        }

        /// <summary>
        /// 释放OracleDataReader对象实例所使用的所有资源
        /// </summary>
        void IDisposable.Dispose()
        {
            InnerReader.Dispose();
        }

        /// <summary>
        /// 关闭OracleDataReader对象
        /// </summary>
        public void Close()
        {
            InnerReader.Close();
        }

        /// <summary>
        /// 返回元数据描述
        /// </summary>
        public DataTable GetSchemaTable()
        {
            return InnerReader.GetSchemaTable();
        }

        /// <summary>
        /// 使OracleDataReader前进到下一个结果
        /// </summary>
        public bool NextResult()
        {
            return InnerReader.NextResult();
        }

        /// <summary>
        /// 使OracleDataReader前进到下一条记录
        /// </summary>
        /// <returns><see langword="true"/> if there are more rows; otherwise, <see langword="false"/>.</returns>
        public bool Read()
        {
            return InnerReader.Read();
        }

        /// <summary>
        /// 获取一个值，该值指示当前行的嵌套深度
        /// </summary>
        public int Depth
        {
            get { return InnerReader.Depth; }
        }

        /// <summary>
        /// 获取OracleDataReader对象是否关闭
        /// </summary>
        public bool IsClosed
        {
            get { return InnerReader.IsClosed; }
        }

        /// <summary>
        /// 获取通过执行SQL语句插入、更新、删除的行数
        /// </summary>
        public int RecordsAffected
        {
            get { return InnerReader.RecordsAffected; }
        }

        /// <summary>
        /// 返回当前行中的列数
        /// </summary>
        public int FieldCount
        {
            get { return InnerReader.FieldCount; }
        }

        public bool GetBoolean(int index)
        {
            return Convert.ToBoolean(InnerReader[index], CultureInfo.InvariantCulture);
        }

        public byte GetByte(int index)
        {
            return Convert.ToByte(InnerReader[index], CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 从指定的列偏移量将字节流作为数组从给定的缓冲区偏移量开始读入缓冲区
        /// </summary>
        /// <param name="ordinal">从零开始的列序号</param>
        /// <param name="dataIndex">行中读取操作开始位置的索引</param>
        /// <param name="buffer">要向其中复制数据的缓冲区</param>
        /// <param name="bufferIndex">开始写操作位置的索引.</param>
        /// <param name="length">要读取的字符数</param>
        /// <returns>读取的实际字符数</returns>
        public long GetBytes(int ordinal, long dataIndex, byte[] buffer, int bufferIndex, int length)
        {
            return InnerReader.GetBytes(ordinal, dataIndex, buffer, bufferIndex, length);
        }

        /// <summary>
        /// 获取指定列字符形式的值
        /// </summary>
        public Char GetChar(int index)
        {
            return InnerReader.GetChar(index);
        }

        /// <summary>
        /// 从指定的列偏移量将字符流作为数组从给定的缓冲区偏移量开始读入缓冲区
        /// </summary>
        /// <param name="index">从零开始的列序号</param>
        /// <param name="dataIndex">行中读取操作开始位置的索引</param>
        /// <param name="buffer">要向其中复制数据的缓冲区</param>
        /// <param name="bufferIndex">开始写操作位置的索引.</param>
        /// <param name="length">要读取的字符数</param>
        /// <returns>读取的实际字符数</returns>
        public long GetChars(int index, long dataIndex, char[] buffer, int bufferIndex, int length)
        {
            return InnerReader.GetChars(index, dataIndex, buffer, bufferIndex, length);
        }

        /// <summary>
        /// 返回被请求的列序号的 System.Data.Common.DbDataReader 对象
        /// </summary>
        public IDataReader GetData(int index)
        {
            return InnerReader.GetData(index);
        }

        /// <summary>
        /// 获取源数据类型的名称
        /// </summary>
        public string GetDataTypeName(int index)
        {
            return InnerReader.GetDataTypeName(index);
        }

        public DateTime GetDateTime(int ordinal_)
        {
            return InnerReader.GetDateTime(ordinal_);
        }

        public decimal GetDecimal(int index)
        {
            return InnerReader.GetDecimal(index);
        }

        public double GetDouble(int index)
        {
            return InnerReader.GetDouble(index);
        }

        /// <summary>
        /// 获取是对象的数据类型的 System.Type
        /// </summary>
        public Type GetFieldType(int index)
        {
            return InnerReader.GetFieldType(index);
        }
  
        public float GetFloat(int index)
        {
            return InnerReader.GetFloat(index);
        }
  
        public Guid GetGuid(int index)
        {
            byte[] guidBuffer = (byte[])InnerReader[index];
            return new Guid(guidBuffer);
        }

        public short GetInt16(int index)
        {
            return Convert.ToInt16(InnerReader[index], CultureInfo.InvariantCulture);
        }

        public int GetInt32(int index)
        {
            return InnerReader.GetInt32(index);
        }

        public long GetInt64(int index)
        {
            return InnerReader.GetInt64(index);
        }

        /// <summary>
        /// 获取指定列的名称
        /// </summary>
        public string GetName(int index)
        {
            return InnerReader.GetName(index);
        }

        /// <summary>
        /// 在给定列名称的情况下获取列序号
        /// </summary>
        public int GetOrdinal(string index)
        {
            return InnerReader.GetOrdinal(index);
        }

        /// <summary>
        /// 获取指定列字符串形式的值
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetString(int index)
        {
            return InnerReader.GetString(index);
        }

        public object GetValue(int index)
        {
            return InnerReader.GetValue(index);
        }

        /// <summary>
        /// 获取当前记录所有集合中的属性字段
        /// </summary>
        public int GetValues(object[] values)
        {
            return InnerReader.GetValues(values);
        }

        public bool IsDBNull(int index)
        {
            return InnerReader.IsDBNull(index);
        }

        /// <summary>
        /// 获取OracleDataReader的包装实例
        /// </summary>
        public OracleDataReader InnerReader
        {
            get { return this.innerReader; }
        }
    }
}
