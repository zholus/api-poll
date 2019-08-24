namespace Polling.Security
{
    public class TokenGenerator : ITokenGenerator
    {
        public string Generate()
        {
            return System.Guid.NewGuid().ToString();
        }
    }
}