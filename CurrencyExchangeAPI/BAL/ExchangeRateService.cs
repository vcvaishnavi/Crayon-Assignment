using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CurrencyExchangeAPI.Models;
using System.Net.Http.Headers;

namespace CurrencyExchangeAPI.BAL
{
    public class ExchangeRateService : IExchangeRateService
    {
               
        public  double GetData(ExchangeRate exchangeRate)
        {
            string url = "https://api.exchangeratesapi.io/history?start_at=" + exchangeRate.Date + "&end_at=" + exchangeRate.Date + "&base=" + exchangeRate.BaseCurrency;
            return GetExchangeData(url,exchangeRate.TargetCurrency);
        }
        static double GetExchangeData(string url,string targetCurrency)
        {
            HttpClient client = new HttpClient();
     

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage Res = client.GetAsync(url).Result;
            if (Res.IsSuccessStatusCode)
            {
                var Response = Res.Content.ReadAsStringAsync().Result;
                return JsonExtract(Response.ToString(),targetCurrency);

            }
            else
                return (0);
        }

        static double JsonExtract(string jsonData, string targetCurrency)
        {
            //Extracting nested JSON data and get the target currency rate
            double targetExchangeRate = 0;
            Dictionary<string, object> outerDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonData);
            foreach (KeyValuePair<string, object> outerEntry in outerDictionary)
            {
                if (!(outerEntry.Value is string))  // for Meta and Data
                {
                    Dictionary<string, object> lowerDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(outerEntry.Value.ToString());
                    foreach (KeyValuePair<string, object> lowerEntry in lowerDictionary)
                    {
                        Dictionary<string, double> innerDictionary = JsonConvert.DeserializeObject<Dictionary<string, double>>(lowerEntry.Value.ToString());
                        foreach (KeyValuePair<string, double> innerEntry in innerDictionary)
                        {
                            if (innerEntry.Key == targetCurrency)
                                targetExchangeRate = innerEntry.Value;
                        }
                    }
                }
            }
            return targetExchangeRate;
        }

        }
    }