using OYMLCN.JdVop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OYMLCN.JdVop
{
    public partial class JdVopApi
    {
        /// <inheritdoc cref="AreaGetProvinceAsync(string)"/>
        public async Task<RspResult<Dictionary<string, int>>> AreaGetProvinceAsync()
            => await AreaGetProvinceAsync(this.AccessToken);

        /// <inheritdoc cref="AreaGetCityAsync(string, int)"/>
        public async Task<RspResult<Dictionary<string, int>>> AreaGetCityAsync(int id)
            => await AreaGetCityAsync(this.AccessToken, id);

        /// <inheritdoc cref="AreaGetCountyAsync(string, int)"/>
        public async Task<RspResult<Dictionary<string, int>>> AreaGetCountyAsync(int id)
            => await AreaGetCountyAsync(this.AccessToken, id);

        /// <inheritdoc cref="AreaGetTownAsync(string, int)"/>
        public async Task<RspResult<Dictionary<string, int>>> AreaGetTownAsync(int id)
            => await AreaGetTownAsync(this.AccessToken, id);


        /// <inheritdoc cref="AreaCheckAreaAsync(string, int, int, int, int)"/>
        public async Task<RspResult<CheckAreaResult>> AreaCheckAreaAsync(int provinceId, int cityId, int countyId, int townId = 0)
            => await AreaCheckAreaAsync(this.AccessToken, provinceId, cityId, countyId, townId);

        /// <inheritdoc cref="AreaGetJDAddressFromAddressAsync(string, string)"/>
        public async Task<RspResult<JDAddress>> AreaGetJDAddressFromAddressAsync(string address)
            => await AreaGetJDAddressFromAddressAsync(this.AccessToken, address);

    }
}
