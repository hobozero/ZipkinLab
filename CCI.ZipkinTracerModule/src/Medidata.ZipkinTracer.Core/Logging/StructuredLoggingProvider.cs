using System;
using AltSource.Logging.Structured;
using AltSource.Logging.Structured.Config;
using Medidata.ZipkinTracer.Core.Logging;

namespace CCI.ZipkinTracer.Core.Logging
{
    class StructuredLoggingProvider: Medidata.ZipkinTracer.Core.Logging.LogProviders.LogProviderBase
    {
        private static StructuredLibLogLogger _logger;

        static StructuredLoggingProvider()
        {
            LoggingConfiguration loggingConfig = LoggingConfigurationFactory.GetFromConfigSection();
            _logger = new StructuredLibLogLogger(StructuredLoggingFactory.GetLogger(loggingConfig));
        }

        public StructuredLoggingProvider()
        {
            if (!IsLoggerAvailable())
            {
                throw new InvalidOperationException("Structured logger not found");
            }
        }
        
        public override Logger GetLogger(string name)
        {
            return _logger.Log;
        }

        internal static bool IsLoggerAvailable()
        {
            return _logger != null;
        }
    }
}
