using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Polling.Entities
{
    public class Poll
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<Question> Questions { get; set; }
        
        public User User { get; set; }

        public Poll()
        {
        }
        
        public Poll(string title, IEnumerable<Question> questions, User user)
        {
            Title = title;
            Questions = questions;
            User = user;
        }
    }
}