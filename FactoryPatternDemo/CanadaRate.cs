namespace FactoryPatternDemo
{
    public class CanadaRate : IExchangeRate
    {
        public int Convert(int amount)
        {
            return amount * 3;
        }
    }
}
