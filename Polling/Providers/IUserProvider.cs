using Microsoft.AspNetCore.Http;
using Polling.Entities;

namespace Polling.Providers
{
    public interface IUserProvider
    {
        User GetUser(HttpRequest request);
    }
}