using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2020
{
	public class Day12
	{
		[Test]
		public void Part1()
		{
			const string input = @"F10
N3
F7
R90
F11";

			var d12 = new AdventOfCode.Days._2020._12.Day12(input);
			var result = d12.Part1();

			result.ShouldBe(17 + 8);
		}

		[Test]
		public void Part2()
		{
			const string input = @"F10
N3
F7
R90
F11";

			var d12 = new AdventOfCode.Days._2020._12.Day12(input);
			var result = d12.Part2();

			result.ShouldBe(214 + 72);
		}
	}
}
