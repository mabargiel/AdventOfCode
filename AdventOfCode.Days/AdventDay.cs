using System;

namespace AdventOfCode.Days
{
    public abstract class AdventDay<TOut1, TOut2>
    {
	    public abstract TOut1 Part1();
	    public abstract TOut2 Part2();

        public override string ToString()
        {
	        string r1;
	        string r2;

	        try
	        {
		        r1 = Part1().ToString();
	        }
	        catch (Exception e)
	        {
		        r1 = e.ToString();
	        }

	        try
	        {
		        r2 = Part2().ToString();
	        }
	        catch (Exception e)
	        {
		        r2 = e.ToString();
	        }

	        return $"Part1: {r1}, Part2: {r2}";
        }
    }
}
