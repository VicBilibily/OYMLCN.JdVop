using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OYMLCN.JdVop.Models
{
    /// <summary>
    /// 京东配送信息
    /// </summary>
    public class OrderTrackResult
    {
        /// <summary>
        ///   京东订单ID
        /// </summary>
        public long JdOrderId { get; set; }
        /// <summary>
        ///   配送信息
        /// </summary>
        public List<OrderTrack> OrderTrack { get; set; }
        /// <summary>
        ///   订单的运单信息
        /// </summary>
        public List<WaybillCode> WaybillCode { get; set; }
    }
    /// <summary>
    ///   运单信息
    /// </summary>
    public class WaybillCode
    {
        /// <summary>
        ///   订单号
        /// </summary>
        [JsonConverter(typeof(Internal.JsonStringToInt64Converter))]
        public long OrderId { get; set; }
        /// <summary>
        ///   父订单号，此字段为0即未拆单
        /// </summary>
        [JsonConverter(typeof(Internal.JsonStringToInt64Converter))]
        public long ParentId { get; set; }
        /// <summary>
        ///   承运商。可以为“京东快递”或是京东配送站点名称或者商家自行录入的承运商名称。
        /// </summary>
        public string Carrier { get; set; }
        /// <summary>
        ///   运单号（可能没有，可能是京东订单号本身）
        /// </summary>
        public string DeliveryOrderId { get; set; }
    }
    /// <summary>
    ///   配送信息
    /// </summary>
    public class OrderTrack
    {
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime MsgTime { get; set; }
        /// <summary>
        ///   操作员名称
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        ///   操作内容明细
        /// </summary>
        public string Content { get; set; }
    }
}
