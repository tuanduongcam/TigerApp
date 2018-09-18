using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using EventManager.BusinessService;
using Repository.Pattern.Repositories;
using Repository.Pattern.DataContext;
using Repository.Pattern.UnitOfWork;
using EventManager.DataModel;
using EventManager.DataModel.Models;
using Repository.Pattern.Ef6;
using Repository.Pattern;
using EventManager.ApiModels;
using System.Web.Routing;

namespace EventManager.Admin.Controllers
{
	public class AccountApiController : System.Web.Http.ApiController
    {
		[AllowAnonymous]
		[HttpGet]
		[Route("AccountApi/Get_AllEmployee")]
		public APIResponse Get_AllEmployee(int pageindex, int pagesize, int cityId)
		{
			int count = 0;
			List<ApiAccountModel> Emp = new List<ApiAccountModel>();
			using (IDataContextAsync context = new GameManagerContext())
			using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
			{
				IRepositoryAsync<AspNetUser> customerRepository = new Repository<AspNetUser>(context, unitOfWork);
				AccountBusinessService AccountBusinessServiceService = new AccountBusinessService(customerRepository);
				Emp = AccountBusinessServiceService.GetAccounts(pageindex, pagesize, cityId, out count).ToList();
			}
			return new APIResponse() { Status = eResponseStatus.Success, Result = Emp, TotalCount = count };
		}
    }
}
