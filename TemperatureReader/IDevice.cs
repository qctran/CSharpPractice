namespace TemperatureReader
{
    interface IDevice
    {
        void SendBytes(byte[] toSend);
        byte[] ReceiveBytes();
    }
}
