using Logger.Appenders;
using Logger.Layouts;
using Logger.Messages;
using Logger.Loggers;
using System;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            var XMLLayout = new XMLLayout();
            var file = new LogFile();
            var fileAppender = new FileAppender(XMLLayout,file);
            var logger = new MyLogger(fileAppender);
            fileAppender.ReportLevel = ReportLevel.Warning;
            
            logger.Info(new Message("3/31/2015 5:33:07 PM", "Everything seems fine"));
            logger.Warning(new Message("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent"));
            logger.Error(new Message("3/31/2015 5:33:07 PM", "Error parsing request"));
            logger.Critical(new Message("3/31/2015 5:33:07 PM", "No connection string found in App.config"));
            logger.Fatal(new Message("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond"));
            Console.WriteLine(file.Logs);
        }
    }
}
