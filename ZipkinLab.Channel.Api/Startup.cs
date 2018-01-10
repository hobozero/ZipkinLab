using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ZipkinLab.Channel.Api.Startup))]

namespace ZipkinLab.Channel.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ZipkinStartup.Configuration(app);
        }
    }
}
