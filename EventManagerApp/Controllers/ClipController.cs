using EventManager.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Drawing;
using System.IO;
using System.Web;
using EventManager.BusinessService;
using EventManager.ApiModels;

namespace EventManager.Web.Controllers
{
    public class ClipController : ApiController
    {
	
		[AllowAnonymous]
		[HttpPost]
		public APIResponse UpdateClip(string userid, string ClipName, string filepath,string tag)
		{
			try
			{
				ApiClipModel apiClipModel = new ApiClipModel();
				apiClipModel.Name = ClipName;
				apiClipModel.UserId = userid;
				apiClipModel.ClipPath = filepath;
				apiClipModel.Approval = 0;
				apiClipModel.ApprovedBy = "";
				apiClipModel.NoView = 0;
				apiClipModel.Point = 0;
				apiClipModel.Tag = tag;
				
				apiClipModel.ClipID = Guid.NewGuid().ToString();
				IClipBusinessService clip = new ClipBusinessService();
				Tuple<bool,ApiClipModel> res = clip.SaveClip(apiClipModel);
				return new APIResponse() { Status = eResponseStatus.Success, Result = "Successfully update clip to use" };
			}
			catch (Exception ex)
			{
				return new APIResponse() { Status = eResponseStatus.Fail, Message = "Failed to update clip to user" };
			}
		}

		[ValidateMimeMultipartContentFilter]
		[Route("api/Clip/PostClip")]
		[ImportFileParamType.SwaggerFormAttribute("PostClip", "Upload clip file")]
		[AllowAnonymous]
		[HttpPost]
		public APIResponse PostClip()
		{
			try
			{
				eResponseStatus status = eResponseStatus.Success;
				var httpPostedFile = HttpContext.Current.Request.Files[0];
				var filePath = "Movies/" + new Random().Next().ToString() + httpPostedFile.FileName;
				if (httpPostedFile != null)
				{
					var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/"), filePath);
					httpPostedFile.SaveAs(fileSavePath);
				}
				
				return new APIResponse() { Status = status, Result = filePath };
			}
			catch (Exception ex)
			{
				return new APIResponse() { Status = eResponseStatus.Fail, Message = "Please Upload image of type *.mp4." };
			}
		}
    }
}
