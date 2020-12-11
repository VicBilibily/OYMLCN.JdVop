using OYMLCN.JdVop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        static JdVopApi()
        {
            HttpClient = new HttpClient() { BaseAddress = new Uri("https://bizapi.jd.com") };
            JsonSerializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            JsonSerializerOptions.Converters.Add(new Internal.JsonNumToBoolConverter());
            JsonSerializerOptions.Converters.Add(new Internal.JsonStringToDatetimeConverter());
        }
        internal static HttpClient HttpClient;
        /// <summary>
        /// JSON序列化自定义参数对象
        /// </summary>
        public static JsonSerializerOptions JsonSerializerOptions;

        internal static async Task<HttpContent> PostAsync(string url, Dictionary<string, string> parameter)
        {
            var result = await HttpClient.PostAsync(url, new FormUrlEncodedContent(parameter));
            if (result.IsSuccessStatusCode)
            {
#if DEBUG // 仅开发时看原始JSON
                string json = await result.Content.ReadAsStringAsync();
#endif
                return result.Content;
            }
            throw new Exception($"请求异常：{result.ReasonPhrase}");
        }
        internal static async Task<RspResult<T>> PostAsync<T>(string url, Dictionary<string, string> parameter)
        {
            var result = await HttpClient.PostAsync(url, new FormUrlEncodedContent(parameter));
            if (result.IsSuccessStatusCode)
            {
#if DEBUG // 仅开发时看原始JSON
                string json = await result.Content.ReadAsStringAsync();
#endif
                return await result.Content.ReadFromJsonAsync<RspResult<T>>(JsonSerializerOptions);
            }
            throw new Exception($"请求异常：{result.ReasonPhrase}");
        }
    }
}
