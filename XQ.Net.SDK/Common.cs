using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XQ.Net.SDK
{
    public static class Common
    {
        /// <summary>
        /// 先驱API
        /// </summary>
        public static XQAPI xQAPI = new XQAPI();

        public static void Log(string log)
        {
            if (!Directory.Exists("XQNetLogs"))
            {
                Directory.CreateDirectory("XQNetLogs");
            }
            File.AppendAllText("XQNetLogs\\log.txt", log + "\n");
        }
    }
}
