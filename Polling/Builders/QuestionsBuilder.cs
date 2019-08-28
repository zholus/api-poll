using System.Collections.Generic;
using System.Linq;
using Polling.Entities;
using Polling.RequestModels;

namespace Polling.Builders
{
    public class QuestionsBuilder : IQuestionsBuilder
    {
        private readonly IQuestionBuilder _questionBuilder;

        public QuestionsBuilder(IQuestionBuilder questionBuilder)
        {
            _questionBuilder = questionBuilder;
        }
        
        public IEnumerable<Question> BuildQuestions(IEnumerable<QuestionRequestModel> questions)
        {
            var result = new List<Question>();
            
            foreach (var newQuestion in questions)
            {
                result.Add(
                    _questionBuilder.BuildQuestion(newQuestion)
                );
            }

            return result;
        }
    }
}