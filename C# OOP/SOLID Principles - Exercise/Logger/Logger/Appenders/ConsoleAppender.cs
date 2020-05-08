using Logger.Interfaces;
using Logger.Layouts;
using Logger.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Appenders
{
    class ConsoleAppender : Appender,IAppender
    {
        public ConsoleAppender(ILayout layout, ReportLevel reportLevel = ReportLevel.Info)
            : base(layout, reportLevel)
        {
        }
        public void Append(Message message)
        {
            if (base.HasPermission(message))
            {
                Console.WriteLine(layout.Implement(message));
            }       
        }
    }
}
