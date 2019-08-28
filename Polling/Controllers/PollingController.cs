using Microsoft.AspNetCore.Mvc;
using Polling.Attributes.Filters;
using Polling.Builders;
using Polling.Db.UoW;
using Polling.Entities;
using Polling.Providers;
using Polling.RequestModels;
using Polling.ResponseModels;

namespace Polling.Controllers
{
    [ApiController]
    public class PollingController : ControllerBase
    {
        private readonly IUserProvider _userProvider;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IQuestionsBuilder _questionsBuilder;
        private readonly IPollModelResponseBuilder _pollModelResponseBuilder;

        public PollingController(
            IUserProvider userProvider, 
            IUnitOfWork unitOfWork, 
            IQuestionsBuilder questionsBuilder,
            IPollModelResponseBuilder pollModelResponseBuilder
        ) {
            _userProvider = userProvider;
            _unitOfWork = unitOfWork;
            _questionsBuilder = questionsBuilder;
            _pollModelResponseBuilder = pollModelResponseBuilder;
        }
        
        [HttpGet("poll/{pollId}")]
        public ActionResult<PollModelResponse> Get(int pollId)
        {
            var poll = _unitOfWork.Polls.Get(pollId);

            if (poll == null)
            {
                return NotFound("Poll not found");
            }

            return _pollModelResponseBuilder.Build(poll);
        }
        
        [HttpPost("poll")]
        [TypeFilter(typeof(AccessTokenNeedAttribute))]
        public ActionResult<PollModelResponse> Create([FromForm] PollRequestModel requestModel)
        {
            var user = _userProvider.GetUser(HttpContext.Request);

            var questions = _questionsBuilder.BuildQuestions(requestModel.Questions);

            var poll = new Poll(requestModel.Title, questions, user);
            
            _unitOfWork.Polls.Add(poll);

            _unitOfWork.Commit();

            poll = _unitOfWork.Polls.FindByUserAndTitle(user, poll.Title);

            return _pollModelResponseBuilder.Build(poll);
        }
    }
}