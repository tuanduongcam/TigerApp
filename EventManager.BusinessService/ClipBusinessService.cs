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
	public interface IClipBusinessService
	{
		List<ApiClipModel> GetClips(string userId);
		ApiClipModel GetClip(string clipId);

		Tuple<bool, ApiClipModel> SaveClip(ApiClipModel apiClipModel);
	}

	public class ClipBusinessService : IClipBusinessService
	{
		private IRepositoryAsync<Clip> _clipRegisterRepo;
		public List<ApiClipModel> GetClips(string userId)
		{
			List<ApiClipModel> models;
			using (IDataContextAsync context = new GameManagerContext())
			using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
			{
				_clipRegisterRepo = new Repository<Clip>(context, unitOfWork);
				models = _clipRegisterRepo.Query().Select
				(
					x => new ApiClipModel { ClipID = x.ClipID, Name = x.Name, Point = x.Point, UserId = x.UserId, ClipPath =x.ClipPath,
					Approval = x.Approval, ApprovedBy = x.ApprovedBy, Tag = x.Tag, NoView = x.NoView}
				).ToList();
				return models;
			}	
		}
		public ApiClipModel GetClip(string clipId)
		{
			ApiClipModel model;
			using (IDataContextAsync context = new GameManagerContext())
			using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
			{
				_clipRegisterRepo = new Repository<Clip>(context, unitOfWork);
				model = _clipRegisterRepo.Query().Select
				(
					x => new ApiClipModel
					{
						ClipID = x.ClipID,
						Name = x.Name,
						Point = x.Point,
						UserId = x.UserId,
						ClipPath = x.ClipPath,
						Approval = x.Approval,
						ApprovedBy = x.ApprovedBy,
						Tag = x.Tag,
						NoView = x.NoView
					}
				).FirstOrDefault();
				return model;
			}	
		}

		public Tuple<bool, ApiClipModel> SaveClip(ApiClipModel apiClipModel)
		{
			Clip clip = new Clip();
			try
			{
				using (IDataContextAsync context = new GameManagerContext())
				using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
				{
					_clipRegisterRepo = new Repository<Clip>(context, unitOfWork);

					clip.ClipID = apiClipModel.ClipID;
					clip.Name =apiClipModel.Name;
					clip.Point = apiClipModel.Point;
					clip.UserId = apiClipModel.UserId;
					clip.ClipPath = apiClipModel.ClipPath;
					clip.Approval = apiClipModel.Approval;
					clip.ApprovedBy = apiClipModel.ApprovedBy;
					clip.Tag = apiClipModel.Tag;
					clip.NoView = apiClipModel.NoView;
					clip.ObjectState = ObjectState.Added;
					_clipRegisterRepo.Insert(clip);
					unitOfWork.SaveChanges();
					apiClipModel.ClipID = clip.ClipID;
					return new Tuple<bool, ApiClipModel>(true, apiClipModel);
				}
			}
			catch (Exception ex)
			{
				return new Tuple<bool, ApiClipModel>(false, apiClipModel);;
			}
		}
	}
}
