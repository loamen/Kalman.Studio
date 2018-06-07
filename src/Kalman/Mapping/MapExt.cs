using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;

namespace Kalman.Mapping
{
    /// <summary>
    /// EmitMapper扩展类
    /// </summary>
	public static class MapExt
	{
        public static string ToCSV<T>(this IEnumerable<T> collection, string delim)
        {
			if (collection == null)
			{
				return "";
			}

            StringBuilder result = new StringBuilder();
            foreach (T value in collection)
            {
                result.Append(value);
                result.Append(delim);
            }
            if (result.Length > 0)
            {
                result.Length -= delim.Length;
            }
            return result.ToString();
        }

		public static T ToObject<T>(this DbDataReader reader)
		{
			return reader.ToObject<T>(null, null, null);
		}

		public static T ToObject<T>(this DbDataReader reader, string readerName)
		{
			return reader.ToObject<T>(readerName, null, null);
		}

		public static T ToObject<T>(this DbDataReader reader, string[] excludeFields)
		{
			return reader.ToObject<T>(null, excludeFields, null);
		}

		public static T ToObject<T>(this DbDataReader reader, string readerName, string[] excludeFields, ObjectsChangeTracker changeTracker)
		{
            ///这里将数据库表对应的字段串在一起赋值给readerName变量，方便后面判断非数据库字段
            if (string.IsNullOrEmpty(readerName))
            {
                var mappingKeyBuilder = new StringBuilder();
                for (int i = 0; i < reader.FieldCount; ++i)
                {
                    mappingKeyBuilder.Append(reader.GetName(i));
                    mappingKeyBuilder.Append('$');
                }
                readerName = mappingKeyBuilder.ToString().ToLower();
            }

			T result = new DataReaderToObjectMapper<T>(readerName, null, excludeFields).MapUsingState(reader, reader);
			if (changeTracker != null)
			{
				changeTracker.RegisterObject(result);
			}
			return result;
		}

		public static IEnumerable<T> ToObjects<T>(this DbDataReader reader)
		{
			return reader.ToObjects<T>(null, null, null);
		}

		public static IEnumerable<T> ToObjects<T>(this DbDataReader reader, string readerName)
		{
			return reader.ToObjects<T>(readerName, null, null);
		}

		public static IEnumerable<T> ToObjects<T>(this DbDataReader reader, string[] excludeFields)
		{
			return reader.ToObjects<T>(null, excludeFields, null);
		}

		public static IEnumerable<T> ToObjects<T>(this DbDataReader reader, string readerName, string[] excludeFields, ObjectsChangeTracker changeTracker)
		{
			if (string.IsNullOrEmpty(readerName))
			{
				var mappingKeyBuilder = new StringBuilder();
				for (int i = 0; i < reader.FieldCount; ++i)
				{
					mappingKeyBuilder.Append(reader.GetName(i));
					mappingKeyBuilder.Append('$');
				}
				readerName = mappingKeyBuilder.ToString().ToLower();
			}
			return new DataReaderToObjectMapper<T>(readerName, null, excludeFields).ReadCollection(reader, changeTracker);
		}

	}
}
