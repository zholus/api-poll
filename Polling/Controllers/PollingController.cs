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
    [TypeFilter(typeof(AccessTokenNeedAttribute))]
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

        [HttpPost("polling")]
        public ActionResult<PollModelResponse> Create([FromForm] NewPollModel model)
        {
            var user = _userProvider.GetUser(HttpContext.Request);

            var questions = _questionsBuilder.BuildQuestions(model.Questions);

            var poll = new Poll(model.Title, questions, user);
            
            _unitOfWork.Polls.Add(poll);

            _unitOfWork.Commit();

            poll = _unitOfWork.Polls.FindByUserAndTitle(user, poll.Title);

            return _pollModelResponseBuilder.Build(poll);
        }
    }
}