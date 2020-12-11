namespace OYMLCN.JdVop.Test
{
    public partial class JdVopApiTest
    {
        string AccessToken
        {
            get
            {
                if (TestHelper.AccessToken == null)
                {
                    var req = JdVopApi.Oauth2AccessTokenAsync(TestHelper.VopClient);
                    req.Wait();
                    TestHelper.AccessToken = req.Result.Result;
                }
                return TestHelper.AccessToken.AccessToken;
            }
        }
        JdVopApi __jdVopApi;
        JdVopApi ApiInstance => __jdVopApi ??= new JdVopApi(AccessToken);
    }
}
