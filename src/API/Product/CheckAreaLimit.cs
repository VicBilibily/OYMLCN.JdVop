using OYMLCN.JdVop.Models;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        /// <summary>
        ///   查询商品在特定区域是否可售。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="skuIds">商品编号 (最高支持100个商品)</param>
        /// <param name="province">京东一级地址编号</param>
        /// <param name="city">京东二级地址编号</param>
        /// <param name="county">京东三级地址编号</param>
        /// <param name="town">京东四级地址编号（三级下无四级地址传0）</param>
        public static async Task<RspResult<ProductAreaLimit[]>> ProductCheckAreaLimitAsync(string token, string skuIds, int province, int city, int county, int town = 0)
        {
            if (string.IsNullOrEmpty(token)) throw AccessTokenArgumentException;

            var parameter = new Dictionary<string, string>
            {
                { "token", token },
                { "skuIds", skuIds },
                { "province", province.ToString() },
                { "city", city.ToString() },
                { "county", county.ToString() },
                { "town", town.ToString() },
            };
            var url = "/api/product/checkAreaLimit";
            var rsp = await PostAsync<string>(url, parameter);
            var result = new RspResult<ProductAreaLimit[]>()
            {
                Success = rsp.Success,
                ResultCode = rsp.ResultCode,
                ResultMessage = rsp.ResultMessage,
            };
            if (rsp.Success)
                result.Result = JsonSerializer.Deserialize<ProductAreaLimit[]>(rsp.Result, JsonSerializerOptions);
            return result;
        }
        /// <inheritdoc cref="ProductCheckAreaLimitAsync(string, string, int, int, int, int)"/>
        public async Task<RspResult<ProductAreaLimit[]>> ProductCheckAreaLimitAsync(string skuIds, int province, int city, int county, int town = 0)
            => await ProductCheckAreaLimitAsync(this.AccessToken, skuIds, province, city, county, town);
    }
}
