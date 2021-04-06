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
            // See the instructions on the Device.cs class
            // for different test cases.
            return _device.ReceiveBytes();
        }
    }
}
