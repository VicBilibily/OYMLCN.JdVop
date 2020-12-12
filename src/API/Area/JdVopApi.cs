using OYMLCN.JdVop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        /// <inheritdoc cref="GetProvinceAsync(string)"/>
        public async Task<RspResult<Dictionary<string, int>>> GetProvinceAsync()
            => await GetProvinceAsync(this.AccessToken);

        /// <inheritdoc cref="GetCityAsync(string, int)"/>
        public async Task<RspResult<Dictionary<string, int>>> GetCityAsync(int id)
            => await GetCityAsync(this.AccessToken, id);

        /// <inheritdoc cref="GetCountyAsync(string, int)"/>
        public async Task<RspResult<Dictionary<string, int>>> GetCountyAsync(int id)
            => await GetCountyAsync(this.AccessToken, id);

        /// <inheritdoc cref="GetTownAsync(string, int)"/>
        public async Task<RspResult<Dictionary<string, int>>> GetTownAsync(int id)
            => await GetTownAsync(this.AccessToken, id);


        /// <inheritdoc cref="CheckAreaAsync(string, int, int, int, int)"/>
        public async Task<RspResult<CheckAreaResult>> CheckAreaAsync(int provinceId, int cityId, int countyId, int townId = 0)
            => await CheckAreaAsync(this.AccessToken, provinceId, cityId, countyId, townId);

        /// <inheritdoc cref="GetJDAddressFromAddressAsync(string, string)"/>
        public async Task<RspResult<JDAddress>> GetJDAddressFromAddressAsync(string address)
            => await GetJDAddressFromAddressAsync(this.AccessToken, address);
    }
}
