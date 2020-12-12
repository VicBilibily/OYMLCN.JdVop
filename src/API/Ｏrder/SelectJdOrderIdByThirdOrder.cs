using OYMLCN.JdVop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        /// <summary>
        ///   订单反查接口，根据第三方订单号反查京东的订单号。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="thirdOrder">第三方订单号</param>
        /// <returns>京东的订单号</returns>
        public static async Task<RspResult<string>> SelectJdOrderIdByThirdOrderAsync(string token, string thirdOrder)
        {
            if (string.IsNullOrEmpty(token)) throw AccessTokenArgumentException;

            var parameter = new Dictionary<string, string>
            {
                { "token", token },
                { "thirdOrder", thirdOrder },
            };
            var url = "/api/order/selectJdOrderIdByThirdOrder";
            return await PostAsync<string>(url, parameter);
        }
        /// <inheritdoc cref="SelectJdOrderIdByThirdOrderAsync(string, string)"/>
        public async Task<RspResult<string>> SelectJdOrderIdByThirdOrderAsync(string thirdOrder)
            => await SelectJdOrderIdByThirdOrderAsync(this.AccessToken, thirdOrder);
    }
}
