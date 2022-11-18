using GenesisDataMunging.Models;
using System.Collections.Generic;

namespace GenesisDataMunging.Interfaces
{
    public interface ISoccerService
    {
        List<CommonModel> GetDetails();
    }
}
