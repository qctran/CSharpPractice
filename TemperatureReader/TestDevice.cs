using System;
using System.Collections.Generic;

namespace TemperatureReader
{
    public class TestDevice : IDevice
    {
        private List<byte[]> _sampleData;
        private int _index;

        public TestDevice()
        {
            // Assuming this class returns pre-defined data instead of
            // from the actual device.
            PrepareForFakeData();
        }

        /// <summary>
        /// In the real world, the data should be reading from a device, queue or some kind
        /// of a messaging system.  For the demo purpose, the data is coming from _sampleData.
        /// </summary>
        /// <returns>A byte array representing the command.</returns>
        public byte[] ReceiveBytes()
        {
            if (_index > _sampleData.Count - 1)
            {
                _index = 0; // Just loop again.
            }
            return _sampleData[_index++];
        }

        public void SendBytes(byte[] toSend)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Prepare for simulator mode.
        /// </summary>
        private void PrepareForFakeData()
        {
            CreateSampleData();
        }

        /// <summary>
        /// Generate different test case scenarios for simulator
        /// </summary>
        private void CreateSampleData()
        {
            _sampleData = new List<byte[]>
            {
                // * Good test cases
                new byte[] { 0xaa, 0x02, 0x30, 0x00, 0x55 }, // Valid test and expect 25C
                new byte[] { 0xaa, 0x02, 0x00, 0x00, 0x55 }, // Valid case with min limit
                new byte[] { 0xaa, 0x02, 0xff, 0xff, 0x55 }, // Valid case with max limit
                new byte[] { 0xaa, 0x02, 0xff, 0x00, 0x55 }, // Valid case 
                new byte[] { 0xaa, 0x02, 0x00, 0xff, 0x55 }, // Valid case 
                new byte[] { 0xaa, 0x02, 0x00, 0x30, 0x55 }, // Valid case
                new byte[] { 0xaa, 0x06, 0x30, 0x00, 0x40, 0x00, 0x20, 0x00, 0x55 }, // Valid multiple bytes for temperature
                new byte[] { 0xaa, 0x02, 0x30, 0x00, 0x40, 0x00, 0x55 }, // Valid length byte where length lesser than temperature bytes.  Expect only one temperature will display.
                // * Negative test cases
                new byte[] { 0x33, 0x02, 0x30, 0x00, 0x55 }, // Invalid start byte - "Unrecognized data format"
                new byte[] { 0xaa, 0x02, 0x30, 0x00, 0xbb }, // Invalid end byte - "Unrecognized data format"
                new byte[] { 0xaa, 0x03, 0x30, 0x00, 0x55 }, // Invalid length byte where length greater than temperature bytes - Not enough temperature data value
                new byte[] { 0xaa, 0x01, 0x30, 0x55 }, // Invalid length - Invalid data size
            };
        }
    }
}
  