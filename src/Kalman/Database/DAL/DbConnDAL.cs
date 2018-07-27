using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalman.Database
{
    /// <summary>
    /// DbConn DAL
    /// </summary>
    public class DbConnDAL
    {
        static string TABLE_NAME = "DbConns"; //table name

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(DbConn model)
        {
            // Open database (or create if not exits)
            using (var db = new LiteDatabase(NormalConfig.SettingDataFileName))
            {
                // Get DbConnection collection
                var col = db.GetCollection<DbConn>(TABLE_NAME);
                model.IsActive = true;

                var value = col.Insert(model);
                return value.AsInt32;
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(DbConn model)
        {
           return LiteDBHelper<DbConn>.Update(model, TABLE_NAME);
        }

        /// <summary>
        /// Exists
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>

        public bool Exists(string name)
        {
            // Open database (or create if not exits)
            using (var db = new LiteDatabase(NormalConfig.SettingDataFileName))
            {
                // Get DbConnection collection
                var col = db.GetCollection<DbConn>(TABLE_NAME);

                return col.Exists(x => x.Name == name);
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int Delete(string name)
        {
            // Open database (or create if not exits)
            using (var db = new LiteDatabase(NormalConfig.SettingDataFileName))
            {
                // Get DbConnection collection
                var col = db.GetCollection<DbConn>(TABLE_NAME);

                return col.Delete(x => x.Name == name);
            }
        }

        /// <summary>
        /// Query one model
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DbConn FindOne(string name)
        {
            // Open database (or create if not exits)
            using (var db = new LiteDatabase(NormalConfig.SettingDataFileName))
            {
                // Get DbConnection collection
                var col = db.GetCollection<DbConn>(TABLE_NAME);

                return col.FindOne(x => x.Name == name);
            }
        }

        /// <summary>
        /// Find all list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DbConn> FindAll()
        {
            // Open database (or create if not exits)
            using (var db = new LiteDatabase(NormalConfig.SettingDataFileName))
            {
                // Get DbConnection collection
                var col = db.GetCollection<DbConn>(TABLE_NAME);

                return col.FindAll();
            }
        }

        /// <summary>
        /// Count
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            // Open database (or create if not exits)
            using (var db = new LiteDatabase(NormalConfig.SettingDataFileName))
            {
                // Get DbConnection collection
                var col = db.GetCollection<DbConn>(TABLE_NAME);

                return col.Count();
            }
        }

        /// <summary>
        /// Init Database
        /// </summary>
        public static void Init()
        {
            // Open database (or create if not exits)
            using (var db = new LiteDatabase(NormalConfig.SettingDataFileName))
            {
                // Get DbConnection collection
                var col = db.GetCollection<DbConn>(TABLE_NAME);

                if (col.Count() == 0)
                {
                    // Index document using a document property
                    col.EnsureIndex(x => x.Name, true);
                }
            }
        }
    }
}
