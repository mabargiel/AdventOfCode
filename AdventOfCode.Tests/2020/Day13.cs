using AdventOfCode.Tests.Helpers;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2020
{
	public class Day13
	{
		[Test]
		public void Part1()
		{
			var input = @"939
								7,13,x,x,59,x,31,19".TrimIndent();

			var d13 = new AdventOfCode.Days._2020._13.Day13(input);
			var result = d13.Part1();

			result.ShouldBe(59 * 5);
		}

		[Test]
		public void Part2()
		{
			var input = @"939
								7,13,x,x,59,x,31,19".TrimIndent();

			var d13 = new AdventOfCode.Days._2020._13.Day13(input);
			var result = d13.Part2();

			result.ShouldBe(1_068_781);
		}
	}
}
