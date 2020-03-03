using System;

namespace FactoryPatternDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ExchangeFactory();
            var excObj = factory.GetExchangeObject("Eu");
            var value = excObj.Convert(100);
            Console.WriteLine("Exchanging ${0} to {1}", 100, value);
        }
    }
}
