using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2020._7
{
    public class Day7 : IAdventDay<int, int>
    {
        private readonly List<Bag> _bags;

        public Day7(string input)
        {
            _bags = BagsParser.ParseInput(input);
        }

        public int Part1()
        {
            return _bags.Count(AtLeastOneShinyGoldBag);
        }

        public int Part2()
        {
            return _bags.Where(bag => bag.Shade == "shiny" && bag.Color == "gold").Sum(TotalBagsInsideIncludeSelf) - 1;
        }

        private bool AtLeastOneShinyGoldBag(Bag bag)
        {
            if (bag.Bags.Any(insideBag => insideBag.Shade == "shiny" && insideBag.Color == "gold"))
                return true;

            return bag.Bags
                .Select(insideBag =>
                    _bags.FirstOrDefault(bag1 => bag1.Shade == insideBag.Shade && bag1.Color == insideBag.Color))
                .Where(topBag => topBag != null)
                .Any(AtLeastOneShinyGoldBag);
        }

        private int TotalBagsInsideIncludeSelf(Bag bag)
        {
            int sum = 0;
            foreach (var insideBag in bag.Bags)
            {
                Bag? topBag = _bags.FirstOrDefault(bag1 => bag1.Shade == insideBag.Shade && bag1.Color == insideBag.Color);
                if (topBag != null) sum += insideBag.Qty * TotalBagsInsideIncludeSelf(topBag);
            }

            return bag.Qty + sum;
        }
    }
}