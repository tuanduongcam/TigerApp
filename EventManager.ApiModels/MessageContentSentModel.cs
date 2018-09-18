using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.ApiModels
{
	public class ApiMessageContentSentModel
	{
		public Int64 MessageContentSentID { get; set; }
		public int ServiceTypeID { get; set; }
		public string Sender { get; set; }
		public string Receiver { get; set; }
		public string Subject { get; set; }
		public string BodyMessage { get; set; }
		public string UserId { get; set; }
		public int Status { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime ModifiedDate { get; set; }
	}
}
