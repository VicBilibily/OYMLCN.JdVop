using OYMLCN.JdVop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        /// <summary>
        ///   厂商直送订单可使用此接口批量确认收货并将订单置为完成状态。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="jdOrderIds">京东子单号(最高支持50个订单)</param>
        public static async Task<RspResult<OrderBatchConfirmInfo[]>> BatchConfirmReceivedAsync(string token, params long[] jdOrderIds)
        {
            if (string.IsNullOrEmpty(token)) throw AccessTokenArgumentException;
           
            var parameter = new Dictionary<string, string>
            {
                { "token", token },
                { "jdOrderIds", string.Join(',', jdOrderIds?.Select(v=>v.ToString())) },
            };
            var url = "/api/order/batchConfirmReceived";
            return await PostAsync<OrderBatchConfirmInfo[]>(url, parameter);
        }
        /// <inheritdoc cref="BatchConfirmReceivedAsync(string, long[])"/>
        public async Task<RspResult<OrderBatchConfirmInfo[]>> BatchConfirmReceivedAsync(params long[] jdOrderIds)
            => await BatchConfirmReceivedAsync(this.AccessToken, jdOrderIds);
    }
}
