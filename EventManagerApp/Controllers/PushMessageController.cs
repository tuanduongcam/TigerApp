using EventManager.ApiModels;
using EventManager.BusinessService;
using EventManager.DataModel.Models;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventManager.Web.Controllers
{
    public class PushMessageController : ApiController
    {
        // GET: api/PushMessage
        [AllowAnonymous]
        [HttpGet]
        public APIResponse GetUserPushMessage(string userId)
		{			
			IContentSentBusinessService campaignRepository = new ContentSentBusinessService();
			List<ApiMessageContentSentModel> result = campaignRepository.GetSentMessageByUser(userId);
			if (result == null || result.Count == 0)
			{
				return new APIResponse() { Status = eResponseStatus.Success, Result = "Không tìm thông báo" };
			}
			return new APIResponse() { Status = eResponseStatus.Success, Result = result };
		}

		[AllowAnonymous]
		[HttpGet]
		[Route("api/PushMessage/GetUserPushMessageType")]
		public APIResponse GetUserPushMessageType(string userId, int type)
		{
			IContentSentBusinessService campaignRepository = new ContentSentBusinessService();
			List<ApiMessageContentSentModel> result = campaignRepository.GetSentMessageByTypeUser(userId, type);
			if (result == null || result.Count == 0)
			{
				return new APIResponse() { Status = eResponseStatus.Success, Result = "Không tìm thông báo" };
			}
			return new APIResponse() { Status = eResponseStatus.Success, Result = result };
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("api/PushMessage/SetPushMessageSeen")]
		public APIResponse SetMessageSeen(Int64 messageContentSentID)
		{
			IContentSentBusinessService contentSentBusinessService = new ContentSentBusinessService();
			Tuple<bool, string> result = contentSentBusinessService.SetMessageSeen(messageContentSentID);
			if (result.Item1 != true)
			{
				return new APIResponse() { Status = eResponseStatus.Fail, Result = result.Item2 };
			}
			return new APIResponse() { Status = eResponseStatus.Success, Result = result.Item2 };
		}

		[AllowAnonymous]
		[HttpGet]
		public APIResponse NotYetReadPushMessage(string userId)
		{
			IContentSentBusinessService campaignRepository = new ContentSentBusinessService();
			int result = campaignRepository.GetNotReadMessageByUser(userId);
			
			return new APIResponse() { Status = eResponseStatus.Success, Result = result };
		}
    }
}
