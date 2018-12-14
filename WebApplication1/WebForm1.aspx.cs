using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public class Exchange
    {
        public DateTime end_at { get; set; }
        public DateTime start_at { get; set; }
        public Dictionary<string, string> rates { get; set; }
        public string basecurr { get; set; }
    }

    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

                string Baseurl = "https://api.exchangeratesapi.io/history?start_at=2018-01-01&end_at=2018-01-02&base=USD";
                List<Exchange> listStateInfo = new List<Exchange>();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Res = await client.GetAsync(Baseurl);
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var StateResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        listStateInfo = JsonConvert.DeserializeObject<List<Exchange>>(StateResponse);

                    }






                   

            }
        }
    
    }
}