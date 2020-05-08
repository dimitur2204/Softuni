using Logger.Interfaces;
using Logger.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Appenders
{
    public abstract class Appender
    {
        protected readonly ILayout layout;
        public Appender(ILayout layout, ReportLevel reportLevel = ReportLevel.Info)
        {
            this.layout = layout;
            this.ReportLevel = reportLevel;
        }
        public ReportLevel ReportLevel { get; set; }
        protected bool HasPermission(Message message)
        {
            if (message.ReportLevel < this.ReportLevel)
            {
                Console.WriteLine("No permission to log!");
                return false;
            }
            return true;
        }
    }
}
