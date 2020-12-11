using System;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace OYMLCN.JdVop
{
    /// <summary>
    /// 大客户开放平台VOP（基于v2.0.5）
    /// </summary>
    public partial class JdVopApi
    {
        /// <summary>
        ///   大客户开放平台VOP（基于v2.0.5）
        /// </summary>
        /// <param name="accessToken">之前登录授权成功的凭证</param>
        public JdVopApi(string accessToken) => this.AccessToken = accessToken;
        /// <summary>
        ///   AccessToken 授权令牌
        /// </summary>
        public string AccessToken { get; private set; }

        static ArgumentException AccessTokenArgumentException = new ArgumentException("token 不能为 null 或空字符串", "token");
    }
}
