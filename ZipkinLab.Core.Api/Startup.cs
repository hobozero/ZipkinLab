using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ZipkinLab.Core.Api.Startup))]

namespace ZipkinLab.Core.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ZipkinStartup.Configuration(app);
        }
    }
}
