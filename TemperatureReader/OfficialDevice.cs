using System;

namespace TemperatureReader
{
    public class OfficialDevice : IDevice
    {
        public void SendBytes(byte[] toSend)
        {
            Console.WriteLine($"Official device SendBytes() implementation.");
        }

        public byte[] ReceiveBytes()
        {
            Console.WriteLine($"Official device ReceiveBytes() implementation.");
            return new byte[]{ 0xaa, 0x02, 0x30, 0x00, 0x55 };  // Just dummy data
        }
    }
}
