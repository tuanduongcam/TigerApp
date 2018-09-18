using EventManager.ApiModels;
using EventManager.DataModel.Models;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.BusinessService
{
	public interface IUserGiftRedeem
	{
		ApiRemainingPoint RemainingPoint(string userid);
		List<ApiUserGifRedeemModel> UserGiftRedeemList(string userid);

		bool Insert(ApiUserGifRedeemModel apiRemainingPoint);
	}
	public  class UserGiftRedeemBusinessService : IUserGiftRedeem
	{
		private IRepositoryAsync<UserGiftRedeem> _redeemRegisterRepo;
		
		public ApiRemainingPoint RemainingPoint(string userid)
		{
			List<UserGiftRedeem> models;
			using (IDataContextAsync context = new GameManagerContext())
			using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
			{
				_redeemRegisterRepo = new Repository<UserGiftRedeem>(context, unitOfWork);
				models = _redeemRegisterRepo.Query().Select().ToList();
				int sumRedeemPoint  = models.Sum(x => x.Point);
				IRepositoryAsync<EventRegister> _eventRegisterRegisterRepo = new Repository<EventRegister>(context, unitOfWork);
				int totalPoint = _eventRegisterRegisterRepo.Query(x => x.UserId == userid).Select().Sum(y => y.Point);
				ApiRemainingPoint apiRemainingPoint = new ApiRemainingPoint();
				apiRemainingPoint.UseId = userid;
				apiRemainingPoint.RemainingPoint = totalPoint - sumRedeemPoint;
				return apiRemainingPoint;
			}			
		}

		public List<ApiUserGifRedeemModel> UserGiftRedeemList(string userid)
		{
			List<ApiUserGifRedeemModel> models;
			using (IDataContextAsync context = new GameManagerContext())
			using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
			{
				_redeemRegisterRepo = new Repository<UserGiftRedeem>(context, unitOfWork);
				models = _redeemRegisterRepo.Query(x => x.UserId == userid).Select(
					 x => new ApiUserGifRedeemModel 
					 { UserGiftRedeemID = x.UserGiftRedeemID , UserId = x.UserId, 
						GiftID = x.GiftID, 
						CreatedDate = x.CreatedDate,
						Point = x.Point,
						RedeemDate = x.RedeemDate,
						ModifiedDate = x.ModifiedDate
					 }
				    ).ToList();
					
				return models;
			}	
		}

		public bool Insert(ApiUserGifRedeemModel apiUserGifRedeemModel)
		{
			UserGiftRedeem userGiftRedeem = new UserGiftRedeem();
			try
			{
				using (IDataContextAsync context = new GameManagerContext())
				using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
				{
					_redeemRegisterRepo = new Repository<UserGiftRedeem>(context, unitOfWork);

					userGiftRedeem.UserId = apiUserGifRedeemModel.UserId;
					userGiftRedeem.GiftID = apiUserGifRedeemModel.GiftID;
					userGiftRedeem.Point = apiUserGifRedeemModel.Point;
					userGiftRedeem.ModifiedDate = apiUserGifRedeemModel.ModifiedDate;
					userGiftRedeem.CreatedDate = DateTime.Now;
					userGiftRedeem.RedeemDate = DateTime.Now;
					userGiftRedeem.ObjectState = ObjectState.Added;
					_redeemRegisterRepo.Insert(userGiftRedeem);
					unitOfWork.SaveChanges();
					apiUserGifRedeemModel.UserGiftRedeemID = userGiftRedeem.UserGiftRedeemID;
					return true;
				}	
			}catch(Exception ex)
			{
				return false;
			}
			
		}
	}
}
