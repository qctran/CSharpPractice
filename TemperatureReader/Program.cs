using System;

namespace TemperatureReader
{
    class Program
    {
        private static readonly Device _device = new Device();
        static void Main(string[] args)
        {
            var data = Read();
            PrintTemperature(data);
        }

        private static byte[] Read()
        {
            // See the instructions on the Device.cs class
            // for different test cases.
            return _device.ReceiveBytes();
        }

        /// <summary>
        /// Validate receiving data, calculate the temperature and print to screen
        /// </summary>
        /// <param name="data">Receiving data</param>
        private static void PrintTemperature(byte[] data)
        {
            if (!Validator.ValidateRawData(data)) return;
            
            var length = GetNumberOfTemperatureByteCount(data);

            // Total array length - 1 byte for <length> - the <length> value
            // should be two or more bytes
            if ((data.Length - 1 - length) < 2)
            {
                Console.WriteLine("Not enough temperature data value");
                return;
            }

            // Retrieve the number of bytes for the temperature values.
            // Exclude the <start>, <end> and <length> bytes.
            var valueBytes = new ArraySegment<byte>(data, 2, length).ToArray();
            Print(valueBytes);
        }

        /// <summary>
        /// Print the temperature from the receiving data.
        /// </summary>
        /// <param name="data">The temperature byte array from the receiving data</param>
        private static void Print(byte[] data)
        {
            if (data.Length < 2)
            {
                Console.WriteLine("There is not enough data to print");
                return;
            }

            var index = 0;
            while (data.Length - index > 1)
            {
                var valueBytes = new ArraySegment<byte>(data, index, 2).ToArray();
                
                var degree = CalculateTemperature(valueBytes);
                Console.WriteLine($"The temperature is {degree:0.0}C");

                index += 2;
            }
        }

        /// <summary>
        /// Calculate the temperature degree in Celcius
        /// </summary>
        /// <param name="data">A two bytes array representing the temperature value.</param>
        /// <returns>Degree in Celcius</returns>
        private static double CalculateTemperature(byte[] data)
        {
            Array.Reverse(data);
            var dec = BitConverter.ToUInt16(data);
            var degree = (dec - 8192) / 163.84;
            return degree;
        }

        /// <summary>
        /// Retrieve the specified length from the receiving data
        /// </summary>
        /// <param name="data">The value of the <length> byte</param>
        /// <returns>The length</returns>
        private static int GetNumberOfTemperatureByteCount(byte[] data)
        {
            if (data.Length < 2) return -1;
            return data[1];
        }
    }
}
