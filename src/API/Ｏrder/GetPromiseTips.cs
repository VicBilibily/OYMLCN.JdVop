using OYMLCN.JdVop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        /// <summary>
        ///   查询商品配送预计送达时间，需结合商品实际情况。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="skuId">商品编号</param>
        /// <param name="num">数量</param>
        /// <param name="province">一级地址</param>
        /// <param name="city">二级地址</param>
        /// <param name="county">三级地址</param>
        /// <param name="town">四级地址ID（若三级地址下无四级地址传0）</param>
        public static async Task<RspResult<string>> GetPromiseTipsAsync(string token, long skuId, int num, int province, int city, int county, int town = 0)
        {
            if (string.IsNullOrEmpty(token)) throw AccessTokenArgumentException;

            var parameter = new Dictionary<string, string>
            {
                { "token", token },
                { "skuId", skuId.ToString() },
                { "num", num.ToString() },
                { "province", province.ToString() },
                { "city", city.ToString() },
                { "county", county.ToString() },
                { "town", town.ToString() },
            };
            var url = "/api/order/getPromiseTips";
            return await PostAsync<string>(url, parameter);
        }
        /// <inheritdoc cref="GetPromiseTipsAsync(string, long, int, int, int, int, int)"/>
        public async Task<RspResult<string>> GetPromiseTipsAsync(long skuId, int num, int province, int city, int county, int town = 0)
            => await GetPromiseTipsAsync(this.AccessToken, skuId, num, province, city, county, town);
    }
}
