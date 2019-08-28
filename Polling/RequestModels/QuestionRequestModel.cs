using System.ComponentModel.DataAnnotations;

namespace Polling.RequestModels
{
    public class QuestionRequestModel
    {
        [Required]
        public string Title { get; set; }
    }
}