using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2017
{
    public class Day4
    {
        private Days._2017.Day4 _day;

        [SetUp]
        public void Initialize()
        {
            _day = new Days._2017.Day4();
        }
        
        [Test]
        public void ParseRawInput_IntoListOfPassphrases()
        {
            var rawInput = 
@"aa bb cc dd ee
aa bb cc dd aa
aa bb cc dd aaa";

            var input = _day.ParseRawInput(rawInput);

            input.ShouldBe(new List<List<string>>
            {
                new() { "aa", "bb", "cc", "dd", "ee" },
                new() { "aa", "bb", "cc", "dd", "aa" },
                new() { "aa", "bb", "cc", "dd", "aaa" }
            });
        }

        [Test]
        public void Part1_CountValidPassphrases()
        {
            var input = new List<List<string>>
            {
                new() { "aa", "bb", "cc", "dd", "ee" },
                new() { "aa", "bb", "cc", "dd", "aa" },
                new() { "aa", "bb", "cc", "dd", "aaa" }
            };

            var result = _day.Part1(input);
            
            result.ShouldBe(2);
        }
        
        [Test]
        public void Part2_CountValidPassphrases()
        {
            var input = new List<List<string>>
            {
                new() { "abcde", "fghij" },
                new() { "abcde", "xyz", "ecdab" },
                new() { "a", "ab", "abc", "abd", "abf", "abj" },
                new() { "oiii","ioii","iioi","iiio" }
            };

            var result = _day.Part2(input);
            
            result.ShouldBe(2);
        }
    }
}