using OYMLCN.JdVop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        /// <summary>
        ///   查询单个商品池下的商品列表。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="pageNum">商品池编码</param>
        /// <param name="pageNo">
        ///   <para>页码，默认取第一页；（因每页数据动态过滤，可能存在当前页全量返回或无数据的情况，请根据实际情况继续查询下一页），品类商品池可能存在多页数据，具体根据返回的页总数判断是否有下一页数据。</para>
        ///   <para>获取结果时，需要按照页码顺序依次查询，跳页可能导致查询结果为空（已经获取过的页码，短时间内跳页查询该页内容，可以获取到结果，但不建议这么做）。</para>
        /// </param>
        public static async Task<RspResult<PageNumSku>> GetSkuByPageAsync(string token, string pageNum, int pageNo = 1)
        {
            if (string.IsNullOrEmpty(token)) throw AccessTokenArgumentException;

            var parameter = new Dictionary<string, string>
            {
                { "token", token },
                { "pageNum", pageNum },
                { "pageNo", pageNo.ToString() },
            };
            var url = "/api/product/getSkuByPage";
            return await PostAsync<PageNumSku>(url, parameter);
        }
        /// <inheritdoc cref="GetSkuByPageAsync(string, string, int)"/>
        public async Task<RspResult<PageNumSku>> GetSkuByPageAsync(string pageNum, int pageNo = 1)
            => await GetSkuByPageAsync(this.AccessToken, pageNum, pageNo);
    }
}
