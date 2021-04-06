using System;

namespace TemperatureReader
{
    public class Device : IDevice
    {
        public byte[] ReceiveBytes()
        {
            // Instructions - Unremark each test case below then press
            // CTRL + F5 to execute the program.
            
            // * Good test cases
            // Valid DEFAULT case where there is 2 bytes for temperature
            var data = new byte[] { 0xaa, 0x02, 0x30, 0x00, 0x55 };
            //var data = new byte[] { 0xaa, 0x02, 0x00, 0x00, 0x55 };
            //var data = new byte[] { 0xaa, 0x02, 0xff, 0x00, 0x55 };

            // Valid multiple bytes for temperature
            //var data = new byte[] { 0xaa, 0x06, 0x30, 0x00, 0x40, 0x00, 0x20, 0x00, 0x55 };

            // Valid length byte where length lesser than temperature bytes
            // Expect only one temperature will display
            //var data = new byte[] { 0xaa, 0x02, 0x30, 0x00, 0x40, 0x00, 0x55 };

            // * Negative test cases
            // Invalid start byte - "Unrecognize data format"
            //var data = new byte[] { 0x33, 0x02, 0x30, 0x00, 0x55 };

            // Invalid end byte - "Unrecognize data format"
            //var data = new byte[] { 0xaa, 0x02, 0x30, 0x00, 0xbb };

            // Invalid length byte where length greater than temperature bytes - Not enough temperature data value
            //var data = new byte[] { 0xaa, 0x03, 0x30, 0x00, 0x55 };

            // Invalid length - Invalid data size
            //var data = new byte[] { 0xaa, 0x01, 0x30, 0x55 };

            return data;
        }

        public void SendBytes(byte[] toSend)
        {
            throw new NotImplementedException();
        }
    }
}
  