using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AltSource.Logging.Structured;
using AltSource.Logging.Structured.Config;
using Zipkin.Logging.Logging;
using Zipkin.Logging.Logging.LogProviders;

namespace Zipkin.Logging
{
    class StructuredLoggingProvider: CCI.ZipkinTracer.Core.Logging.LogProviders.LogProviderBase
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
        

        private static Type GetLogManagerType()
        {
            return Type.GetType("Serilog.Log, Serilog");
        }
    }
}
