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
    public class GiftRedeemController : ApiController
    {
         // GET: api/GiftRedeem/5
		[AllowAnonymous]
		[HttpGet]
		[Route("api/GiftRedeem/GetRemainingPointByUser")]
		public APIResponse RemainingPoint(string userId)
        {
			IUserGiftRedeem userGiftRedeem = new UserGiftRedeemBusinessService();
			ApiRemainingPoint result = userGiftRedeem.RemainingPoint(userId);
			if (result == null)
			{
				return new APIResponse() { Status = eResponseStatus.Fail, Result = "Tài khoản của bạn thông tin đổi quà" };
			}
			return new APIResponse() { Status = eResponseStatus.Success, Result = result };
        }

		[HttpGet]
		public APIResponse Get(string userId)
		{
			IUserGiftRedeem userGiftRedeem = new UserGiftRedeemBusinessService();
			List<ApiUserGifRedeemModel> result = userGiftRedeem.UserGiftRedeemList(userId);
			if (result == null)
			{
				return new APIResponse() { Status = eResponseStatus.Fail, Result = "Tài khoản của bạn chưa có thông tin đổi quà" };
			}
			return new APIResponse() { Status = eResponseStatus.Success, Result = result };
		}
        // POST: api/GiftRedeem
		public APIResponse Post(ApiUserGifRedeemModel model)
        {
			IUserGiftRedeem userGiftRedeem = new UserGiftRedeemBusinessService();
			bool result = userGiftRedeem.Insert(model);
			if (result == false)
			{
				return new APIResponse() { Status = eResponseStatus.Fail, Result = "Đã có lỗi xảy ra, hệ thống Không ghi nhận thông tin đổi quả" };
			}
			return new APIResponse() { Status = eResponseStatus.Success, Result = "Thông tin đổi quà đã được ghi nhận trong hệ thống" };
        }

        // PUT: api/GiftRedeem/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GiftRedeem/5
        public void Delete(int id)
        {
        }
    }
}
