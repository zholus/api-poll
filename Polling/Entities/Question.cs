using System.Collections.Generic;

namespace Polling.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Poll Poll { get; set; }
        
        public IEnumerable<Answer> Answers { get; set; }
        
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