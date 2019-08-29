using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Polling.Db.UoW;
using Polling.Entities;

namespace Polling.Controllers
{
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnswerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("poll/{pollId}/question/{questionId}/answer")]
        public ActionResult AddAnswer(int pollId, int questionId)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();

            var poll = _unitOfWork.Polls.Get(pollId);

            if (poll == null)
            {
                return NotFound(new {Message = "Poll not found"});
            }

            var question = poll.Questions.FirstOrDefault(q => q.Id == questionId);

            if (question == null)
            {
                return NotFound(new {Message = "Question for poll not found"});
            }

            var answer = poll.Answers.FirstOrDefault(a => a.Ip == ip);

            if (answer != null)
            {
                return UnprocessableEntity(new {Message = "You had been already voted for this poll"});
            }

            var newAnswer = new Answer
            {
                Ip = ip,
                Poll = poll,
                Question = question
            };
            
            _unitOfWork.Answers.Add(newAnswer);
            _unitOfWork.Commit();
            
            return StatusCode(201, new {Message = "Answer was added to poll"});
        }
    }
}