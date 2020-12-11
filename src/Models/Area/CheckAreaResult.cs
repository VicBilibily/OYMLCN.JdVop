namespace OYMLCN.JdVop.Models
{
    /// <summary>
    ///   验证地址有效性返回数据
    /// </summary>
    public class CheckAreaResult
    {
        /// <summary>
        ///   状态
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        ///   状态码
        /// </summary>
        public int ResultCode { get; set; }
        /// <summary>
        ///   0
        /// </summary>
        public int AddressId { get; set; }
        /// <summary>
        ///   null
        /// </summary>
        public string Message { get; set; }
    }
}
