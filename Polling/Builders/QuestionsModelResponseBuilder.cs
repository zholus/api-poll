using System.Collections.Generic;
using System.Linq;
using Polling.Entities;
using Polling.ResponseModels;

namespace Polling.Builders
{
    public class QuestionsModelResponseBuilder : IQuestionsModelResponseBuilder
    {
        private readonly IQuestionModelResponseBuilder _questionModelResponseBuilder;

        public QuestionsModelResponseBuilder(IQuestionModelResponseBuilder questionModelResponseBuilder)
        {
            _questionModelResponseBuilder = questionModelResponseBuilder;
        }

        public IEnumerable<QuestionModelResponse> Build(IEnumerable<Question> questions)
        {
            return questions.Select(question => _questionModelResponseBuilder.Builder(question));
        }
    }
}