using Logger.Messages;

namespace Logger.Interfaces
{
    public interface IAppender
    {
        public ReportLevel ReportLevel { get; set; }
        public void Append(Message message);
    }
}