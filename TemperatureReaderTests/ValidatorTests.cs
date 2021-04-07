using NUnit.Framework;
using TemperatureReader;

namespace TemperatureReaderTests
{
    public class ValidatorTests
    {
        [Test]
        [TestCase(new byte[] { 0xaa, 0x02, 0x30, 0x00, 0x55 })]
        public void ValidateRawData_ValidData_Pass(byte[] data)
        {
            var output = new ConsoleDisplay();
            var obj = new Validator(output);

            var result = obj.ValidateRawData(data);

            Assert.IsTrue(result);

        }

        [Test]
        [TestCase(new byte[] { 0x33, 0x02, 0x30, 0x00, 0x55 })]
        [TestCase(new byte[] { 0xaa, 0x02, 0x30, 0x00, 0xbb })]
        [TestCase(new byte[] { 0xaa, 0x01, 0x30, 0x55 })]
        public void ValidateRawData_InvalidData_Pass(byte[] data)
        {
            var output = new ConsoleDisplay();
            var obj = new Validator(output);

            var result = obj.ValidateRawData(data);

            Assert.IsFalse(result);

        }
    }
}
