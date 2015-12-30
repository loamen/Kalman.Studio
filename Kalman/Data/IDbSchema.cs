using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kalman.Data.SchemaObject;
using System.Data;

namespace Kalman.Data
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDbSchema
    {
        /// <summary>
        /// 获取或设置数据提供者实例
        /// </summary>
        Database DbProvider { get; set; }
        
        /// <summary>
        /// 获取数据库列表
        /// </summary>
        /// <returns></returns>
        List<SODatabase> GetDatabaseList();

        /// <summary>
        /// 获取表列表
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        List<SOTable> GetTableList(SODatabase db);

        /// <summary>
        /// 获取表所拥有的列列表
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        List<SOColumn> GetTableColumnList(SOTable table);

        /// <summary>
        /// 获取表所拥有的索引列表
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        List<SOIndex> GetTableIndexList(SOTable table);

        /// <summary>
        /// 获取视图列表
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        List<SOView> GetViewList(SODatabase db);

        /// <summary>
        /// 获取视图所拥有的列列表
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        List<SOColumn> GetViewColumnList(SOView view);

        /// <summary>
        /// 获取视图所拥有的索引列表
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        List<SOIndex> GetViewIndexList(SOView view);

        /// <summary>
        /// 获取存储过程列表
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        List<SOCommand> GetCommandList(SODatabase db);

        /// <summary>
        /// 获取存储过程参数列表
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        List<SOCommandParameter> GetCommandParameterList(SOCommand command);

        /// <summary>
        /// 获取表的Sql脚本
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        string GetTableSqlText(SOTable table);

        /// <summary>
        /// 获取视图的Sql脚本
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        string GetViewSqlText(SOView view);

        /// <summary>
        /// 获取存储过程的Sql脚本
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        string GetCommandSqlText(SOCommand command);

        /// <summary>
        /// 基于DbConnection对象的元数据对象获取方法
        /// </summary>
        /// <param name="metaDataCollectionName">元数据集合名</param>
        /// <returns></returns>
        DataTable GetSchema(string metaDataCollectionName);

        /// <summary>
        /// 基于DbConnection对象的元数据对象获取方法
        /// </summary>
        /// <param name="metaDataCollectionName">元数据集合名</param>
        /// <param name="restrictions">过滤条件</param>
        /// <returns></returns>
        DataTable GetSchema(string metaDataCollectionName, string[] restrictions);

        /// <summary>
        /// 获取.Net Framework数据类型
        /// </summary>
        /// <param name="nativeType"></param>
        /// <returns></returns>
        DbType GetDbType(string nativeType);

        /// <summary>
        /// 以正确的目录大小写给定一个不带引号的标识符，返回该标识符的带引号的正确形式，包括正确转义该标识符中嵌入的任何引号。
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        string QuoteIdentifier(string name);

        /// <summary>
        /// 在指定数据库上执行一个查询，返回一个结果集
        /// </summary>
        /// <param name="db"></param>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        DataSet ExecuteQuery(SODatabase db, string cmdText);
    }
}
