using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions.Ordering;

namespace OYMLCN.JdVop.Test
{
    public partial class JdVopApiTest
    {
        [Trait("xUnit", "4、商品API接口")]
        [Fact(DisplayName = "4.1 查询商品池编号"), Order(4010)]
        public async Task ProductGetPageNumTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.ProductGetPageNumAsync(null));

            var res = await ApiInstance.ProductGetPageNumAsync();
            Assert.True(res.Success, res.ResultMessage);
            var pageNum = res.Result;
            Assert.NotNull(pageNum);
            Assert.NotEmpty(pageNum);
            Assert.DoesNotContain(pageNum, v => v.ContractSkuPoolExt != null);
            TestHelper.ProductPageNum = pageNum;
        }
        [Trait("xUnit", "4、商品API接口")]
        [Fact(DisplayName = "4.1 查询商品池编号（含扩展字段）", Skip = "数据量大，按需测试。"), Order(4011)]
        public async Task ProductGetPageNumExtTest()
        {
            var res = await ApiInstance.ProductGetPageNumAsync(contractSkuPoolExt: true);
            Assert.True(res.Success, res.ResultMessage);
            var pageNum = res.Result;
            Assert.NotNull(pageNum);
            Assert.NotEmpty(pageNum);
            Assert.Contains(pageNum, v => v.ContractSkuPoolExt != null);
        }

        [Trait("xUnit", "4、商品API接口")]
        [Fact(DisplayName = "4.2 查询池内商品编号[需与4.1联调]"), Order(4020)]
        public async Task ProductGetSkuByPageTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.ProductGetSkuByPageAsync(null, default));

            var pageNum = TestHelper.ProductPageNum.Select(v => v.PageNum).First();
            var res = await ApiInstance.ProductGetSkuByPageAsync(pageNum, 1);
            Assert.True(res.Success, res.ResultMessage);
            var pnSku = res.Result;
            Assert.NotNull(pnSku);
            Assert.True(pnSku.PageCount > 0);
            Assert.NotEmpty(pnSku.SkuIds);
        }


    }
}
