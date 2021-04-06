namespace TemperatureReader
{
    public interface IDevice
    {
        void SendBytes(byte[] toSend);
        byte[] ReceiveBytes();
    }
}
