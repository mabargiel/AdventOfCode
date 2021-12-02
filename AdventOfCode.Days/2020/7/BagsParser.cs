using System.Collections.Generic;
using System.Linq;
using Sprache;

namespace AdventOfCode.Days._2020._7
{
    internal static class BagsParser
    {
        private static readonly Parser<string> BagSeparator = Parse.String(", ").Text();
        private static readonly Parser<char> SpaceCharacter = Parse.Char(' ');

        private static readonly Parser<string> ContentSeparator =
            from leading in SpaceCharacter
            from indicator in Parse.String("contain").Text()
            from trailing in SpaceCharacter
            select indicator;

        private static readonly Parser<(string, string)> Bag =
            from shade in Parse.Letter.Many().Text()
            from _ in SpaceCharacter
            from color in Parse.Letter.Many().Text()
            from __ in SpaceCharacter
            from bags in Parse.String("bag")
            from sc in Parse.Char('s').Optional()
            select (shade, color);

        private static readonly Parser<(int, string, string)> BagWithQty =
            from qty in Parse.Digit
            from _ in SpaceCharacter
            from bag in Bag
            select ((int)char.GetNumericValue(qty), bag.Item1, bag.Item2);

        private static readonly Parser<List<(int, string, string)>> BagContent =
            Parse.String("no other bags").Return(new List<(int, string, string)>()).Or(from leading in BagWithQty
                from rest in BagSeparator.Optional().Then(_ => BagWithQty).Many()
                select Cons(leading, rest.ToList()).ToList());

        private static readonly Parser<List<Bag>> AllBags =
            from bags in (from main in Bag
                    from separator in ContentSeparator
                    from content in BagContent
                    select new Bag(main.Item1, main.Item2, 1,
                        content.Select(bag => new Bag(bag.Item2, bag.Item3, bag.Item1)).ToList()))
                .DelimitedBy(Parse.Char('.').Then(_ => Parse.LineEnd))
            select bags.ToList();

        public static List<Bag> ParseInput(string input)
        {
            return AllBags.Parse(input);
        }

        private static IEnumerable<T> Cons<T>(T head, IEnumerable<T> rest)
        {
            yield return head;
            foreach (var item in rest ?? new List<T>())
            {
                yield return item;
            }
        }
    }
}