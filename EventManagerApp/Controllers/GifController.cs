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
    public class GifController : ApiController
    {
        // GET: api/Gif
		[AllowAnonymous]
		[HttpGet]
		public APIResponse Get()
		{
			IGifBusinessService accountImageRepository = new GifBusinessService();
			List<ApiGifModel> result = accountImageRepository.GetGifts();
			if (result == null || result.Count == 0)
			{
				return new APIResponse() { Status = eResponseStatus.Success, Result = "Không tìm thấy dữ liệu quà tặng" };
			}
			return new APIResponse() { Status = eResponseStatus.Success, Result = result };
		}

        // GET: api/Gif/5
		public APIResponse Get(int id)
        {
			IGifBusinessService accountImageRepository = new GifBusinessService();
			ApiGifModel result = accountImageRepository.GetGift(id);
			if (result == null )
			{
				return new APIResponse() { Status = eResponseStatus.Success, Result = "Không tìm thấy dữ liệu quà tặng" };
			}
			return new APIResponse() { Status = eResponseStatus.Success, Result = result };
        }

        // POST: api/Gif
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Gif/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Gif/5
        public void Delete(int id)
        {
        }
    }
}
