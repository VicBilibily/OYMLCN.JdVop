using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions.Ordering;

namespace OYMLCN.JdVop.Test
{
    public partial class JdVopApiTest
    {
        [Trait("xUnit", "2、授权API接口")]
        [Fact(DisplayName = "2.3 获取Access Token"), Order(2030)]
        public async Task Oauth2AccessTokenTest()
        {
            var res = await JdVopApi.Oauth2AccessTokenAsync(TestHelper.VopClient);
            Assert.True(res.Success, res.ResultMessage);
            var token = res.Result;
            Assert.NotNull(token);
            Assert.NotEmpty(token.AccessToken);
            TestHelper.AccessToken = token;
        }

        [Trait("xUnit", "2、授权API接口")]
        [Fact(DisplayName = "2.4 刷新 Access Token"), Order(2040)]
        public async Task Oauth2RefreshATokenTest()
        {
            var res = await JdVopApi.Oauth2RefreshATokenAsync(TestHelper.VopClient, TestHelper.AccessToken.RefreshToken);
            Assert.True(res.Success, res.ResultMessage);
            var token = res.Result;
            Assert.NotNull(token);
            Assert.NotEmpty(token.AccessToken);
            TestHelper.AccessToken = token;
        }


    }
}
