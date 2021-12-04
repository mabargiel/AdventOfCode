using System;
using AdventOfCode.Days;
using NUnit.Framework;

namespace AdventOfCode.Tests
{
    public abstract class AdventDayTest<T> where T: IAdventDay
    {
        protected T _day;

        [SetUp]
        public void Initialize()
        {
            _day = Activator.CreateInstance<T>();
        }

        [Test]
        public abstract void ParseRawInputTest();
    }
}