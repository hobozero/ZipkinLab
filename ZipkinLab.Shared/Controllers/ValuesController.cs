using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;
using CCI.ZipkinTracer.Core.Handlers;
using Newtonsoft.Json;

namespace ZipkinLab.Shared.Controllers
{
    public class SharedController : ApiController
    {
        // GET api/values/5
        public string Get(int id)
        {
            Thread.Sleep(id*1000);

            //using (var httpClient = new HttpClient(new ZipkinMessageHandler(ZipkinStartup.GetClient(HttpContext.Current.GetOwinContext()))))
            //{
            //    var response = httpClient.GetAsync($"http://ZipkinWeb.localmachine.altsrc.net/coreapi/customer/{123}").Result;
            //    if (response.IsSuccessStatusCode)
            //    {
            //        var content = response.Content.ReadAsStringAsync().Result;
            //    }
            //}

            return id.ToString();
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
