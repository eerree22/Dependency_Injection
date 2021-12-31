namespace LogServices
{
    public interface ILogProvider
    {
        void LogError(string msg);
        void LogInfo(string msg);
    }
}