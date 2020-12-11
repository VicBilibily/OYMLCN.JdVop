using OYMLCN.JdVop.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        /// <summary>
        ///   获取 AccessToken
        /// </summary>
        /// <param name="client">京东对接信息</param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="client"/> 不能为 <see langword="null"/>。
        /// </exception>
        public static async Task<RspResult<Oauth2Token>> Oauth2AccessTokenAsync(VopClient client)
        {
            if (client == null) throw new ArgumentNullException($"{nameof(client)} 不能为 null");

            var grant_type = "access_token";
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var passwd = client.Password;

            using var md5 = MD5.Create();
            if (string.IsNullOrEmpty(passwd) == false)
                passwd = BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(passwd))).Replace("-", "").ToLower();

            var sign = client.ClientSecret + timestamp + client.ClientId + client.UserName + passwd + grant_type + client.ClientSecret;
            sign = BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(sign))).Replace("-", "").ToUpper();

            var url = "/oauth2/accessToken";
            var parameter = new Dictionary<string, string>
            {
                { "grant_type", grant_type },
                { "client_id", client.ClientId },
                { "timestamp", timestamp },
                { "username", client.UserName },
                { "password", passwd },
                { "sign", sign }
            };
            return await PostAsync<Oauth2Token>(url, parameter);
        }

        /// <summary>
        ///   刷新 AccessToken
        /// </summary>
        /// <param name="client">京东对接信息</param>
        /// <param name="refreshToken">授权获取 AccessToken 时返回的 RefreshToken</param>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="client"/> 不能为 <see langword="null"/>。
        /// </exception>
        /// <exception cref="ArgumentException">
        ///   <paramref name="refreshToken"/> 不能为 <see langword="null"/> 或 空字符串("")。
        /// </exception>
        public static async Task<RspResult<Oauth2Token>> Oauth2RefreshATokenAsync(VopClient client, string refreshToken)
        {
            if (client == null) throw new ArgumentNullException(nameof(client), $"{nameof(client)} 不能为 null");
            if (string.IsNullOrEmpty(refreshToken)) throw new ArgumentException($"{nameof(refreshToken)} 不能为 null 或 空字符", nameof(refreshToken));

            var url = "/oauth2/refreshToken";
            var parameter = new Dictionary<string, string>
            {
                { "refresh_token", refreshToken },
                { "client_id", client.ClientId },
                { "client_secret", client.ClientSecret }
            };
            return await PostAsync<Oauth2Token>(url, parameter);
        }



    }
}
