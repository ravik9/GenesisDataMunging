using System;
using System.Collections.Generic;
using System.IO;
using GenesisDataMunging.Interfaces;
using GenesisDataMunging.Models;

namespace GenesisDataMunging
{
    public class WeatherService: IWeatherService
    {
        public List<CommonModel> GetWeatherRows()
        {
            DatFileReader datFileReader = new DatFileReader();
            List<CommonModel> weatherRows = new List<CommonModel>();
            try
            {
                string WeatherData = File.ReadAllText("Data\\weather.dat");
                weatherRows = datFileReader.WeatherData(WeatherData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unable to read the file: {ex.Message}");
            }
            return weatherRows;

        }

    }
}
