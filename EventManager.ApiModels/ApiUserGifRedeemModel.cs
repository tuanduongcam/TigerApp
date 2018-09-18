using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.ApiModels
{
	public class ApiUserGifRedeemModel
	{
		public int UserGiftRedeemID { get; set; }
		public int GiftID { get; set; }
		public string UserId { get; set; }
		public int Point { get; set; }
		public DateTime RedeemDate { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime ModifiedDate { get; set; }
	}
}
