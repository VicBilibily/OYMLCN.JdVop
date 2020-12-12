using OYMLCN.JdVop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        static async Task<RspResult<Dictionary<string, int>>> AreaGetDataAsync(string token, string url, int? id)
        {
            if (string.IsNullOrEmpty(token)) throw AccessTokenArgumentException;

            var parameter = new Dictionary<string, string>() {
                { "token", token },
            };
            if (id.HasValue) parameter.Add("id", id.ToString());
            return await PostAsync<Dictionary<string, int>>(url, parameter);
        }

        /// <summary>
        ///   查询京东一级地址列表。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        public static async Task<RspResult<Dictionary<string, int>>> AreaGetProvinceAsync(string token)
            => await AreaGetDataAsync(token, "/api/area/getProvince", default);
    
        /// <summary>
        ///   根据京东一级地址ID，查询京东二级地址列表。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="id">一级地址ID</param>
        public static async Task<RspResult<Dictionary<string, int>>> AreaGetCityAsync(string token, int id)
            => await AreaGetDataAsync(token, "/api/area/getCity", id);
      
        /// <summary>
        ///   根据京东二级地址ID，查询京东三级地址列表。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="id">二级地址ID</param>
        public static async Task<RspResult<Dictionary<string, int>>> AreaGetCountyAsync(string token, int id)
            => await AreaGetDataAsync(token, "/api/area/getCounty", id);
      
        /// <summary>
        ///   根据京东三级地址ID，查询京东四级地址列表。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="id">三级地址ID</param>
        public static async Task<RspResult<Dictionary<string, int>>> AreaGetTownAsync(string token, int id)
            => await AreaGetDataAsync(token, "/api/area/getTown", id);


        /// <summary>
        ///   验证已编码为京东一至四级地址ID的有效性。
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="provinceId">一级地址ID</param>
        /// <param name="cityId">二级地址ID</param>
        /// <param name="countyId">三级地址ID</param>
        /// <param name="townId">四级地址ID（若三级地址下无四级地址传0）</param>
        public static async Task<RspResult<CheckAreaResult>> AreaCheckAreaAsync(string token, int provinceId, int cityId, int countyId, int townId = 0)
        {
            if (string.IsNullOrEmpty(token)) throw AccessTokenArgumentException;

            var parameter = new Dictionary<string, string>
            {
                { "token", token },
                { "provinceId", provinceId.ToString() },
                { "cityId", cityId.ToString() },
                { "countyId", countyId.ToString() },
                { "townId", townId.ToString() },
            };
            var url = "/api/area/checkArea";
            return await PostAsync<CheckAreaResult>(url, parameter);
        }

        /// <summary>
        ///   根据地址详情转换为京东地址编码。
        ///   <para>该接口不能保证所有地址都匹配到京东地址，也不能保证所有匹配到的京东地址都正确。因而，优先推荐使用逐级选择的方法。</para>
        /// </summary>
        /// <param name="token">授权时获取的 AccessToken</param>
        /// <param name="address">地址</param>
        public static async Task<RspResult<JDAddress>> AreaGetJDAddressFromAddressAsync(string token, string address)
        {
            if (string.IsNullOrEmpty(token)) throw AccessTokenArgumentException;

            var parameter = new Dictionary<string, string>
            {
                { "token", token },
                { "address", address },
            };
            var url = "/api/area/getJDAddressFromAddress";
            return await PostAsync<JDAddress>(url, parameter);
        }

    }
}
