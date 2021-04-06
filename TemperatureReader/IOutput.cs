namespace TemperatureReader
{
    public interface IOutput
    {
        void PrintDegree(double degree);
        void WriteMessage(string msg);
    }
}
