using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions.Ordering;

namespace OYMLCN.JdVop.Test
{
    public partial class JdVopApiTest
    {
        [Trait("xUnit", "3、地址api接口")]
        [Fact(DisplayName = "3.1 查询一级地址"), Order(3010)]
        public async Task AreaGetProvinceTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.AreaGetProvinceAsync(null));

            var res = await ApiInstance.AreaGetProvinceAsync();
            Assert.True(res.Success, res.ResultMessage);
            var province = res.Result;
            Assert.NotNull(province);
            Assert.NotEmpty(province);
            Assert.Contains(TestHelper.JDArress.Province, province.Keys);
        }
        [Trait("xUnit", "3、地址api接口")]
        [Fact(DisplayName = "3.2 查询二级地址"), Order(3020)]
        public async Task AreaGetCityTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.AreaGetCityAsync(null, 0));

            var res = await ApiInstance.AreaGetCityAsync(TestHelper.JDArress.ProvinceId);
            Assert.True(res.Success, res.ResultMessage);
            var city = res.Result;
            Assert.NotNull(city);
            Assert.NotEmpty(city);
            Assert.Contains(TestHelper.JDArress.City, city.Keys);
        }
        [Trait("xUnit", "3、地址api接口")]
        [Fact(DisplayName = "3.3 查询三级地址"), Order(3030)]
        public async Task AreaGetCountyTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.AreaGetCountyAsync(null, 0));

            var res = await ApiInstance.AreaGetCountyAsync(TestHelper.JDArress.CityId);
            Assert.True(res.Success, res.ResultMessage);
            var country = res.Result;
            Assert.NotNull(country);
            Assert.NotEmpty(country);
            Assert.Contains(TestHelper.JDArress.County, country.Keys);
        }
        [Trait("xUnit", "3、地址api接口")]
        [Fact(DisplayName = "3.4 查询四级地址"), Order(3040)]
        public async Task AreaGetTownTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.AreaGetTownAsync(null, 0));

            var res = await ApiInstance.AreaGetTownAsync(TestHelper.JDArress.CountyId);
            Assert.True(res.Success, res.ResultMessage);
            var town = res.Result;
            Assert.NotNull(town);
            Assert.NotEmpty(town);
            Assert.Contains(TestHelper.JDArress.Town, town.Keys);
        }
        [Trait("xUnit", "3、地址api接口")]
        [Fact(DisplayName = "3.5 验证地址有效性"), Order(3050)]
        public async Task AreaCheckAreaTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.AreaCheckAreaAsync(null, 0, 0, 0, 0));

            var jdAddr = TestHelper.JDArress;
            var res = await ApiInstance.AreaCheckAreaAsync(jdAddr.ProvinceId, jdAddr.CityId, jdAddr.CountyId, jdAddr.TownId.Value);
            Assert.True(res.Success, res.ResultMessage);
            Assert.NotNull(res.Result);
            Assert.True(res.Result.Success);
        }
        [Trait("xUnit", "3、地址api接口")]
        [Fact(DisplayName = "3.6 地址详情转换京东地址编码"), Order(3060)]
        public async Task AreaGetJDAddressFromAddressTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.AreaGetJDAddressFromAddressAsync(null, default));

            var jdAddr = TestHelper.JDArress;
            var res = await ApiInstance.AreaGetJDAddressFromAddressAsync(TestHelper.JDAddressTest);
            Assert.True(res.Success, res.ResultMessage);
            var jdAddrRes = res.Result;
            Assert.NotNull(jdAddrRes);
            Assert.Equal("4744", jdAddrRes.NationId);
            Assert.Equal("中国", jdAddrRes.Nation);
            Assert.Equal(jdAddr.ProvinceId, jdAddrRes.ProvinceId);
            Assert.Equal(jdAddr.Province, jdAddrRes.Province);
            Assert.Equal(jdAddr.CityId, jdAddrRes.CityId);
            Assert.Equal(jdAddr.City, jdAddrRes.City);
            Assert.Equal(jdAddr.CountyId, jdAddrRes.CountyId);
            Assert.Equal(jdAddr.County, jdAddrRes.County);
            Assert.Equal(jdAddr.TownId, jdAddrRes.TownId);
            Assert.Equal(jdAddr.Town, jdAddrRes.Town);
        }
    }
}
