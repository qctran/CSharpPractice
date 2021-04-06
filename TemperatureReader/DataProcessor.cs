namespace TemperatureReader
{
    public class DataProcessor
    {
        private readonly IDevice _device;

        public DataProcessor(IDevice device)
        {
            _device = device;
        }

        public byte[] Read()
        {
            return _device.ReceiveBytes();
        }
    }
}
