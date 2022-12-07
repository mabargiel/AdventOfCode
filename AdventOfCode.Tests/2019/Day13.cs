using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventOfCode.Days._2019._13;
using AdventOfCode.Days._2019.Intcode;
using NSubstitute;
using NUnit.Framework;

namespace AdventOfCode.Tests._2019;

public class Day13
{
    [Test]
    [TestCase(new long[] { 1, 2, 3, 6, 5, 4 }, 2)]
    public async Task Part1(long[] outputs, int expectedResult)
    {
        var intcodeComputer = Substitute.For<IIntcodeComputer>();

        var cabinet = new ArcadeCabinet(intcodeComputer);
        var tiles = new List<long>();

        cabinet.OnTileUpdated += tile => tiles.Add(tile.Item2);

        var game = cabinet.RunGame();

        foreach (var output in outputs)
        {
            intcodeComputer.OnOutput += Raise.Event<Action<long>>(output);
        }

        await game;

        Assert.AreEqual(expectedResult, tiles.Count);
    }
}