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
	public interface IContentBusinessService
	{
		void SentMessage(int numberOfMessage);
		void InserContentMessage(MessageContent messageContent);
	}
	public class ContentBusinessService : IContentBusinessService
	{
		private IRepositoryAsync<MessageContentSent> _messageHistoryRegisterRepo;
		private IRepositoryAsync<MessageContent> _messageRegisterRepo;

		public void SentMessage(int numberOfMessage)
		{
			INotificationService srvNotification = new NotificationService();
			using (IDataContextAsync context = new GameManagerContext())
			using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
			{
				_messageRegisterRepo = new Repository<MessageContent>(context, unitOfWork);
				_messageHistoryRegisterRepo = new Repository<MessageContentSent>(context, unitOfWork);
				int count = 0;
				List<MessageContent> messages = _messageRegisterRepo.Query(x => x.Status == 0).OrderBy(x => x.OrderBy(y => y.MessageContentID)).SelectPage(1, numberOfMessage, out count).ToList();
				foreach (MessageContent msg in messages)
				{
					if (!string.IsNullOrEmpty(msg.Receiver))
					{
						srvNotification.NotifyAsync(msg.Receiver.Trim(), msg.BodyMessage.Trim());

						MessageContentSent messageContentSent = new MessageContentSent();
						messageContentSent.MessageContentID = msg.MessageContentID;
						messageContentSent.Receiver = msg.Receiver;
						messageContentSent.BodyMessage = msg.BodyMessage;
						messageContentSent.ServiceTypeID = msg.ServiceTypeID;
						messageContentSent.Status = 1;
						messageContentSent.ModifiedDate = DateTime.Now;
						messageContentSent.CreatedDate = DateTime.Now;
						messageContentSent.Sender = msg.Sender;
						messageContentSent.UserId = msg.UserId;
						messageContentSent.ObjectState = ObjectState.Added;
						_messageHistoryRegisterRepo.Insert(messageContentSent);
						msg.ObjectState = ObjectState.Deleted;
						_messageRegisterRepo.Delete(msg.MessageContentID);
						unitOfWork.SaveChanges();
					}
				}
			}
		}

		public void InserContentMessage(MessageContent messageContent)
		{			
			using (IDataContextAsync context = new GameManagerContext())
			using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
			{
				_messageRegisterRepo = new Repository<MessageContent>(context, unitOfWork);
				messageContent.ObjectState = ObjectState.Added;
				_messageRegisterRepo.Insert(messageContent);
				unitOfWork.SaveChanges();
			}
		}
	}
}
