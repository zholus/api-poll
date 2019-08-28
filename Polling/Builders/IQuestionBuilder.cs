using Polling.Entities;
using Polling.RequestModels;

namespace Polling.Builders
{
    public interface IQuestionBuilder
    {
        Question BuildQuestion(QuestionRequestModel questionRequestModel);
    }
}