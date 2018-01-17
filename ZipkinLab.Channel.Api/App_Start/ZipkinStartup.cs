using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CCI.ZipkinTracer.Core.Middlewares;
using CCI.ZipkinTracer.Core;
using Microsoft.Owin;
using Microsoft.Owin.Logging;
using Owin;

namespace ZipkinLab.Channel.Api
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
                    Domain = (IOwinRequest request) => new Uri("http://channelapi"),
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