using System;
using System.Collections.Generic;
using System.Linq;
using EmitMapper;
using EmitMapper.Mappers;
using System.Data.Common;
using System.Reflection;
using EmitMapper.Utils;
using EmitMapper.MappingConfiguration.MappingOperations;
using EmitMapper.MappingConfiguration;
using System.Text;

namespace Kalman.Mapping
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
	public class DataReaderToObjectMapper<T> : ObjectsMapper<DbDataReader, T>
	{
		class DbReaderMappingConfig : IMappingConfigurator
		{
			class ReaderValuesExtrator<T>
			{
				public Func<int, DbDataReader, T> valueExtractor;
				public int fieldNum;
				public string fieldName;
				
				public ReaderValuesExtrator(string fieldName, Func<int, DbDataReader, T> valueExtractor)
				{
					fieldNum = -1;
					this.fieldName = fieldName;
					this.valueExtractor = valueExtractor;
				}

				public Delegate ExtrationDelegate
				{
					get
					{
						return (ValueGetter<T>)
							(
								(value, state) =>
								{
									return ValueToWrite<T>.ReturnValue(GetValue((DbDataReader)state));
								}
							);
					}
				}

				private T GetValue(DbDataReader reader)
				{
					if (fieldNum == -1)
					{
						fieldNum = reader.GetOrdinal(fieldName);
					}
					return reader.IsDBNull(fieldNum) ? default(T) : valueExtractor(fieldNum, reader);
				}
			}

			IEnumerable<string> _skipFields;
			string _mappingKey;

			public DbReaderMappingConfig(IEnumerable<string> skipFields, string mappingKey)
			{
				_skipFields = skipFields == null ? new List<string>() : skipFields;
				_mappingKey = mappingKey;
			}

			public IRootMappingOperation GetRootMappingOperation(Type from, Type to)
			{
				return null;
			}

			private Delegate GetValuesGetter(int ind, MemberInfo m)
			{
				var memberType = ReflectionUtils.GetMemberType(m);

                //需要判断非数据库字段，否则会抛异常
                if (_mappingKey != null && _mappingKey.IndexOf(string.Concat(m.Name, "$").ToLower()) != -1)
                {
                    if (memberType == typeof(string))
                    {
                        return new ReaderValuesExtrator<string>(m.Name, (idx, reader) => reader.IsDBNull(idx) ? null : reader.GetString(idx)).ExtrationDelegate;
                    }
                    else if (memberType == typeof(bool))
                    {
                        return new ReaderValuesExtrator<bool>(m.Name, (idx, reader) => reader.GetBoolean(idx)).ExtrationDelegate;
                    }
                    else if (memberType == typeof(bool?))
                    {
                        return new ReaderValuesExtrator<bool?>(m.Name, (idx, reader) => reader.GetBoolean(idx)).ExtrationDelegate;
                    }
                    else if (memberType == typeof(Int16))
                    {
                        return new ReaderValuesExtrator<Int16>(m.Name, (idx, reader) => reader.GetInt16(idx)).ExtrationDelegate;
                    }
                    else if (memberType == typeof(Int16?))
                    {
                        return new ReaderValuesExtrator<Int16?>(m.Name, (idx, reader) => reader.GetInt16(idx)).ExtrationDelegate;
                    }
                    else if (memberType == typeof(Int32))
                    {
                        return new ReaderValuesExtrator<Int32>(m.Name, (idx, reader) => reader.GetInt32(idx)).ExtrationDelegate;
                    }
                    else if (memberType == typeof(Int32?))
                    {
                        return new ReaderValuesExtrator<Int32?>(m.Name, (idx, reader) => reader.GetInt32(idx)).ExtrationDelegate;
                    }
                    else if (memberType == typeof(Int64))
                    {
                        return new ReaderValuesExtrator<Int64>(m.Name, (idx, reader) => reader.GetInt64(idx)).ExtrationDelegate;
                    }
                    else if (memberType == typeof(Int64?))
                    {
                        return new ReaderValuesExtrator<Int64?>(m.Name, (idx, reader) => reader.GetInt64(idx)).ExtrationDelegate;
                    }
                    else if (memberType == typeof(byte))
                    {
                        return new ReaderValuesExtrator<byte>(m.Name, (idx, reader) => reader.GetByte(idx)).ExtrationDelegate;
                    }
                    else if (memberType == typeof(byte?))
                    {
                        return new ReaderValuesExtrator<byte?>(m.Name, (idx, reader) => reader.GetByte(idx)).ExtrationDelegate;
                    }
                    else if (memberType == typeof(char))
                    {
                        return new ReaderValuesExtrator<char>(m.Name, (idx, reader) => reader.GetChar(idx)).ExtrationDelegate;
                    }
                    else if (memberType == typeof(char?))
                    {
                        return new ReaderValuesExtrator<char?>(m.Name, (idx, reader) => reader.GetChar(idx)).ExtrationDelegate;
                    }
                    else if (memberType == typeof(DateTime))
                    {
                        return new ReaderValuesExtrator<DateTime>(m.Name, (idx, reader) => reader.GetDateTime(idx)).ExtrationDelegate;
                    }
                    else if (memberType == typeof(DateTime?))
                    {
                        return new ReaderValuesExtrator<DateTime?>(m.Name, (idx, reader) => reader.GetDateTime(idx)).ExtrationDelegate;
                    }
                    else if (memberType == typeof(decimal))
                    {
                        return new ReaderValuesExtrator<decimal>(m.Name, (idx, reader) => reader.GetDecimal(idx)).ExtrationDelegate;
                    }
                    else if (memberType == typeof(decimal?))
                    {
                        return new ReaderValuesExtrator<decimal?>(m.Name, (idx, reader) => reader.GetDecimal(idx)).ExtrationDelegate;
                    }
                    else if (memberType == typeof(double))
                    {
                        return new ReaderValuesExtrator<double>(m.Name, (idx, reader) => reader.GetDouble(idx)).ExtrationDelegate;
                    }
                    else if (memberType == typeof(double?))
                    {
                        return new ReaderValuesExtrator<double?>(m.Name, (idx, reader) => reader.GetDouble(idx)).ExtrationDelegate;
                    }
                    else if (memberType == typeof(float))
                    {
                        return new ReaderValuesExtrator<float>(m.Name, (idx, reader) => reader.GetFloat(idx)).ExtrationDelegate;
                    }
                    else if (memberType == typeof(float?))
                    {
                        return new ReaderValuesExtrator<float?>(m.Name, (idx, reader) => reader.GetFloat(idx)).ExtrationDelegate;
                    }
                    else if (memberType == typeof(Guid))
                    {
                        return new ReaderValuesExtrator<Guid>(m.Name, (idx, reader) => reader.GetGuid(idx)).ExtrationDelegate;
                    }
                    else if (memberType == typeof(Guid?))
                    {
                        return new ReaderValuesExtrator<Guid?>(m.Name, (idx, reader) => reader.GetGuid(idx)).ExtrationDelegate;
                    }
                }

				Func<object, object> converter = StaticConvertersManager.DefaultInstance.GetStaticConverterFunc(typeof(object), memberType);
				if (converter == null)
				{
					throw new EmitMapperException("Could not convert an object to " + memberType.ToString());
				}
				int fieldNum = -1;
				string fieldName = m.Name;
                Type fieldType = m.GetType();
				return
					(ValueGetter<object>)
					(
						(value, state) =>
						{
							var reader = ((DbDataReader)state);
							object result = null;

                            //需要判断非数据库字段，否则会抛异常
                            if (_mappingKey != null && _mappingKey.IndexOf(string.Concat(fieldName, "$").ToLower()) == -1)
                            {
                                PropertyInfo p = (PropertyInfo)m;

                                if (p.PropertyType.IsValueType)
                                {
                                    var blank = Activator.CreateInstance(p.PropertyType);
                                    return ValueToWrite<object>.ReturnValue(blank);
                                }
                                else
                                {
                                    return ValueToWrite<object>.ReturnValue(null);
                                }
                            }

                            if (_mappingKey != null)
							{
								if (fieldNum == -1)
								{
									fieldNum = reader.GetOrdinal(fieldName);
								}
								result = reader[fieldNum];
							}
							else
							{
								result = reader[fieldName];
							}

							if (result is DBNull)
							{
								return ValueToWrite<object>.ReturnValue(null);
							}
							return ValueToWrite<object>.ReturnValue(converter(result));
						}
					)
					;
			}

			public IMappingOperation[] GetMappingOperations(Type from, Type to)
			{
				return ReflectionUtils
					.GetPublicFieldsAndProperties(to)
					.Where(
						m => m.MemberType == MemberTypes.Field || 
							m.MemberType == MemberTypes.Property && ((PropertyInfo)m).GetSetMethod() != null
					)
					.Where(m => !_skipFields.Select(sf => sf.ToUpper()).Contains(m.Name.ToUpper()))
					.Select(
						(m, ind) =>
							new DestWriteOperation()
							{
								Destination = new MemberDescriptor(new[] { m }),
								Getter = GetValuesGetter(ind, m)
							}
					)
					.ToArray();
			}

			public string GetConfigurationName()
			{
				if (_mappingKey != null)
				{
					return "dbreader_" + _mappingKey;
				}
				else
				{
					return "dbreader_";
				}
			}

			public StaticConvertersManager GetStaticConvertersManager()
			{
				return null;
			}
		}

		public DataReaderToObjectMapper(
			string mappingKey,
			ObjectMapperManager mapperManager,
			IEnumerable<string> skipFields)
			: base(GetMapperImpl(mappingKey, mapperManager, skipFields))
		{
		}

		public DataReaderToObjectMapper(ObjectMapperManager mapperManager)
			: this(null, mapperManager, null)
		{
		}

		public DataReaderToObjectMapper()
			: this(null, null, null)
		{
		}

		public DataReaderToObjectMapper(IEnumerable<string> skipFields)
			: this(null, null, skipFields)
		{
		}

		public T ReadSingle(DbDataReader reader)
		{
			return ReadSingle(reader, null);
		}

		public T ReadSingle(DbDataReader reader, ObjectsChangeTracker changeTracker)
		{
			T result = reader.Read() ? MapUsingState(reader, reader) : default(T);
			if (changeTracker != null)
			{
				changeTracker.RegisterObject(result);
			}
			return result;
		}

		public IEnumerable<T> ReadCollection(DbDataReader reader)
		{
			return ReadCollection(reader, null);
		}

		public IEnumerable<T> ReadCollection(DbDataReader reader, ObjectsChangeTracker changeTracker)
		{
			while (reader.Read())
			{
				T result = MapUsingState(reader, reader);
				if (changeTracker != null)
				{
					changeTracker.RegisterObject(result);
				}
				yield return result;
			}
			reader.Close();
		}

		private static ObjectsMapperBaseImpl GetMapperImpl(
			string mappingKey,
			ObjectMapperManager mapperManager,
			IEnumerable<string> skipFields)
		{
			IMappingConfigurator config = new DbReaderMappingConfig(skipFields, mappingKey);

			if (mapperManager != null)
			{
				return mapperManager.GetMapperImpl(
					typeof(DbDataReader),
					typeof(T),
					config);
			}
			else
			{
				return ObjectMapperManager.DefaultInstance.GetMapperImpl(
					typeof(DbDataReader),
					typeof(T),
					config);
			}
		}
	}
}
