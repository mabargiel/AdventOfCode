using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace AdventOfCode.Tests._2019;

public class Day9
{
    [Test]
    [TestCase(new long[] { 109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99 },
        new long[] { 109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99 })]
    [TestCase(new long[] { 1102, 34915192, 34915192, 7, 4, 7, 99, 0 }, new[] { 34915192L * 34915192L })]
    [TestCase(new[] { 104, 1125899906842624, 99 }, new[] { 1125899906842624 })]
    public void Part1Part2(long[] code, long[] expectedOutput)
    {
        var d9 = new Days._2019._9.Day9(code);
        CollectionAssert.AreEqual(expectedOutput, d9.Part1());
    }
}
