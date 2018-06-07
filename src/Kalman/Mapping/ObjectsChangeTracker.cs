using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmitMapper;
using EmitMapper.MappingConfiguration;
using EmitMapper.Utils;
using EmitMapper.MappingConfiguration.MappingOperations;

namespace Kalman.Mapping
{
	public class ObjectsChangeTracker
	{
		class MappingConfiguration : IMappingConfigurator
		{
			public IMappingOperation[] GetMappingOperations(Type from, Type to)
			{
				return ReflectionUtils
					.GetPublicFieldsAndProperties(from)
					.Select(m =>
						new SrcReadOperation
						{
							Source = new MemberDescriptor(m),
							Setter =
								(obj, value, state) =>
									(state as TrackingMembersList).TrackingMembers.Add(
										new TrackingMember { name = m.Name, value = value }
									)
						}
					)
					.ToArray();
			}

			public IRootMappingOperation GetRootMappingOperation(Type from, Type to)
			{
				return null;
			}

			public string GetConfigurationName()
			{
				return "ObjectsTracker";
			}

			public StaticConvertersManager GetStaticConvertersManager()
			{
				return null;
			}
		}

		internal class TrackingMembersList
		{
			public List<TrackingMember> TrackingMembers = new List<TrackingMember>();
		}

		public struct TrackingMember
		{
			public string name;
			public object value;
		}

		Dictionary<object, List<TrackingMember>> _trackingObjects = new Dictionary<object, List<TrackingMember>>();
		ObjectMapperManager _mapManager;

		public ObjectsChangeTracker()
		{
			_mapManager = ObjectMapperManager.DefaultInstance;
		}

		public ObjectsChangeTracker(ObjectMapperManager MapManager)
		{
			_mapManager = MapManager;
		}

		public void RegisterObject(object Obj)
		{
			var type = Obj.GetType();
			_trackingObjects[Obj] = GetObjectMembers(Obj);
		}

		public TrackingMember[] GetChanges(object Obj)
		{
			List<TrackingMember> originalValues;
			if (!_trackingObjects.TryGetValue(Obj, out originalValues))
			{
				return null;
			}
			var currentValues = GetObjectMembers(Obj);
			return currentValues
				.Where(
					(current, idx) =>
					{
						var original = originalValues[idx];
						return
							((original.value == null) != (current.value == null))
							||
							(original.value != null && !original.value.Equals(current.value));
					}
				)
				.ToArray();
		}

		private List<TrackingMember> GetObjectMembers(object Obj)
		{
			var type = Obj.GetType();
			var fields = new TrackingMembersList();
			_mapManager.GetMapperImpl(
				type,
				null,
				new MappingConfiguration()
			).Map(Obj, null, fields);

			return fields.TrackingMembers;
		}
	}
}
