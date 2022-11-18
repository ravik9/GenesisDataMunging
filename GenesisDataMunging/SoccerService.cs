using GenesisDataMunging.Interfaces;
using GenesisDataMunging.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GenesisDataMunging
{
    public class SoccerService : ISoccerService
    {
        public List<CommonModel> GetDetails()
        {
            DatFileReader datFileReader = new DatFileReader();
            List<CommonModel> soccerRows = new List<CommonModel>();

            try
            {
                var SoccerData = File.ReadAllText("Data\\football.dat");
                soccerRows = datFileReader.SoccerScores(SoccerData);
                //var teamWithSmallDifference = rows.OrderBy(x => x.Difference).FirstOrDefault();
                //if (teamWithSmallDifference != null)
                //{
                //    Console.WriteLine($"Team: {teamWithSmallScoreDifference.Name}" +
                //                      $" Against: {teamWithSmallScoreDifference.Col1}" +
                //                      $" For: {teamWithSmallScoreDifference.Col2}" +
                //                      $" Difference: {teamWithSmallScoreDifference.Differance}");
                //}
                //else
                //{
                //    Console.WriteLine("Football.dat file is empty");
                //}
            }

             catch (Exception ex)
            {
                Console.WriteLine($"Unable to read the file: {ex.Message}");
            }
            return soccerRows;
        }
    }
}
