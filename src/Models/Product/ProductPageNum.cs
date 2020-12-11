using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OYMLCN.JdVop.Models
{
    /// <summary>
    ///   商品池编号
    /// </summary>
    public class ProductPageNum
    {
        /// <summary>
        ///   商品池名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///   商品池编号
        /// </summary>
        [JsonPropertyName("page_num")]
        public string PageNum { get; set; }

        /// <summary>
        ///   商品池扩展字段
        /// </summary>
        public ContractSkuPoolExt[] ContractSkuPoolExt { get; set; }
    }
    /// <summary>
    ///   商品池扩展字段
    /// </summary>
    public class ContractSkuPoolExt
    {
        /// <summary>
        ///   商品池编号
        /// </summary>
        public int PoolId { get; set; }
        /// <summary>
        ///   扩展Key
        /// </summary>
        public string ExtKey { get; set; }
        /// <summary>
        ///   扩展Name
        /// </summary>
        public string ExtName { get; set; }
        /// <summary>
        ///   扩展Value
        /// </summary>
        public string ExtValue { get; set; }
    }
}
