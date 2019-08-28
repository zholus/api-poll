using System.Collections.Generic;

namespace Polling.ResponseModels
{
    public class PollModelResponse
    {
        public int PollId { get; }
        public string PollTitle { get; }
        public IEnumerable<QuestionModelResponse> Questions { get; }

        public PollModelResponse(int pollId, string pollTitle, IEnumerable<QuestionModelResponse> questions)
        {
            PollId = pollId;
            PollTitle = pollTitle;
            Questions = questions;
        }
    }
}