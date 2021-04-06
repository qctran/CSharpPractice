using System;

namespace TemperatureReader
{
    class Program
    {
        static void Main()
        {
            // Create an output object to where we want the output to.
            // Console or file...
            var output = new ConsoleDisplay();

            // We can create a Fahrenheit calculator and inject that to the
            // TemperatureProcessor if we want to convert to F degree.
            var calculator = new CelsiusCalculator();

            // Create a testDevice instance that return fake data.
            var factory = new DeviceFactory();
            var device = factory.GetDevice(true); // True to get simulator data

            // Inject an output object so the Validator can either write
            // to console or file.
            var validator = new Validator(output); 

            var dataProc = new DataProcessor(device);
            var tempProc = new TemperatureProcessor(calculator, validator, output);

            ShowAllData(device, dataProc, tempProc);
        }

        /// <summary>
        /// This method will go through all sample data from the testDevice.
        /// </summary>
        /// <param name="device"></param>
        /// <param name="dataProc"></param>
        /// <param name="tempProc"></param>
        private static void ShowAllData(IDevice device, DataProcessor dataProc, TemperatureProcessor tempProc)
        {
            try
            {
                Console.WriteLine("Press [ESC] to exit.");
                do
                {
                    var data = dataProc.Read();
                    tempProc.PrintTemperature(data);
                } while (Console.ReadKey().Key != ConsoleKey.Escape);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}\r\n{e.StackTrace}");
            }
        }
    }
}
