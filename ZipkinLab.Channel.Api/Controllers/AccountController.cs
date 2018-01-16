﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Medidata.ZipkinTracer.Core;
using Medidata.ZipkinTracer.Core.Handlers;
using Newtonsoft.Json;
using RestSharp;
using ZipkinLab.Dto;

namespace ZipkinLab.Channel.Api.Controllers
{
    [RoutePrefix("account")]
    public class AccountController : ApiController
    {

        [HttpGet]
        [Route("{accountId}")]
        public AccountDto Get(int accountId)
        {
            CustomerDto customer = null;

            using (var httpClient = new HttpClient(new ZipkinMessageHandler(ZipkinStartup.GetClient(HttpContext.Current.GetOwinContext()))))
            {
                var response = httpClient.GetAsync($"http://ZipkinWeb.localmachine.altsrc.net/coreapi/customer/{123}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    customer = JsonConvert.DeserializeObject<CustomerDto>(content);
                }

                var sharedResponse =
                    httpClient.GetAsync($"http://zipkinweb.localmachine.altsrc.net/shared/api/shared/5").Result;
            }
            
            var acctDto = new AccountDto(accountId, customer);

            return acctDto;
        }
    }
}
