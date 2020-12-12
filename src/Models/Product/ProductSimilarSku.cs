namespace OYMLCN.JdVop.Models
{
    /// <summary>
    ///   同类商品信息
    /// </summary>
    public class ProductSimilarSku
    {
        /// <summary>
        ///   维度
        /// </summary>
        public int Dim { get; set; }
        /// <summary>
        ///   销售名称
        /// </summary>
        public string SaleName { get; set; }
        /// <summary>
        ///   商品销售标签
        /// </summary>
        public ProductSaleAttr[] SaleAttrList { get; set; }
    }
    /// <summary>
    ///   商品销售标签
    /// </summary>
    public class ProductSaleAttr
    {
        /// <summary>
        ///   标签图片地址
        /// </summary>
        public string ImagePath { get; set; }
        /// <summary>
        ///   标签名称
        /// </summary>
        public string SaleValue { get; set; }
        /// <summary>
        ///   当前标签下的同类商品skuId
        /// </summary>
        public long[] SkuIds { get; set; }
    }
}
