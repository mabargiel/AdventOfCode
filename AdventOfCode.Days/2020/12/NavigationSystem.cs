using System;
using System.Collections.Generic;

namespace AdventOfCode.Days._2020._12
{
	public class NavigationSystem
	{
		private static readonly List<Direction> AllDirections = new() {Direction.North, Direction.East, Direction.South, Direction.West};
		private Direction _currentDirection = Direction.East;
		public Position Waypoint { get; private set; }
		public Position Ship { get; private set; } = new Position(0, 0);

		public NavigationSystem(Position waypoint)
		{
			Waypoint = waypoint;
		}

		public void MoveWaypoint(in int value, Direction? direction = null)
		{
			direction ??= _currentDirection;

			Waypoint = direction switch
			{
				Direction.North => new Position(Waypoint.NorthSouth + value, Waypoint.EastWest),
				Direction.East => new Position(Waypoint.NorthSouth, Waypoint.EastWest + value),
				Direction.South => new Position(Waypoint.NorthSouth - value, Waypoint.EastWest),
				Direction.West => new Position(Waypoint.NorthSouth, Waypoint.EastWest - value),
				_ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
			};
		}

		public void RotateDirection(in int value, bool counterClockwise)
		{
			var times = (counterClockwise ? -value : value) / 90;
			var index = AllDirections.IndexOf(_currentDirection);
			var newIndex = (times < 0 ? 4 + times + index : index + times) % 4;

			_currentDirection = AllDirections[newIndex];
		}

		public void RotateWaypoint(int value, bool counterClockwise)
		{
			value = counterClockwise ? 360 - value : value;
			Waypoint = value switch
			{
				90 => new Position(-Waypoint.EastWest, Waypoint.NorthSouth),
				180 => new Position(-Waypoint.NorthSouth, -Waypoint.EastWest),
				270 => new Position(Waypoint.EastWest, -Waypoint.NorthSouth),
				_ => throw new ArgumentException("Value should be 90, 180 or 270", nameof(value))
			};
		}

		public void MoveShip(in int value)
		{
			var moveNorthSouth = Waypoint.NorthSouth * value;
			var moveEastWest = Waypoint.EastWest * value;

			Ship = new Position(Ship.NorthSouth + moveNorthSouth, Ship.EastWest + moveEastWest);
		}
	}
}