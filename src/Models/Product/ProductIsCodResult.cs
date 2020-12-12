namespace OYMLCN.JdVop.Models
{
    /// <summary>
    ///   商品是否支持货到付款
    /// </summary>
    public class ProductIsCodResult
    {
        /// <summary>
        ///   状态码
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        ///   异常信息提示
        /// </summary>
        public string ResultMessage { get; set; }
        /// <summary>
        ///   错误码
        /// </summary>
        public string ResultCode { get; set; }
        /// <summary>
        ///   若验证所有商品都支持货到付款，则返回
        ///   <see langword="true"/>，除此之外返回
        ///   <see langword="false"/>。
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        ///   不支持货到付款的商品
        /// </summary>
        public string SkuIds { get; set; }
    }
}
