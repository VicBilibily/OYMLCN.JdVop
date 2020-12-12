using OYMLCN.JdVop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        /// <summary>
        ///   根据分类id查询对应分类信息。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="cid">分类id（可通过商品详情接口查询）</param>
        public static async Task<RspResult<ProductCategory>> GetCategoryAsync(string token, long cid)
        {
            if (string.IsNullOrEmpty(token)) throw AccessTokenArgumentException;
         
            var parameter = new Dictionary<string, string>
            {
                { "token", token },
                { "cid", cid.ToString() },
            };
            var url = "/api/product/getCategory";
            return await PostAsync<ProductCategory>(url, parameter);
        }
        /// <inheritdoc cref="GetCategoryAsync(string, long)"/>
        public async Task<RspResult<ProductCategory>> GetCategoryAsync(long cid)
            => await GetCategoryAsync(this.AccessToken, cid);
    }
}
