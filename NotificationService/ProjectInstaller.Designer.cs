﻿namespace TigerWallNotificationService
{
	partial class ProjectInstaller
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller;
		private System.ServiceProcess.ServiceInstaller serviceInstaller;
		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			serviceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
			serviceInstaller = new System.ServiceProcess.ServiceInstaller();

			serviceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalService;
			serviceProcessInstaller.Password = null;
			serviceProcessInstaller.Username = null;

			serviceInstaller.Description = "TigerWall Notification Service";
			serviceInstaller.DisplayName = "TigerWall Notification Service";
			serviceInstaller.ServiceName = "TigerWallNotificationService";
			serviceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;

			Installers.AddRange(new System.Configuration.Install.Installer[] {this.serviceProcessInstaller, this.serviceInstaller }
				);

		}

		#endregion

	}
}