using OYMLCN.JdVop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        /// <summary>
        ///   查询金采和预存款余额的余额。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="pin">京东PIN。必须是相同合同下的pin。</param>
        public static async Task<RspResult<UnionBalanceResult>> GetUnionBalanceAsync(string token, string pin)
        {
            if (string.IsNullOrEmpty(token)) throw AccessTokenArgumentException;
         
            var parameter = new Dictionary<string, string>
            {
                { "token", token },
                { "pin", pin },
                { "type", "1,2" },
            };
            var url = "/api/price/getUnionBalance";
            return await PostAsync<UnionBalanceResult>(url, parameter);
        }
        /// <inheritdoc cref="GetUnionBalanceAsync(string, string)"/>
        public async Task<RspResult<UnionBalanceResult>> GetUnionBalanceAsync(string pin)
            => await GetUnionBalanceAsync(this.AccessToken, pin);
    }
}
