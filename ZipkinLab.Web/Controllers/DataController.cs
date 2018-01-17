using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.Owin;
using Newtonsoft.Json;
using RestSharp;
using ZipkinLab.Dto;
using ZipkinLab.Web.Models.DTO;
using CCI.ZipkinTracer.Core.Handlers;
using CCI.ZipkinTracer.Core;
using CCI.ZipkinTracer.Core.Models;

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
                var response = httpClient.GetAsync("http://channel.ZipkinLab.localmachine.altsrc.net/account/9999").Result;
                
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    acct = JsonConvert.DeserializeObject<AccountDto>(content);
                }
            }

            using (var httpClient = new HttpClient(new ZipkinMessageHandler(zipkinClient)))
            {
                var sharedResponse = httpClient.GetAsync($"http://shared.ZipkinLab.localmachine.altsrc.net/api/shared/3").Result;

                if (sharedResponse.IsSuccessStatusCode)
                {
                    var sharedContent = sharedResponse.Content.ReadAsStringAsync().Result;
                }
            }
            



            var dataDto = new DataDto(acct.Customer.FirstName, acct.Customer.LastName, acct.AccountId);

            var span = new Span();
            //span.Id = ???
            zipkinClient.RecordBinary<object>(span, "correlationId", Guid.NewGuid().ToString("N"));

            return dataDto;
        }

        private ZipkinConfig ZipkinSetup()
        {
            
            var config = new ZipkinConfig // you can use Dependency Injection to get the same config across your app.
            {
                Domain = (IOwinRequest request) => new Uri("http://web"),
                ZipkinBaseUri = new Uri("http://localhost:9411"),
                SpanProcessorBatchSize = 10,
                SampleRate = 0.5
            };

            return config;
        }
    }
}
