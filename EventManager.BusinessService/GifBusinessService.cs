using EventManager.ApiModels;
using Repository.Pattern.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.DataModel.Models;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using Repository.Pattern.Ef6;

namespace EventManager.BusinessService
{
	public interface IGifBusinessService
	{
		List<ApiGifModel> GetGifts();
		ApiGifModel GetGift(int giftID);
	}

	public class GifBusinessService : IGifBusinessService
	{
		private IRepositoryAsync<Gift> _accountImageRegisterRepo;
		public List<ApiGifModel> GetGifts()
		{			
			List<ApiGifModel> models;
			using (IDataContextAsync context = new GameManagerContext())
			using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
			{
				_accountImageRegisterRepo = new Repository<Gift>(context, unitOfWork);
				models = _accountImageRegisterRepo.Query().Select
				(
					x => new ApiGifModel { GiftID = x.GiftID, Name = x.Name, Point = x.Point, Remark = x.Remark, FilePath =x.FilePath }
				).ToList();
				return models;
			}	
		}

		public ApiGifModel GetGift(int giftID)
		{
			ApiGifModel model;
			using (IDataContextAsync context = new GameManagerContext())
			using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
			{
				_accountImageRegisterRepo = new Repository<Gift>(context, unitOfWork);
				model = _accountImageRegisterRepo.Query().Select
				(
					x => new ApiGifModel { GiftID = x.GiftID, Name = x.Name, Point = x.Point, Remark = x.Remark, FilePath = x.FilePath }
				).FirstOrDefault();
				return model;
			}	
		}
	}
}
