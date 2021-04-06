using System;

namespace TemperatureReader
{
    public interface ICalculator
    {
        double GetDegree(UInt16 dec);
    }
}
