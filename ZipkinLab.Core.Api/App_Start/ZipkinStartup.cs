using System;
using Medidata.ZipkinTracer.Core;
using Medidata.ZipkinTracer.Core.Middlewares;
using Microsoft.Owin;
using Owin;

namespace ZipkinLab.Core.Api
{
    public static class ZipkinStartup
    {
        private static ZipkinClient _client;

        public static void Configuration(IAppBuilder app)
        {
            app.UseZipkin(ZipkinConfig);
        }

        public static ZipkinConfig ZipkinConfig
        {
            get
            {
                return new ZipkinConfig
                {
                    Bypass = (IOwinRequest request) => false,
                    Domain = (IOwinRequest request) => new Uri("http://coreapi"),
                    ZipkinBaseUri = new Uri("http://localhost:9411"),
                    SpanProcessorBatchSize = 10,
                    SampleRate = 1.0
                };
            }
        }

        public static ZipkinClient GetClient(IOwinContext context)
        {
            return new ZipkinClient(ZipkinConfig, context);
        }
    }
}