namespace OYMLCN.JdVop.Models
{
    /// <summary>
    ///   商品实时库存
    /// </summary>
    public class StockResult
    {
        /// <summary>
        ///   商品编码
        /// </summary>
        public long SkuId { get; set; }

        /// <summary>
        ///   入参时传入的区域码area。
        ///   因京东目前是3、4级地址均支持，存在areaId在传入的3级地址后填充4级地址“_0“后返回的情况。
        /// </summary>
        public string AreaId { get; set; }
        /// <summary>
        ///   库存状态编号。
        ///   参考枚举值：33,39,40,36,34,99
        /// </summary>
        public decimal StockStateId { get; set; }
        /// <summary>
        ///   库存状态描述。
        ///   <para>以下为stockStateId不同时，此字段不同的返回值：</para>
        ///   <para> 33 有货 现货-下单立即发货</para>
        ///   <para> 39 有货 在途-正在内部配货，预计2~6天到达本仓库</para>
        ///   <para> 40 有货 可配货-下单后从有货仓库配货</para>
        ///   <para> 36 预订</para>
        ///   <para> 34 无货</para>
        ///   <para> 99 无货开预定，此时desc返回的数值代表预计到货天数，并且该功能需要依赖合同上有无货开预定权限的用户，到货周期略长，谨慎采用该功能。</para>
        /// </summary>
        public string StockStateDesc { get; set; }
        /// <summary>
        ///   剩余数量。
        ///   <para>当此值为-1时，为未查询到。</para>
        ///   <para>StockStateDesc为33：</para>
        ///   <para>入参的skuNums字段，skuId对应的 num &#60; 50，此字段为实际库存。</para>
        ///   <para>入参的skuNums字段，skuId对应的 50 &#60;= num &#60; 100，此字段为-1。</para>
        ///   <para>入参的skuNums字段，skuId对应的 num &#62; 100，此字段等于num。(此种情况并未返回真实京东库存)</para>
        /// </summary>
        public int RemainNum { get; set; }
    }
}
