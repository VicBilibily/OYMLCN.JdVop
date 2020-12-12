using System;

namespace OYMLCN.JdVop.Models
{
    /// <summary>
    ///   查询订单列表结果
    /// </summary>
    public class OrderCheckResult
    {
        /// <summary>
        ///   订单总数
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        ///   总页码数
        /// </summary>
        public int TotalPage { get; set; }
        /// <summary>
        ///   当前页码
        /// </summary>
        public int CurPage { get; set; }
        /// <summary>
        ///   订单信息列表
        /// </summary>
        public OrderCheckItem[] Orders { get; set; }
    }
    /// <summary>
    ///   订单列表信息
    /// </summary>
    public class OrderCheckItem
    {
        /// <summary>
        ///   京东订单编号
        /// </summary>
        public long JdOrderId { get; set; }
        /// <summary>
        ///   订单配送状态
        /// </summary>
        public OrderDeliveryState State { get; set; }
        /// <summary>
        ///   是否挂起
        /// </summary>
        public bool HangUpState { get; set; }
        /// <summary>
        ///   开票方式
        /// </summary>
        public InvoiceState InvoiceState { get; set; }
        /// <summary>
        ///   订单金额
        /// </summary>
        public decimal OrderPrice { get; set; }
        /// <summary>
        ///   订单创建时间
        /// </summary>
        public DateTime Time { get; set; }
    }
}
