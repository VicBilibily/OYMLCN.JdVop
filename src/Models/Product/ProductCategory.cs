namespace OYMLCN.JdVop.Models
{
    /// <summary>
    ///   商品分类
    /// </summary>
    public class ProductCategory
    {
        /// <summary>
        ///   分类ID
        /// </summary>
        public int CatId { get; set; }
        /// <summary>
        ///   父分类ID
        /// </summary>
        public int? ParentId { get; set; }
        /// <summary>
        ///   分类名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///   0：一级分类；
        ///   1：二级分类；
        ///   2：三级分类；
        /// </summary>
        public int CatClass { get; set; }
        /// <summary>
        ///   有效分类
        /// </summary>
        public bool State { get; set; }
    }
}
