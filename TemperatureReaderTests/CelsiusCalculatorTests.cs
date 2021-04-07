using System;
using NUnit.Framework;
using TemperatureReader;

namespace TemperatureReaderTests
{
    class CelsiusCalculatorTests
    {
        [Test]
        [TestCase((ushort)12288, 25, 0.00)]
        [TestCase((ushort)65535, 350, 0.00)]
        [TestCase((ushort)0, -50, 0.00)]
        [TestCase((ushort)65280, 348.4, 0.00)]
        [TestCase((ushort)255, -48.4, 0.00)]
        [TestCase((ushort)48, -49.7, 0.00)]
        public void GetDegree_ValidData_Pass(ushort data, double expectValue, double delta)
        {
            var calculator = new CelsiusCalculator();
            var device = new TestDevice();
            var output = new ConsoleDisplay();
            var validator = new Validator(output);

            var temp = new CelsiusCalculator();
            var result = temp.GetDegree(data);
            result = Math.Round(result, 1);

            Assert.AreEqual(expectValue, result, delta);
        }
    }
}
