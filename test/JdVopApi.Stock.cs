using OYMLCN.JdVop.Models;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions.Ordering;

namespace OYMLCN.JdVop.Test
{
    public partial class JdVopApiTest
    {
        [Trait("xUnit", "6、库存API接口")]
        [Fact(DisplayName = "6.1 查询商品库存"), Order(6010)]
        public async Task GetNewStockByIdTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.GetNewStockByIdAsync(null, default, 0, 0, 0, 0));

            var skuNums = new SkuNum[]{
                new (long.Parse(TestHelper.SkuNormal1), 2),
                new (long.Parse(TestHelper.SkuNormal2), 1),
            };
            var jdAddr = TestHelper.JDArress;
            var res = await ApiInstance.GetNewStockByIdAsync(skuNums, jdAddr.ProvinceId, jdAddr.CityId, jdAddr.CountyId, jdAddr.TownId.Value);
            Assert.True(res.Success, res.ResultMessage);
            var result = res.Result;
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

    }
}
