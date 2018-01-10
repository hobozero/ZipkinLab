using System;
using Medidata.ZipkinTracer.Core;
using Medidata.ZipkinTracer.Core.Middlewares;
using Microsoft.Owin;
using Owin;

namespace ZipkinLab.Core.Api
{
    public static class ZipkinStartup
    {
        public static void Configuration(IAppBuilder app)
        {
            app.UseZipkin(new ZipkinConfig
            {
                Bypass = (IOwinRequest request) => false,
                Domain = (IOwinRequest request) => new Uri("http://ZipkinWeb.localmachine.altsrc.net/coreapi"),
                ZipkinBaseUri = new Uri("http://localhost:9411"),
                SpanProcessorBatchSize = 10,
                SampleRate = 1.0
            });
        }
    }
}