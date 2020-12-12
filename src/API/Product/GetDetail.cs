using OYMLCN.JdVop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        /// <summary>
        ///   查询单个商品的详细信息，不校验是否存在于商品池中。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="sku">商品编号，只支持单个查询</param>
        /// <param name="queryExts">
        ///   商品维度扩展字段，当入参输入某个扩展字段后，出参会返回该字段对应的出参。
        ///   可以根据需要选用。
        /// </param>
        public static async Task<RspResult<ProductDetail>> ProductGetDetailAsync(string token, string sku, string queryExts = default)
        {
            if (string.IsNullOrEmpty(token)) throw AccessTokenArgumentException;
          
            var parameter = new Dictionary<string, string>
            {
                { "token",token },
                { "sku", sku },
            };
            if (string.IsNullOrWhiteSpace(queryExts) == false)
                parameter.Add("queryExts", queryExts);

            var url = "/api/product/getDetail";
            var content = await PostAsync(url, parameter);
            var stream = await content.ReadAsStreamAsync();
            var res = await JsonSerializer.DeserializeAsync<RspResult<JsonElement>>(stream, JsonSerializerOptions);
            if (res.Success)
            {
                var jsonElement = res.Result;
                var skuType = string.Empty;
                if (jsonElement.TryGetProperty("skuType", out var type))
                    skuType = type.GetString()?.ToLower();
                stream.Position = 0;
                ProductDetail result;
                switch (skuType)
                {
                    case "book":
                        result = (await JsonSerializer.DeserializeAsync<RspResult<ProductBook>>(stream, JsonSerializerOptions)).Result;
                        break;
                    case "video":
                    case "vedio":
                        result = (await JsonSerializer.DeserializeAsync<RspResult<ProductVideo>>(stream, JsonSerializerOptions)).Result;
                        break;
                    default:
                        result = (await JsonSerializer.DeserializeAsync<RspResult<ProductDetail>>(stream, JsonSerializerOptions)).Result;
                        break;
                }
                result.ExtData = new Dictionary<string, string>();
                if (string.IsNullOrWhiteSpace(queryExts) == false)
                    foreach (var ext in queryExts.Split(',').Select(v => v.Trim()))
                        if (jsonElement.TryGetProperty(ext, out var extData))
                            result.ExtData.Add(ext, extData.ToString());
                return new RspResult<ProductDetail>()
                {
                    Success = res.Success,
                    ResultCode = res.ResultCode,
                    ResultMessage = res.ResultMessage,
                    Result = result,
                };
            }
            return await JsonSerializer.DeserializeAsync<RspResult<ProductDetail>>(stream, JsonSerializerOptions);
        }
        /// <inheritdoc cref="ProductGetDetailAsync(string, string, string)"/>
        public async Task<RspResult<ProductDetail>> ProductGetDetailAsync(string sku, string queryExts = default)
            => await ProductGetDetailAsync(this.AccessToken, sku, queryExts);
    }
}
