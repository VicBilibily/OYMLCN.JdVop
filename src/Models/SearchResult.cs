namespace OYMLCN.JdVop.Models
{
    /// <summary>
    ///   商品搜索排序
    /// </summary>
    public enum SearchSort
    {
        /// <summary>
        ///   销量降序
        /// </summary>
        sale_desc,
        /// <summary>
        ///   价格升序
        /// </summary>
        price_asc,
        /// <summary>
        ///   价格降序
        /// </summary>
        price_desc,
        /// <summary>
        ///   上架时间降序
        /// </summary>
        winsdate_desc,
        /// <summary>
        ///   按销量排序_15天销售额
        /// </summary>
        sort_totalsales15_desc,
        /// <summary>
        ///   按15日销量排序
        /// </summary>
        sort_days_15_qtty_desc,
        /// <summary>
        ///   按30日销量排序
        /// </summary>
        sort_days_30_qtty_desc,
        /// <summary>
        ///   按15日销售额排序
        /// </summary>
        sort_days_15_gmv_desc,
        /// <summary>
        ///   按30日销售额排序
        /// </summary>
        sort_days_30_gmv_desc,
    }

    /// <summary>
    ///   搜索结果
    /// </summary>
    public class SearchResult
    {
        /// <summary>
        ///   搜索结果总记录数量
        /// </summary>
        public int ResultCount { get; set; }
        /// <summary>
        ///   总页数
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        ///   当前页
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        ///   每页大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        ///   品牌汇总信息
        /// </summary>
        public BrandAggregate BrandAggregate { get; set; }
        /// <summary>
        ///   相关分类汇总信息
        /// </summary>
        public CategoryAggregate CategoryAggregate { get; set; }
        /// <summary>
        ///   价格区间汇总信息
        /// </summary>
        public PriceIntervalAggregate[] PriceIntervalAggregate { get; set; }
        /// <summary>
        ///   搜索命中数据
        /// </summary>
        public HitResult[] HitResult { get; set; }
        /// <summary>
        ///   扩展属性汇总信息
        /// </summary>
        public ExpandAttrAggregate[] ExpandAttrAggregate { get; set; }
    }

    /// <summary>
    ///   品牌汇总信息
    /// </summary>
    public class BrandAggregate
    {
        /// <summary>
        ///   首字母拼音
        /// </summary>
        public string[] PinyinAggr { get; set; }
        /// <summary>
        ///   品牌列表
        /// </summary>
        public BrandVo[] BrandList { get; set; }
    }
    /// <summary>
    ///   品牌信息
    /// </summary>
    public class BrandVo
    {
        /// <summary>
        ///   品牌id
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        ///   品牌名称
        /// </summary>
        public string Pinyin { get; set; }
        /// <summary>
        ///   品牌首字母拼音
        /// </summary>
        public string Name { get; set; }
    }
    /// <summary>
    ///   分类汇总
    /// </summary>
    public class CategoryAggregate
    {
        /// <summary>
        ///   一级类目分类
        /// </summary>
        public CategoryVo[] FirstCategory { get; set; }
        /// <summary>
        ///   二级类目分类
        /// </summary>
        public CategoryVo[] SecondCategory { get; set; }
        /// <summary>
        ///   三级类目分类
        /// </summary>
        public CategoryVo[] ThridCategory { get; set; }
    }
    /// <summary>
    ///   分类条目
    /// </summary>
    public class CategoryVo
    {
        /// <summary>
        ///   分类Id
        /// </summary>
        public int CatId { get; set; }
        /// <summary>
        ///   分类下商品数量
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        ///   上级Id
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        ///   分类名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///   分类权重
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        ///   分类级别标识
        /// </summary>
        public string Field { get; set; }
    }
    /// <summary>
    ///   价格汇总
    /// </summary>
    public class PriceIntervalAggregate
    {
        /// <summary>
        ///   低价
        /// </summary>
        public int Min { get; set; }
        /// <summary>
        ///   高价
        /// </summary>
        public int Max { get; set; }
    }
    /// <summary>
    ///   搜索命中数据
    /// </summary>
    public class HitResult
    {
        /// <summary>
        ///   商品id
        /// </summary>
        public string WareId { get; set; }
        /// <summary>
        ///   商品spuid
        /// </summary>
        public string WarePId { get; set; }
        /// <summary>
        ///   商品名称
        /// </summary>
        public string WareName { get; set; }


        /// <summary>
        ///   品牌id
        /// </summary>
        public string BrandId { get; set; }
        /// <summary>
        ///   品牌名称
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        ///   一级类目id
        /// </summary>
        public string Cid1 { get; set; }
        /// <summary>
        ///   一级分类名
        /// </summary>
        public object Cid1Name { get; set; }
        /// <summary>
        ///   二级类目id
        /// </summary>
        public string Cid2 { get; set; }
        /// <summary>
        ///   二级分类名
        /// </summary>
        public object Cid2Name { get; set; }
        /// <summary>
        ///   三级类目id
        /// </summary>
        public string CatId { get; set; }
        /// <summary>
        ///   三级分类名
        /// </summary>
        public object CatName { get; set; }

        /// <summary>
        ///   商品图片url
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        ///   上柜状态
        /// </summary>
        public string WState { get; set; }
        /// <summary>
        ///   商品状态
        /// </summary>
        public string WYN { get; set; }
        /// <summary>
        ///   商品同义词
        /// </summary>
        public string Synonyms { get; set; }
    }

    /// <summary>
    ///   扩展属性汇总
    /// </summary>
    public class ExpandAttrAggregate
    {
        /// <summary>
        ///   扩展属性ID
        /// </summary>
        public int ExpandSortId { get; set; }
        /// <summary>
        ///   扩展属性名称
        /// </summary>
        public string ExpandSortName { get; set; }
        /// <summary>
        ///   扩展属性集合
        /// </summary>
        public ExpandAttr[] ExpandAttrs { get; set; }
    }
    /// <summary>
    ///   扩展属性
    /// </summary>
    public class ExpandAttr
    {
        /// <summary>
        ///   扩展值Id
        /// </summary>
        public int ValueId { get; set; }
        /// <summary>
        ///   扩展值
        /// </summary>
        public string ValueName { get; set; }
    }

}
