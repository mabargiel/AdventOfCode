namespace AdventOfCode.Days._2020._12
{
	public class Position
	{
		public Position(int northSouth, int eastWest)
		{
			NorthSouth = northSouth;
			EastWest = eastWest;
		}

		public int NorthSouth { get; }
		public int EastWest { get; }
	}
}