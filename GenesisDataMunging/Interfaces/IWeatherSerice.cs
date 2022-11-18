using GenesisDataMunging.Models;
using System.Collections.Generic;

namespace GenesisDataMunging.Interfaces
{
    public interface IWeatherService
    {
        List<CommonModel> GetWeatherRows();
    }
}