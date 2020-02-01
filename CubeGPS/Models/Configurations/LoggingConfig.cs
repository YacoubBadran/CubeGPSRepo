using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CubeGPS.Models.Configurations
{
    public class LoggingConfig
    {
        public string PathFormat { get; set; }
        public LogLevel MinimumLevel { get; set; }
        public bool IsJson { get; set; }
        public long? FileSizeLimitBytes { get; set; }
        public int? RetainedFileCountLimit { get; set; }
        public IDictionary<string, LogLevel> Override { get; set; }
    }
}