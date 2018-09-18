using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.ApiModels
{
	public class ApiAccountImageModel
	{
		public long AspNetUserImgID { get; set; }
		public string UserId { get; set; }
		public string FilePath { get; set; }
		public bool IsFearureImg { get; set; }
	}
}
