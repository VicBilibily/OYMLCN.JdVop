namespace OYMLCN.JdVop.Models
{
    /// <summary>
    ///   商品上下架状态
    /// </summary>
    public class ProductSkuState
    {
        /// <summary>
        ///   是否上架
        /// </summary>
        public bool State { get; set; }
        /// <summary>
        ///   skuId sku编号
        /// </summary>
        public long SKU { get; set; }
    }
}
