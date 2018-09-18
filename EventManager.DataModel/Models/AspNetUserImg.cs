using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace EventManager.DataModel.Models
{
	public partial class AspNetUserImg : Entity
    {
		public AspNetUserImg()
        {
           
        }

		public long AspNetUserImgID { get; set; }
		public string UserId { get; set; }
		public string FilePath { get; set; }
		public bool IsFearureImg { get; set; }
		public virtual AspNetUser AspNetUser { get; set; }
    }
}
