
namespace Attackers
{
    public interface IHandler
    {
        void Handle(LogType logType, string msg);
        void SetSuccessor(IHandler handler);
    }
}
