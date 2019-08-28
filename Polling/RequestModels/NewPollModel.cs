using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Polling.Attributes.Validation;

namespace Polling.RequestModels
{
    public class NewPollModel
    {
        [Required]
        [UniquePollTitle]
        public string Title { get; set; }
        
        [Required]
        [UniqueEnumerableValue("Title")]
        public IEnumerable<NewQuestion> Questions { get; set; }
    }
}