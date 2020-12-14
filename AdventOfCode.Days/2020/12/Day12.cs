using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MoreLinq;

namespace AdventOfCode.Days._2020._12
{
	public class Day12 : AdventDay<int, int>
	{
		private readonly List<(Actions, int)> _actions;

		public Day12(string input)
		{
			var actions = input.Split(Environment.NewLine)
				.Select(action =>
				{
					var a = action[0] switch
					{
						'N' => Actions.MoveNorth,
						'S' => Actions.MoveSouth,
						'E' => Actions.MoveEast,
						'W' => Actions.MoveWest,
						'L' => Actions.TurnLeft,
						'R' => Actions.TurnRight,
						'F' => Actions.Forward,
						_ => throw new ArgumentException("Invalid action symbol")
					};

					return (a, int.Parse(action.Substring(1, action.Length - 1)));
				}).ToList();

			_actions = actions;
		}

		public override int Part1()
		{
			var system = new NavigationSystem(new Position(0, 0));
			var actions = new Queue<(Actions, int)>(_actions);

			while (actions.Count > 0)
			{
				var (action, value) = actions.Dequeue();

				switch (action)
				{
					case Actions.MoveNorth:
						system.MoveWaypoint(value, Direction.North);
						break;
					case Actions.MoveEast:
						system.MoveWaypoint(value, Direction.East);
						break;
					case Actions.MoveSouth:
						system.MoveWaypoint(value, Direction.South);
						break;
					case Actions.MoveWest:
						system.MoveWaypoint(value, Direction.West);
						break;
					case Actions.TurnLeft:
						system.RotateDirection(value, true);
						break;
					case Actions.TurnRight:
						system.RotateDirection(value, false);
						break;
					case Actions.Forward:
						system.MoveWaypoint(value);
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}

			return Math.Abs(system.Waypoint.EastWest) + Math.Abs(system.Waypoint.NorthSouth);
		}

		public override int Part2()
		{
			var system = new NavigationSystem(new Position(1, 10));
			var actions = new Queue<(Actions, int)>(_actions);

			while (actions.Count > 0)
			{
				var (action, value) = actions.Dequeue();

				switch (action)
				{
					case Actions.MoveNorth:
						system.MoveWaypoint(value, Direction.North);
						break;
					case Actions.MoveEast:
						system.MoveWaypoint(value, Direction.East);
						break;
					case Actions.MoveSouth:
						system.MoveWaypoint(value, Direction.South);
						break;
					case Actions.MoveWest:
						system.MoveWaypoint(value, Direction.West);
						break;
					case Actions.TurnLeft:
						system.RotateWaypoint(value, true);
						break;
					case Actions.TurnRight:
						system.RotateWaypoint(value, false);
						break;
					case Actions.Forward:
						system.MoveShip(value);
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}

			return Math.Abs(system.Ship.EastWest) + Math.Abs(system.Ship.NorthSouth);
		}
	}
}
