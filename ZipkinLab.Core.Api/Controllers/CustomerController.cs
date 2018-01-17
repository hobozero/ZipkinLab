using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;
using CCI.ZipkinTracer.Core;
using CCI.ZipkinTracer.Core.Handlers;
using ZipkinLab.Dto;

namespace ZipkinLab.Core.Api.Controllers
{
    [RoutePrefix("customer")]
    public class CustomerController : ApiController
    {
        [HttpGet]
        [Route("{customerId}")]
        public CustomerDto Get(int customerId)
        {
            var context = System.Web.HttpContext.Current.GetOwinContext();
            var zipkinClient = new ZipkinClient(ZipkinStartup.ZipkinConfig, context);

            using (var httpClient = new HttpClient(new ZipkinMessageHandler(zipkinClient)))
            {
                var sharedResponse = httpClient.GetAsync($"http://shared.ZipkinLab.localmachine.altsrc.net/api/shared/3").Result;

                if (sharedResponse.IsSuccessStatusCode)
                {
                    var sharedContent = sharedResponse.Content.ReadAsStringAsync().Result;
                }
            }

            return new CustomerDto("Steve", "Austin");
        }
    }
}
