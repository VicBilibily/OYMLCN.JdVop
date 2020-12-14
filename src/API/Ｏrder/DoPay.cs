using OYMLCN.JdVop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        /// <summary>
        ///   下单成功支付失败的情况，可以调用此接口重新支付（此接口在特殊场景使用）
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="jdOrderId">京东系统订单号</param>
        public async Task<RspResult<bool>> DoPayAsync(string token, string jdOrderId)
        {
            if (string.IsNullOrEmpty(token)) throw AccessTokenArgumentException;

            var parameter = new Dictionary<string, string>
            {
                { "token", this.AccessToken },
                { "jdOrderId", jdOrderId },
            };
            var url = "/api/order/doPay";
            return await PostAsync<bool>(url, parameter);
        }
        /// <inheritdoc cref="DoPayAsync(string, string)"/>
        public async Task<RspResult<bool>> DoPayAsync(string jdOrderId)
            => await DoPayAsync(this.AccessToken, jdOrderId);
    }
}
