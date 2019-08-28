using Polling.Entities;
using Polling.ResponseModels;

namespace Polling.Builders
{
    public interface IQuestionModelResponseBuilder
    {
        QuestionModelResponse Builder(Question question);
    }
}