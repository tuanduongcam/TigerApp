using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace EventManager.DataModel.Models
{
	public partial class UserGiftRedeem : Entity
    {
		public UserGiftRedeem()
        {
          
        }

		public int UserGiftRedeemID { get; set; }
		public int GiftID { get; set; }
		public string UserId { get; set; }
        public int Point { get; set; }
		public DateTime RedeemDate { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime ModifiedDate { get; set; }
		public virtual AspNetUser AspNetUser { get; set; }
		public virtual Gift Gift { get; set; }
    }
}
