using Polling.Entities;
using Polling.RequestModels;

namespace Polling.Builders
{
    public class QuestionBuilder : IQuestionBuilder
    {
        public Question BuildQuestion(QuestionRequestModel questionRequestModel)
        {
            return new Question(questionRequestModel.Title);
        }
    }
}