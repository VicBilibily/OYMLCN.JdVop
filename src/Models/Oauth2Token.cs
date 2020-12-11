using System.Text.Json.Serialization;

namespace OYMLCN.JdVop.Models
{
    /// <summary>
    /// 用户登录授权 AccessToken 信息
    /// </summary>
    public class Oauth2Token
    {
        /// <summary>
        /// 业务id
        /// </summary>
        public string UID { get; set; }

        /// <summary>
        /// 访问令牌，用于业务接口调用。 有效期24小时
        /// </summary>
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
        /// <summary>
        /// 当前时间，时间戳格式：1551663377887
        /// </summary>
        public long Time { get; set; }

        /// <summary>
        /// access_token的有效期，单位：秒，有效期24小时
        /// </summary>
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }


        /// <summary>
        /// 当access_token过期时，用于刷新access_token
        /// </summary>
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }
        /// <summary>
        /// refresh_token的过期时间，毫秒级别,时间戳
        /// </summary>
        [JsonPropertyName("refresh_token_expires")]
        public long RefreshTokenExpires { get; set; }


        /// <summary>
        /// 返回访问令牌，用于业务接口调用。
        /// </summary>
        public override string ToString()
            => this.AccessToken;
        /// <summary>
        /// 隐式转换为 <see cref="string"/>
        /// </summary>
        public static implicit operator string(Oauth2Token token)
            => token.AccessToken;
    }

}
