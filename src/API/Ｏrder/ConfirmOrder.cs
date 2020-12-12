using OYMLCN.JdVop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        /// <summary>
        ///   确认预占库存订单。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="jdOrderId">京东订单号(父订单号)</param>
        public static async Task<RspResult<bool>> ConfirmOrderAsync(string token, long jdOrderId)
        {
            if (string.IsNullOrEmpty(token)) throw AccessTokenArgumentException;

            var parameter = new Dictionary<string, string>
            {
                { "token", token },
                { "jdOrderId", jdOrderId.ToString() },
            };
            var url = "/api/order/confirmOrder";
            return await PostAsync<bool>(url, parameter);
        }
        /// <inheritdoc cref="ConfirmOrderAsync(string, long)"/>
        public async Task<RspResult<bool>> ConfirmOrderAsync(long jdOrderId)
            => await ConfirmOrderAsync(this.AccessToken, jdOrderId);
    }
}
