﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace CCI.ZipkinTracer.Core.Models.Serialization.Json
{
    internal class JsonSpan
    {
        private readonly Span span;

        [JsonProperty("traceId")]
        public string TraceId => span.TraceId;

        [JsonProperty("name")]
        public string Name => span.Name;

        [JsonProperty("id")]
        public string Id => span.Id;

        [JsonProperty("parentId", NullValueHandling = NullValueHandling.Ignore)]
        public string ParentId => string.IsNullOrWhiteSpace(span.ParentId) ? null : span.ParentId;

        [JsonProperty("annotations")]
        public IEnumerable<JsonAnnotation> Annotations =>
            span.GetAnnotationsByType<Annotation>().Select(annotation => new JsonAnnotation(annotation));

        [JsonProperty("binaryAnnotations")]
        public IEnumerable<JsonBinaryAnnotation> BinaryAnnotations =>
            span.GetAnnotationsByType<BinaryAnnotation>().Select(annotation => new JsonBinaryAnnotation(annotation));

        public JsonSpan(Span span)
        {
            if (span == null)
                throw new ArgumentNullException(nameof(span));

            this.span = span;
        }
    }
}
