using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
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

            http://zipkinweb.localmachine.altsrc.net/shared/api/shared/5

            return new CustomerDto("Steve", "Austin");
        }
    }
}
