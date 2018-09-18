using EventManager.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.ApiModels;
using Repository.Pattern.Repositories;
using Repository.Pattern.DataContext;
using Repository.Pattern.UnitOfWork;
using Repository.Pattern.Ef6;

namespace EventManager.BusinessService
{
	public interface IAccountImageBusinessService
	{
		List<ApiAccountImageModel> AccountImages(string accountid);
	}

	public class AccountImageBusinessService : IAccountImageBusinessService
	{
		private IRepositoryAsync<AspNetUserImg> _accountImageRegisterRepo;


		public List<ApiAccountImageModel> AccountImages(string accountid)
		{
			List<ApiAccountImageModel> models;
			using (IDataContextAsync context = new GameManagerContext())
			using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
			{
				_accountImageRegisterRepo = new Repository<AspNetUserImg>(context, unitOfWork);
				 models = _accountImageRegisterRepo.Query(x=>x.UserId  == accountid).Select
				(
					x => new ApiAccountImageModel { UserId = x.UserId, AspNetUserImgID = x.AspNetUserImgID, FilePath = x.FilePath, IsFearureImg = x.IsFearureImg }
				).ToList();
				return models;
			}			
		}
	}
}
