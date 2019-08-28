using System.ComponentModel.DataAnnotations;

namespace Polling.RequestModels
{
    public class NewQuestion
    {
        [Required]
        public string Title { get; set; }
    }
}