using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Algo
{
    public class CanadaExchange : IExchange
    {
        private double _rate = 3.24;
        public double CalcExchange(double amount)
        {
            return amount * _rate;
        }
    }
}
