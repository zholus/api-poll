using System.ComponentModel.DataAnnotations.Schema;

namespace Polling.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public Poll Poll { get; set; }
        public Question Question { get; set; }
        public string Ip { get; set; }

        public Answer()
        {
        }

        public Answer(Poll poll, Question question, string ip)
        {
            Poll = poll;
            Question = question;
            Ip = ip;
        }
    }
}