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
        [Trait("xUnit", "7、订单API接口")]
        [Fact(DisplayName = "7.1 查询运费"), Order(7010)]
        public async Task GetFreightTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.GetFreightAsync(null, default, default, 0, 0, 0, 0));

            var sku = new SkuNum[]{
                new (long.Parse(TestHelper.SkuNormal1), 2),
                new (long.Parse(TestHelper.SkuNormal2), 1),
            };
            var jdAddr = TestHelper.JDArress;
            var paymentType = PaymentType.Transfer; // 测试仅签约开通转账方式
            var res = await ApiInstance.GetFreightAsync(sku, paymentType, jdAddr.ProvinceId, jdAddr.CityId, jdAddr.CountyId, jdAddr.TownId.Value);
            Assert.True(res.Success, res.ResultMessage);
            var result = res.Result;
            Assert.NotNull(result);

            sku = new SkuNum[] {
                new (long.Parse(TestHelper.SkuHeightWeight), 1),
            };
            res = await ApiInstance.GetFreightAsync(sku, paymentType, jdAddr.ProvinceId, jdAddr.CityId, jdAddr.CountyId, jdAddr.TownId.Value);
            Assert.True(res.Success, res.ResultMessage);
            result = res.Result;
            Assert.NotNull(result);
            Assert.True(result.Freight > 0);
        }

        [Trait("xUnit", "7、订单API接口")]
        [Fact(DisplayName = "7.2 查询预约日历"), Order(7020)]
        public async Task PromiseCalendarTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.PromiseCalendarAsync(null, default, default, 0, 0, 0, 0));

            var sku = new SkuNum[]{
                new (long.Parse(TestHelper.SkuNormal1), 2),
                new (long.Parse(TestHelper.SkuNormal3), 1),
            };
            var jdAddr = TestHelper.JDArress;
            var paymentType = PaymentType.Transfer; // 测试仅签约开通转账方式
            var res = await ApiInstance.PromiseCalendarAsync(sku, paymentType, jdAddr.ProvinceId, jdAddr.CityId, jdAddr.CountyId, jdAddr.TownId.Value);
            Assert.True(res.Success, res.ResultMessage);
            var result = res.Result;
            Assert.NotNull(result); // 返回的JSON能够反序列化成功
        }

        [Trait("xUnit", "7、订单API接口")]
        [Fact(DisplayName = "7.3 提交订单", Skip = "手动测试，会提交订单"), Order(7030)]
        public async Task SubmitOrderTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.SubmitOrderAsync(null, default, default, default, default));

            var skuId = long.Parse(TestHelper.OrderSku2);
            var sku = new OrderSku[]
            {
                //new (long.Parse(TestHelper.OrderSku1), 2, TestHelper.OrderSku1Price),
                new (skuId, 1, TestHelper.OrderSku2Price),
                //new (long.Parse(TestHelper.OrderSku3), 1, TestHelper.OrderSku3Price),
                //new (long.Parse(TestHelper.OrderSku4), 1, TestHelper.OrderSku4Price),
            };
            var orderNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            TestHelper.OrderSubmitNo = orderNo;
            var name = "xUnitTest";
            var jdAddr = TestHelper.JDArress;
            var address = "xUnit单元测试";
            var mobile = "13800138000";

            var orderBasic = new OrderBasic(orderNo, PaymentType.Transfer, name, mobile,
                jdAddr.ProvinceId, jdAddr.CityId, jdAddr.CountyId, jdAddr.TownId.Value, address);
            var orderInvoice = new OrderInvoice(
                InvoiceState.Centralized, InvoiceType.EInvoice,
                InvoiceTitle.Personal, InvoiceContent.Major,
                mobile, name, string.Empty, name);

            var res = await ApiInstance.SubmitOrderAsync(orderBasic, sku, orderInvoice);
            Assert.True(res.Success, res.ResultMessage);
            var result = res.Result;
            Assert.NotNull(result);
            TestHelper.JdOrderNo = result.JdOrderId;
            Assert.Equal(TestHelper.OrderSku2Price, result.OrderPrice);
            Assert.NotEmpty(result.SKU);
            Assert.Contains(result.SKU, v => v.SkuId == skuId);
        }

        [Trait("xUnit", "7、订单API接口")]
        [Fact(DisplayName = "7.4 反查订单"), Order(7040)]
        public async Task SelectJdOrderIdByThirdOrderTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.SelectJdOrderIdByThirdOrderAsync(null, default));

            var orderNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            var res = await ApiInstance.SelectJdOrderIdByThirdOrderAsync(orderNo);
            Assert.False(res.Success, res.ResultMessage);

            if (TestHelper.OrderSubmitNo is { Length: > 0 })
            {
                res = await ApiInstance.SelectJdOrderIdByThirdOrderAsync(TestHelper.OrderSubmitNo);
                Assert.True(res.Success, res.ResultMessage);
                Assert.Equal(TestHelper.JdOrderNo.ToString(), res.Result);
            }
        }

        [Trait("xUnit", "7、订单API接口")]
        [Theory(DisplayName = "7.5 确认预占库存订单"), Order(7050)]
        [InlineData(133724048178)]
        public async Task ConfirmOrderTest(long jdOrderNo)
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.ConfirmOrderAsync(null, default));

            var res = await ApiInstance.ConfirmOrderAsync(jdOrderNo);
            Assert.True(res.Success, res.ResultMessage);
            Assert.True(res.Result);
        }

        [Trait("xUnit", "7、订单API接口")]
        [Theory(DisplayName = "7.6 取消未确认订单", Skip = "请更改单号后测试"), Order(7060)]
        [InlineData(133726939870)]
        public async Task OrderCancelTest(long jdOrderNo)
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.OrderCancelAsync(null, default));

            var res = await ApiInstance.OrderCancelAsync(jdOrderNo);
            Assert.True(res.Success, res.ResultMessage);
            Assert.True(res.Result);
        }

        [Trait("xUnit", "7、订单API接口")]
        [Theory(DisplayName = "7.7 查询订单详情"), Order(7070)]
        [InlineData(TestHelper.JdOrderNo_Test)]
        public async Task SelectJdOrderTest(long jdOrderNo)
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.SelectJdOrderAsync(null, default));

            var res = await ApiInstance.SelectJdOrderAsync(jdOrderNo, clientId: TestHelper.VopClient.ClientId);
            Assert.True(res.Success, res.ResultMessage);
            var result = res.Result;
            Assert.Equal("xUnitTest", result.Name);
            Assert.Equal("13800138000", result.Mobile);
            Assert.EndsWith("xUnit单元测试", result.Address);

            var demoJson = "{\"success\":true,\"resultMessage\":\"\",\"resultCode\":\"0000\",\"result\":{\"pOrder\":0,\"orderState\":1,\"orderType\":1,\"jdOrderId\":86403369569,\"state\":1,\"submitState\":1,\"type\":2,\"sku\":[{\"category\":12347,\"num\":1,\"price\":\"137.21\",\"tax\":16,\"oid\":0,\"name\":\"小米（MI）小米手环3 智能运动 心率监测 智能提醒 睡眠监测 计步 触摸大屏 50米防水\",\"taxPrice\":21.95,\"skuId\":7545792,\"nakedPrice\":137.21,\"type\":0}],\"jdOrderState\":19,\"poNo\":\"11\",\"address\":\"1ca6528da73a6b3f03fb8823c569da1fd6f4e7fd8461a36b5447f5b691f0eec236f6902e754bb41d6dd2cf19fded831758435427c0ea4d1cc639f287350c545960868ca9ab66a8cc16b9bab6581ae05576636418132bcedd\",\"name\":\"913594afd1079ebd07224a1c1024cd31\",\"freight\":0,\"orderPrice\":159.16,\"orderNakedPrice\":137.21,\"orderTaxPrice\":21.95,\"mobile\":\"f796fcc9978f7c95c0518373d38eb2a5\"}}";
            var demoDetail = JsonSerializer.Deserialize<RspResult<OrderDetail>>(demoJson, JdVopApi.JsonSerializerOptions);
            Assert.NotNull(demoDetail);
            demoJson = "{\"success\":true,\"resultMessage\":\"\",\"resultCode\":\"0000\",\"result\":{\"pOrder\":{\"jdOrderId\":82439393004,\"freight\":0,\"orderPrice\":99.76,\"orderNakedPrice\":86,\"sku\":[{\"category\":760,\"num\":1,\"price\":98.6,\"tax\":16,\"oid\":0,\"name\":\"美的（Midea）电水壶热水壶电热水壶304不锈钢1.7L容量 双层防烫全钢无缝烧水壶WH517E2b\",\"taxPrice\":13.6,\"skuId\":1072238,\"nakedPrice\":85,\"type\":0},{\"category\":2603,\"num\":1,\"price\":1.16,\"tax\":16,\"oid\":0,\"name\":\"齐心(Comix)0.5mm黑色耐用型中性台笔 柜台粘帖台式中性笔 办公文具 GP308\",\"taxPrice\":0.16,\"skuId\":614907,\"nakedPrice\":1,\"type\":0}],\"orderTaxPrice\":13.76},\"orderState\":1,\"cOrder\":[{\"pOrder\":82439393004,\"orderState\":1,\"jdOrderId\":82439212677,\"state\":1,\"freight\":0,\"submitState\":1,\"orderPrice\":98.6,\"orderNakedPrice\":85,\"type\":2,\"sku\":[{\"category\":760,\"num\":1,\"price\":98.6,\"tax\":16,\"oid\":0,\"name\":\"美的（Midea）电水壶热水壶电热水壶304不锈钢1.7L容量 双层防烫全钢无缝烧水壶WH517E2b\",\"taxPrice\":13.6,\"skuId\":1072238,\"nakedPrice\":85,\"type\":0}],\"orderTaxPrice\":13.6},{\"pOrder\":82439393004,\"orderState\":1,\"jdOrderId\":82437660963,\"state\":1,\"freight\":0,\"submitState\":1,\"orderPrice\":1.16,\"orderNakedPrice\":1,\"type\":2,\"sku\":[{\"category\":2603,\"num\":1,\"price\":1.16,\"tax\":16,\"oid\":0,\"name\":\"齐心(Comix)0.5mm黑色耐用型中性台笔 柜台粘帖台式中性笔 办公文具 GP308\",\"taxPrice\":0.16,\"skuId\":614907,\"nakedPrice\":1,\"type\":0}],\"orderTaxPrice\":0.16}],\"submitState\":1,\"type\":1}}";
            var demoParent = JsonSerializer.Deserialize<RspResult<OrderParent>>(demoJson, JdVopApi.JsonSerializerOptions);
            Assert.NotNull(demoParent);
        }

        [Trait("xUnit", "7、订单API接口")]
        [Theory(DisplayName = "7.8 查询配送信息"), Order(7080)]
        [InlineData(TestHelper.JdOrderNo_Test)]
        public async Task OrderTrackTest(long jdOrderNo)
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.OrderTrackAsync(null, default));

            var res = await ApiInstance.OrderTrackAsync(jdOrderNo);
            Assert.True(res.Success, res.ResultMessage);
            var result = res.Result;
            Assert.NotNull(result);
            Assert.NotEmpty(result.OrderTrack);
            Assert.Null(result.WaybillCode);
            Assert.Equal(jdOrderNo, result.JdOrderId);

            res = await ApiInstance.OrderTrackAsync(jdOrderNo, true);
            Assert.True(res.Success, res.ResultMessage);
            result = res.Result;
            Assert.NotNull(result);
            Assert.NotEmpty(result.OrderTrack);
            Assert.NotEmpty(result.WaybillCode);
            Assert.Equal(jdOrderNo, result.WaybillCode[0].OrderId);
        }

        [Trait("xUnit", "7、订单API接口")]
        [Theory(DisplayName = "7.9 确认收货", Skip = "仅已发货的第三方订单可操作"), Order(7090)]
        [InlineData(133724048188)]
        public async Task ConfirmReceivedTest(long jdOrderNo)
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.ConfirmReceivedAsync(null, default));

            var res = await ApiInstance.ConfirmReceivedAsync(jdOrderNo);
            Assert.True(res.Success, res.ResultMessage);
            Assert.True(res.Result);
        }

        [Trait("xUnit", "7、订单API接口")]
        [Theory(DisplayName = "7.10 更新采购单号"), Order(7100)]
        [InlineData(TestHelper.JdOrderNo_Test)]
        public async Task SaveOrUpdatePoNoTest(long jdOrderNo)
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.SaveOrUpdatePoNoAsync(null, default, default));

            var poNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            var res = await ApiInstance.SaveOrUpdatePoNoAsync(jdOrderNo, poNo);
            Assert.True(res.Success, res.ResultMessage);
            Assert.True(res.Result);
        }

        [Trait("xUnit", "7、订单API接口")]
        [Fact(DisplayName = "7.15 查询配送预计送达时间"), Order(7150)]
        public async Task GetPromiseTipsTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.GetPromiseTipsAsync(null, default, default, 0, 0, 0, 0));

            var jdAddr = TestHelper.JDArress;
            var res = await ApiInstance.GetPromiseTipsAsync(long.Parse(TestHelper.OrderSku1), 1, jdAddr.ProvinceId, jdAddr.CityId, jdAddr.CountyId, jdAddr.TownId.Value);
            Assert.True(res.Success, res.ResultMessage);
            Assert.NotEmpty(res.Result);
        }

        [Trait("xUnit", "7、订单API接口")]
        [Theory(DisplayName = "7.16 批量确认收货接口"), Order(7160)]
        [InlineData(TestHelper.JdOrderNo_Test)]
        public async Task BatchConfirmReceivedTest(params long[] jdOrderIds)
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.BatchConfirmReceivedAsync(null, default));

            var res = await ApiInstance.BatchConfirmReceivedAsync(jdOrderIds);
            Assert.True(res.Success, res.ResultMessage);
            Assert.NotEmpty(res.Result);
        }

    }
}
