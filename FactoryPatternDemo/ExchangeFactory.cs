using System;

namespace FactoryPatternDemo
{
    public class ExchangeFactory
    {
        public IExchangeRate GetExchangeObject(string countryCode)
        {
            if (string.Compare(countryCode, "Can", true) == 0)
            {
                return new CanadaRate();
            }
            else if (string.Compare(countryCode, "Eu", true) == 0)
            {
                return new EuroRate();
            }

            throw new ArgumentException("Unknown country code.");
        }
    }
}
