using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;


namespace Kalman.IocContainer
{
    /// <summary>
    /// Service locator interface used for getting any service instance.
    /// </summary>
    public interface IIoc
    {
        /// <summary>
        /// Get a named service  associated with the type.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        T GetObject<T>(string objectName);


        /// <summary>
        /// Get object using just the type.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        T GetObject<T>();


        /// <summary>
        /// Determine if the container contains the specified type.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        bool Contains<T>();


        /// <summary>
        /// Add a named service.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="serviceName"></param>
        /// <param name="obj"></param>
        void AddObject(string objectName, object obj);
    }
}
