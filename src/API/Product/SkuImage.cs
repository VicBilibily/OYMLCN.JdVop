using OYMLCN.JdVop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        /// <summary>
        ///   查询单个商品的主图、轮播图。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="sku">商品编号(支持批量，最高支持100个商品)</param>
        public static async Task<RspResult<Dictionary<string, ProductImage[]>>> SkuImageAsync(string token, string sku)
        {
            if (string.IsNullOrEmpty(token)) throw AccessTokenArgumentException;

            var parameter = new Dictionary<string, string>
            {
                { "token", token },
                { "sku", sku },
            };
            var url = "/api/product/skuImage";
            return await PostAsync<Dictionary<string, ProductImage[]>>(url, parameter);
        }
        /// <inheritdoc cref="SkuImageAsync(string, string)"/>
        public async Task<RspResult<Dictionary<string, ProductImage[]>>> SkuImageAsync(string sku)
            => await SkuImageAsync(this.AccessToken, sku);
    }
}
