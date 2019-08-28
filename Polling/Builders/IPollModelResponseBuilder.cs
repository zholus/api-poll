using Polling.Entities;
using Polling.ResponseModels;

namespace Polling.Builders
{
    public interface IPollModelResponseBuilder
    {
        PollModelResponse Build(Poll poll);
    }
}