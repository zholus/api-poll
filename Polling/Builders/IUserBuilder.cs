using Polling.Entities;
using Polling.RequestModels;

namespace Polling.Builders
{
    public interface IUserBuilder
    {
        User BuildFrom(RegisterRequestModel registerRequestModel);
    }
}