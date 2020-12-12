namespace OYMLCN.JdVop.Models
{
    /// <summary>
    ///   验证货到付款项目
    /// </summary>
    public class ProductIsCodItem
    {
        /// <summary>
        ///   是否支持货到付款
        /// </summary>
        public bool CanCOD { get; set; }
        /// <summary>
        ///   错误原因
        /// </summary>
        public string NonCODmsg { get; set; }
    }
}
