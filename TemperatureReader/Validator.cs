namespace TemperatureReader
{
    public class Validator : IValidator
    {
        private readonly IOutput _output;

        public Validator(IOutput output)
        {
            _output = output;
        }
        public bool ValidateRawData(byte[] data)
        {
            if (data.Length < 5)
            {
                // Data must contain at least 5 bytes
                // as <start><length><data> . . . <data><end>
                _output.WriteMessage("Invalid data size");
                return false;
            }

            if (!ValidateProtocol(data))
            {
                _output.WriteMessage("Unrecognized data format");
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
