using OYMLCN.JdVop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        /// <summary>
        ///   获取京东预约日历。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="sku">商品和数量（最多支持50种商品）</param>
        /// <param name="paymentType">支付类型，合同上允许的支付类型都可以。</param>
        /// <param name="province">京东一级地址编号</param>
        /// <param name="city">京东二级地址编号</param>
        /// <param name="county">京东三级地址编号</param>
        /// <param name="town">京东四级地址编号（三级下无四级地址传0）</param>
        public static async Task<RspResult<PromiseCalendar>> PromiseCalendarAsync(string token, SkuNum[] sku, PaymentType paymentType, int province, int city, int county, int town = 0)
        {
            if (string.IsNullOrEmpty(token)) throw AccessTokenArgumentException;
          
            var parameter = new Dictionary<string, string>
            {
                { "token", token },
                { "sku", $"[{string.Join(',', sku.Select(v => v.ToString()))}]"},
                { "province", province.ToString() },
                { "city", city.ToString() },
                { "county", county.ToString() },
                { "town", town.ToString() },
                { "paymentType", ((int)paymentType).ToString() },
            };
            var url = "/api/order/promiseCalendar";
            return await PostAsync<PromiseCalendar>(url, parameter);
        }
        /// <inheritdoc cref="PromiseCalendarAsync(string, SkuNum[], PaymentType, int, int, int, int)"/>
        public async Task<RspResult<PromiseCalendar>> PromiseCalendarAsync(SkuNum[] sku, PaymentType paymentType, int province, int city, int county, int town = 0)
            => await PromiseCalendarAsync(this.AccessToken, sku, paymentType, province, city, county, town);
    }
}
