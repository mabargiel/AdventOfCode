using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode._2019.Intcode;

namespace AdventOfCode._2019._11
{
    public class Day11 : IAdventDay<int, int>
    {
        private readonly long[] _robotCode;

        public Day11(long[] robotCode)
        {
            _robotCode = robotCode;
        }
        
        public int Part1()
        {
            var paintArea = new Dictionary<Point, bool>();
            var robot = new HullPaintingRobot(_robotCode, ref paintArea);

            robot.Run();

            return paintArea.Count;
        }

        public int Part2()
        {
            throw new System.NotImplementedException();
        }
    }

    public class HullPaintingRobot
    {
        private Direction _facingDirection;
        private readonly LinkedList<Direction> _allDirections = new LinkedList<Direction>(new[] { Direction.Up, Direction.Right, Direction.Bottom, Direction.Left });
        private readonly Dictionary<Point, bool> _paintArea;
        private Point _currentPosition;
        private readonly IntcodeComputer _boardComputer;

        internal HullPaintingRobot(IEnumerable<long> code, ref Dictionary<Point, bool> paintArea)
        {
            var instructions = code.Select((x, i) => (x, (long) i)).ToDictionary(x => x.Item2, x => x.x);
            _boardComputer = new IntcodeComputer(new Intcode.Program(instructions));
            _facingDirection = Direction.Up;
            _currentPosition = new Point(0, 0);
            _paintArea = paintArea;
        }

        public void Run()
        {
            
            var currentOutput = new BlockingCollection<long>(2);
            
            var runningProgram = Task.Run(() => _boardComputer.Run());
            _boardComputer.Program.OnOutput += output => currentOutput.Add(output);

            using var file = File.OpenWrite("file.txt");
            while (!runningProgram.IsCompleted)
            {
                var alreadyPainted = _paintArea.TryGetValue(_currentPosition, out var isWhite);
                _boardComputer.Program.Buffer.Add(alreadyPainted && isWhite ? 1 : 0);

                _paintArea[_currentPosition] = currentOutput.Take() == 1;

                var linkedListNode = _allDirections.Find(_facingDirection);
                _facingDirection = currentOutput.Take() == 0
                    ? linkedListNode?.Previous?.Value ?? _allDirections.Last.Value
                    : linkedListNode?.Next?.Value ?? _allDirections.First.Value;
                
                file.Write(Convert.);

                Move();
            }
        }

        private void Move()
        {
            _currentPosition = _facingDirection switch
            {
                Direction.Up => new Point(_currentPosition.X, _currentPosition.Y - 1),
                Direction.Right => new Point(_currentPosition.X + 1, _currentPosition.Y),
                Direction.Bottom => new Point(_currentPosition.X, _currentPosition.Y + 1),
                Direction.Left => new Point(_currentPosition.X - 1, _currentPosition.Y),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private enum Direction
        {
            Up,
            Right,
            Bottom,
            Left
        }
    }
}