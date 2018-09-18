using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.DataContext;
using Repository.Pattern.UnitOfWork;
using EventManager.DataModel.Models;
using Repository.Pattern.Ef6;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.Repositories;
using EventManager.BusinessService;
using System.Linq;
using EventManager.ApiModels;
using System.Drawing;
using System.IO;
using System.Net;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			IContentBusinessService contentBusiness = new ContentBusinessService();
			contentBusiness.SentMessage(30);
		}
	}
}
