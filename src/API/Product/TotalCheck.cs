using OYMLCN.JdVop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        /// <summary>
        ///   查询商品状态验证统一接口信息。
        ///   <para>商品可售验证+商品库存验证+商品有效性架接口+商品区域销售限制四个接口信息。</para>
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="skuNums">商品和数量（最多传入5条记录）</param>
        /// <param name="province">京东一级地址编号</param>
        /// <param name="city">京东二级地址编号</param>
        /// <param name="county">京东三级地址编号</param>
        /// <param name="town">京东四级地址编号（三级下无四级地址传0）</param>
        public static async Task<ProductTotalCheckResult> ProductTotalCheckAsync(string token, SkuNum[] skuNums, int province, int city, int county, int town = 0)
        {
            if (string.IsNullOrEmpty(token)) throw AccessTokenArgumentException;
           
            var queryExts = string.Join(',', new[] {
                "noReasonToReturn", // 无理由退货类型
                "thwa", // 无理由退货文案类型
                "isSelf", // 是否自营
                "isJDLogistics", // 是否京东配送
                "taxInfo", // 商品税率
            });
            var parameter = new Dictionary<string, string>
            {
                { "token", token },
                { "skuIds", string.Join(',', skuNums.Select(v=>v.SkuId.ToString())) },
                { "province", province.ToString() },
                { "city", city.ToString() },
                { "county", county.ToString() },
                { "town", town.ToString() },
                { "skuNums", $"[{string.Join(',', skuNums.Select(v => v.ToString()))}]" },
                { "queryExts", queryExts },
            };
            var url = "/api/product/totalCheck";
            var content = await PostAsync(url, parameter);
            return await content.ReadFromJsonAsync<ProductTotalCheckResult>(JsonSerializerOptions);
        }
        /// <inheritdoc cref="ProductTotalCheckAsync(string, SkuNum[], int, int, int, int)"/>
        public async Task<ProductTotalCheckResult> ProductTotalCheckAsync(SkuNum[] skuNums, int province, int city, int county, int town = 0)
            => await ProductTotalCheckAsync(this.AccessToken, skuNums, province, city, county, town);
    }
}
