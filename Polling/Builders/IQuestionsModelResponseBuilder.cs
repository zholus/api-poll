using System.Collections.Generic;
using Polling.Entities;
using Polling.ResponseModels;

namespace Polling.Builders
{
    public interface IQuestionsModelResponseBuilder
    {
        IEnumerable<QuestionModelResponse> Build(IEnumerable<Question> questions);
    }
}