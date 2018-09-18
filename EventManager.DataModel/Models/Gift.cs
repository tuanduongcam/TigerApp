using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace EventManager.DataModel.Models
{
    public partial class Gift : Entity
    {
		public Gift()
        {
			this.UserGiftRedeems = new List<UserGiftRedeem>();
        }

		public int GiftID { get; set; }
        public string Name { get; set; }
		public string Remark { get; set; }
		public string FilePath { get; set; }
		public int Point { get; set; }
		public virtual ICollection<UserGiftRedeem> UserGiftRedeems { get; set; }
    }
}
