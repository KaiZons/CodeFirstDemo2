using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities
{
    public class Logger
    {
        private static log4net.ILog s_logger = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Logger()
        {

        }

        public static void LoadConfig()
        {
            log4net.Config.XmlConfigurator.Configure();//配置信息在启动项App.Config
        }

        public static void WriteInformation(string message)
        {
            LoadConfig();

            string processId = GetProcessId();

            s_logger.Info($"{processId} -【Info】: {message}", null);
        }

        public static void WriteError(Exception exception, string repairType, string message = "")
        {
            LoadConfig();

            string processId = GetProcessId();

            s_logger.Error($"{processId} -【{repairType}】: {message}", exception);
        }

        private static string GetProcessId()
        {
            try
            {
                return System.Diagnostics.Process.GetCurrentProcess().Id.ToString();
            }
            catch
            {
                return "Unknow";
            }
        }
    }
}
