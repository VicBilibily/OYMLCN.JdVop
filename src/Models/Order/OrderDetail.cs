using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OYMLCN.JdVop.Models
{
    /// <summary>
    ///   订单详情信息
    /// </summary>
    public class OrderSubmitResult
    {
        /// <summary>
        ///   京东订单号
        /// </summary>
        public long JdOrderId { get; set; }
        /// <summary>
        ///   运费
        /// </summary>
        public decimal Freight { get; set; }
        /// <summary>
        ///   订单总金额（不包含运费）
        /// </summary>
        public decimal OrderPrice { get; set; }
        /// <summary>
        ///   订单未税金额
        /// </summary>
        public decimal OrderNakedPrice { get; set; }
        /// <summary>
        ///   订单包含的商品信息列表 
        /// </summary>
        public List<OrderBizSku> SKU { get; set; }
        /// <summary>
        ///   订单税额
        /// </summary>
        public decimal OrderTaxPrice { get; set; }
    }
    /// <summary>
    ///   订单包含的商品信息列表
    /// </summary>
    public class OrderBizSku
    {
        /// <summary>
        ///   京东商品编号
        /// </summary>
        public long SkuId { get; set; }
        /// <summary>
        ///   购买商品数量
        /// </summary>
        public int Num { get; set; }
        /// <summary>
        ///   商品分类编号
        /// </summary>
        public int Category { get; set; }
        /// <summary>
        ///   商品单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        ///   商品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///   商品税率
        /// </summary>
        public decimal Tax { get; set; }
        /// <summary>
        ///   商品税额
        /// </summary>
        public decimal TaxPrice { get; set; }
        /// <summary>
        ///   商品未税价
        /// </summary>
        public decimal NakedPrice { get; set; }
        /// <summary>
        ///   商品类型：0普通、1附件、2赠品、3延保
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        ///   主商品skuid，如果本身是主商品，则oid为0
        /// </summary>
        public int OID { get; set; }
    }


    /// <summary>
    ///   订单类别
    /// </summary>
    public enum OrderType : int
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
        普通商品 = 1,
        大家电 = 2,
        实物礼品卡 = 3,
        售后换新单 = 4,
        厂家直送订单 = 5,
        FBP订单 = 6,
        生鲜 = 7,
        IBS订单 = 11,
        电子卡 = 20,
        机票 = 21,
        酒店 = 22,
        合约机号卡 = 23,
        火车票 = 24,
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释
    }
    /// <summary>
    ///   京东订单状态
    /// </summary>
    public enum JdOrderState : int
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
        新单 = 1,
        等待支付 = 2, 等待支付确认 = 3, 延迟付款确认 = 4,
        订单暂停 = 5, 店长最终审核 = 6,
        等待打印 = 7, 等待出库 = 8, 等待打包 = 9, 等待发货 = 10,
        自提途中 = 11, 上门提货 = 12, 自提退货 = 13, 确认自提 = 14,
        等待确认收货 = 16, 配送退货 = 17, 货到付款确认 = 18,
        已完成 = 19, 收款确认 = 21,
        锁定 = 22,
        等待三方出库 = 29, 等待三方发货 = 30, 等待三方发货完成 = 31,
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释
    }
    /// <summary>
    ///   物流状态
    /// </summary>
    public enum OrderDeliveryState
    {
        /// <summary>
        ///   新建
        /// </summary>
        [Description("新建")]
        New = 0,
        /// <summary>
        ///   妥投
        /// </summary>
        [Description("妥投")]
        OK = 1,
        /// <summary>
        ///   拒收
        /// </summary>
        [Description("拒收")]
        Reject = 2,
    }

    /// <summary>
    ///   京东订单详情
    /// </summary>
    public class OrderDetail
    {
        /// <summary>
        ///   订单状态（有效性，<see langword="false"/> 为已取消）
        /// </summary>
        public bool OrderState { get; set; }
        /// <summary>
        ///   预占确认状态
        /// </summary>
        public bool SubmitState { get; set; }
        /// <summary>
        ///   订单类型。1是父订单，2是子订单。
        /// </summary>
        public int Type { get; set; }

        #region 扩展字段
        /// <summary>
        ///   订单类别
        /// </summary>
        public OrderType? OrderType { get; set; }
        /// <summary>
        ///   订单创建时间
        /// </summary>
        public DateTime? CreateOrderTime { get; set; }
        /// <summary>
        ///   订单完成时间
        /// </summary>
        public DateTime? FinishTime { get; set; }
        /// <summary>
        ///   京东状态
        /// </summary>
        public JdOrderState? JdOrderState { get; set; }
        /// <summary>
        ///   收货地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        ///   姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///   加密后的联系方式
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        ///    京东配送订单的出库时间/厂家直送订单的确认发货时间
        /// </summary>
        public DateTime? OutTime { get; set; }
        /// <summary>
        ///   下单时的开票类型 
        /// </summary>
        public InvoiceType? InvoiceType { get; set; }
        /// <summary>
        ///   支付方式
        /// </summary>
        public PaymentType? PaymentType { get; set; }
        /// <summary>
        ///   混合支付明细
        /// </summary>
        public OrderPayDetail[] PayDetails { get; set; }

        /// <summary>
        ///   采购订单号
        /// </summary>
        public string PoNo { get; set; }
        #endregion

        /// <summary>
        ///   京东订单编号
        /// </summary>
        public long JdOrderId { get; set; }
        /// <summary>
        ///   父订单号。为0时，此订单为父单。
        /// </summary>
        public long POrder { get; set; }

        /// <summary>
        ///   物流状态
        /// </summary>
        public OrderDeliveryState State { get; set; }
        /// <summary>
        ///   运费
        /// </summary>
        public decimal Freight { get; set; }
        /// <summary>
        ///   商品列表
        /// </summary>
        public List<OrderBizSku> SKU { get; set; }
        /// <summary>
        ///   商品总金额（不包含运费，订单总金额 = <see cref="Freight"/> + <see cref="OrderPrice"/>）
        /// </summary>
        public decimal OrderPrice { get; set; }
        /// <summary>
        ///   订单未含税金额
        /// </summary>
        public decimal OrderNakedPrice { get; set; }
        /// <summary>
        ///   订单税额
        /// </summary>
        public decimal OrderTaxPrice { get; set; }
    }
    /// <summary>
    ///   京东父单详情
    /// </summary>
    public class OrderParent : OrderDetail
    {
        /// <summary>
        /// 父订单详情
        /// </summary>
        public new OrderDetail POrder { get; set; }
        /// <summary>
        /// 子订单详情。
        /// </summary>
        public List<OrderDetail> COrder { get; set; }
    }
}
