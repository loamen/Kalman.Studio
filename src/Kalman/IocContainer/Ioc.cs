using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;


namespace Kalman.IocContainer
{

    /// <summary>
    /// Helper class to get a service object out of the 
    /// service locator.
    /// </summary>
    public class Ioc
    {
        private static IIoc _container;
        private static object _syncRoot = new object();


        /// <summary>
        /// Sets the object container.
        /// </summary>
        /// <param name="container">The container.</param>
        public static void Init(IIoc container)
        {
            lock (_syncRoot)
            {
                _container = container;
            }
        }


        /// <summary>
        /// Adds the object to the container.
        /// </summary>
        /// <param name="objName">Name of the obj.</param>
        /// <param name="obj">The obj.</param>
        public static void AddObject(string objName, object obj)
        {
            _container.AddObject(objName, obj);
        }


        /// <summary>
        /// Get the service and automatically converts to the appropriate type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetObject<T>(string objName) 
        {
            return _container.GetObject<T>(objName);
        }


        /// <summary>
        /// Get the object using just the type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetObject<T>()
        {
            return _container.GetObject<T>();
        }


        /// <summary>
        /// Determine if the container contains the specified type.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public static bool Contains<T>()
        {
            return _container.Contains<T>();
        }
    }
}
