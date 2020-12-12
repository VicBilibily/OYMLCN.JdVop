using OYMLCN.JdVop.Models;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        /// <summary>
        ///   查询京东订单信息。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="jdOrderId">京东订单号</param>
        /// <param name="queryExts">扩展参数(不提供时默认全部获取)</param>
        /// <param name="clientId">提供 <see cref="VopClient.ClientId"/> 以用于自动解密加密数据</param>
        public static async Task<RspResult<OrderDetail>> SelectJdOrderAsync(string token, long jdOrderId, string[] queryExts = null, string clientId = null)
        {
            if (string.IsNullOrEmpty(token)) throw AccessTokenArgumentException;

            var queryExtsStr = string.Join(',', queryExts ?? new string[] {
                "orderType",        // 订单类型
                "jdOrderState",     // 京东订单状态
                "name",             // 商品名称
                "address",          // 收件人地址
                "mobile",           // 手机号
                "poNo",             // 采购单号
                "finishTime",       // 订单完成时间
                "createOrderTime",  // 订单创建时间
                "paymentType",      // 订单支付类型
                "outTime",          // 订单出库时间
                "invoiceType",      // 订单发票类型
            });
            var parameter = new Dictionary<string, string>
            {
                { "token", token },
                { "jdOrderId", jdOrderId.ToString() },
                { "queryExts", queryExtsStr },
            };
            var url = "/api/order/selectJdOrder";
            var content = await PostAsync(url, parameter);
            using var stream = await content.ReadAsStreamAsync();
            var rsp = await JsonSerializer.DeserializeAsync<RspResult<JsonElement>>(stream, JsonSerializerOptions);
            var rst = new RspResult<OrderDetail>()
            {
                Success = rsp.Success,
                ResultCode = rsp.ResultCode,
                ResultMessage = rsp.ResultMessage,
            };
            if (rsp.Success)
            {
                var jsonElement = rsp.Result;
                stream.Position = 0;
                OrderDetail result;
                switch (jsonElement.GetProperty("type").GetInt32())
                {
                    case 1: // 父订单
                        result = (await JsonSerializer.DeserializeAsync<RspResult<OrderParent>>(stream, JsonSerializerOptions)).Result;
                        break;
                    case 2: // 子订单
                    default:
                        result = (await JsonSerializer.DeserializeAsync<RspResult<OrderDetail>>(stream, JsonSerializerOptions)).Result;
                        break;
                }

                if (clientId is { Length: > 6 })
                {
                    clientId = clientId.Substring(0, 6);
                    var nameKey = $"NA{clientId}";
                    var mobileKey = $"MO{clientId}";
                    var addressKey = $"AD{clientId}";
                    void Decrypt(OrderDetail detail)
                    {
                        if (detail == null) return;
                        if (detail.Name is { Length: > 0 })
                            try { detail.Name = DesDecrypt(detail.Name, nameKey); } catch { }
                        if (detail.Mobile is { Length: > 0 })
                            try { detail.Mobile = DesDecrypt(detail.Mobile, mobileKey); } catch { }
                        if (detail.Address is { Length: > 0 })
                            try { detail.Address = DesDecrypt(detail.Address, addressKey); } catch { }
                    }
                    Decrypt(result);
                    if (result.Type == 1)
                    {
                        var parent = result as OrderParent;
                        Decrypt(parent.POrder);
                        parent.COrder?.ForEach(Decrypt);
                    }
                }
                rst.Result = result;
            }
            return rst;
        }
        /// <inheritdoc cref="SelectJdOrderAsync(string, long, string[], string)"/>
        public async Task<RspResult<OrderDetail>> SelectJdOrderAsync(long jdOrderId, string[] queryExts = null, string clientId = null)
            => await SelectJdOrderAsync(this.AccessToken, jdOrderId, queryExts, clientId);
    }
}
