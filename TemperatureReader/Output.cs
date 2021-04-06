using System;

namespace TemperatureReader
{
    public class ConsoleDisplay : IOutput
    {
        public void PrintToConsole(double degree)
        {
            Console.WriteLine($"The temperature is {degree:0.0}C");
        }

        public void WriteMessage(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
