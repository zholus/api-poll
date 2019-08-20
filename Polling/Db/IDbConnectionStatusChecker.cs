namespace Polling.Db
{
    public interface IDbConnectionStatusChecker
    {
        bool IsConnected();
    }
}