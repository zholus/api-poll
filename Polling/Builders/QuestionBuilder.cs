using Polling.Entities;
using Polling.RequestModels;

namespace Polling.Builders
{
    public class QuestionBuilder : IQuestionBuilder
    {
        public Question BuildQuestion(NewQuestion question)
        {
            return new Question(question.Title);
        }
    }
}