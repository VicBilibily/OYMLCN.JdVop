namespace OYMLCN.JdVop.Models
{
    /// <summary>
    ///   订单运费
    /// </summary>
    public class OrderFreight
    {
        /// <summary>
        /// 总运费
        /// </summary>
        public decimal Freight { get; set; }
        /// <summary>
        /// 基础运费
        /// </summary>
        public decimal BaseFreight { get; set; }
        /// <summary>
        /// 偏远地区加收运费
        /// </summary>
        public decimal RemoteRegionFreight { get; set; }
        /// <summary>
        /// 需收取偏远运费的sku
        /// </summary>
        public string RemoteSku { get; set; }
        /// <summary>
        /// 续重运费
        /// </summary>
        public decimal ConFreight { get; set; }
    }
}
