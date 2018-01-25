﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using NUnit.Framework;
using osu.Framework.Configuration;

namespace osu.Framework.Tests.Bindables
{
    [TestFixture]
    public class BindableLongTest
    {
        [TestCase(0)]
        [TestCase(-0)]
        [TestCase(1)]
        [TestCase(-105)]
        [TestCase(105)]
        [TestCase(long.MinValue)]
        [TestCase(long.MaxValue - 1)] // This will overflow a double - this is probably an issue
        public void TestSet(long value)
        {
            var bindable = new BindableLong { Value = value };
            Assert.AreEqual(value, bindable.Value);
        }

        [TestCase("0", 0)]
        [TestCase("1", 1)]
        [TestCase("-0", 0)]
        [TestCase("-105", -105)]
        [TestCase("105", 105)]
        public void TestParsingString(string value, long expected)
        {
            var bindable = new BindableLong();
            bindable.Parse(value);

            Assert.AreEqual(expected, bindable.Value);
        }

        [TestCase("0", -10, 10, 0)]
        [TestCase("1", -10, 10, 1)]
        [TestCase("-0", -10, 10, 0)]
        [TestCase("-105", -10, 10, -10)]
        [TestCase("105", -10, 10, 10)]
        public void TestParsingStringWithRange(string value, long minValue, long maxValue, long expected)
        {
            var bindable = new BindableLong { MinValue = minValue, MaxValue = maxValue };
            bindable.Parse(value);

            Assert.AreEqual(expected, bindable.Value);
        }

        [TestCase(0)]
        [TestCase(-0)]
        [TestCase(1)]
        [TestCase(-105)]
        [TestCase(105)]
        [TestCase(long.MinValue)]
        [TestCase(long.MaxValue)]
        public void TestParsingLong(long value)
        {
            var bindable = new BindableLong();
            bindable.Parse(value);

            Assert.AreEqual(value, bindable.Value);
        }
    }
}
