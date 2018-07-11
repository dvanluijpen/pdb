using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace PeelseDartBond.Utilities
{
    public static class Logger
    {
        public static TraceLevel Level { get; set; } = TraceLevel.Verbose;

        [Conditional("DEBUG")]
        public static void Error(string message, Exception error = null, string category = "App", [CallerFilePath]string filePath = null, [CallerLineNumber]int lineNumber = 0)
        {
            WriteLine(TraceLevel.Error, message, error?.ToString(), category, filePath, lineNumber);
        }

        //public static void HockeyError(string message, Exception error = null, string category = "App", [CallerFilePath]string filePath = null, [CallerLineNumber]int lineNumber = 0)
        //{
        //    HockeyApp.MetricsManager.TrackEvent(
        //        message,
        //        new System.Collections.Generic.Dictionary<string, string>()
        //    {
        //        {"EXC-MSG", error.Message},
        //        {"EXC-STT", error.StackTrace},
        //        {"INN-MSG", error.InnerException.Message},
        //        {"INN-STT", error.InnerException.StackTrace},
        //    },
        //        new System.Collections.Generic.Dictionary<string, double>() { });
        //}

        [Conditional("DEBUG")]
        public static void Info(string message, string category = "App", [CallerFilePath]string filePath = null, [CallerLineNumber]int lineNumber = 0)
        {
            WriteLine(TraceLevel.Info, message, null, category, filePath, lineNumber);
        }

        [Conditional("DEBUG")]
        public static void Verbose(string message, string category = "App", [CallerFilePath]string filePath = null, [CallerLineNumber]int lineNumber = 0)
        {
            WriteLine(TraceLevel.Verbose, message, null, category, filePath, lineNumber);
        }

        [Conditional("DEBUG")]
        public static void Warning(string message, string category = "App", [CallerFilePath]string filePath = null, [CallerLineNumber]int lineNumber = 0)
        {
            WriteLine(TraceLevel.Warning, message, null, category, filePath, lineNumber);
        }

        [Conditional("DEBUG")]
        public static void Warning(string message, Exception warning, string category = "App", [CallerFilePath]string filePath = null, [CallerLineNumber]int lineNumber = 0)
        {
            WriteLine(TraceLevel.Warning, message, warning?.ToString(), category, filePath, lineNumber);
        }

        [Conditional("DEBUG")]
        public static void WriteLine(TraceLevel level, string message, string details = null, string category = "App", [CallerFilePath]string filePath = null, [CallerLineNumber]int lineNumber = 0)
        {
            if (level == TraceLevel.Off || level > Level)
            {
                return;
            }

            var fileName = "(unknown)";

            if (filePath != null)
            {
                fileName = Path.GetFileName(filePath);
            }

            var levelStr = level.ToString().ToUpperInvariant().Substring(0, 4);

            Debug.WriteLine($"{DateTime.Now:HH:mm:ss.fff} {levelStr} [{category}] {message} ({fileName}:{lineNumber})");

            if (details != null)
            {
                Debug.WriteLine(details);
            }
        }
    }
}
