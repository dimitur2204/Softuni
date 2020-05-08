using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class LogFile
    {
        private StringBuilder logs = new StringBuilder();
        public LogFile()
        {
        }
        public void Write(string message)
        {
            this.logs.Append(message + "\n");
        }
        public StringBuilder Logs => this.logs;
        public int Size 
        {
            get 
            {
                var sum = 0;
                foreach (var symbol in logs.ToString())
                {
                    sum += symbol;
                }
                return sum;
            }
        }
    }
}
