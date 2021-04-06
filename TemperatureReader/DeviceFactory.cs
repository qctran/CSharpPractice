namespace TemperatureReader
{
    public class DeviceFactory
    {
        public IDevice GetDevice(bool sim = false)
        {
            if (sim)
            {
                return new TestDevice();
            }

            return new OfficialDevice();
        }
    }
}
