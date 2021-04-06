namespace TemperatureReader
{
    public interface IOutput
    {
        void PrintToConsole(double degree);
        void WriteMessage(string msg);
    }
}
