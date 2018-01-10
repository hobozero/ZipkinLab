using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Medidata.ZipkinTracer.Core.Middlewares;
using Medidata.ZipkinTracer.Core;
using Microsoft.Owin;
using Owin;

namespace ZipkinLab.Channel.Api
{
    public static class ZipkinStartup
    {
        public static void Configuration(IAppBuilder app)
        {
            app.UseZipkin(new ZipkinConfig
            {
                Bypass = (IOwinRequest request) => false ,
                Domain = (IOwinRequest request) => new Uri("http://ZipkinWeb.localmachine.altsrc.net/channelapi"),
                ZipkinBaseUri = new Uri("http://localhost:9411"),
                SpanProcessorBatchSize = 10,
                SampleRate = 1.0
            });
        }
    }
}