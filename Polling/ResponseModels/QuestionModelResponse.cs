namespace Polling.ResponseModels
{
    public class QuestionModelResponse
    {
        public int QuestionId { get; }
        public string QuestionTitle { get; }
        
        public int AnswersCount { get; }
        
        public QuestionModelResponse(int questionId, string questionTitle, int answersCount)
        {
            QuestionId = questionId;
            QuestionTitle = questionTitle;
            AnswersCount = answersCount;
        }
    }
}