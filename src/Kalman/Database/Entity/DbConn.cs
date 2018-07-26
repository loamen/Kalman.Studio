using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalman.Database
{
    /// <summary>
    /// 数据库连接
    /// </summary>
    public class DbConn
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ConnectionString { get; set; }
        public string ProviderName { get; set; }
        public bool IsActive { get; set; }
    }
}
