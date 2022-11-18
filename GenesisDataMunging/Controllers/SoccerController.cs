using GenesisDataMunging.Interfaces;
using GenesisDataMunging.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace GenesisDataMunging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoccerController : ControllerBase
    {
        private readonly ISoccerService _soccerService;

        public SoccerController(ISoccerService soccerService)
        {
            _soccerService = soccerService;

        }
        [HttpGet]
        public IActionResult GetSoccerDetails()
        {
            var rows = _soccerService.GetDetails();
            CommonModel res = new CommonModel();
            var teamWithSmallScoreDifference = rows.OrderBy(x => x.Difference).FirstOrDefault();
            if (teamWithSmallScoreDifference != null)
            {
                res = teamWithSmallScoreDifference;
            }
            else
            {
                Console.WriteLine("Football.dat file is empty");
            }
            return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(res));
        }
    }
}
