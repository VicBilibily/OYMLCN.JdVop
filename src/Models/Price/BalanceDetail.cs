using System;

namespace OYMLCN.JdVop.Models
{
    /// <summary>
    ///   余额变动详情
    /// </summary>
    public class BalanceDetail
    {
        /// <summary>
        ///   记录总条数
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        ///   分页大小，默认20，最大1000
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        ///   当前页码
        /// </summary>
        public int PageNo { get; set; }
        /// <summary>
        ///   总页数
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        ///   余额变动明细
        /// </summary>
        public BalanceDetailData[] Data { get; set; }
    }
    /// <summary>
    ///   余额变动明细
    /// </summary>
    public class BalanceDetailData
    {
        /// <summary>
        ///   余额明细ID
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        ///   账户类型
        ///   <para>1：可用余额 2：锁定余额</para>
        /// </summary>
        public int AccountType { get; set; }
        /// <summary>
        ///   金额（元）
        ///   <para>有正负，可以是零，表示订单流程变化，如退款时会先有一条退款申请的记录，金额为0。</para>
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        ///   京东Pin
        /// </summary>
        public string Pin { get; set; }
        /// <summary>
        ///   订单号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        ///   业务类型
        /// </summary>
        public int TradeType { get; set; }
        /// <summary>
        ///   业务类型名称
        /// </summary>
        public string TradeTypeName { get; set; }
        /// <summary>
        ///   余额变动日期
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        ///   备注信息
        /// </summary>
        public string NotePub { get; set; }
        /// <summary>
        ///   业务号，一般由余额系统，在每一次操作成功后自动生成，也可以由前端业务系统传入
        /// </summary>
        public long tradeNo { get; set; }
    }

}
