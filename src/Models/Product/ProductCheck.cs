namespace OYMLCN.JdVop.Models
{
    /// <summary>
    ///   商品可售性
    /// </summary>
    public class ProductCheck
    {
        /// <summary>
        ///   商品编号
        /// </summary>
        public long SkuId { get; set; }
        /// <summary>
        ///   商品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///   是否可售
        /// </summary>
        public bool SaleState { get; set; }
        /// <summary>
        ///   是否可开专票
        /// </summary>
        public bool IsCanVAT { get; set; }

        /// <summary>
        ///   是否自营
        /// </summary>
        public bool IsSelf { get; set; }
        /// <summary>
        ///   是否京东配送
        /// </summary>
        public bool IsJDLogistics { get; set; }

        /// <summary>
        ///   无理由退货类型：0,1,2,3,4,5,6,7,8
        /// </summary>
        public int? NoReasonToReturn { get; set; }
        /// <summary>
        ///   无理由退货文案类型
        /// </summary>
        public int? THWA { get; set; }

        /// <summary>
        ///   商品税率
        /// </summary>
        public string TaxInfo { get; set; }
    }
}
