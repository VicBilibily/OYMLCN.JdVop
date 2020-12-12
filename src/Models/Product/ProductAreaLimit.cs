namespace OYMLCN.JdVop.Models
{
    /// <summary>
    ///   商品在特定区域是否可售
    /// </summary>
    public class ProductAreaLimit
    {
        /// <summary>
        ///   商品编码
        /// </summary>
        public long SkuId { get; set; }
        /// <summary>
        ///   <see langword="true"/> 或空值代表区域受限
        ///   <see langword="false"/> 区域不受限
        /// </summary>
        public bool? IsAreaRestrict { get; set; }
    }
}
