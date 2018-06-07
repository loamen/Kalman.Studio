using System.Data;
using System.Data.Common;
using System;

namespace Kalman.Data
{
    /// <summary>
    /// <para>
    /// Provides parameter caching services for dynamic parameter discovery of stored procedures.
    /// Eliminates the round-trip to the database to derive the parameters and types when a command
    /// is executed more than once.
    /// </para>
    /// </summary>
    public class ParameterCache
    {
        private CachingMechanism cache = new CachingMechanism();

        /// <summary>
        /// <para>
        /// Populates the parameter collection for a command wrapper from the cache 
        /// or performs a round-trip to the database to query the parameters.
        /// </para>
        /// </summary>
        /// <param name="command">
        /// <para>The command to add the parameters.</para>
        /// </param>
        /// <param name="database">
        /// <para>The database to use to set the parameters.</para>
        /// </param>
		public void SetParameters(DbCommand command, Database database)
        {
			if (command == null) throw new ArgumentNullException("command");
			if (database == null) throw new ArgumentNullException("database");


			if (AlreadyCached(command, database))
            {
				AddParametersFromCache(command, database);
            }
            else
            {
				database.DiscoverParameters(command);
                IDataParameter[] copyOfParameters = CreateParameterCopy(command);

				this.cache.AddParameterSetToCache(database.ConnectionString, command, copyOfParameters);
            }
        }

        /// <summary>
		/// <para>Empties the parameter cache.</para>
        /// </summary>
        protected internal void Clear()
        {
            this.cache.Clear();
        }       

        /// <summary>
        /// <para>Adds parameters to a command using the cache.</para>
        /// </summary>
        /// <param name="command">
        /// <para>The command to add the parameters.</para>
		/// </param>
		/// <param name="database">The database to use.</param>
		protected virtual void AddParametersFromCache(DbCommand command, Database database)
        {
			IDataParameter[] parameters = this.cache.GetCachedParameterSet(database.ConnectionString, command);

            foreach (IDataParameter p in parameters)
            {
				command.Parameters.Add(p);
            }
        }

		/// <summary>
		/// <para>Checks to see if a cache entry exists for a specific command on a specific connection</para>
		/// </summary>
		/// <param name="command">
		/// <para>The command to check.</para>
		/// </param>
		/// <param name="database">The database to check.</param>
		/// <returns>True if the parameters are already cached for the provided command, false otherwise</returns>
		private bool AlreadyCached(IDbCommand command, Database database)
		{
			return this.cache.IsParameterSetCached(database.ConnectionString, command);
		}

		private static IDataParameter[] CreateParameterCopy(DbCommand command)
        {
			IDataParameterCollection parameters = command.Parameters;
            IDataParameter[] parameterArray = new IDataParameter[parameters.Count];
            parameters.CopyTo(parameterArray, 0);

            return CachingMechanism.CloneParameters(parameterArray);
        }
    }
}
