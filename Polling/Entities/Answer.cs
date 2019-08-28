using System.ComponentModel.DataAnnotations.Schema;

namespace Polling.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public virtual Poll Poll { get; set; }
        public virtual Question Question { get; set; }
        public virtual string Ip { get; set; }

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