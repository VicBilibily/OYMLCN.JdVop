using OYMLCN.JdVop.Models;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions.Ordering;

namespace OYMLCN.JdVop.Test
{
    public partial class JdVopApiTest
    {
        [Trait("xUnit", "5、价格API接口")]
        [Fact(DisplayName = "5.1 查询商品售卖价"), Order(5010)]
        public async Task GetSellPriceTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.GetSellPriceAsync(null, null));

            var sku = $"{TestHelper.SkuNormal1},{TestHelper.SkuNormal2}";
            var res = await ApiInstance.GetSellPriceAsync(sku);
            Assert.True(res.Success, res.ResultMessage);
            var result = res.Result;
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }


        [Trait("xUnit", "8、支付API接口")]
        [Fact(DisplayName = "8.1 查询余额"), Order(8010)]
        public async Task GetUnionBalanceTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.GetUnionBalanceAsync(null, null));

            var pin = TestHelper.VopClient.UserName;
            var res = await ApiInstance.GetUnionBalanceAsync(pin);
            Assert.True(res.Success, res.ResultMessage);
            var result = res.Result;
            Assert.NotNull(result);
            Assert.NotNull(result.Balance);
            Assert.Equal(result.Balance.Pin, pin);
            //测试帐号无金采权限时不返回geious内容
            //Assert.NotNull(result.Geious);
            //Assert.Equal(result.Geious.PIN, pin);
        }

        [Trait("xUnit", "8、支付API接口")]
        [Fact(DisplayName = "8.2 查询余额变动明细"), Order(8020)]
        public async Task GetBalanceDetailTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.GetBalanceDetailAsync(null));

            //测试账号采用对公转账模式，没有余额相关内容
            var res = await ApiInstance.GetBalanceDetailAsync();
            Assert.NotNull(res);
            var result = res.Result;
            Assert.NotNull(result);

            //使用测试JSON验证反序列化结果
            var demoJson = "{\"success\":true,\"resultMessage\":\"操作成功\",\"resultCode\":\"0000\",\"result\":{\"total\":281,\"pageSize\":20,\"pageNo\":1,\"pageCount\":15,\"data\":[{\"id\":2427064792,\"accountType\":1,\"amount\":-1,\"pin\":\"测试y\",\"orderId\":\"84567164608\",\"tradeType\":1209,\"tradeTypeName\":\"实物/礼品卡余额支付\",\"createdDate\":\"2019-01-04 12:44:58\",\"notePub\":\"订单:84567164608,消费余额：1\",\"tradeNo\":3429237517},{\"id\":2417527803,\"accountType\":1,\"amount\":1,\"pin\":\"测试y\",\"orderId\":\"84079230412\",\"tradeType\":758,\"tradeTypeName\":\"余额支付\",\"createdDate\":\"2018-12-27 14:07:06\",\"notePub\":\"订单84079230412退款为京东余额\",\"tradeNo\":3420482480}]}}";
            var demo = JsonSerializer.Deserialize<RspResult<BalanceDetail>>(demoJson, JdVopApi.JsonSerializerOptions);
            result = demo.Result;
            Assert.NotNull(result);
            Assert.NotEmpty(result.Data);
        }

    }
}
