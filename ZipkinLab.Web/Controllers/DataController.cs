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
using Medidata.ZipkinTracer.Models;
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

            using (var httpClient = new HttpClient(new ZipkinMessageHandler(zipkinClient)))
            {
                var sharedResponse = httpClient.GetAsync($"http://zipkinweb.localmachine.altsrc.net/shared/api/shared/3").Result;

                if (sharedResponse.IsSuccessStatusCode)
                {
                    var sharedContent = sharedResponse.Content.ReadAsStringAsync().Result;
                }
            }
            



            var dataDto = new DataDto(acct.Customer.FirstName, acct.Customer.LastName, acct.AccountId);

            var span = new Span();
            //span.Id = ???
            zipkinClient.RecordBinary<object>(span, "dataDto", dataDto);

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
