namespace AdventOfCode.Days._2019._14
{
    public class Day14 : IAdventDay<long, int>
    {
        private readonly Nanofactory _nanofactory;

        public Day14(string input)
        {
            _nanofactory = new Nanofactory(input);
        }
        
        public long Part1()
        {
            var oresUsed = _nanofactory.GetRequiredOres("FUEL", 1);
            return oresUsed.Ores;
        }

        public int Part2()
        {
            const long cargoHold = 1_000_000_000_000;
            return 0;
        }
    }
}