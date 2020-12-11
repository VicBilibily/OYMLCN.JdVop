using Microsoft.Extensions.Configuration;
using OYMLCN.JdVop.Models;
using System.Collections.Generic;

namespace OYMLCN.JdVop.Test
{
    static partial class TestHelper
    {
        internal static IConfiguration Configuration = new ConfigurationBuilder()
            .AddUserSecrets<JdVopApiTest>().Build(); // 用于测试的配置信息从用户机密信息中读取

        private static VopClient _vopClient;
        public static VopClient VopClient
        {
            get
            {
                if (_vopClient != null) return _vopClient;

                var client = new VopClient();
                Configuration.GetSection(nameof(VopClient)).Bind(client);
                return _vopClient = client;
            }
        }

        public static Oauth2Token AccessToken { get; set; }

        public static List<ProductPageNum> ProductPageNum;
        public static string OrderSubmitNo { get; set; }
        public static long? JdOrderNo { get; set; }
    }
}
