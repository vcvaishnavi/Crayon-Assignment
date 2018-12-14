using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrencyExchangeAPI.Models
{
    public class ExchangeRateCalculation
    {
        public string MinRate { get; set; }
        public string MinDate { get; set; }
        public string MaxRate { get; set; }
        public string MaxDate { get; set; }
        public string AvgRate { get; set; }
        
        public ExchangeRateCalculation()
        {
            this.MaxDate = this.MinDate = this.MaxRate = this.MinRate = this.AvgRate = "";
        }
    }
}