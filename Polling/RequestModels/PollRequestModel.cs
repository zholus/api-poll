using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Polling.Attributes.Validation;

namespace Polling.RequestModels
{
    public class PollRequestModel
    {
        [Required]
        [UniquePollTitle]
        public string Title { get; set; }
        
        [Required]
        [UniqueEnumerableValue("Title")]
        public IEnumerable<QuestionRequestModel> Questions { get; set; }
    }
}