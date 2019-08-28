using System.Linq;
using Polling.Entities;
using Polling.ResponseModels;

namespace Polling.Builders
{
    public class QuestionModelResponseBuilder : IQuestionModelResponseBuilder
    {
        public QuestionModelResponse Builder(Question question)
        {
            var count = question.Answers?.Count() ?? 0;
            
            return new QuestionModelResponse(question.Id, question.Title, count);
        }
    }
}