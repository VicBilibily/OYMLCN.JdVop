namespace OYMLCN.JdVop.Models
{
    /// <summary>
    ///   支付方式
    /// </summary>
    public enum PaymentType
    {
        /// <summary>
        ///   货到付款
        /// </summary>
        Cash = 1,
        /// <summary>
        ///   预存款
        /// </summary>
        Advance = 4,
        /// <summary>
        ///   公司转账
        /// </summary>
        Transfer = 5,

        /// <summary>
        ///   京东金采
        /// </summary>
        JDJC = 101,
        /// <summary>
        ///   商城金采(一般不适用，仅限确认开通商城账期的特殊情况使用，请与业务确认后使用)
        /// </summary>
        SCJC = 102,

        /// <summary>
        ///   混合支付
        /// </summary>
        Mixed = 20,

        /// <summary>
        ///   微信支付
        /// </summary>
        WeixinPay = 17,
    }
}
