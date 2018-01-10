using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
            var client = new RestClient("http://ZipkinWeb.localmachine.altsrc.net/coreapi");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("customer/{id}", Method.GET);
            request.AddUrlSegment("id", "123");
            request.AddHeader("header", "value");
            var customer = client.Execute<CustomerDto>(request);

            var acctDto = new AccountDto(accountId, customer.Data);

            return acctDto;
        }
    }
}
