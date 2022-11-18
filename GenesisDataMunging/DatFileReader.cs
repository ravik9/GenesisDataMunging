using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using GenesisDataMunging.Models;

namespace GenesisDataMunging
{
    public class DatFileReader
    {
        public List<CommonModel> WeatherData(string fileData)
        {
            return DatReader(
                fileData,
                2,
                2,
                1,2,3);
        }

        private List<CommonModel> DatReader(string fileData, int skipStart, int skipEnd, int namecol, int maxcol, int mincol)
        {
            var sample = Regex.Split("   1  88    59    74          53.8       0.00 F       280  9.6 270  17  1.6  93 23 1004.5", @"\s+");
            string[] split = fileData.Split("\n");
            var parsed = split
                .Skip(skipStart)
                .Take(split.Length - (skipStart + skipEnd))
                .Where(row => !row.Contains("-------------------------------------------------------"))
                .Select(x =>
                {
                    Console.WriteLine($"{Regex.Split(x, @"\s+")[namecol].Trim()}, {Regex.Split(x, @"\s+")[maxcol].Trim()}, {Regex.Split(x, @"\s+")[mincol].Trim()}");
                    return new CommonModel()
                    {
                        Day = Regex.Split(x, @"\s+")[namecol].Trim(),
                        Max = int.Parse(Regex.Split(x, @"\s+")[maxcol].Trim()),
                        Min = int.Parse(Regex.Split(x, @"\s+")[mincol].Trim())
                    };
                })
                .ToList();
            return parsed;
        }

        public List<CommonModel> SoccerScores(string fileData)
        {
            return DatReader(fileData, 1, 1, 2,3,4);
        }

    }
}