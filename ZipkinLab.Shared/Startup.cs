using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ZipkinLab.Shared.Startup))]

namespace ZipkinLab.Shared
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ZipkinStartup.Configuration(app);
        }
    }
}
