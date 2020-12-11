using System.Collections.Generic;

namespace OYMLCN.JdVop.Models
{
    /// <summary>
    ///   商品池商品编号列表
    /// </summary>
    public class PageNumSku
    {
        /// <summary>
        ///   总页数
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        ///   skuId集合
        /// </summary>
        public List<long> SkuIds { get; set; }
    }
}
