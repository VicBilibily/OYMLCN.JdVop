namespace OYMLCN.JdVop.Models
{
    /// <summary>
    ///   厂商配送订单的批量确认收货处理状态信息
    /// </summary>
    public class OrderBatchConfirmInfo
    {
        /// <summary>
        ///   京东订单号
        /// </summary>
        public long JdOrderId { get; set; }
        /// <summary>
        ///   确认状态
        /// </summary>
        public bool ConfirmState { get; set; }
        /// <summary>
        ///   失败描述，成功时为 <see langword="null"/>。
        /// </summary>
        public string ErrorMsg { get; set; }
    }
}
