using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZipkinLab.Web.Controllers
{
    public class ZipkinController : Controller
    {
        // GET: Zipkin
        public ActionResult Index()
        {
            return View();
        }
    }
}