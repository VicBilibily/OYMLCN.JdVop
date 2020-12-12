namespace OYMLCN.JdVop.Models
{
    /// <summary>
    ///   赠品信息
    /// </summary>
    public class ProductSkuGift
    {
        /// <summary>
        ///   赠品附件列表
        /// </summary>
        public GiftVo[] Gifts { get; set; }
        /// <summary>
        ///   赠品要求最多购买数量（为0表示没配置）
        /// </summary>
        public int MaxNum { get; set; }
        /// <summary>
        ///   赠品要求最少购买数量 （为0表示没配置）
        /// </summary>
        public int MinNum { get; set; }
        /// <summary>
        ///   促销开始时间
        /// </summary>
        public long PromoStartTime { get; set; }
        /// <summary>
        ///   促销结束时间
        /// </summary>
        public long PromoEndTime { get; set; }
    }
    /// <summary>
    ///   赠品附件
    /// </summary>
    public class GiftVo
    {
        /// <summary>
        ///   商品编码
        /// </summary>
        public long SkuId { get; set; }
        /// <summary>
        ///   数量
        /// </summary>
        public int Num { get; set; }
        /// <summary>
        ///   1：附件，2：赠品。
        ///   <para>附件是指与主商品配套使用的部分，如空调的外机。</para>
        ///   <para>赠品是不影响主商品使用的附赠商品。</para>
        ///   <para>下单时，可以选择是否要赠品，但附件默认都必须要。</para>
        /// </summary>
        public int GiftType { get; set; }
    }
}
