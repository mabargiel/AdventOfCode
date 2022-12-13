using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2021;

public class Day16 : AdventDay<byte[], int, long>
{
    public override byte[] ParseRawInput(string rawInput)
    {
        var hex = rawInput.Trim();
        var binary = new byte[hex.Length * 4];

        var curr = 0;
        foreach (var hexChar in hex)
        {
            var hexValue = Convert.ToInt32(hexChar.ToString(), 16);
            for (var i = 3; i >= 0; i--)
            {
                binary[curr + i] = (byte)(hexValue % 2);
                hexValue /= 2;
            }

            curr += 4;
        }

        return binary;
    }

    public override int Part1(byte[] input)
    {
        var (versionSum, _) = ExecuteBITS(input);
        return versionSum;
    }

    public override long Part2(byte[] input)
    {
        var (_, result) = ExecuteBITS(input);
        return result;
    }

    private static (int versionNumSum, long result) ExecuteBITS(byte[] bitsProgram)
    {
        int versionsSum = 0;
        var reader = new Queue<byte>(bitsProgram);
        var result = ProcessPacket(reader, ref versionsSum);
        return (versionsSum, result);
    }

    private static long ProcessPacket(Queue<byte> reader, ref int versionsSum)
    {
        var packetVersion = Decode(DequeueChunk(reader, 3));
        versionsSum += (int) packetVersion;

        var packetTypeId = Decode(DequeueChunk(reader, 3));
        if (packetTypeId == 4) //literal
        {
            var literalBytes = new List<byte>();
            bool isLastGroup;
            do
            {
                isLastGroup = reader.Dequeue() == 0;
                literalBytes.AddRange(DequeueChunk(reader, 4));
            } while (!isLastGroup);

            return Decode(literalBytes.ToArray());
        }
        //else
        
        var literals = new List<long>();
        var lengthTypeId = reader.Dequeue();
        if (lengthTypeId == 0)
        {
            var subPacketsTotalLength = Decode(DequeueChunk(reader, 15));
            var subReader = new Queue<byte>(DequeueChunk(reader, subPacketsTotalLength));

            while (subReader.Any())
            {
                literals.Add(ProcessPacket(subReader, ref versionsSum));
            }
        }
        else
        {
            var subPacketsCount = Decode(DequeueChunk(reader, 11));
            for (var i = 0; i < subPacketsCount; i++)
            {
                literals.Add(ProcessPacket(reader, ref versionsSum));
            }
        }

        return ExecuteOperation(literals, (int) packetTypeId);
    }

    private static long ExecuteOperation(List<long> literals, int packetTypeId)
    {
        return packetTypeId switch
        {
            0 => literals.Sum(),
            1 => literals.Aggregate(1L, (curr, prev) => curr * prev),
            2 => literals.Min(),
            3 => literals.Max(),
            5 => literals[0] > literals[1] ? 1 : 0,
            6 => literals[0] < literals[1] ? 1 : 0,
            7 => literals[0] == literals[1] ? 1 : 0,
            _ => throw new ArgumentException("Invalid operation", nameof(packetTypeId))
        };
    }

    private static byte[] DequeueChunk(Queue<byte> queue, long chunkSize)
    {
        var chunk = new byte[chunkSize];
        for (var i = 0; i < chunkSize; i++)
        {
            chunk[i] = queue.Dequeue();
        }

        return chunk;
    }

    private static long Decode(byte[] bits)
    {
        var result = 0L;
        for (var i = bits.Length - 1; i >= 0; i--)
        {
            result += bits[^(i + 1)] * (long) Math.Pow(2, i);
        }

        return result;
    }
}