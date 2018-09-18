using EventManager.ApiModels;
using EventManager.DataModel.Models;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EventManager.BusinessService
{


	public interface IContentSentBusinessService
	{
		List<ApiMessageContentSentModel> GetSentMessageByUser(string userId);
		List<ApiMessageContentSentModel> GetSentMessageByTypeUser(string userId, int type);

		Tuple<bool, string> SetMessageSeen(Int64 messageContentSentID);

		int GetNotReadMessageByUser(string userId);
	}
	public class ContentSentBusinessService : IContentSentBusinessService
	{
		private IRepositoryAsync<MessageContentSent> _messageHistoryRegisterRepo;
		public List<ApiMessageContentSentModel> GetSentMessageByUser(string userId)
		{
			List<ApiMessageContentSentModel> models = null;
			using (IDataContextAsync context = new GameManagerContext())
			using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
			{
				_messageHistoryRegisterRepo = new Repository<MessageContentSent>(context, unitOfWork);
				models = _messageHistoryRegisterRepo.Query(c => c.UserId == userId).OrderBy(c => c.OrderByDescending(y=>y.CreatedDate)).
					Select(c => new ApiMessageContentSentModel()
					{
						MessageContentSentID = c.MessageContentSentID,
						ServiceTypeID = c.ServiceTypeID,
						Sender = c.Sender,
						Receiver = c.Receiver,
						Subject = c.Subject,
						BodyMessage = c.BodyMessage,
						Status = c.Status,
						UserId = c.UserId,
						CreatedDate = c.CreatedDate,
						ModifiedDate = c.ModifiedDate
					}).ToList();				
			}
			return models;
		}

		public List<ApiMessageContentSentModel> GetSentMessageByTypeUser(string userId, int type)
		{
			List<ApiMessageContentSentModel> models = null;
			using (IDataContextAsync context = new GameManagerContext())
			using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
			{
				_messageHistoryRegisterRepo = new Repository<MessageContentSent>(context, unitOfWork);
				models = _messageHistoryRegisterRepo.Query(c => c.UserId == userId && c.ServiceTypeID == type).OrderBy(c => c.OrderByDescending(y=>y.CreatedDate)).
					Select(c => new ApiMessageContentSentModel()
					{
						MessageContentSentID = c.MessageContentSentID,
						ServiceTypeID = c.ServiceTypeID,
						Sender = c.Sender,
						Receiver = c.Receiver,
						Subject = c.Subject,
						BodyMessage = c.BodyMessage,
						Status = c.Status,
						UserId = c.UserId,
						CreatedDate = c.CreatedDate,
						ModifiedDate = c.ModifiedDate
					}).ToList();
			}
			return models;
		}

		public Tuple<bool, string> SetMessageSeen(Int64 messageContentSentID)
		{
			Tuple<bool, string> result = new Tuple<bool,string>(true, "Cập nhật trạng thái thành công");
			MessageContentSent model = null;
			using (IDataContextAsync context = new GameManagerContext())
			using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
			{
				_messageHistoryRegisterRepo = new Repository<MessageContentSent>(context, unitOfWork);
				model = _messageHistoryRegisterRepo.Find(messageContentSentID);
				if (model != null)
				{
					model.Status = 3;
					model.ObjectState = ObjectState.Modified;
					_messageHistoryRegisterRepo.Update(model);
					unitOfWork.SaveChanges();
				}else
				{
					result = new Tuple<bool, string>(false, "Không tồn tại thông báo này");
				}
			}
			return result;
		}

		public int GetNotReadMessageByUser(string userId)
		{
			int cnt = 0;
			using (IDataContextAsync context = new GameManagerContext())
			using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
			{
				_messageHistoryRegisterRepo = new Repository<MessageContentSent>(context, unitOfWork);
				cnt = _messageHistoryRegisterRepo.Query(c => c.UserId == userId && c.Status != 3).Select().Count();				
			}
			return cnt;
		}
	}


}
