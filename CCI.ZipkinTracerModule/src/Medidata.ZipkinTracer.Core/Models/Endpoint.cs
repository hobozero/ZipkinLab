using System.Net;

namespace CCI.ZipkinTracer.Core.Models
{
    public class Endpoint
    {
        public IPAddress IPAddress { get; set; }

        public ushort Port { get; set; }

        public string ServiceName { get; set; }
    }
}
