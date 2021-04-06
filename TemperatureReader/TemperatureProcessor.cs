using System;

namespace TemperatureReader
{
    public class TemperatureProcessor
    {
        private readonly ICalculator _calculator;
        private readonly IValidator _validator;
        private readonly IOutput _output;

        public TemperatureProcessor(ICalculator calculator, IValidator validator, IOutput output)
        {
            _calculator = calculator;
            _validator = validator;
            _output = output;
        }

        /// <summary>
        /// Validate receiving data, calculate the temperature and print to screen
        /// </summary>
        /// <param name="data">Receiving data</param>
        public void PrintTemperature(byte[] data)
        {
            if (!_validator.ValidateRawData(data)) return;

            var length = GetNumberOfTemperatureByteCount(data);

            // Total array length - 1 byte for <length> - the <length> value
            // should be two or more bytes
            if (length < 0 || data.Length - 1 - length < 2)
            {
                _output.WriteMessage("Not enough temperature data value");
                return;
            }

            // Retrieve the number of bytes for the temperature values.
            // Exclude the <start>, <end> and <length> bytes.
            var valueBytes = new ArraySegment<byte>(data, 2, length).ToArray();
            CalcAndPrint(valueBytes);
        }

        /// <summary>
        /// Calculate and print the temperature from the receiving data.
        /// </summary>
        /// <param name="data">The temperature byte array from the receiving data</param>
        private void CalcAndPrint(byte[] data)
        {
            if (data.Length < 2)
            {
                _output.WriteMessage("There is not enough data to print");
                return;
            }

            var index = 0;
            while (data.Length - index > 1)
            {
                var valueBytes = new ArraySegment<byte>(data, index, 2).ToArray();

                ShowOneTemperature(valueBytes);
                index += 2;
            }
        }

        /// <summary>
        /// ShowOneTemperature one temperature
        /// </summary>
        /// <param name="valueBytes">An array or two bytes for one temperature</param>
        private void ShowOneTemperature(byte[] valueBytes)
        {
            var degree = CalculateTemperature(valueBytes);
            _output.PrintDegree(degree);
        }

        /// <summary>
        /// Calculate the temperature degree in Celsius
        /// </summary>
        /// <param name="data">A two bytes array representing the temperature value.</param>
        /// <returns>Degree in Celsius</returns>
        private double CalculateTemperature(byte[] data)
        {
            Array.Reverse(data);
            var dec = BitConverter.ToUInt16(data);
            return _calculator.GetDegree(dec);
        }

        /// <summary>
        /// Retrieve the specified length from the receiving data
        /// </summary>
        /// <param name="data">The value of the [length] byte</param>
        /// <returns>The length</returns>
        private static int GetNumberOfTemperatureByteCount(byte[] data)
        {
            if (data.Length < 2) return -1;
            return data[1];
        }
    }
}
