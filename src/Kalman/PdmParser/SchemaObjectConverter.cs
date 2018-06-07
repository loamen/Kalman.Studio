using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kalman.Data.SchemaObject;
using System.Data;
using Kalman.Utilities;

namespace Kalman.PdmParser
{
    /// <summary>
    /// 将PDObject对象转换成SchemaObject对象，方便重用基于SchemaObject代码生成引擎
    /// PDM模型的代码生成主要是针对表对象，其他对象暂时不予支持
    /// </summary>
    public sealed class SOConverter
    {
        public static SODatabase ToSODatabase(PDPackage package)
        {
            if (package == null) return null;

            SODatabase db = new SODatabase();

            db.Name = package.Code;
            db.Comment = string.IsNullOrEmpty(package.Comment) ? package.Name : package.Comment;
            db.TableList = new List<SOTable>();
            foreach (PDTable item in package.TableList)
            {
                db.TableList.Add(ToSOTable(item));
            }
            db.ViewList = new List<SOView>();
            //foreach (PDView item in package.ViewList)
            //{
            //    db.ViewList.Add(ToSOView(item));
            //}
            db.CommandList = new List<SOCommand>();
            //foreach (PDProcedure item in package.ProcedureList)
            //{
            //    db.CommandList.Add(ToSOCommand(item));   
            //}

            return db;
        }

        public static SODatabase ToSODatabase(PDModel model)
        {
            if (model == null) return null;

            SODatabase db = new SODatabase();

            db.Name = model.Code;
            db.Comment = string.IsNullOrEmpty(model.Comment) ? model.Name : model.Comment;
            db.TableList = new List<SOTable>();
            foreach (PDTable item in model.AllTableList)
            {
                db.TableList.Add(ToSOTable(item));
            }
            db.ViewList = new List<SOView>();
            //foreach (PDView item in model.AllViewList)
            //{
            //    db.ViewList.Add(ToSOView(item));
            //}
            db.CommandList = new List<SOCommand>();
            //foreach (PDProcedure item in model.AllProcedureList)
            //{
            //    db.CommandList.Add(ToSOCommand(item));
            //}

            return db;
        }

        public static SOTable ToSOTable(PDTable table)
        {
            SOTable t = new SOTable();

            t.Name = table.Code;
            t.Comment = string.IsNullOrEmpty(table.Comment) ? table.Name : table.Comment;
            t.ColumnList = new List<SOColumn>();
            foreach (PDColumn item in table.ColumnList)
            {
                t.ColumnList.Add(ToSOColumn(item));
            }
            t.IndexList = new List<SOIndex>();

            return t;
        }

        [Obsolete("暂时不实现该对象的转换")]
        public static SOView ToSOView(PDView view)
        {
            SOView v = new SOView();
            return v;
        }

        [Obsolete("暂时不实现该对象的转换")]
        public static SOCommand ToSOCommand(PDProcedure sp)
        {
            SOCommand cmd = new SOCommand();
            return cmd;
        }

        public static SOColumn ToSOColumn(PDColumn column)
        {
            SOColumn c = new SOColumn();

            c.Name = column.Code;
            c.Comment = string.IsNullOrEmpty(column.Comment) ? column.Name : column.Comment;
            c.PrimaryKey = column.IsPK;
            c.ForeignKey = column.IsFK;
            c.Identify = column.Identity;
            c.Length = column.Length;
            c.NativeType = column.DataType.Split('(')[0];
            c.Nullable = !column.Mandatory;
            c.DefaultValue = column.DefaultValue;
            c.Precision = column.Length;
            c.Scale = column.Precision; //pdm的精度对应数据库的小数位数
            c.DataType = PDMDataTypeToDbType(column);

            return c;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbms"></param>
        /// <returns></returns>
        public static DbType PDMDataTypeToDbType(PDColumn column)
        {
            PDDbms dbms = column.Model.DBMS;
            string dataType = column.DataType;

            ///todo:将PDM模型中不同关系数据库的数据类型转换成System.Data.DbType
            if (dbms.Code.StartsWith("MSSQLSRV")) return TypeUtil.SqlServerDataType2DbType(column.DataType);
            if (dbms.Code.StartsWith("MYSQL")) return TypeUtil.MySqlDataType2DbType(column.DataType);


            return DbType.String;
        }
    }
}
