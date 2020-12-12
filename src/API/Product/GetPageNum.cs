using OYMLCN.JdVop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        /// <summary>
        ///   查询所有商品池编号，商品池编号将用于获取池内商品编号。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="contractSkuPoolExt">包含商品池扩展字段</param>
        public static async Task<RspResult<List<ProductPageNum>>> ProductGetPageNumAsync(string token, bool contractSkuPoolExt = false)
        {
            if (string.IsNullOrEmpty(token)) throw AccessTokenArgumentException;

            var parameter = new Dictionary<string, string>() {
                { "token", token },
            };
            if (contractSkuPoolExt) parameter.Add("queryExts", "contractSkuPoolExt");
            var url = "/api/product/getPageNum";
            return await PostAsync<List<ProductPageNum>>(url, parameter);
        }
        /// <inheritdoc cref="ProductGetPageNumAsync(string, bool)"/>
        public async Task<RspResult<List<ProductPageNum>>> ProductGetPageNumAsync(bool contractSkuPoolExt = false)
            => await ProductGetPageNumAsync(this.AccessToken, contractSkuPoolExt);
    }
}
