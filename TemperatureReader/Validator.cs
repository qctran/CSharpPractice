using System;

namespace TemperatureReader
{
    public class Validator
    {
        public static bool ValidateRawData(byte[] data)
        {
            if (data.Length < 5)
            {
                // Data must contain at least 5 bytes
                // as <start><length><data> . . . <data><end>
                Console.WriteLine("Invalid data size");
                return false;
            }

            if (!ValidateProtocol(data))
            {
                Console.WriteLine("Unrecognize data format");
                return false;
            }

            return true;
        }

        private static bool ValidateProtocol(byte[] data)
        {
            if ((data[0] == 0xaa) && (data[data.Length - 1] == 0x55))
            {
                return true;
            }

            return false;
        }
    }
}
