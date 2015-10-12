using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Kalman.IocContainer
{
        /// <summary>
        /// Simple in Memory container to use for Unit Testing.
        /// </summary>
        public class IocContainerInMemory : IIoc
        {
            private Hashtable _objects;

            /// <summary>
            /// The instance name given to the service 
            /// added as a default service.
            /// </summary>
            public const string DefaultServiceName = "default";

            /// <summary>
            /// Make this class a singleton.
            /// </summary>
            public IocContainerInMemory()
            {
                _objects = new Hashtable();
            }

            #region IIocContainer Members
            /// <summary>
            /// Adds a service to the service to the locator.
            /// Supports multiple ( instances ) of a specific type.
            /// This is to support different implementations of specific interface
            /// for example.
            /// </summary>
            /// <param name="t"></param>
            /// <param name="instanceName"><see cref="ServiceNames"/></param>
            /// <param name="obj"></param>
            public void AddObject(string key, object obj)
            {
                _objects.Add(key, obj);
            }

            /// <summary>
            /// Gets a specific service with name provided.
            /// </summary>
            /// <param name="t"></param>
            /// <param name="serviceName"><see cref="ServiceNames"/></param>
            /// <returns></returns>
            public T GetObject<T>(string serviceName)
            {
                if (!_objects.ContainsKey(serviceName))
                {
                    throw new ArgumentException("object : " + serviceName + " does not exist.");
                }
                object obj = _objects[serviceName];                
                return (T)obj;
            }

            /// <summary>
            /// Get object using just the type.
            /// </summary>
            /// <param name="t"></param>
            /// <param name="serviceName"></param>
            /// <returns></returns>
            public T GetObject<T>()
            {
                return GetObject<T>(typeof(T).FullName);
            }

            /// <summary>
            /// Determine if the container contains the specified type.
            /// </summary>
            /// <param name="t"></param>
            /// <param name="serviceName"></param>
            /// <returns></returns>
            public bool Contains<T>()
            {
                return _objects.ContainsKey(typeof(T).FullName);
            }
            #endregion
        }
}
