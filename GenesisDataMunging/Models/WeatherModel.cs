using System;

namespace GenesisDataMunging.Models
{
    public class CommonModel
    {
        public string Day;
        public int Max;
        public int Min;

        public int Difference
        {
            get
            {
                return Math.Abs(Min - Max);
            }
        }
    }
}
