using OYMLCN.JdVop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        /// <summary>
        ///   查询配送信息。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="jdOrderId">京东订单ID</param>
        /// <param name="waybillCode">是否返回订单的配送信息</param>
        public static async Task<RspResult<OrderTrackResult>> OrderTrackAsync(string token, long jdOrderId, bool waybillCode = false)
        {
            if (string.IsNullOrEmpty(token)) throw AccessTokenArgumentException;

            var parameter = new Dictionary<string, string>
            {
                { "token", token },
                { "jdOrderId", jdOrderId.ToString() },
                { "waybillCode", waybillCode?"1":"0" },
            };
            var url = "/api/order/orderTrack";
            return await PostAsync<OrderTrackResult>(url, parameter);
        }
        /// <inheritdoc cref="OrderTrackAsync(string, long, bool)"/>
        public async Task<RspResult<OrderTrackResult>> OrderTrackAsync(long jdOrderId, bool waybillCode = false)
            => await OrderTrackAsync(this.AccessToken, jdOrderId, waybillCode);
    }
}
