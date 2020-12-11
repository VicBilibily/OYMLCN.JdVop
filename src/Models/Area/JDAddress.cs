namespace OYMLCN.JdVop.Models
{
    /// <summary>
    ///   京东地址编码
    /// </summary>
    public class JDAddress
    {
        /// <summary>
        ///   国家ID
        /// </summary>
        public string NationId { get; set; }
        /// <summary>
        ///   国家名称
        /// </summary>
        public string Nation { get; set; }

        /// <summary>
        ///   一级地址ID
        /// </summary>
        public int ProvinceId { get; set; }
        /// <summary>
        ///   一级地址名称
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        ///   二级地址ID
        /// </summary>
        public int CityId { get; set; }
        /// <summary>
        ///   二级地址名称
        /// </summary>
        public string City { get; set; }

        /// <summary>
        ///   三级地址ID
        /// </summary>
        public int CountyId { get; set; }
        /// <summary>
        ///   三级地址名称
        /// </summary>
        public string County { get; set; }

        /// <summary>
        ///   四级地址ID
        /// </summary>
        public int? TownId { get; set; }
        /// <summary>
        ///   四级地址名称
        /// </summary>
        public string Town { get; set; }
    }

}
