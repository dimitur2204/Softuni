using Logger.Interfaces;
using Logger.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Appenders
{
    public class FileAppender : Appender,IAppender
    {
        private LogFile file;
        public FileAppender(ILayout layout, LogFile file, ReportLevel reportLevel = ReportLevel.Info)
            :base(layout, reportLevel)
        {
            this.file = file;
        }
        public void Append(Message message)
        {
            if (base.HasPermission(message))
            {
                this.file.Write(layout.Implement(message));
            }
        }
    }
}
