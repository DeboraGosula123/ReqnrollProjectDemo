using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace ReqnrollProjectDemo.Utilities
{
    
        public static class AppLogger
        {
            public static void Init()
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.Console()
                    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
                    .CreateLogger();
            }

            public static void Info(string message) => Log.Information(message);
            public static void Warn(string message) => Log.Warning(message);
            public static void Debug(string message) => Log.Debug(message);
            public static void Error(string message, Exception ex = null) => Log.Error(ex, message);
            public static void Close() => Log.CloseAndFlush();
        }
    }

