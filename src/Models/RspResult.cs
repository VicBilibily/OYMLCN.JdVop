using System;

namespace OYMLCN.JdVop.Models
{
    /// <summary>
    /// 请求京东响应实体
    /// </summary>
    public class RspResult<T>
    {
        /// <summary>
        /// 请求是否处理成功
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 业务处理结果编码，详细参见：【错误码】
        /// </summary>
        public string ResultCode { get; set; }
        /// <summary>
        /// 对 <see cref="ResultCode"/> 的简要说明
        /// </summary>
        public string ResultMessage { get; set; }
        /// <summary>
        /// 成功时有值
        /// </summary>
        public T Result { get; set; }
    }
}
