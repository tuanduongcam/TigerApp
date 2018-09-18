using EventManager.BusinessService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;

namespace NotificationService
{
	public partial class PlayerNotification : ServiceBase
	{
		BackgroundWorker notificationBackGroundWorker;
		private int numberofAlerts = 10, intervalInSecond = 10;
		public PlayerNotification()
		{
			InitializeComponent();
			
		}

		public void Start()
		{
			Console.WriteLine("Start service");
			GetParamaterValue();
			notificationBackGroundWorker = new BackgroundWorker();
			notificationBackGroundWorker.DoWork += notificationBackGroundWorker_DoWork;
			notificationBackGroundWorker.RunWorkerAsync();
			
		}
		protected override void OnStart(string[] args)
		{
			Start();
		}

		void notificationBackGroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			while(true)
			{
				try
				{
					Console.WriteLine("Start sending");
					IContentBusinessService contentBusiness = new ContentBusinessService();
					contentBusiness.SentMessage(numberofAlerts);
					Console.WriteLine("End of sending");
				}
				catch(Exception ex )
				{
					Console.WriteLine("Error :" + ex.Message);
				}
				//Thread.Sleep(1 * 1000 * 60);
				Thread.Sleep(intervalInSecond*1000);
			}
		}

		protected override void OnStop()
		{
			if(notificationBackGroundWorker != null)
			{
				notificationBackGroundWorker = null;
			}
		}

		private void GetParamaterValue()
		{
			try
			{
				numberofAlerts = Convert.ToInt32(ConfigurationManager.AppSettings["numberofItemfor1Batch"]);
			}catch(Exception ex)
			{
				numberofAlerts = 10;
			}
			try
			{
				intervalInSecond = Convert.ToInt32(ConfigurationManager.AppSettings["intervalInSecond"]);
			}
			catch
			{
				intervalInSecond = 1;
			}
			
		}
	}
}
