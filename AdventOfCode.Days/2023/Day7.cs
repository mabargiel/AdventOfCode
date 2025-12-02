using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2023;

public class Day7 : AdventDay<Hand[], int, int>
{
    public override Hand[] ParseRawInput(string rawInput)
    {
        return rawInput
            .Trim()
            .Split(Environment.NewLine)
            .Select(x =>
            {
                var hand = x.Split(' ');
                return new Hand(hand[0].ToCharArray(), int.Parse(hand[1]));
            })
            .ToArray();
    }

    public override int Part1(Hand[] input)
    {
        return DoAssignment(input, false);
    }

    public override int Part2(Hand[] input)
    {
        return DoAssignment(input, true);
    }

    private static int DoAssignment(Hand[] input, bool includeJokers)
    {
        var scores = new Dictionary<Hand, int>();
        foreach (var hand in input)
        {
            var score = CalculateHandScore(hand.Cards, includeJokers);
            scores.Add(hand, score);
        }

        var jokerValue = includeJokers ? -1 : 10;

        var sorted = scores
            .OrderByDescending(pair => pair.Value)
            .ThenByDescending(pair => CalculateCardScore(pair.Key.Cards[0], jokerValue))
            .ThenByDescending(pair => CalculateCardScore(pair.Key.Cards[1], jokerValue))
            .ThenByDescending(pair => CalculateCardScore(pair.Key.Cards[2], jokerValue))
            .ThenByDescending(pair => CalculateCardScore(pair.Key.Cards[3], jokerValue))
            .ThenByDescending(pair => CalculateCardScore(pair.Key.Cards[4], jokerValue))
            .ToArray();

        return checked(sorted.Select((t, i) => (sorted.Length - i) * t.Key.Bet).Sum());
    }

    private static int CalculateCardScore(char card, int jokerValue = 10)
    {
        return card switch
        {
            'A' => 13,
            'K' => 12,
            'Q' => 11,
            'J' => jokerValue,
            'T' => 9,
            _ => (int)char.GetNumericValue(card) - 1,
        };
    }

    private static int CalculateHandScore(IEnumerable<char> handCards, bool includeJokers = false)
    {
        var copy = handCards.ToList();
        var distinctCount = copy.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

        if (distinctCount.Any(x => x.Value == 5))
        {
            return (int)HandTypes.FiveOfAKind;
        }

        if (distinctCount.Any(x => x.Value == 4))
        {
            if (includeJokers && distinctCount.TryGetValue('J', out var value))
            {
                if (value is 1 or 4)
                {
                    return (int)HandTypes.FiveOfAKind;
                }
            }

            return (int)HandTypes.FourOfAKind;
        }

        if (distinctCount.Count == 2)
        {
            if (includeJokers && distinctCount.ContainsKey('J'))
            {
                return (int)HandTypes.FiveOfAKind;
            }

            return (int)HandTypes.FullHouse;
        }

        if (distinctCount.Any(x => x.Value == 3))
        {
            if (includeJokers && distinctCount.ContainsKey('J'))
            {
                return (int)HandTypes.FourOfAKind;
            }

            return (int)HandTypes.ThreeOfAKind;
        }

        if (distinctCount.Count(x => x.Value == 2) == 2)
        {
            if (includeJokers && distinctCount.TryGetValue('J', out var count))
            {
                switch (count)
                {
                    case 1:
                        return (int)HandTypes.FullHouse;
                    case 2:
                        return (int)HandTypes.FourOfAKind;
                }
            }

            return (int)HandTypes.TwoPairs;
        }

        if (distinctCount.Count == 4)
        {
            if (includeJokers && distinctCount.TryGetValue('J', out var v1))
            {
                if (v1 is 1 or 2)
                {
                    return (int)HandTypes.ThreeOfAKind;
                }
            }

            return (int)HandTypes.OnePair;
        }

        if (includeJokers && distinctCount.ContainsKey('J'))
        {
            return (int)HandTypes.OnePair;
        }

        return (int)HandTypes.HighCard;
    }

    private enum HandTypes
    {
        HighCard = 0,
        OnePair,
        TwoPairs,
        ThreeOfAKind,
        FullHouse,
        FourOfAKind,
        FiveOfAKind,
    }
}

public record Hand(char[] Cards, int Bet);
