using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CurrencyExchangeAPI.Models;

namespace CurrencyExchangeAPI.BAL
{
    public class CurrencyRateCalculation : ExchangeRateService
    {
        public readonly ExchangeRate exchangeRate = new ExchangeRate();

        public ExchangeRateCalculation GetCalculatedData(string baseCurrency, string targetCurrency, string dates)
        {
            ExchangeRateCalculation calculation = new ExchangeRateCalculation();
            //initialisation
            List<double> values = new List<double>();

            int maxindex, minindex;
            double minvalue, maxvalue, sumvalue;

            string[] dateArray = dates.Split(',');
            exchangeRate.BaseCurrency = baseCurrency;
            exchangeRate.TargetCurrency = targetCurrency;



            // get exchange rate
            for (int i = 0; i < dateArray.Count(); i++)
            {
                exchangeRate.Date = dateArray[i];
                values.Add(GetData(exchangeRate));
            }

            // Calculations

            if (values.Count != 0)
            {
                minvalue = maxvalue = values[0];
                minindex = maxindex = 0; sumvalue = 0;

                for (int i = 0; i < values.Count; i++)
                {
                    sumvalue = sumvalue + values[i];
                    if (values[i] > maxvalue)
                    {
                        maxvalue = values[i];
                        maxindex = i;
                    }
                    else if (values[i] < minvalue)
                    {
                        minvalue = values[i];
                        minindex = i;
                    }
                }

                calculation.MinDate = dateArray[minindex];
                calculation.MaxDate = dateArray[maxindex];
                calculation.MinRate = minvalue.ToString();
                calculation.MaxRate = maxvalue.ToString();
                calculation.AvgRate = (sumvalue / values.Count()).ToString();
            }

            return calculation;
        }

    }

}