using Polling.Entities;
using Polling.ResponseModels;

namespace Polling.Builders
{
    public class PollModelResponseBuilder : IPollModelResponseBuilder
    {
        private readonly IQuestionsModelResponseBuilder _questionsModelResponseBuilder;

        public PollModelResponseBuilder(IQuestionsModelResponseBuilder questionsModelResponseBuilder)
        {
            _questionsModelResponseBuilder = questionsModelResponseBuilder;
        }

        public PollModelResponse Build(Poll poll)
        {
            var questions = _questionsModelResponseBuilder.Build(poll.Questions);
            
            return new PollModelResponse(poll.Id, poll.Title, questions);
        }
    }
}