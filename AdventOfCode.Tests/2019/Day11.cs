using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using AdventOfCode._2019._11;
using AdventOfCode._2019.Intcode;
using MoreLinq;
using NSubstitute;
using NUnit.Framework;

namespace AdventOfCode.Tests._2019
{
    public class Day11
    {
        [Test]
        [TestCase(new[] {1, 0, 0, 0, 1, 0, 1, 0, 0, 1, 1, 0, 1, 0}, 6)]
        [TestCase(new[] {1, 0, 0, 0, 1, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1}, 12)]
        [TestCase(new[] {1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1}, 10)]
        [TestCase(new[] {1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1}, 50)]
        public async Task Run_HullPaintingRobot(int[] output, int expectedResult)
        {
            var paintArea = new Dictionary<Point, bool>();
            var intcodeComputer = Substitute.For<IIntcodeComputer>();
            var program = new Program(new Dictionary<long, long>());
            intcodeComputer.Program.Returns(program);
            var hullRobot = new HullPaintingRobot(intcodeComputer, paintArea);
            
            var task = hullRobot.Run();
            
            output.ForEach(o => intcodeComputer.Program.Output(o));
            
            await task;

            Assert.AreEqual(expectedResult, paintArea.Count);
        }
    }
}