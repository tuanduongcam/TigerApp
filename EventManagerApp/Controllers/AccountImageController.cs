using EventManager.ApiModels;
using EventManager.BusinessService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventManager.Web.Controllers
{
    public class AccountImageController : ApiController
    {
        // GET: api/AccountImage
		[AllowAnonymous]
		[HttpGet]
		public APIResponse Get(string userId)
        {
			IAccountImageBusinessService accountImageRepository = new AccountImageBusinessService();
			List<ApiAccountImageModel> result = accountImageRepository.AccountImages(userId);
			if (result == null || result.Count == 0)
			{
				return new APIResponse() { Status = eResponseStatus.Fail, Result = "Tài khoản của bạn chưa có hình ảnh" };
			}
			return new APIResponse() { Status = eResponseStatus.Success, Result = result };
        }

        // GET: api/AccountImage/5
        

        // POST: api/AccountImage
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AccountImage/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AccountImage/5
        public void Delete(int id)
        {
        }
    }
}
