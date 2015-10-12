namespace Kalman.Data
{
    /// <summary>
    /// 使用Database.UpdateDataSet方法当DataAdapter的更新命令遇到错误时，选择采用哪种更新行为
    /// </summary>
    public enum UpdateBehavior
    {
        /// <summary>
        /// 标准行为，更新数据时遇到错误后终止，剩下的数据行不再更新
        /// </summary>
        Standard,
        /// <summary>
        /// 更新数据时遇到错误后继续更新后面的数据行
        /// </summary>
        Continue,
        /// <summary>
        /// 使用实物，所有更新过的数据行自动回滚
        /// </summary>
        Transactional
    }
}
