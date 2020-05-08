using Logger.Interfaces;
using Logger.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Layouts
{
    public class XMLLayout : ILayout
    {
        //<log>
        //<date>3/31/2015 5:33:07 PM</date>
        //<level>ERROR</level>
        //<message>Error parsing request</message>
        //</log>
        public string Implement(Message message)
        {
            return $@"
        <log>
        <date>{message.DateTime}</date>
        <level>{message.ReportLevel.ToString().ToUpper()}</level>
        <message>{message.Info}</message>
        </log>";
        }
    }
}
