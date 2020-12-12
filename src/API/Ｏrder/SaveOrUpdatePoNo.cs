using OYMLCN.JdVop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        /// <summary>
        ///   更新订单上的PO单号。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="jdOrderId">订单号</param>
        /// <param name="poNo">采购单号</param>
        public static async Task<RspResult<bool>> SaveOrUpdatePoNoAsync(string token, long jdOrderId, string poNo)
        {
            if (string.IsNullOrEmpty(token)) throw AccessTokenArgumentException;

            var parameter = new Dictionary<string, string>
            {
                { "token", token },
                { "jdOrderId", jdOrderId.ToString() },
                { "poNo", poNo },
            };
            var url = "/api/order/saveOrUpdatePoNo";
            return await PostAsync<bool>(url, parameter);
        }
        /// <inheritdoc cref="SaveOrUpdatePoNoAsync(string, long, string)"/>
        public async Task<RspResult<bool>> OrderSaveOrUpdatePoNoAsync(long jdOrderId, string poNo)
            => await SaveOrUpdatePoNoAsync(this.AccessToken, jdOrderId, poNo);
    }
}
