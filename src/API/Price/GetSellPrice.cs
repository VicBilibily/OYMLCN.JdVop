using OYMLCN.JdVop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        /// <summary>
        ///   批量查询商品售卖价。查询在客户商品池中的商品价格。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="sku">商品编号（最高支持100个商品）</param>
        public static async Task<RspResult<SellPrice[]>> GetSellPriceAsync(string token, string sku)
        {
            if (string.IsNullOrEmpty(token)) throw AccessTokenArgumentException;

            var queryExts = string.Join(',', new[] {
                "price", //大客户默认价格(根据合同类型查询价格)。
                "marketPrice", //市场价。
                "containsTax", //税率。出参增加tax,taxPrice,nakedPrice 3个字段。
                //"nakedPrice", //未税价。出参增加nakedPrice字段(加此入参时，出参price也是未税价，此时price=nakedPrice，那返回的price值无获取意义，拓展参数不建议加此字段)
            });
            var parameter = new Dictionary<string, string>
            {
                { "token", token },
                { "sku", sku },
                { "queryExts", queryExts },
            };
            var url = "/api/price/getSellPrice";
            return await PostAsync<SellPrice[]>(url, parameter);
        }
        /// <inheritdoc cref="GetSellPriceAsync(string, string)"/>
        public async Task<RspResult<SellPrice[]>> GetSellPriceAsync(string sku)
            => await GetSellPriceAsync(this.AccessToken, sku);
    }
}
