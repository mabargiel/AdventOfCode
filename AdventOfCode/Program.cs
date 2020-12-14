using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.Days;
using AdventOfCode.Days._2020._11;
using Utility.CommandLine;

namespace AdventOfCode
{
    internal class Program
    {
	    private static string _input;

	    [Argument('d', "day")]
	    private static int Day { get; set; }

	    [Argument('y', "year")]
	    private static int Year { get; set; }

	    [Argument('i', "input-path")]
	    private static string Input
	    {
		    get => _input;
		    set
		    {
			    if (value == null)
				    return;

			    if (!value.StartsWith('~'))
				    _input = value;
			    else
			    {
				    var homePath = Environment.OSVersion.Platform == PlatformID.Unix ||
				                   Environment.OSVersion.Platform == PlatformID.MacOSX
					    ? Environment.GetEnvironmentVariable("HOME")
					    : Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");

				    _input = homePath + Path.DirectorySeparatorChar + value.Substring(1, value.Length - 1);
			    }
		    }
	    }


	    private static async Task Main(string[] args)
	    {
		    Arguments.Populate();

            var input = await File.ReadAllTextAsync(Path.GetFullPath(Input));
            var dayType = Type.GetType($"AdventOfCode.Days._{Year}._{Day}.Day{Day}, AdventOfCode.Days");
            var day = Activator.CreateInstance(dayType, input.Trim());

	        Console.WriteLine(day.ToString());
        }
    }
}
