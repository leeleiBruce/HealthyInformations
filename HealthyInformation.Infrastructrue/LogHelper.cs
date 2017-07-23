using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.Infrastructrue
{
    public class LogHelper
    {
        static ILog loger = LogManager.GetLogger("WebLogger");

        public static void WriteExceptionLog(string logContent)
        {
            loger.Error(logContent);
        }

        public static void WriteExceptionLog(string logContent, Exception ex)
        {
            loger.Error(logContent, ex);
        }

        public static void WriteExceptionLog(MethodBase methodBase, Exception ex)
        {
            WriteExceptionLog(string.Concat(methodBase.Name, ":", Environment.NewLine, ex.Message));
        }

        public static void WriteExceptionLog(Exception ex)
        {
            WriteExceptionLog(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
        }
    }
}
