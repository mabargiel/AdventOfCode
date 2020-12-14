using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;

namespace AdventOfCode.Days._2020._13
{
	public class Day13 : AdventDay<int, long>
	{
		private readonly int _earliestTimestamp;
		private readonly IEnumerable<int> _buses;

		public Day13(string input)
		{
			var lines = input.Split(Environment.NewLine);
			_earliestTimestamp = int.Parse(lines[0]);
			_buses = lines[1].Split(',').Select(s => s == "x" ? 0 : int.Parse(s));
		}

		public override int Part1()
		{
			var potentialResults = new Dictionary<int, int>();

			foreach (var bus in _buses.Where(it => it > 0))
			{
				var amountOfMultiplies = (int) Math.Ceiling(_earliestTimestamp / (double) bus - 1);
				var highestMultiply = bus * (amountOfMultiplies + 1);

				potentialResults.Add(bus, highestMultiply - _earliestTimestamp);
			}

			var (busToTake, minutesWait) = potentialResults.MinBy(pair => pair.Value).First();

			return busToTake * minutesWait;
		}

		public override long Part2()
		{
			var buses = _buses.Select((i, v) => new BusValue(i + 1, v)).Where(it => it.InitialValue > 0).ToList();

			do
			{
				foreach (var bus in buses)
				{
					bus.CurrentValue += bus.InitialValue;
				}
			} while (!AreValid());

			return buses.First().CurrentValue;

			bool AreValid()
			{
				for (var i = 0; i < buses.Count - 1; i ++)
				{
					if (buses[i + 1].CurrentValue != buses[i].CurrentValue + buses[i + 1].Constraint - buses[i].Constraint)
						return false;
				}

				return true;
			}
		}
	}

	public class BusValue
	{
		public int Constraint { get; }
		public int InitialValue { get; }

		public long CurrentValue { get; set; }

		public BusValue(int constraint, in int initialValue)
		{
			Constraint = constraint;
			InitialValue = initialValue;
			CurrentValue = initialValue;
		}
	}
}
