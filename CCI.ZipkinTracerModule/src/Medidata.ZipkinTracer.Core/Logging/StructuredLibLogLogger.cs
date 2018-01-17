using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Medidata.ZipkinTracer.Core.Logging;

namespace CCI.ZipkinTracer.Core.Logging
{
        public class StructuredLibLogLogger : ILog
        {
            private readonly AltSource.Logging.Structured.ILogger _logger;

            public StructuredLibLogLogger(AltSource.Logging.Structured.ILogger logger)
            {
                _logger = logger;
            }

        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        public bool Log(LogLevel logLevel, Func<string> messageFunc, Exception exception = null, params object[] formatParameters)
            {
                //return state == null
                //    ? _logger.Log(Map(eventType), null) // Equivalent to IsLogLevelXEnabled 
                //                                        //TODO What to do with eventId?
                //    : _logger.Log(Map(eventType), () => formatter(state, exception), exception);

                var dict = null?? new Dictionary<string, string>();

                string message = messageFunc() ?? "No log message provided.";

                switch (logLevel)
                {
                    case LogLevel.Trace:
                        case LogLevel.Debug:
                        _logger.Debug(message);
                        break;
                    case LogLevel.Info:
                        _logger.Debug(message);
                            break;
                    case LogLevel.Warn:
                        _logger.Warning(message);
                        break;
                    case LogLevel.Error:
                        _logger.Error(message);
                       break;
                    case LogLevel.Fatal:
                        _logger.Fatal(message);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
                }

                return true;
            }
            
        }
}
