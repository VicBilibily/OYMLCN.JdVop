using OYMLCN.JdVop.Models;
using System;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        /// <inheritdoc cref="CheckNewOrderAsync(string, DateTime, int, int, int?, DateTime?)"/>
        public async Task<RspResult<OrderCheckResult>> CheckNewOrderAsync(
            DateTime date, int pageNo = 1, int pageSize = 20,
            int? jdOrderIdIndex = null, DateTime? endDate = null)
            => await CheckNewOrderAsync(this.AccessToken, date, pageNo, pageSize, jdOrderIdIndex, endDate);

        /// <inheritdoc cref="CheckDlokOrderAsync(string, DateTime, int, int, int?, DateTime?)"/>
        public async Task<RspResult<OrderCheckResult>> CheckDlokOrderAsync(
            DateTime date, int pageNo = 1, int pageSize = 20,
            int? jdOrderIdIndex = null, DateTime? endDate = null)
            => await CheckDlokOrderAsync(this.AccessToken, date, pageNo, pageSize, jdOrderIdIndex, endDate);

        /// <inheritdoc cref="CheckRefuseOrderAsync(string, DateTime, int, int, int?, DateTime?)"/>
        public async Task<RspResult<OrderCheckResult>> CheckRefuseOrderAsync(
            DateTime date, int pageNo = 1, int pageSize = 20,
            int? jdOrderIdIndex = null, DateTime? endDate = null)
            => await CheckRefuseOrderAsync(this.AccessToken, date, pageNo, pageSize, jdOrderIdIndex, endDate);

        /// <inheritdoc cref="CheckCompleteOrderAsync(string, DateTime, int, int, int?, DateTime?)"/>
        public async Task<RspResult<OrderCheckResult>> CheckCompleteOrderAsync(
            DateTime date, int pageNo = 1, int pageSize = 20,
            int? jdOrderIdIndex = null, DateTime? endDate = null)
            => await CheckCompleteOrderAsync(this.AccessToken, date, pageNo, pageSize, jdOrderIdIndex, endDate);
    }
}
