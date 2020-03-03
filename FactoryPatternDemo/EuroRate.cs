namespace FactoryPatternDemo
{
    public class EuroRate : IExchangeRate
    {
        public int Convert(int amount)
        {
            return amount * 2;
        }
    }
}
