using System;
using Newtonsoft.Json;

namespace CCI.ZipkinTracer.Core.Models.Serialization.Json
{
    internal class JsonAnnotation
    {
        private readonly Annotation annotation;

        [JsonProperty("endpoint")]
        public JsonEndpoint Endpoint => new JsonEndpoint(annotation.Host);

        [JsonProperty("value")]
        public string Value => annotation.Value;

        [JsonProperty("timestamp")]
        public long Timestamp => annotation.Timestamp.ToUnixTimeMicroseconds();

        public JsonAnnotation(Annotation annotation)
        {
            if (annotation == null)
                throw new ArgumentNullException(nameof(annotation));

            this.annotation = annotation;
        }
    }
}