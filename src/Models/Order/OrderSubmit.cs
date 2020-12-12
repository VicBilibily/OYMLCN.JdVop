using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;

namespace OYMLCN.JdVop.Models
{
    /// <summary>
    ///   下单基础信息
    /// </summary>
    public class OrderBasic
    {
        /// <summary>
        ///   下单基础信息
        /// </summary>
        /// <param name="thirdOrder">第三方的订单单号，必须在100字符以内</param>
        /// <param name="paymentType">支付方式</param>
        /// <param name="name">收货人姓名，最多20个字符</param>
        /// <param name="province">一级地址编码：收货人省份地址编码</param>
        /// <param name="city">二级地址编码：收货人市级地址编码</param>
        /// <param name="county">三级地址编码：收货人县（区）级地址编码</param>
        /// <param name="town">四级地址编码：收货人乡镇地址编码(如果该地区有四级地址，则必须传递四级地址，没有四级地址则传0)</param>
        /// <param name="address">收货人详细地址，最多100个字符</param>
        /// <param name="mobile">手机号，最多20个字符</param>
        /// <param name="submitState">是否预占库存</param>
        public OrderBasic(
            string thirdOrder, PaymentType paymentType,
            string name, string mobile,
            int province, int city, int county, int town,
            string address, bool submitState = false)
        {
            this.KV = new Dictionary<string, string>
            {
                { "thirdOrder", thirdOrder },
                { "paymentType", ((int)paymentType).ToString() },

                { "name", name },
                { "province", province.ToString() },
                { "city", city.ToString() },
                { "county", county.ToString() },
                { "town", town.ToString() },
                { "address", address },
                { "mobile", mobile },
                { "email", "xx" }, //邮箱（接口需要，无实际业务意义，可固值xx）

                //使用余额时，此值固定是1，其他支付方式0
                { "isUseBalance", paymentType==PaymentType.Advance?"1":"0" },
                { "submitState", submitState?"1":"0" },
            };
        }

        /// <summary>
        ///   邮编，最多20个字符
        /// </summary>
        public string Zip { set { this.KV["zip"] = value; } }
        /// <summary>
        ///   座机号，最多20个字符
        /// </summary>
        public string Phone { set { this.KV["phone"] = value; } }
        /// <summary>
        ///   备注（少于100字）
        /// </summary>
        public string Remark { set { this.KV["remark"] = value; } }
        /// <summary>
        ///   是否预占库存
        /// </summary>
        public bool SubmitState { set { this.KV["submitState"] = value ? "1" : "0"; } }
        /// <summary>
        ///   支付明细
        ///   <para>当 <see langword="paymentType"/> 为
        ///   <see cref="PaymentType.Mixed"/> 时候必须递此字段</para>
        /// </summary>
        public OrderPayDetail[] PayDetails { set { this.KV["payDetails"] = $"[{string.Join(',', value?.Select(v => v.ToString()))}]"; } }

        /// <summary>
        ///   采购单号，长度范围[1-26]
        /// </summary>
        public string PoNo { set { this.KV["poNo"] = value; } }
        /// <summary>
        ///   第三方平台采购人账号
        /// </summary>
        public string ThrPurchaserAccount { set { this.KV["thrPurchaserAccount"] = value; } }
        /// <summary>
        ///   第三方平台采购人姓名
        /// </summary>
        public string ThrPurchaserName { set { this.KV["thrPurchaserName"] = value; } }
        /// <summary>
        ///   第三方采购人电话（手机号，固定电话区号+号码）
        /// </summary>
        public string ThrPurchaserPhone { set { this.KV["thrPurchaserPhone"] = value; } }

        internal Dictionary<string, string> KV { get; private set; }
    }
    /// <summary>
    ///   下单商品信息
    /// </summary>
    public class OrderSku
    {
        /// <summary>
        ///   下单商品信息
        /// </summary>
        /// <param name="skuId">商品编号</param>
        /// <param name="num">商品数量</param>
        /// <param name="price">下单单价</param>
        /// <param name="bNeedGift">需要赠品</param>
        /// <param name="yanbao">延保商品编号</param>
        public OrderSku(long skuId, int num, decimal price, bool bNeedGift = false, long? yanbao = default)
        {
            var dic = new Dictionary<string, object>()
            {
                { "skuId", skuId },
                { "num", num },
                { "price", price },
                { "bNeedGift", bNeedGift },
            };
            if (yanbao.HasValue)
                dic.Add("yanbao", new[] { new { skuId = yanbao } });
            this.Json = JsonSerializer.Serialize(dic);
        }
        /// <summary>
        ///   下单JSON商品信息字符串
        /// </summary>
        public string Json { get; private set; }
        /// <summary>
        ///   下单JSON商品信息字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString() => this.Json;
    }

    #region 发票相关枚举
    /// <summary>
    ///   开票方式
    /// </summary>
    public enum InvoiceState : int
    {
        /// <summary>
        ///   订单预借
        /// </summary>
        [Description("订单预借")]
        Advance = 0,
        /// <summary>
        ///   随货开票
        /// </summary>
        [Description("随货开票")]
        WithGoods = 1,
        /// <summary>
        ///   集中开票
        /// </summary>
        [Description("集中开票")]
        Centralized = 2,
        /// <summary>
        ///   订单完成后开票
        /// </summary>
        [Description("订单完成后开票")]
        Completion = 4,
    }
    /// <summary>
    ///   发票类型
    /// </summary>
    public enum InvoiceType : int
    {
        /// <summary>
        ///   增值税专用发票
        /// </summary>
        VAT = 2,
        /// <summary>
        ///   电子发票
        /// </summary>
        EInvoice = 3,
    }
    /// <summary>
    ///   发票类型
    /// </summary>
    public enum InvoiceTitle : int
    {
        /// <summary>
        ///   个人
        /// </summary>
        Personal = 4,
        /// <summary>
        ///   单位
        /// </summary>
        Company = 5,
    }
    /// <summary>
    ///   发票内容
    /// </summary>
    public enum InvoiceContent : int
    {
        /// <summary>
        ///   明细
        /// </summary>
        Detail = 1,
        /// <summary>
        ///   大类
        /// </summary>
        Major = 100,
    }
    #endregion
    /// <summary>
    ///   下单发票信息
    /// </summary>
    public class OrderInvoice
    {
        /// <summary>
        ///   下单发票信息
        /// </summary>
        /// <param name="invoiceState">开票方式</param>
        /// <param name="invoiceType">
        ///   发票类型
        ///   <para>当 <paramref name="invoiceType"/> 为 <see cref="InvoiceType.VAT"/>
        ///   增值税专用发票时，开票方式 <paramref name="invoiceState"/> 只支持
        ///   <see cref="InvoiceState.Centralized"/> 集中开票）</para>
        /// </param>
        /// <param name="selectedInvoiceTitle">发票类型</param>
        /// <param name="invoiceContent">发票内容</param>
        /// <param name="invoicePhone">收票人电话</param>
        /// <param name="regCompanyName">专票资质公司名称</param>
        /// <param name="regCode">专票资质纳税人识别号</param>
        /// <param name="companyName">
        ///   发票抬头
        ///   <para>如果 <paramref name="selectedInvoiceTitle"/> 为
        ///   <see cref="InvoiceTitle.Company"/> 时此字段必须</para>
        /// </param>
        /// <param name="poNo">采购单号，长度范围[1-26]</param>
        public OrderInvoice(
            InvoiceState invoiceState, InvoiceType invoiceType,
            InvoiceTitle selectedInvoiceTitle, InvoiceContent invoiceContent,
            string invoicePhone, string regCompanyName, string regCode,
            string companyName = default)
        {
            this.KV = new Dictionary<string, string>
            {
                { "invoiceState", ((int)invoiceState).ToString() },
                { "invoiceType", ((int)invoiceType).ToString() },
                { "selectedInvoiceTitle", ((int)selectedInvoiceTitle).ToString() },
                { "invoiceContent", ((int)invoiceContent).ToString() },
                { "companyName", companyName },
                { "invoicePhone", invoicePhone },
                { "regCompanyName", regCompanyName },
                { "regCode", regCode },
            };
        }

        /// <summary>
        ///   增专票收票人姓名 
        /// </summary>
        public string InvoiceName { set { this.KV["invoiceName"] = value; } }
        /// <summary>
        ///   增专票收票人所在省(京东地址编码)
        /// </summary>
        public int InvoiceProvice { set { this.KV["invoiceProvice"] = value.ToString(); } }
        /// <summary>
        ///   增专票收票人所在市(京东地址编码)
        /// </summary>
        public int InvoiceCity { set { this.KV["invoiceCity"] = value.ToString(); } }
        /// <summary>
        ///   增专票收票人所在区/县(京东地址编码)
        /// </summary>
        public int InvoiceCounty { set { this.KV["invoiceCounty"] = value.ToString(); } }
        /// <summary>
        ///   当 <see langword="invoiceType"/> = <see cref="InvoiceType.VAT"/>
        ///   时提供的增专票收票人所在地址
        /// </summary>
        public string InvoiceAddress { set { this.KV["invoiceAddress"] = value; } }
        /// <summary>
        ///   专票资质注册地址
        /// </summary>
        public string RegAddr { set { this.KV["regAddr"] = value; } }
        /// <summary>
        ///   专票资质注册电话
        /// </summary>
        public string RegPhone { set { this.KV["regPhone"] = value; } }
        /// <summary>
        ///   专票资质注册银行
        /// </summary>
        public string RegBank { set { this.KV["regBank"] = value; } }
        /// <summary>
        ///   专票资质银行账号
        /// </summary>
        public string RegBankAccount { set { this.KV["regBankAccount"] = value; } }

        internal Dictionary<string, string> KV { get; private set; }
    }

    /// <summary>
    ///   下单支付区分
    /// </summary>
    public enum OrderPayFlag
    {
        /// <summary>
        ///   个人
        /// </summary>
        Personal = 1,
        /// <summary>
        ///   企业
        /// </summary>
        Company = 2,
    }
    /// <summary>
    ///   订单支付明细
    /// </summary>
    public class OrderPayDetail
    {
        /// <summary>
        ///   订单支付明细
        /// </summary>
        public OrderPayDetail() { }
        /// <summary>
        ///   订单支付明细
        /// </summary>
        /// <param name="payMoney">支付金额</param>
        /// <param name="paymentType">支付类型</param>
        /// <param name="flag">支付区分</param>
        public OrderPayDetail(decimal payMoney, PaymentType paymentType, OrderPayFlag flag)
        {
            this.PayMoney = payMoney;
            this.PaymentType = paymentType;
            this.Flag = flag;
        }

        /// <summary>
        ///   支付金额
        /// </summary>
        public decimal PayMoney { get; set; }
        /// <summary>
        ///   支付金额
        /// </summary>
        public PaymentType PaymentType { get; set; }
        /// <summary>
        ///   支付区分
        /// </summary>
        public OrderPayFlag Flag { get; set; }

        /// <summary>
        ///   京东格式
        /// </summary>
        public override string ToString()
            => $"{{\"payMoney\":{PayMoney},\"paymentType\":\"{(int)PaymentType}\",\"flag\":\"{(int)Flag}\"}}";
    }

    /// <summary>
    ///   订单配送明细
    /// </summary>
    public class OrderReserving
    {
        /// <summary>
        ///   订单配送明细
        /// </summary>
        public OrderReserving() { this.KV = new Dictionary<string, string>(); }

        /// <summary>
        ///   大家电配送日期（默认值为-1）
        ///   <para>0表示当天，1表示明天，2：表示后天; 如果为-1表示不使用大家电预约日历</para>
        /// </summary>
        public int ReservingDate { set { this.KV["reservingDate"] = value.ToString(); } }
        /// <summary>
        ///   大家电安装日期（默认值为-1）
        ///   <para>0表示当天，1表示明天，2：表示后天</para>
        /// </summary>
        public int InstallDate { set { this.KV["installDate"] = value.ToString(); } }
        /// <summary>
        ///   是否选择了安装，默认为true
        ///   如果选择了“暂缓安装”，此为必填项，必填值为false。
        /// </summary>
        public bool NeedInstall { set { this.KV["needInstall"] = value ? "true" : "false"; } }

        /// <summary>
        ///   中小件配送预约日期
        /// </summary>
        public DateTime PromiseDate { set { this.KV["promiseDate"] = value.ToString("yyyy-MM-dd"); } }
        /// <summary>
        ///   中小件配送预约时间段，时间段如： 9:00-15:00
        /// </summary>
        public string PromiseTimeRange { set { this.KV["promiseTimeRange"] = value; } }
        /// <summary>
        ///   中小件预约时间段的标记
        /// </summary>
        public int PromiseTimeRangeCode { set { this.KV["promiseTimeRangeCode"] = value.ToString(); } }

        /// <summary>
        ///   家电配送预约日期
        /// </summary>
        public DateTime ReservedDate { set { this.KV["reservedDateStr"] = value.ToString("yyyy-MM-dd"); } }
        /// <summary>
        ///   大家电配送预约时间段，如果：9:00-15:00
        /// </summary>
        public string ReservedTimeRange { set { this.KV["reservedTimeRange"] = value; } }

        /// <summary>
        ///   循环日历, 客户传入最近一周可配送的时间段
        ///   <para>客户入参:{"3": "09:00-10:00,12:00-19:00","4": "09:00-15:00"}</para>
        /// </summary>
        public string CycleCalendar { set { this.KV["cycleCalendar"] = value; } }
        /// <summary>
        ///   节假日不可配送，默认值为 <see langword="false"/>，表示节假日可以配送，为 <see langword="true"/> 表示节假日不配送
        /// </summary>
        public bool ValidHolidayVocation { set { this.KV["validHolidayVocation"] = value ? "true" : "false"; } }

        internal Dictionary<string, string> KV { get; private set; }
    }

}
