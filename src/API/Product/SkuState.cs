using OYMLCN.JdVop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        /// <summary>
        ///   查询商品的在主站商城上下架状态，此接口不校验是否存在于商品池中。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="sku">商品编号(支持批量，最高支持100个商品)</param>
        public static async Task<RspResult<ProductSkuState[]>> SkuStateAsync(string token, string sku)
        {
            if (string.IsNullOrEmpty(token)) throw AccessTokenArgumentException;

            var parameter = new Dictionary<string, string>
            {
                { "token", token },
                { "sku", sku },
            };
            var url = "/api/product/skuState";
            return await PostAsync<ProductSkuState[]>(url, parameter);
        }
        /// <inheritdoc cref="SkuStateAsync(string, string)"/>
        public async Task<RspResult<ProductSkuState[]>> SkuStateAsync(string sku)
            => await SkuStateAsync(this.AccessToken, sku);
    }
}
