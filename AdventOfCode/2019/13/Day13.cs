using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode._2019.Intcode;
using MoreLinq.Extensions;

namespace AdventOfCode._2019._13
{
    public class Day13 : IAdventDay<Dictionary<PointF, long>, long>
    {
        private readonly IIntcodeComputer _intcodeComputer;

        public Day13(IIntcodeComputer intcodeComputer)
        {
            _intcodeComputer = intcodeComputer;
        }

        public Dictionary<PointF, long> Part1()
        {
            var arcade = new ArcadeCabinet(_intcodeComputer);

            arcade.GenerateTiles();

            return arcade.Tiles;
        }

        public long Part2()
        {
            _intcodeComputer.Program.Memory[0] = 2;
            var arcade = new ArcadeCabinet(_intcodeComputer);
            var win = false;

            Task.Run(() =>
            {
                while(true)
                {
                    arcade.GenerateTiles();

                    var (board, scoreTile) = CreateBoard(arcade.Tiles);
                    DrawBoard(board, scoreTile.Value);

                    Task.Delay(500);
                }
            });

            while (!win)
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.RightArrow:
                        arcade.SetJoystick(1);
                        break;
                    case ConsoleKey.UpArrow:
                        arcade.SetJoystick(0);
                        break;
                    case ConsoleKey.LeftArrow:
                        arcade.SetJoystick(-1);
                        break;
                    case ConsoleKey.Q:
                        win = true;
                        break;
                }
            }

            return 0;
        }

        private static void DrawBoard(IEnumerable<char[]> board, long score)
        {
            Console.Clear();
            
            foreach (var row in board)
            {
                foreach (var tile in row)
                {
                    Console.Write(tile);
                }
                
                Console.WriteLine();
            }
        }

        private static (char[][] board, KeyValuePair<PointF, long> scoreTile) CreateBoard(Dictionary<PointF, long> tiles)
        {
            var scoreTile = tiles.First(x => x.Key == new PointF(-1, 0));

            var drawableTiles = tiles.Except(new []{scoreTile}).ToList();
            var width = (int) drawableTiles.Max(tile => tile.Key.X) + 1;
            var height = (int) drawableTiles.Max(tile => tile.Key.Y) + 1;

            var board = new char[height][];

            for (var i = 0; i < board.Length; i++)
            {
                board[i] = new char[width];
            }

            foreach (var tile in drawableTiles)
            {
                char c;
                switch ((TileId) tile.Value)
                {
                    case TileId.Wall:
                        c = '@';
                        break;
                    case TileId.Block:
                        c = '#';
                        break;
                    case TileId.HorizontalPaddle:
                        c = '-';
                        break;
                    case TileId.Ball:
                        c = '*';
                        break;
                    default:
                        c = ' ';
                        break;
                }

                board[(long) tile.Key.Y][(long) tile.Key.X] = c;
            }

            return (board, scoreTile);
        }
    }

    public class ArcadeCabinet
    {
        private readonly IIntcodeComputer _intcodeComputer;

        public ArcadeCabinet(IIntcodeComputer intcodeComputer)
        {
            _intcodeComputer = intcodeComputer;
        }

        public Dictionary<PointF, long> Tiles { get; } = new Dictionary<PointF, long>();

        public void GenerateTiles()
        {
            var outputs = new BlockingCollection<long>(3);

            _intcodeComputer.Program.OnOutput += l => outputs.Add(l);
            
            var game = _intcodeComputer.RunAsync();

            while (!game.IsCompleted)
            {
                var x = outputs.Take();
                var y = outputs.Take();
                var tileId = outputs.Take();
                
                Tiles[new PointF(x, y)] = tileId;
            }

            foreach (var args in game.Result.Batch(3))
            {
                var arr = args.ToArray();
                Tiles[new PointF(arr[0], arr[1])] = arr[2];
            }

            _intcodeComputer.Program.Pointer = 0;
        }

        public void SetJoystick(in int movement)
        {
            _intcodeComputer.Input(movement);
        }
    }

    public class Tile
    {
        public PointF Position { get; }
        public long TileId { get; }

        public Tile(PointF position, long tileId)
        {
            Position = position;
            TileId = tileId;
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