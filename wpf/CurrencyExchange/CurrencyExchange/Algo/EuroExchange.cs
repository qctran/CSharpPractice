using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Algo
{
    public class EuroExchange : IExchange
    {
        private double _rate = 1.1;
        public double CalcExchange(double amount)
        {
            return amount * _rate;
        }
    }
}
