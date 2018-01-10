using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;
using Medidata.ZipkinTracer.Core;
using Medidata.ZipkinTracer.Core.Handlers;
using Microsoft.Owin;
using Newtonsoft.Json;
using RestSharp;
using ZipkinLab.Dto;
using ZipkinLab.Web.Models.DTO;

namespace ZipkinLab.Web.Controllers
{
    public class DataController : ApiController
    {
        [HttpGet]
        public DataDto Get()
        {
            var zipkinConfig = ZipkinSetup();
            var context = System.Web.HttpContext.Current.GetOwinContext();
            var zipkinClient = new ZipkinClient(zipkinConfig, context);

            AccountDto acct = null;

            using (var httpClient = new HttpClient(new ZipkinMessageHandler(zipkinClient)))
            {
                var response = httpClient.GetAsync("http://ZipkinWeb.localmachine.altsrc.net/channelapi/account/9999").Result;
                
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    acct = JsonConvert.DeserializeObject<AccountDto>(content);
                }
            }


            ////restSharp implementation
            //var client = new RestClient("http://ZipkinWeb.localmachine.altsrc.net/channelapi");
            //var request = new RestRequest("account/{id}", Method.GET);
            //request.AddUrlSegment("id", "999");
            //acct = client.Execute<AccountDto>(request).Data;


            var dataDto = new DataDto(acct.Customer.FirstName, acct.Customer.LastName, acct.AccountId);

            return dataDto;
        }

        private ZipkinConfig ZipkinSetup()
        {
            
            var config = new ZipkinConfig // you can use Dependency Injection to get the same config across your app.
            {
                Domain = (IOwinRequest request) => new Uri("http://zipkinweb.localmachine.altsrc.net"),
                ZipkinBaseUri = new Uri("http://localhost:9411"),
                SpanProcessorBatchSize = 10,
                SampleRate = 0.5
            };

            return config;
        }
    }
}
