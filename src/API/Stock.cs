using OYMLCN.JdVop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        /// <summary>
        ///   批量获取库存接口。批量查询在客户指定区域的库存信息，最多返回数量50，超过100统一返回有货。
        ///   <para>实际库存为50--100，但用户查询数量大于真实库存数量时显示“无货”，小于等于真实库存数量时显示“有货”。</para>
        ///   <para>举例：实际库存58；用户用59-100查的时候返回无货，1-58查的时候返回有货；实际库存超过100时，查询数量写多少都会返回有货。</para>
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="skuNums">商品和数量（最多传入5条记录）</param>
        /// <param name="province">京东一级地址编号</param>
        /// <param name="city">京东二级地址编号</param>
        /// <param name="county">京东三级地址编号</param>
        /// <param name="town">京东四级地址编号（三级下无四级地址传0）</param>
        public static async Task<RspResult<StockResult[]>> GetNewStockByIdAsync(string token, SkuNum[] skuNums, int province, int city, int county, int town = 0)
        {
            if (string.IsNullOrEmpty(token)) throw AccessTokenArgumentException;

            var parameter = new Dictionary<string, string>
            {
                { "token", token },
                { "skuNums", $"[{string.Join(',', skuNums.Select(v => v.ToString()))}]" },
                { "area", $"{province}_{city}_{county}_{town}" },
            };
            var url = "/api/stock/getNewStockById";
            var rsp = await PostAsync<string>(url, parameter);
            var result = new RspResult<StockResult[]>()
            {
                Success = rsp.Success,
                ResultCode = rsp.ResultCode,
                ResultMessage = rsp.ResultMessage,
            };
            if (rsp.Success)
                result.Result = JsonSerializer.Deserialize<StockResult[]>(rsp.Result, JsonSerializerOptions);
            return result;
        }
        /// <inheritdoc cref="GetNewStockByIdAsync(string, SkuNum[], int, int, int, int)"/>
        public async Task<RspResult<StockResult[]>> GetNewStockByIdAsync(SkuNum[] skuNums, int province, int city, int county, int town = 0)
            => await GetNewStockByIdAsync(this.AccessToken, skuNums, province, city, county, town);
    }
}
