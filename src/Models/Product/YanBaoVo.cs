namespace OYMLCN.JdVop.Models
{
    /// <summary>
    ///   保障服务
    /// </summary>
    public class YanBaoVo
    {
        /// <summary>
        ///   主商品的sku
        /// </summary>
        public int MainSkuId { get; set; }
        /// <summary>
        ///   保障服务类别显示图标url
        /// </summary>
        public string ImgUrl { get; set; }
        /// <summary>
        ///   保障服务类别静态页详情url
        /// </summary>
        public string DetailUrl { get; set; }
        /// <summary>
        ///   保障服务类别显示排序
        /// </summary>
        public int DisplayNo { get; set; }
        /// <summary>
        ///   保障服务分类编码
        /// </summary>
        public string CategoryCode { get; set; }
        /// <summary>
        ///   保障服务类别名称
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        ///   保障服务商品详情列表
        /// </summary>
        public YanBaoVoDeatil[] FuwuSkuDetailList { get; set; }
    }
    /// <summary>
    ///   保障详情
    /// </summary>
    public class YanBaoVoDeatil
    {
        /// <summary>
        ///   保障服务skuId
        /// </summary>
        public int BindSkuId { get; set; }
        /// <summary>
        ///   保障服务sku名称（6字内）
        /// </summary>
        public string BindSkuName { get; set; }
        /// <summary>
        ///   显示排序
        /// </summary>
        public int SortIndex { get; set; }
        /// <summary>
        ///   保障服务sku价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        ///   保障服务说明提示语（20字内）
        /// </summary>
        public string Tip { get; set; }
        /// <summary>
        ///   是否是优惠保障服务
        /// </summary>
        public bool Favor { get; set; }
    }
}
