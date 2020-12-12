using System;

namespace OYMLCN.JdVop.Models
{
    /// <summary>
    ///   京东商品图片（主图、轮播图）
    /// </summary>
    public class ProductImage
    {
        /// <summary>
        ///   编号
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        ///   sku编号
        /// </summary>
        public long SkuId { get; set; }
        /// <summary>
        ///   图片路径，与商品详情页面返回的图片地址一致。
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        ///   创建日期
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        ///   更新时间
        /// </summary>
        public DateTime Modified { get; set; }
        /// <summary>
        ///   是否可用
        /// </summary>
        public bool YN { get; set; }
        /// <summary>
        ///   是否主图
        /// </summary>
        public bool IsPrimary { get; set; }
        /// <summary>
        ///   排序 
        /// </summary>
        public int? OrderSort { get; set; }
        /// <summary>
        ///   位置
        /// </summary>
        public int? Position { get; set; }
        /// <summary>
        ///   类型（0方图/1长图【服装】）
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        ///   特征
        /// </summary>
        public string Features { get; set; }
    }
}
