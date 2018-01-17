﻿using System;
using System.Collections.Generic;
using Microsoft.Owin;

namespace CCI.ZipkinTracer.Core
{
    public interface IZipkinConfig
    {
        Predicate<IOwinRequest> Bypass { get; set; }

        Uri ZipkinBaseUri { get; set; }

        Func<IOwinRequest, Uri> Domain { get; set; }

        uint SpanProcessorBatchSize { get; set; }

        IList<string> ExcludedPathList { get; set; }

        double SampleRate { get; set; }

        IList<string> NotToBeDisplayedDomainList { get; set; }

        bool Create128BitTraceId { get; set; }

        bool ShouldBeSampled(string sampled, string requestPath);

        void Validate();
    }
}