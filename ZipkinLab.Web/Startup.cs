using System;
using System.Threading.Tasks;
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
