namespace TemperatureReader
{
    public class CelsiusCalculator : ICalculator
    {
        public double GetDegree(ushort dec)
        {
            return (dec - 8192) / 163.84;
        }
    }
}
