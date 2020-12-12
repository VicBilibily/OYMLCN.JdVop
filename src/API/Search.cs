using OYMLCN.JdVop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        /// <summary>
        ///   根据搜索条件查询符合要求的商品列表。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="keyword">搜索关键字</param>
        /// <param name="catId">分类Id, 只支持三级类目Id</param>
        /// <param name="pageIndex">当前第几页</param>
        /// <param name="pageSize">当前页显示</param>
        /// <param name="min">价格区间搜索，低价</param>
        /// <param name="max">价格区间搜索，高价</param>
        /// <param name="brands">品牌搜索（多个品牌以逗号分隔,）</param>
        /// <param name="cid1">一级分类</param>
        /// <param name="cid2">二级分类</param>
        /// <param name="sortType">结果降序</param>
        /// <param name="priceCol">价格汇总</param>
        /// <param name="extAttrCol">扩展属性汇总</param>
        /// <param name="areaIds">查询库存的省市区县ID（以逗号分隔,[如:1,2810,51081]）</param>
        public static async Task<RspResult<SearchResult>> SearchAsync(string token,
            string keyword = default, int? catId = default,
            int? pageIndex = default, int? pageSize = default,
            decimal? min = default, decimal? max = default, string brands = default,
            int? cid1 = default, int? cid2 = default, SearchSort? sortType = default,
            bool priceCol = false, bool extAttrCol = false, string areaIds = default)
        {
            if (string.IsNullOrEmpty(token)) throw AccessTokenArgumentException;

            var parameter = new Dictionary<string, string>
            { { "token", token } };
            if (!string.IsNullOrWhiteSpace(keyword)) parameter.Add(nameof(keyword), keyword);
            if (catId.HasValue) parameter.Add(nameof(catId), catId.ToString());
            if (pageIndex.HasValue) parameter.Add(nameof(pageIndex), pageIndex.ToString());
            if (pageSize.HasValue) parameter.Add(nameof(pageSize), pageSize.ToString());
            if (min.HasValue) parameter.Add(nameof(min), min.ToString());
            if (max.HasValue) parameter.Add(nameof(max), max.ToString());
            if (!string.IsNullOrWhiteSpace(brands)) parameter.Add(nameof(brands), brands);
            if (cid1.HasValue) parameter.Add(nameof(cid1), cid1.ToString());
            if (cid2.HasValue) parameter.Add(nameof(cid2), cid2.ToString());
            if (sortType.HasValue) parameter.Add(nameof(sortType), sortType.ToString());
            if (priceCol) parameter.Add(nameof(priceCol), "yes");
            if (extAttrCol) parameter.Add(nameof(extAttrCol), "yes");
            if (!string.IsNullOrWhiteSpace(areaIds))
            {
                parameter.Add(nameof(areaIds), areaIds);
                parameter.Add("redisStore", "true");
            }
            var url = "/api/search/search";
            return await PostAsync<SearchResult>(url, parameter);
        }
        /// <inheritdoc cref="SearchAsync(string, string, int?, int?, int?, decimal?, decimal?, string, int?, int?, SearchSort?, bool, bool, string)"/>
        public async Task<RspResult<SearchResult>> SearchAsync(
            string keyword = default, int? catId = default,
            int? pageIndex = default, int? pageSize = default,
            decimal? min = default, decimal? max = default, string brands = default,
            int? cid1 = default, int? cid2 = default, SearchSort? sortType = default,
            bool priceCol = false, bool extAttrCol = false, string areaIds = default)
            => await SearchAsync(this.AccessToken, keyword, catId,
                pageIndex, pageSize,
                min, max, brands,
                cid1, cid2, sortType,
                priceCol, extAttrCol, areaIds);
    }
}
