using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Algo
{
    public class ExchangeBiz
    {
        public ExchangeBiz(IExchange exchange)
        {
            _exchangeObj = exchange;
        }

        private IExchange _exchangeObj;
    }
}
