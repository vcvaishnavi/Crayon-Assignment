using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrencyExchangeAPI.Models
{
    public class ExchangeRate
    {
        public string BaseCurrency { get; set; }
        public string TargetCurrency { get; set; }
        public string Date { get; set; }
    }
}