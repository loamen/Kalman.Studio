using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalman.Database
{
    public class DbConnDAL
    {
        static string TABLE_NAME = "DbConns"; //table name

        public int Insert(DbConn model)
        {
            // Open database (or create if not exits)
            using (var db = new LiteDatabase(NormalConfig.SettingDataFileName))
            {
                // Get DbConnection collection
                var col = db.GetCollection<DbConn>(TABLE_NAME);
                model.IsActive = true;

                // Insert new DbConnection document (Id will be auto-incremented)
                col.Insert(model);

                // Index document using a document property
                col.EnsureIndex(x => x.Name, true);

                var value = col.Insert(model);
                return value.AsInt32;
            }
        }

        public bool Update(DbConn model)
        {
           return LiteDBHelper<DbConn>.Update(model, TABLE_NAME);
        }

        public bool Exists(string name)
        {
            // Open database (or create if not exits)
            using (var db = new LiteDatabase(NormalConfig.SettingDataFileName))
            {
                // Get DbConnection collection
                var liteCollection = db.GetCollection<DbConn>(TABLE_NAME);

                return liteCollection.Exists(x => x.Name == name);
            }
        }

        public int Delete(string name)
        {
            // Open database (or create if not exits)
            using (var db = new LiteDatabase(NormalConfig.SettingDataFileName))
            {
                // Get DbConnection collection
                var liteCollection = db.GetCollection<DbConn>(TABLE_NAME);

                return liteCollection.Delete(x => x.Name == name);
            }
        }

        public DbConn FindOne(string name)
        {
            // Open database (or create if not exits)
            using (var db = new LiteDatabase(NormalConfig.SettingDataFileName))
            {
                // Get DbConnection collection
                var liteCollection = db.GetCollection<DbConn>(TABLE_NAME);

                return liteCollection.FindOne(x => x.Name == name);
            }
        }

        public IEnumerable<DbConn> FindAll()
        {
            // Open database (or create if not exits)
            using (var db = new LiteDatabase(NormalConfig.SettingDataFileName))
            {
                // Get DbConnection collection
                var liteCollection = db.GetCollection<DbConn>(TABLE_NAME);

                return liteCollection.FindAll();
            }
        }

        public int Count()
        {
            // Open database (or create if not exits)
            using (var db = new LiteDatabase(NormalConfig.SettingDataFileName))
            {
                // Get DbConnection collection
                var liteCollection = db.GetCollection<DbConn>(TABLE_NAME);

                return liteCollection.Count();
            }
        }
    }
}
