
namespace Attackers
{
    public abstract class Logger : IHandler
    {
        private IHandler successor;

        public void SetSuccessor(IHandler handler)
        {
            this.successor = handler;
        }
        protected void PassToSuccessor(LogType type, string message)
        {
            if (this.successor != null)
            {
                this.successor.Handle(type, message);
            }
        }
        public abstract void Handle(LogType logType, string msg);
    }
}
