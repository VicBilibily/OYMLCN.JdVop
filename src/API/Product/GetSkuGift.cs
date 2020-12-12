using OYMLCN.JdVop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        /// <summary>
        ///   查询主商品附带的赠品或者附件。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="skuId">商品编号，只支持单个查询</param>
        /// <param name="province">京东一级地址编号</param>
        /// <param name="city">京东二级地址编号</param>
        /// <param name="county">京东三级地址编号</param>
        /// <param name="town">京东四级地址编号（三级下无四级地址传0）</param>
        public static async Task<RspResult<ProductSkuGift>> ProductGetSkuGiftAsync(string token, string skuId, int province, int city, int county, int town = 0)
        {
            if (string.IsNullOrEmpty(token)) throw AccessTokenArgumentException;

            var parameter = new Dictionary<string, string>
            {
                { "token", token },
                { "skuId", skuId },
                { "province", province.ToString() },
                { "city", city.ToString() },
                { "county", county.ToString() },
                { "town", town.ToString() },
            };
            var url = "/api/product/getSkuGift";
            return await PostAsync<ProductSkuGift>(url, parameter);
        }
        /// <inheritdoc cref="ProductGetSkuGiftAsync(string, string, int, int, int, int)"/>
        public async Task<RspResult<ProductSkuGift>> ProductGetSkuGiftAsync(string skuId, int province, int city, int county, int town = 0)
            => await ProductGetSkuGiftAsync(this.AccessToken, skuId, province, city, county, town);
    }
}
