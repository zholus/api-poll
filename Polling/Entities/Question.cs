using System.Collections.Generic;

namespace Polling.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual Poll Poll { get; set; }
        
        public virtual IEnumerable<Answer> Answers { get; set; }
        
        public Question()
        {
        }

        public Question(string title)
        {
            Title = title;
        }
        
        public Question(string title, Poll poll)
        {
            Title = title;
            Poll = poll;
        }
    }
}