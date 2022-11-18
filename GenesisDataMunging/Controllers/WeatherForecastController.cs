using GenesisDataMunging.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;   
using System.Collections.Generic;
using System.Linq;
using GenesisDataMunging.Interfaces;

namespace GenesisDataMunging.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService )
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet]
        public IActionResult Sample()
        {
            var rows = _weatherService.GetWeatherRows();
            CommonModel res = null;
            CommonModel smallestTempSpreadDay = rows.OrderBy(x => x.Difference).FirstOrDefault();
            if (smallestTempSpreadDay != null)
            {
                res = smallestTempSpreadDay;
            }
            else
            {
                Console.WriteLine("Weather.dat file is empty");
            }
            return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(res));
        }
    }
}
