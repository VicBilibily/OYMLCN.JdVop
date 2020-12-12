using OYMLCN.JdVop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions.Ordering;

namespace OYMLCN.JdVop.Test
{
    public partial class JdVopApiTest
    {
        [Trait("xUnit", "4、商品API接口")]
        [Fact(DisplayName = "4.1 查询商品池编号"), Order(4010)]
        public async Task GetPageNumTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.GetPageNumAsync(null));

            var res = await ApiInstance.GetPageNumAsync();
            Assert.True(res.Success, res.ResultMessage);
            var pageNum = res.Result;
            Assert.NotNull(pageNum);
            Assert.NotEmpty(pageNum);
            Assert.DoesNotContain(pageNum, v => v.ContractSkuPoolExt != null);
            TestHelper.ProductPageNum = pageNum;
        }
        [Trait("xUnit", "4、商品API接口")]
        [Fact(DisplayName = "4.1 查询商品池编号（含扩展字段）", Skip = "数据量大，按需测试。"), Order(4011)]
        public async Task GetPageNumExtTest()
        {
            var res = await ApiInstance.GetPageNumAsync(contractSkuPoolExt: true);
            Assert.True(res.Success, res.ResultMessage);
            var pageNum = res.Result;
            Assert.NotNull(pageNum);
            Assert.NotEmpty(pageNum);
            Assert.Contains(pageNum, v => v.ContractSkuPoolExt != null);
        }

        [Trait("xUnit", "4、商品API接口")]
        [Fact(DisplayName = "4.2 查询池内商品编号[需与4.1联调]"), Order(4020)]
        public async Task GetSkuByPageTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.GetSkuByPageAsync(null, default));

            var pageNum = TestHelper.ProductPageNum.Select(v => v.PageNum).First();
            var res = await ApiInstance.GetSkuByPageAsync(pageNum, 1);
            Assert.True(res.Success, res.ResultMessage);
            var pnSku = res.Result;
            Assert.NotNull(pnSku);
            Assert.True(pnSku.PageCount > 0);
            Assert.NotEmpty(pnSku.SkuIds);
        }

        [Trait("xUnit", "4、商品API接口")]
        [Fact(DisplayName = "4.3 查询商品详情（实物）"), Order(4031)]
        public async Task GetDetailTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.GetDetailAsync(null, default));

            var res = await ApiInstance.GetDetailAsync(TestHelper.SkuNormal1, "isSelf,isJDLogistics");
            Assert.True(res.Success, res.ResultMessage);
            var detail = res.Result;
            Assert.NotNull(detail);
            Assert.Equal(TestHelper.SkuNormal1BrandName, detail.BrandName);
            var keys = detail.ExtData.Keys;
            Assert.Contains("isSelf", keys);
            Assert.Contains("isJDLogistics", keys);
        }
        [Trait("xUnit", "4、商品API接口")]
        [Fact(DisplayName = "4.3 查询商品详情（图书）"), Order(4032)]
        public async Task GetDetailBookTest()
        {
            var res = await ApiInstance.GetDetailAsync(TestHelper.SkuBook);
            Assert.True(res.Success, res.ResultMessage);
            var detail = res.Result;
            Assert.NotNull(detail);
            Assert.True(detail.IsBook);
            var book = detail.AsBook();
            Assert.Equal(TestHelper.SkuBookAuthor, book.Author);
            Assert.Equal(TestHelper.SkuBookISBN, book.ISBN);
        }
        [Trait("xUnit", "4、商品API接口")]
        [Fact(DisplayName = "4.3 查询商品详情（音像）"), Order(4033)]
        public async Task GetDetailVideoTest()
        {
            var res = await ApiInstance.GetDetailAsync(TestHelper.SkuVideo);
            Assert.True(res.Success, res.ResultMessage);
            var detail = res.Result;
            Assert.NotNull(detail);
            Assert.True(detail.IsVideo);
            var video = detail.AsVideo();
            Assert.Equal(TestHelper.SkuVideoSinger, video.Singer);
        }

        [Trait("xUnit", "4、商品API接口")]
        [Fact(DisplayName = "4.4 查询商品图片"), Order(4040)]
        public async Task SkuImageTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.SkuImageAsync(null, default));

            var sku = TestHelper.SkuNormal1;
            var res = await ApiInstance.SkuImageAsync(sku);
            Assert.True(res.Success, res.ResultMessage);
            var skuImage = res.Result;
            Assert.NotNull(skuImage);
            Assert.Contains(sku, skuImage.Keys);
            var images = skuImage.GetValueOrDefault(sku);
            Assert.NotEmpty(images);
            Assert.Equal(1, images.Count(v => v.IsPrimary));
        }

        [Trait("xUnit", "4、商品API接口")]
        [Fact(DisplayName = "4.5 查询商品上下架状态"), Order(4050)]
        public async Task SkuStateTestAsync()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.SkuStateAsync(null, default));

            var sku = TestHelper.SkuNormal1;
            var res = await ApiInstance.SkuStateAsync(sku);
            Assert.True(res.Success, res.ResultMessage);
            var skuState = res.Result;
            Assert.NotNull(skuState);
            Assert.NotEmpty(skuState);
            Assert.Equal(sku, skuState[0].SKU.ToString());
        }

        [Trait("xUnit", "4、商品API接口")]
        [Fact(DisplayName = "4.6 验证商品可售性"), Order(4060)]
        public async Task ProductCheckTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.ProductCheckAsync(null, default));

            var res = await ApiInstance.ProductCheckAsync(TestHelper.SkuNormal1);
            Assert.True(res.Success, res.ResultMessage);
            var result = res.Result;
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Trait("xUnit", "4、商品API接口")]
        [Fact(DisplayName = "4.7 查询商品区域购买限制"), Order(4070)]
        public async Task CheckAreaLimitTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.CheckAreaLimitAsync(null, default, 0, 0, 0, 0));

            var sku = TestHelper.SkuNormal1;
            var jdAddr = TestHelper.JDArress;
            var res = await ApiInstance.CheckAreaLimitAsync(sku, jdAddr.ProvinceId, jdAddr.CityId, jdAddr.CountyId, jdAddr.TownId.Value);
            Assert.True(res.Success, res.ResultMessage);
            var result = res.Result;
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Trait("xUnit", "4、商品API接口")]
        [Fact(DisplayName = "4.8 查询赠品信息"), Order(4080)]
        public async Task GetSkuGiftTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.GetSkuGiftAsync(null, default, 0, 0, 0, 0));

            var sku = TestHelper.SkuNormal1;
            var jdAddr = TestHelper.JDArress;
            var res = await ApiInstance.GetSkuGiftAsync(sku, jdAddr.ProvinceId, jdAddr.CityId, jdAddr.CountyId, jdAddr.TownId.Value);
            Assert.True(res.Success, res.ResultMessage);
            var result = res.Result;
            Assert.Null(result);

            sku = TestHelper.SkuHasGift;
            res = await ApiInstance.GetSkuGiftAsync(sku, jdAddr.ProvinceId, jdAddr.CityId, jdAddr.CountyId, jdAddr.TownId.Value);
            Assert.True(res.Success, res.ResultMessage);
            result = res.Result;
            Assert.NotNull(result);
        }

        [Trait("xUnit", "4、商品API接口")]
        [Fact(DisplayName = "4.9 查询商品延保"/*, Skip = "暂未找到可测试的商品。"*/), Order(4090)]
        public async Task GetYanbaoSkuTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.GetYanbaoSkuAsync(null, default, 0, 0, 0, 0));

            var sku = TestHelper.SkuNormal1;
            var jdAddr = TestHelper.JDArress;

            var res = await ApiInstance.GetYanbaoSkuAsync(sku, jdAddr.ProvinceId, jdAddr.CityId, jdAddr.CountyId, jdAddr.TownId.Value);
            Assert.False(res.Success, res.ResultMessage);

            var demoJson = "{\"result\":{\"2317745\":[{\"categoryCode\":\"VXP-YCBX\",\"detailUrl\":\"http://sale.jd.com/act/s7oXRvFNyVl.html\",\"displayName\":\"延长保修\",\"displayNo\":1,\"fuwuSkuDetailList\":[{\"bindSkuId\":2294753,\"bindSkuName\":\"延长保修1年\",\"favor\":false,\"price\":99,\"sortIndex\":1,\"tip\":\"保修期延长1年，就近维修，不限次服务\"},{\"bindSkuId\":2293796,\"bindSkuName\":\"延长保修2年\",\"favor\":false,\"price\":198,\"sortIndex\":2,\"tip\":\"保修期延长2年，就近维修，不限次服务\"}],\"imgUrl\":\"/fuwu/jfs/t2623/112/1419031929/1227/e5dadbca/573d95abNc672af4d.png\",\"mainSkuId\":2317745}]},\"resultCode\":\"0000\",\"resultMessage\":\"操作成功\",\"success\":true}";
            var demo = JsonSerializer.Deserialize<RspResult<Dictionary<string, YanBaoVo[]>>>(demoJson, JdVopApi.JsonSerializerOptions);
            var result = demo.Result;
            Assert.NotNull(result);
            Assert.NotEmpty(result.First().Value);

            //sku = TestHelper.SkuNormal2;
            //res = await ApiInstance.GetYanbaoSkuAsync(sku, jdAddr.ProvinceId, jdAddr.CityId, jdAddr.CountyId, jdAddr.TownId.Value);
            //Assert.True(res.Success, res.ResultMessage);
            //var result = res.Result;
            //Assert.NotNull(result);
        }

        [Trait("xUnit", "4、商品API接口")]
        [Fact(DisplayName = "4.10 验证货到付款"), Order(4100)]
        public async Task GetIsCodTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.GetIsCodAsync(null, default, 0, 0, 0, 0));

            var sku = TestHelper.SkuNormal1;
            var jdAddr = TestHelper.JDArress;
            var result = await ApiInstance.GetIsCodAsync(sku, jdAddr.ProvinceId, jdAddr.CityId, jdAddr.CountyId, jdAddr.TownId.Value);
            Assert.True(result.Success);
            Assert.False(result.Result); // 不支持货到付款
            Assert.Equal(sku, result.SkuIds);

            sku = TestHelper.SkuNormal2;
            result = await ApiInstance.GetIsCodAsync(sku, jdAddr.ProvinceId, jdAddr.CityId, jdAddr.CountyId, jdAddr.TownId.Value);
            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.True(result.Result);

            sku = $"{TestHelper.SkuNormal1},{TestHelper.SkuNormal2}";
            result = await ApiInstance.GetIsCodAsync(sku, jdAddr.ProvinceId, jdAddr.CityId, jdAddr.CountyId, jdAddr.TownId.Value);
            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.False(result.Result);
            Assert.Equal(TestHelper.SkuNormal1, result.SkuIds);
        }

        [Trait("xUnit", "4、商品API接口")]
        [Fact(DisplayName = "4.11 批量验证货到付款"), Order(4110)]
        public async Task GetBatchIsCodTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.GetBatchIsCodAsync(null, default, 0, 0, 0, 0));

            var sku = $"{TestHelper.SkuNormal1},{TestHelper.SkuNormal2}";
            var jdAddr = TestHelper.JDArress;
            var res = await ApiInstance.GetBatchIsCodAsync(sku, jdAddr.ProvinceId, jdAddr.CityId, jdAddr.CountyId, jdAddr.TownId.Value);
            Assert.True(res.Success, res.ResultMessage);
            var result = res.Result;
            Assert.False(result[TestHelper.SkuNormal1].CanCOD);
            Assert.True(result[TestHelper.SkuNormal2].CanCOD);
        }

        [Trait("xUnit", "4、商品API接口")]
        [Fact(DisplayName = "4.12 搜索商品"), Order(4120)]
        public async Task SearchTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.SearchAsync(null));

            var res = await ApiInstance.SearchAsync(
                pageIndex: 2, pageSize: 25,
                min: 50, max: 200, sortType: SearchSort.price_desc,
                priceCol: true, extAttrCol: true
            );
            Assert.True(res.Success, res.ResultMessage);
            var result = res.Result;
            Assert.NotNull(result);
            Assert.Equal(2, result.PageIndex);
            Assert.Equal(25, result.PageSize);
            Assert.NotNull(result.BrandAggregate);
            Assert.NotEmpty(result.BrandAggregate.BrandList);
            Assert.NotEmpty(result.BrandAggregate.PinyinAggr);
            Assert.NotNull(result.CategoryAggregate);
            Assert.NotEmpty(result.CategoryAggregate.FirstCategory);
            Assert.NotEmpty(result.CategoryAggregate.SecondCategory);
            Assert.NotEmpty(result.CategoryAggregate.ThridCategory);
            Assert.NotEmpty(result.PriceIntervalAggregate);
            Assert.NotEmpty(result.HitResult);
            Assert.NotEmpty(result.ExpandAttrAggregate);
        }

        [Trait("xUnit", "4、商品API接口")]
        [Fact(DisplayName = "4.13 查询同类商品"), Order(4130)]
        public async Task GetSimilarSkuTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.GetSimilarSkuAsync(null, default));

            var sku = TestHelper.SkuNormal1;
            var res = await ApiInstance.GetSimilarSkuAsync(sku);
            Assert.True(res.Success, res.ResultMessage);
            var result = res.Result;
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.NotEmpty(result[0].SaleAttrList);
        }

        [Trait("xUnit", "4、商品API接口")]
        [Fact(DisplayName = "4.14 查询分类信息"), Order(4140)]
        public async Task GetCategoryTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.GetCategoryAsync(null, default));

            var cate = "9987;653;655";
            var categories = cate.Split(';').Select(v => int.Parse(v));
            foreach (var category in categories)
            {
                var res = await ApiInstance.GetCategoryAsync(category);
                Assert.True(res.Success, res.ResultMessage);
                var result = res.Result;
                Assert.NotNull(result);
                Assert.Equal(category, result.CatId);
            }
        }

        [Trait("xUnit", "4、商品API接口")]
        [Fact(DisplayName = "4.15 查询商品状态验证统一接口信息"), Order(4150)]
        public async Task TotalCheckTest()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => JdVopApi.TotalCheckAsync(null, default, 0, 0, 0, 0));

            var skuNums = new
                SkuNum[]{
                new (long.Parse(TestHelper.SkuNormal1), 2),
                new (long.Parse(TestHelper.SkuNormal2), 1),
            };
            var jdAddr = TestHelper.JDArress;
            var result = await ApiInstance.TotalCheckAsync(skuNums, jdAddr.ProvinceId, jdAddr.CityId, jdAddr.CountyId, jdAddr.TownId.Value);
            Assert.True(result.Success);
            Assert.Null(result.ErrorMessage);
            Assert.NotEmpty(result.CheckResult);
            Assert.NotEmpty(result.SkuAreasResult);
            Assert.NotEmpty(result.StockResult);
            Assert.NotEmpty(result.SkuStateResult);
        }

    }
}
