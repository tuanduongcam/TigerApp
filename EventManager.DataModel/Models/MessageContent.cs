using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace EventManager.DataModel.Models
{
    public partial class MessageContent : Entity
    {
		public MessageContent()
        {
            
        }

		public int MessageContentID { get; set; }
		public int ServiceTypeID { get; set; }

		public string Sender { get; set; } 
		public string Receiver { get; set; }
		public string BodyMessage { get; set; }
		public string UserId { get; set; }
		public int Status {get;set;}
		public DateTime CreatedDate { get; set; }
		public DateTime ModifiedDate { get; set; }
    }
}
