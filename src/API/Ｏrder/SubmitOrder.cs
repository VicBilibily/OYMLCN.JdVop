using OYMLCN.JdVop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        /// <summary>
        ///   提交订单信息，生成京东订单。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="basic">用户订单基础信息</param>
        /// <param name="sku">订单商品列表</param>
        /// <param name="invoice">发票信息</param>
        /// <param name="reserving">配送预约信息</param>
        public static async Task<RspResult<OrderSubmitResult>> SubmitOrderAsync(string token, OrderBasic basic, OrderSku[] sku, OrderInvoice invoice, OrderReserving reserving = null)
        {
            if (string.IsNullOrEmpty(token)) throw AccessTokenArgumentException;

            var parameter = new Dictionary<string, string>
            {
                { "token", token },
                { "sku", $"[{string.Join(',', sku.Select(v => v.ToString()))}]"},
            };
            var union = parameter.Union(basic.KV);
            union = union.Union(invoice.KV);
            if (reserving != null)
                union = union.Union(reserving.KV);
            var url = "/api/order/submitOrder";
            return await PostAsync<OrderSubmitResult>(url, union.ToDictionary(v => v.Key, v => v.Value));
        }
        /// <inheritdoc cref="SubmitOrderAsync(string, OrderBasic, OrderSku[], OrderInvoice, OrderReserving)"/>
        public async Task<RspResult<OrderSubmitResult>> SubmitOrderAsync(OrderBasic basic, OrderSku[] sku, OrderInvoice invoice, OrderReserving reserving = null)
            => await SubmitOrderAsync(this.AccessToken, basic, sku, invoice, reserving);
    }
}
