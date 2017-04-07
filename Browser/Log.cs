using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Browser
{
    static class Log
    {
        private static string logPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\Log.txt";

        static StreamWriter sw = new StreamWriter(logPath);

        public static void WriteLog(String content) 
        {
            sw.WriteLine(content);
            sw.Flush();
        }
    }
}
