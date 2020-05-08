using Logger.Interfaces;
using Logger.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger.Loggers
{
    public class MyLogger
    {
        private readonly List<IAppender> appenders;
        public MyLogger(params IAppender[] appenders)
        {
            this.appenders = appenders.ToList();
        }
        public void Info(Message message)
        {
            message.ReportLevel = ReportLevel.Info;
            LogMessage(message);
        }
        public void Warning(Message message)
        {
            message.ReportLevel = ReportLevel.Warning;
            LogMessage(message);
        }
        public void Error(Message message)
        {
            message.ReportLevel = ReportLevel.Error;
            LogMessage(message);
        }
        public void Critical(Message message)
        {
            message.ReportLevel = ReportLevel.Critical;
            LogMessage(message);
        }
        public void Fatal(Message message)
        {
            message.ReportLevel = ReportLevel.Fatal;
            LogMessage(message);
        }
        private void LogMessage(Message message)
        {
            foreach (var appender in this.appenders)
            {
                appender.Append(message);
            }
        }
    }
}
