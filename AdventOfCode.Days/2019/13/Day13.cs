using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using AdventOfCode.Days._2019.Intcode;

namespace AdventOfCode.Days._2019._13
{
    public class Day13 : IAdventDay<List<long>, long>
    {
        private readonly IIntcodeComputer _intcodeComputer;

        public Day13(IIntcodeComputer intcodeComputer)
        {
            _intcodeComputer = intcodeComputer;
        }

        public (TileId[][] board, KeyValuePair<PointF, long> scoreTile) Board { get; private set; }

        public List<long> Part1()
        {
            var arcade = new ArcadeCabinet(_intcodeComputer);

            var game = arcade.RunGame();

            var tiles = new List<long>();
            arcade.OnTileUpdated += tile => tiles.Add(tile.Item2);
            game.Wait();

            return tiles;
        }

        public long Part2()
        {
            _intcodeComputer.Program.Memory[0] = 2;
            var cabinet = new ArcadeCabinet(_intcodeComputer);

            long paddlePositionX = 0;
            long score = 0;

            cabinet.OnTileUpdated += tile =>
            {
                var (pointF, tileId) = tile;

                if ((long)pointF.X == -1 && (long)pointF.Y == 0)
                {
                    score = tileId;
                }

                switch ((TileId)tileId)
                {
                    case TileId.Ball:
                        var joystickMode = pointF.X.CompareTo(paddlePositionX);
                        cabinet.SetJoystick(joystickMode);
                        break;
                    case TileId.HorizontalPaddle:
                        paddlePositionX = (long)pointF.X;
                        break;
                }
            };

            cabinet.RunGame().Wait();

            return score;
        }
    }

    public class ArcadeCabinet
    {
        private readonly IIntcodeComputer _intcodeComputer;

        public ArcadeCabinet(IIntcodeComputer intcodeComputer)
        {
            _intcodeComputer = intcodeComputer;
        }

        public event Action<(PointF, long)> OnTileUpdated;

        public async Task RunGame()
        {
            var outputs = new BlockingCollection<long>();
            _intcodeComputer.OnOutput += l =>
            {
                outputs.Add(l);
                if (outputs.Count == 3)
                {
                    var x = outputs.Take();
                    var y = outputs.Take();
                    var tileId = outputs.Take();

                    OnTileUpdated?.Invoke((new PointF(x, y), tileId));
                }
            };

            await _intcodeComputer.StartAsync();
        }

        public void SetJoystick(int movement)
        {
            _intcodeComputer.Input(movement);
        }
    }

    public enum TileId
    {
        Empty,
        Wall,
        Block,
        HorizontalPaddle,
        Ball
    }
}