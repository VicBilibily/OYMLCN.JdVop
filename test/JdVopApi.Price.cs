using System;
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

    }
}
