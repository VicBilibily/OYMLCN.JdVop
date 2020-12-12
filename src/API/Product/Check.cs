using OYMLCN.JdVop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        /// <summary>
        ///   查询商品可售性、是否支持专票等影响销售的重要属性。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="skuIds">商品编号 (最高支持100个商品)</param>
        public static async Task<RspResult<ProductCheck[]>> ProductCheckAsync(string token, string skuIds)
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
                { "skuIds", skuIds },
                { "queryExts", queryExts },
            };
            var url = "/api/product/check";
            return await PostAsync<ProductCheck[]>(url, parameter);
        }
        /// <inheritdoc cref="ProductCheckAsync(string, string)"/>
        public async Task<RspResult<ProductCheck[]>> ProductCheckAsync(string skuIds)
            => await ProductCheckAsync(this.AccessToken, skuIds);
    }
}
