using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.ApiModels
{
	public class ApiGifModel
	{
		public int GiftID { get; set; }
		public string Name { get; set; }
		public string Remark { get; set; }

		public string FilePath { get; set; }
		public int Point { get; set; }
	}
}
