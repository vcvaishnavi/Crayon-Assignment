using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyExchangeAPI.Models;

namespace CurrencyExchangeAPI.BAL
{
    public interface IExchangeRateService
    {
        double  GetData(ExchangeRate exchangerate);
    }
}
