using OYMLCN.JdVop.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        static async Task<RspResult<OrderCheckResult>> CheckOrderAsync(string token, string url,
            DateTime date, int pageNo = 1, int pageSize = 20,
            int? jdOrderIdIndex = null, DateTime? endDate = null)
        {
            if (string.IsNullOrEmpty(token)) throw AccessTokenArgumentException;

            var parameter = new Dictionary<string, string>
            {
                { "token", token },
                { "date", date.ToString("yyyy-MM-dd") },
                { "pageSize", pageSize.ToString() },
            };
            if (jdOrderIdIndex.HasValue)
                parameter.Add("jdOrderIdIndex", jdOrderIdIndex.ToString());
            else
                parameter.Add("pageNo", pageNo.ToString());
            if (endDate.HasValue)
                parameter.Add("endDate", endDate?.ToString("yyyy-MM-dd"));

            return await PostAsync<OrderCheckResult>(url, parameter);
        }

        /// <summary>
        ///   查询所有新建的订单列表。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="date">查询日期（不包含当天）</param>
        /// <param name="pageNo">页码，默认1</param>
        /// <param name="pageSize">页大小取值范围[1,100]，默认20</param>
        /// <param name="jdOrderIdIndex">最小订单号索引游标(规则参考文档)</param>
        /// <param name="endDate">结束日期</param>
        public static async Task<RspResult<OrderCheckResult>> CheckNewOrderAsync(string token,
            DateTime date, int pageNo = 1, int pageSize = 20,
            int? jdOrderIdIndex = null, DateTime? endDate = null)
        {
            var url = "/api/checkOrder/checkNewOrder";
            return await CheckOrderAsync(token, url, date, pageNo, pageSize, jdOrderIdIndex, endDate);
        }

        /// <summary>
        ///   查询所有妥投的订单列表。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="date">查询日期（不包含当天）</param>
        /// <param name="pageNo">页码，默认1</param>
        /// <param name="pageSize">页大小取值范围[1,100]，默认20</param>
        /// <param name="jdOrderIdIndex">最小订单号索引游标(规则参考文档)</param>
        /// <param name="endDate">结束日期</param>
        public static async Task<RspResult<OrderCheckResult>> CheckDlokOrderAsync(string token, 
            DateTime date, int pageNo = 1, int pageSize = 20,
            int? jdOrderIdIndex = null, DateTime? endDate = null)
        {
            var url = "/api/checkOrder/checkDlokOrder";
            return await CheckOrderAsync(token, url, date, pageNo, pageSize, jdOrderIdIndex, endDate);
        }

        /// <summary>
        ///   查询所有拒收的订单列表。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="date">查询日期（不包含当天）</param>
        /// <param name="pageNo">页码，默认1</param>
        /// <param name="pageSize">页大小取值范围[1,100]，默认20</param>
        /// <param name="jdOrderIdIndex">最小订单号索引游标(规则参考文档)</param>
        /// <param name="endDate">结束日期</param>
        public static async Task<RspResult<OrderCheckResult>> CheckRefuseOrderAsync(string token, 
            DateTime date, int pageNo = 1, int pageSize = 20,
            int? jdOrderIdIndex = null, DateTime? endDate = null)
        {
            var url = "/api/checkOrder/checkRefuseOrder";
            return await CheckOrderAsync(token, url, date, pageNo, pageSize, jdOrderIdIndex, endDate);
        }

        /// <summary>
        ///   查询所有完成的订单列表。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="date">查询日期（不包含当天）</param>
        /// <param name="pageNo">页码，默认1</param>
        /// <param name="pageSize">页大小取值范围[1,100]，默认20</param>
        /// <param name="jdOrderIdIndex">最小订单号索引游标(规则参考文档)</param>
        /// <param name="endDate">结束日期</param>
        public static async Task<RspResult<OrderCheckResult>> CheckCompleteOrderAsync(string token, 
            DateTime date, int pageNo = 1, int pageSize = 20,
            int? jdOrderIdIndex = null, DateTime? endDate = null)
        {
            var url = "/api/checkOrder/checkCompleteOrder";
            return await CheckOrderAsync(token, url, date, pageNo, pageSize, jdOrderIdIndex, endDate);
        }
    }
}
