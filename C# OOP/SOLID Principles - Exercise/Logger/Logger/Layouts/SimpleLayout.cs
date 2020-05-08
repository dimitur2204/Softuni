using Logger.Interfaces;
using Logger.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Layouts
{
    class SimpleLayout : ILayout
    {
        public string Implement(Message message)
        {
            return $"{message.DateTime} - {message.ReportLevel} - {message.Info}";
        }
    }
}
