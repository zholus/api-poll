namespace Polling.Security
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool Verify(string plainPassword, string hash);
    }
}