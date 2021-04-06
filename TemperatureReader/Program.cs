namespace TemperatureReader
{
    class Program
    {
        static void Main()
        {
            var output = new ConsoleDisplay();
            var calculator = new CelsiusCalculator();
            var device = new Device();
            var validator = new Validator(output);

            var dataObj = new DataProcessor(device);
            var data = dataObj.Read();

            var tempObj = new TemperatureProcessor(calculator, validator, output);
            tempObj.PrintTemperature(data);
        }
    }
}
