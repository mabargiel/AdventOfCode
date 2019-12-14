using NUnit.Framework;

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
..#.#.....#....##", 1403)]
        public void Part2(string asteroidsMap, int expected200ThAsteroidCoordinates)
        {
            var d9 = new AdventOfCode._2019._10.Day10(asteroidsMap, 9);
            Assert.AreEqual(expected200ThAsteroidCoordinates, d9.Part2());
        }
    }
}