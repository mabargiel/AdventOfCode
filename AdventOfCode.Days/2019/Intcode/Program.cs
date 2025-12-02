using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace AdventOfCode.Days._2019.Intcode;

public class Program
{
    public Program(IDictionary<long, long> instructions, BlockingCollection<long> input)
    {
        Memory = new ProgramMemory(instructions);
        OnInput += input.Take;
    }

    public Func<long> OnInput { get; }
    public Action<long> OnOutput { get; set; }
    public ProgramMemory Memory { get; private set; }
    public int Pointer { get; set; }
    public long RelativeBase { get; private set; }

    public long CurrentInteger()
    {
        return Memory[Pointer];
    }

    public void IncrementRelativeBase(long incrementValue)
    {
        RelativeBase += incrementValue;
    }

    public void Reset()
    {
        Memory = null;
        Pointer = 0;
    }
}

public class ProgramMemory : IDictionary<long, long>
{
    private readonly IDictionary<long, long> _baseDictionary;

    public ProgramMemory(IDictionary<long, long> baseDictionary)
    {
        _baseDictionary = baseDictionary;
    }

    public IEnumerator<KeyValuePair<long, long>> GetEnumerator()
    {
        return _baseDictionary.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(KeyValuePair<long, long> item)
    {
        _baseDictionary.Add(item);
    }

    public void Clear()
    {
        _baseDictionary.Clear();
    }

    public bool Contains(KeyValuePair<long, long> item)
    {
        return _baseDictionary.Contains(item);
    }

    public void CopyTo(KeyValuePair<long, long>[] array, int arrayIndex)
    {
        _baseDictionary.CopyTo(array, arrayIndex);
    }

    public bool Remove(KeyValuePair<long, long> item)
    {
        return _baseDictionary.Remove(item);
    }

    public int Count => _baseDictionary.Count;
    public bool IsReadOnly => _baseDictionary.IsReadOnly;

    public void Add(long key, long value)
    {
        _baseDictionary.Add(key, value);
    }

    public bool ContainsKey(long key)
    {
        return _baseDictionary.ContainsKey(key);
    }

    public bool Remove(long key)
    {
        return _baseDictionary.Remove(key);
    }

    public bool TryGetValue(long key, out long value)
    {
        return _baseDictionary.TryGetValue(key, out value);
    }

    public long this[long key]
    {
        get
        {
            TryGetValue(key, out var value);
            return value;
        }
        set => _baseDictionary[key] = value;
    }

    public ICollection<long> Keys => _baseDictionary.Keys;
    public ICollection<long> Values => _baseDictionary.Values;
}
