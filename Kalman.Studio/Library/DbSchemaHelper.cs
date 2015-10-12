using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kalman.Data;

namespace Kalman.Studio
{
    public class DbSchemaHelper
    {
        public static readonly DbSchemaHelper Instance = new DbSchemaHelper();
        private DbSchemaHelper()
        {
        }

        /// <summary>
        /// 当前DbSchema
        /// </summary>
        public DbSchema CurrentSchema { get; set; }
    }
}
