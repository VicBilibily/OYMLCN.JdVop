using OYMLCN.JdVop.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        /// <summary>
        ///   预存款余额明细查询（不支持金采余额明细查询）。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="pageNum">分页查询当前页数，默认为1</param>
        /// <param name="pageSize">每页记录数，默认为20</param>
        /// <param name="orderId">订单号</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">截止日期</param>
        public static async Task<RspResult<BalanceDetail>> GetBalanceDetailAsync(string token,
            int pageNum = 1, int pageSize = 20, string orderId = null,
            DateTime? startDate = null, DateTime? endDate = null)
        {
            if (string.IsNullOrEmpty(token)) throw AccessTokenArgumentException;

            var parameter = new Dictionary<string, string>
            {
                { "token", token },
                { "pageNum", pageNum.ToString() },
                { "pageSize", pageSize.ToString() },
            };
            if (orderId is { Length: > 0 }) parameter.Add("orderId", orderId);
            if (startDate.HasValue) parameter.Add("startDate", startDate.Value.ToString("yyyyMMdd"));
            if (endDate.HasValue) parameter.Add("startDate", endDate.Value.ToString("yyyyMMdd"));

            var url = "/api/price/getBalanceDetail";
            return await PostAsync<BalanceDetail>(url, parameter);
        }
        /// <inheritdoc cref="GetBalanceDetailAsync(string, int, int, string, DateTime?, DateTime?)"/>
        public async Task<RspResult<BalanceDetail>> GetBalanceDetailAsync(
           int pageNum = 1, int pageSize = 20, string orderId = null,
           DateTime? startDate = null, DateTime? endDate = null)
           => await GetBalanceDetailAsync(this.AccessToken, pageNum, pageSize, orderId, startDate, endDate);
    }
}
