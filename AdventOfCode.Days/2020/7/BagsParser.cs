using System;
using System.Collections.Generic;
using System.Linq;
using Sprache;

namespace AdventOfCode.Days._2020._7
{
    public class BagsParser
    {
        private static readonly Parser<string> BagSeparator = Parse.String(", ").Text();
        private static readonly Parser<string> NewLine = Parse.String(Environment.NewLine).Text();
        private static readonly Parser<char> SpaceCharacter = Parse.Char(' ');

        private static readonly Parser<string> ContentSeparator =
            from leading in SpaceCharacter
            from indicator in Parse.String("contain").Text()
            from trailing in SpaceCharacter
            select indicator;

        private static readonly Parser<(string, string, int)> Bag =
            from qty in Parse.Digit.Optional()
            from s1 in SpaceCharacter.Optional()
            from shade in Parse.Letter.Many().Text()
            from s2 in SpaceCharacter
            from color in Parse.Letter.Many().Text()
            from s3 in SpaceCharacter
            from bags in Parse.String("bag")
            from sc in Parse.Char('s').Optional()
            select (shade, color, qty.IsDefined ? (int) char.GetNumericValue(qty.Get()) : 1);

        private static readonly Parser<List<(string, string, int)>> Bags =
            from leading in Bag
            from rest in BagSeparator.Optional().Then(_ => Bag).Many()
            select Cons(leading, rest).ToList();

        private static readonly Parser<Bag> BagWithContent =
            from main in Bag
            from content in ContentSeparator.Then(_ =>
                Parse.String("no other bags").Text().Return(new List<(string, string, int)>()).Or(Bags))
            from end in Parse.Char('.')
            select new Bag(main.Item1, main.Item2, main.Item3,
                content.Select(bag => new Bag(bag.Item1, bag.Item2, bag.Item3)).ToList());

        private static readonly Parser<List<Bag>> AllBags =
            from leading in BagWithContent
            from rest in NewLine.Then(_ => BagWithContent).Many().Optional()
            select Cons(leading, rest.Get()).ToList();

        public List<Bag> ParseInput(string input)
        {
            return AllBags.Parse(input);
        }

        private static IEnumerable<T> Cons<T>(T head, IEnumerable<T> rest)
        {
            yield return head;
            foreach (var item in rest ?? new List<T>())
                yield return item;
        }
    }
}