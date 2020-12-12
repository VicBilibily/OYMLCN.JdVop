using OYMLCN.JdVop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        /// <summary>
        ///   厂商直送订单可使用此接口确认收货并将订单置为完成状态。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="jdOrderId">订单号</param>
        public static async Task<RspResult<bool>> ConfirmReceivedAsync(string token, long jdOrderId)
        {
            if (string.IsNullOrEmpty(token)) throw AccessTokenArgumentException;

            var parameter = new Dictionary<string, string>
            {
                { "token", token },
                { "jdOrderId", jdOrderId.ToString() },
            };
            var url = "/api/order/confirmReceived";
            return await PostAsync<bool>(url, parameter);
        }
        /// <inheritdoc cref="ConfirmReceivedAsync(string, long)"/>
        public async Task<RspResult<bool>> OrderConfirmReceivedAsync(long jdOrderId)
            => await ConfirmReceivedAsync(this.AccessToken, jdOrderId);
    }
}
