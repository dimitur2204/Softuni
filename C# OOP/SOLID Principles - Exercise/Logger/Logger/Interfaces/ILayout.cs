using Logger.Messages;

namespace Logger.Interfaces
{
    public interface ILayout
    {
        public string Implement(Message message);
    }
}