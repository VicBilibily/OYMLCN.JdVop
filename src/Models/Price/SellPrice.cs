namespace OYMLCN.JdVop.Models
{
    /// <summary>
    ///   商品售卖价
    /// </summary>
    public class SellPrice
    {
        /// <summary>
        ///   商品编码
        /// </summary>
        public long SkuId { get; set; }
        /// <summary>
        ///   京东价（仅供参考）
        /// </summary>
        public decimal JdPrice { get; set; }
        /// <summary>
        ///   京东销售价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        ///   京东的前台划线价（仅供参考）
        /// </summary>
        public decimal? MarketPrice { get; set; }
        /// <summary>
        ///   税率（此值为16时，代表税率为16%）
        /// </summary>
        public decimal? Tax { get; set; }
        /// <summary>
        ///   税额
        /// </summary>
        public decimal? TaxPrice { get; set; }
        /// <summary>
        ///   未税价（仅供参考）
        /// </summary>
        public decimal? NakedPrice { get; set; }
    }
}
