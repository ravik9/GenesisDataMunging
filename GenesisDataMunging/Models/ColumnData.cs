namespace GenesisDataMunging.Models
{
    public class ColumnData
    {
        public int From;
        public int Length;

        public static ColumnData Range(int from, int length)
        {
            return new ColumnData { From = from, Length = length };
        }
    }
}