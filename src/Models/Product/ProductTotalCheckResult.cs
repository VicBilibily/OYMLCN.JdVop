namespace OYMLCN.JdVop.Models
{
    /// <summary>
    ///   商品是否支持货到付款
    /// </summary>
    public class ProductTotalCheckResult
    {
        /// <summary>
        ///   true成功 false 失败
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        ///   业务处理结果编码，详细参见：【错误码】
        /// </summary>
        public string ResultCode { get; set; }
        /// <summary>
        ///   对resultCode的简要说明
        /// </summary>
        public string ResultMessage { get; set; }
        /// <summary>
        ///   判断如果是 <see langword="null"/> 则调用成功，否则说明没有通过校验
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        ///   商品可售校验
        /// </summary>
        public ProductCheck[] CheckResult { get; set; }
        /// <summary>
        ///   区域限售信息
        /// </summary>
        public ProductAreaLimit[] SkuAreasResult { get; set; }
        /// <summary>
        ///   库存信息
        /// </summary>
        public StockResult[] StockResult { get; set; }
        /// <summary>
        ///   商品上下架状态信息
        /// </summary>
        public ProductSkuState[] SkuStateResult { get; set; }
    }
}
