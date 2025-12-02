using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.Days.Common;

namespace AdventOfCode.Days._2019._8;

public class Day8 : IAdventDay<int, string>
{
    private readonly IEnumerable<char[]> _layers;

    public Day8(string imageData, uint width, uint height)
    {
        var imageSize = width * height;
        if (imageData.Length < imageSize || imageData.Length % imageSize > 0)
        {
            throw new ArgumentException(
                "The image data is corrupted and cannot be parsed to layers",
                nameof(imageData)
            );
        }

        _layers = imageData.Batch((int)(width * height)).Select(x => x.ToArray());
    }

    public int Part1()
    {
        var leastZerosLayer =
            _layers.MinBy(layer => layer.Count(c => c == '0'))?.ToArray() ?? Array.Empty<char>();

        var onesCount = leastZerosLayer.Count(c => c == '1');
        var twosCount = leastZerosLayer.Count(c => c == '2');

        return onesCount * twosCount;
    }

    public string Part2()
    {
        var size = _layers.First().Length;
        var drillJobs = Enumerable
            .Range(0, size)
            .Select(pixelIndex => Task.Run(() => DrillThroughLayers(pixelIndex)));

        var password = Task.WhenAll(drillJobs).Result;
        return new string(password);
    }

    private char DrillThroughLayers(in int pixelIndex)
    {
        foreach (var layer in _layers)
        {
            if (layer[pixelIndex] != '2')
            {
                return layer[pixelIndex];
            }
        }

        throw new InvalidOperationException("Cannot decode the image");
    }
}
