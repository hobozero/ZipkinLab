using System;
using System.Threading.Tasks;
using AltSource.Logging.Structured;
using AltSource.Logging.Structured.Config;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ZipkinLab.Web.Startup))]

namespace ZipkinLab.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
