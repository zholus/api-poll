using System.Collections.Generic;
using Polling.Entities;
using Polling.RequestModels;

namespace Polling.Builders
{
    public interface IQuestionsBuilder
    {
        IEnumerable<Question> BuildQuestions(IEnumerable<QuestionRequestModel> questions);
    }
}