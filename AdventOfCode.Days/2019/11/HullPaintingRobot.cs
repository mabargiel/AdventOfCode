using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using AdventOfCode.Days._2019.Intcode;

namespace AdventOfCode.Days._2019._11
{
    public class HullPaintingRobot
    {
        private readonly LinkedList<Direction> _allDirections =
            new(new[] { Direction.Up, Direction.Right, Direction.Bottom, Direction.Left });

        private readonly IIntcodeComputer _boardComputer;
        private readonly Dictionary<Point, bool> _paintArea;
        private Point _currentPosition;
        private Direction _facingDirection;
        private bool _moveMode;

        public HullPaintingRobot(IIntcodeComputer boardComputer, Dictionary<Point, bool> paintArea)
        {
            _boardComputer = boardComputer;
            _facingDirection = Direction.Up;
            _currentPosition = new Point(0, 0);
            _paintArea = paintArea;
            _moveMode = false;
        }

        public async Task RunAsync()
        {
            _boardComputer.OnOutput += output =>
            {
                if (_moveMode)
                {
                    var linkedListNode = _allDirections.Find(_facingDirection);
                    _facingDirection = output == 0
                        ? linkedListNode?.Previous?.Value ?? _allDirections.Last.Value
                        : linkedListNode?.Next?.Value ?? _allDirections.First.Value;

                    Move();

                    var alreadyPainted = _paintArea.TryGetValue(_currentPosition, out var isWhite);
                    _boardComputer.Input(alreadyPainted && isWhite ? 1 : 0);
                }
                else //paint mode
                {
                    _paintArea[_currentPosition] = output == 1;
                }

                _moveMode = !_moveMode;
            };

            await _boardComputer.StartAsync();
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