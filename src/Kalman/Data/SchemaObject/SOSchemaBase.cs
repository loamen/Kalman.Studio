using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kalman.Data.SchemaObject
{
    /// <summary>
    /// 具有Schema特性的对象基类，Schema对象用来标志数据库对象[如：SchemaName.ObjectName]，如Table、View、StoreProcedure等，每个对象只能属于一个Schema
    /// Schema概念的引入就是为了解决数据库对象太多不好管理的缺点，也就是将对象进行分类，目前只有SqlServer2005以上的版本支持
    /// </summary>
    [Obsolete]
    public abstract class SOSchemaBase : SOBase
    {
        public string SchemaName { get; set; }
    }
}
