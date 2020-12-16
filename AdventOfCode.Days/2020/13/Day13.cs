using System;
using System.Collections;
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
			var buses = new Buses(_buses.Select(b => new Bus(b)));

			long multiplier = buses.First().Initial;
			for (var i = 1; i < buses.Count; i++)
			{
				var current = buses[i];
				
				if(current.Initial == 0)
					continue;
				
				var (prev, offset) = buses.Prev(i);
				
				while(current.MinutesArrived - offset != prev.MinutesArrived)
				{
					current.MinutesArrived += current.Initial;
					
					while (prev.MinutesArrived + multiplier < current.MinutesArrived)
					{
						foreach (var bus in buses.AllPrev(i))
						{
							bus.MinutesArrived += multiplier;
						}
					}
				}

				multiplier *= current.Initial;
			}

			return buses.First().MinutesArrived;
		}
	}

	public class Buses : List<Bus>
	{
		public Buses(IEnumerable<Bus> buses)
		{
			foreach (var bus in buses)
			{
				Add(bus);
			}
		}

		public (Bus, int Offset) Prev(int index)
		{
			var offset = 1;
			for (var i = index - 1; i >= 0; i--)
			{
				if (this[i].Initial != 0) 
					return (this[i], offset);
				
				offset++;
			}

			throw new InvalidOperationException();
		}

		public IEnumerable<Bus> AllPrev(int index)
		{
			for (var i = index - 1; i >= 0; i--)
			{
				if (this[i].Initial != 0) 
					yield return this[i];
			}
		}
	}

	public class Bus
	{
		public Bus(int initial)
		{
			Initial = initial;
			MinutesArrived = initial;
		}
		
		public int Initial { get; }
		public long MinutesArrived { get; set; }
	}
}
