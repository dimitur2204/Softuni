namespace Logger.Messages
{
    public class Message
    {
        public Message(string dateTime, string info)
        {
            this.DateTime = dateTime;
            this.Info = info;
        }
        public string DateTime { get; set; }
        public string Info { get; set; }
        public ReportLevel ReportLevel { get; set; }
    }
}