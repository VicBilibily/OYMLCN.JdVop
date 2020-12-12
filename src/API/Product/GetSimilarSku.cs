using OYMLCN.JdVop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        /// <summary>
        ///   查询被指定为同一类的商品，如同一款式不同颜色的商品，需要注意符合此条件的商品并不一定被指定为同类商品。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="skuId">商品编码</param>
        public static async Task<RspResult<ProductSimilarSku[]>> ProductGetSimilarSkuAsync(string token, string skuId)
        {
            if (string.IsNullOrEmpty(token)) throw AccessTokenArgumentException;

            var parameter = new Dictionary<string, string>
            {
                { "token", token },
                { "skuId", skuId },
            };
            var url = "/api/product/getSimilarSku";
            return await PostAsync<ProductSimilarSku[]>(url, parameter);
        }
        /// <inheritdoc cref="ProductGetSimilarSkuAsync(string, string)"/>
        public async Task<RspResult<ProductSimilarSku[]>> ProductGetSimilarSkuAsync(string skuId)
            => await ProductGetSimilarSkuAsync(this.AccessToken, skuId);
    }
}
