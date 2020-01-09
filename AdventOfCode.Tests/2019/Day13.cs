using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode._2019.Intcode;
using MoreLinq;
using NSubstitute;
using NUnit.Framework;

namespace AdventOfCode.Tests._2019
{
    public class Day13
    {
        [Test]
        [TestCase(new long[] {1,2,3,6,5,4}, 2)]
        public void Part1(long[] outputs, int expectedResult)
        {
            var intcodeComputer = Substitute.For<IIntcodeComputer>();
            var program = new Program(new Dictionary<long, long>());
            intcodeComputer.Program.Returns(program);
            intcodeComputer.RunAsync().Returns(Task.FromResult(outputs));
            
            var d13 = new AdventOfCode._2019._13.Day13(intcodeComputer);
            
            Assert.AreEqual(expectedResult, d13.Part1().Count);
        }
    }
}