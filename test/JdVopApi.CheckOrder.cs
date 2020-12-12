using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions.Ordering;

namespace OYMLCN.JdVop.Test
{
    public partial class JdVopApiTest
    {
        [Trait("xUnit", "7、订单API接口")]
        [Fact(DisplayName = "7.11 查询新建订单列表"), Order(7110)]
        public async Task CheckNewOrderTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.CheckNewOrderAsync(null, default));

            var result = await ApiInstance.CheckNewOrderAsync(DateTime.Now);
            Assert.NotNull(result);
        }

        [Trait("xUnit", "7、订单API接口")]
        [Fact(DisplayName = "7.12 查询妥投订单列表"), Order(7120)]
        public async Task CheckDlokOrderTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.CheckDlokOrderAsync(null, default));

            var result = await ApiInstance.CheckDlokOrderAsync(DateTime.Now);
            Assert.NotNull(result);
        }

        [Trait("xUnit", "7、订单API接口")]
        [Fact(DisplayName = "7.13 查询拒收订单列表"), Order(7130)]
        public async Task CheckRefuseOrderTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.CheckRefuseOrderAsync(null, default));

            var result = await ApiInstance.CheckRefuseOrderAsync(DateTime.Now);
            Assert.NotNull(result);
        }

        [Trait("xUnit", "7、订单API接口")]
        [Fact(DisplayName = "7.14 查询完成订单列表"), Order(7140)]
        public async Task CheckCompleteOrderTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.CheckCompleteOrderAsync(null, default));

            var result = await ApiInstance.CheckCompleteOrderAsync(DateTime.Now);
            Assert.NotNull(result);
        }

    }
}
