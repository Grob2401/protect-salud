using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    class LogExcepciones
    {
        public static void LogException(Exception exc, string source, string logfile)
        {
            // Include logic for logging exceptions
            // Get the absolute path to the log file
            // Dim logFile As String = "Errors/ErrorLog.txt"
            // logFile = HttpContext.Current.Server.MapPath(logFile)

            // Dim rootPath As String = HttpContext.Current.Server.MapPath(logFile)
            // Dim rootPath As String = HttpContext.Current.Server.MapPath("/")
            // Open the log file for append and write the log
            StreamWriter sw = new StreamWriter(logfile, true);
            sw.WriteLine("********** {0} **********", DateTime.Now);
            if (exc.InnerException != null)
            {
                sw.Write("Inner Exception Type: ");
                sw.WriteLine(exc.InnerException.GetType().ToString());
                sw.Write("Inner Exception: ");
                sw.WriteLine(exc.InnerException.Message);
                sw.Write("Inner Source: ");
                sw.WriteLine(exc.InnerException.Source);
                if (exc.InnerException.StackTrace != null)
                {
                    sw.WriteLine("Inner Stack Trace: ");
                    sw.WriteLine(exc.InnerException.StackTrace);
                }
            }
            sw.Write("Exception Type: ");
            sw.WriteLine(exc.GetType().ToString());
            sw.WriteLine("Exception: " + exc.Message);
            sw.WriteLine("Source: " + source);
            sw.WriteLine("Stack Trace: ");
            if (exc.StackTrace != null)
            {
                sw.WriteLine(exc.StackTrace);
                sw.WriteLine();
            }
            sw.Close();
        }
        private static object HttpContext()
        {
            throw new NotImplementedException();
        }
    }
}
