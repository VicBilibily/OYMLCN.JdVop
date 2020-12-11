namespace OYMLCN.JdVop.Models
{
    /// <summary>
    ///  京东对接信息
    /// </summary>
    public class VopClient
    {
        /// <summary>
        /// 对接账号(由京东人员提供)
        /// </summary>
        public string ClientId { get; set; }
        /// <summary>
        /// 京东分配的，以邮件形式发送给客户
        /// </summary>
        public string ClientSecret { get; set; }
        /// <summary>
        /// 京东用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 京东帐号登录密码
        /// </summary>
        public string Password { get; set; }
    }
}
