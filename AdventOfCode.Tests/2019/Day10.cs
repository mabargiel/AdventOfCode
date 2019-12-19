using System.Drawing;
using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode.Tests._2019
{
    public class Day10
    {
        [Test]
        [TestCase(@".#..#
                    .....
                    #####
                    ....#
                    ...##", 8)]
        [TestCase(@"......#.#.
                    #..#.#....
                    ..#######.
                    .#.#.###..
                    .#..#.....
                    ..#....#.#
                    #..#....#.
                    .##.#..###
                    ##...#..#.
                    .#....####", 33)]
        [TestCase(@".#..##.###...#######
                                ##.############..##.
                                .#.######.########.#
                                .###.#######.####.#.
                                #####.##.#.##.###.##
                                ..#####..#.#########
                                ####################
                                #.####....###.#.#.##
                                ##.#################
                                #####.##.###..####..
                                ..######..##.#######
                                ####.##.####...##..#
                                .#####..#.######.###
                                ##...#.##########...
                                #.##########.#######
                                .####.#.###.###.#.##
                                ....##.##.###..#####
                                .#.#.###########.###
                                #.#.#.#####.####.###
                                ###.##.####.##.#..##", 210)]
        
        public void Part1(string asteroidsMap, int expectedDetectedAsteroids)
        {
            var d9 = new AdventOfCode._2019._10.Day10(asteroidsMap);
            Assert.AreEqual(expectedDetectedAsteroids, d9.Part1());
        }

        [Test]
        [TestCase(@".#....#####...#..
                                ##...##.#####..##
                                ##...#...#.#####.
                                ..#.....#...###..
                                ..#.#.....#....##")]
        public void Part2_1(string asteroidsMap)
        {
            var d9 = new AdventOfCode._2019._10.Day10(asteroidsMap);
            var vaporizedAsteroids = d9.Part2().ToArray();

            vaporizedAsteroids.ShouldBe(new[]
            {
                new Point { X = 8, Y = 1 }, new Point { X = 9, Y = 0 }, new Point { X = 9, Y = 1 }, new Point { X = 10, Y = 0 }, new Point { X = 9, Y = 2 },
                new Point { X = 11, Y = 1 }, new Point { X = 12, Y = 1 }, new Point { X = 11, Y = 2 }, new Point { X = 15, Y = 1 }, new Point { X = 12, Y = 2 },
                new Point { X = 13, Y = 2 }, new Point { X = 14, Y = 2 }, new Point { X = 15, Y = 2 }, new Point { X = 12, Y = 3 }, new Point { X = 16, Y = 4 },
                new Point { X = 15, Y = 4 }, new Point { X = 10, Y = 4 }, new Point { X = 4, Y = 4 }, new Point { X = 2, Y = 4 }, new Point { X = 2, Y = 3 },
                new Point { X = 0, Y = 2 }, new Point { X = 1, Y = 2 }, new Point { X = 0, Y = 1 }, new Point { X = 1, Y = 1 }, new Point { X = 5, Y = 2 },
                new Point { X = 1, Y = 0 }, new Point { X = 5, Y = 1 }, new Point { X = 6, Y = 1 }, new Point { X = 6, Y = 0 }, new Point { X = 7, Y = 0 },
                new Point { X = 8, Y = 0 }, new Point { X = 10, Y = 1 }, new Point { X = 14, Y = 0 }, new Point { X = 16, Y = 1 }, new Point { X = 13, Y = 3 },
                new Point { X = 14, Y = 3 }
            });
        }
        
        [Test]
        [TestCase(@".#..##.###...#######
                                ##.############..##.
                                .#.######.########.#
                                .###.#######.####.#.
                                #####.##.#.##.###.##
                                ..#####..#.#########
                                ####################
                                #.####....###.#.#.##
                                ##.#################
                                #####.##.###..####..
                                ..######..##.#######
                                ####.##.####...##..#
                                .#####..#.######.###
                                ##...#.##########...
                                #.##########.#######
                                .####.#.###.###.#.##
                                ....##.##.###..#####
                                .#.#.###########.###
                                #.#.#.#####.####.###
                                ###.##.####.##.#..##")]
        public void Part2_2(string asteroidsMap)
        {
            var d9 = new AdventOfCode._2019._10.Day10(asteroidsMap);
            var selectedVaporizedAsteroids = d9.Part2().Where((point, i) => new[] { 1, 2, 3, 10, 20, 50, 100, 199, 200, 201, 299 }.Contains(i + 1)).ToArray();

            selectedVaporizedAsteroids.ShouldBe(new[]
            {
                new Point(11, 12), new Point(12, 1), new Point(12, 2), new Point(12, 8), new Point(16, 0), new Point(16, 9), new Point(10, 16), new Point(9, 6),
                new Point(8, 2), new Point(10, 9), new Point(11, 1)
            });
        }
    }
}