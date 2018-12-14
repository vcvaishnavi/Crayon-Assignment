using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using CurrencyExchangeAPI.BAL;
using CurrencyExchangeAPI.Models;

namespace CurrencyExchangeAPI.Controllers
{   

    public class ExchangeController : ApiController
    {
       
        // GET api/Exchange/USD/INR/2018-02-02,2018-07-05
        public IEnumerable<string> Get(string baseCurrency,string targetCurrency,string dates)
        {
           
            CurrencyRateCalculation obj = new CurrencyRateCalculation();
            ExchangeRateCalculation calculation =   obj.GetCalculatedData(baseCurrency, targetCurrency, dates);

            return new string[] { "Min Rate - ",calculation.MinRate, "Min Date - ",calculation.MinDate, "Max Rate - ",calculation.MaxRate, "Max Date - ",calculation.MaxDate, "Average Rate - ",calculation.AvgRate};
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
