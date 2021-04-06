namespace TemperatureReader
{
    public interface IValidator
    {
        bool ValidateRawData(byte[] data);
    }
}
