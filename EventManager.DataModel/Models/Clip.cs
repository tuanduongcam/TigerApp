using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.DataModel.Models
{
	public class Clip : Entity
	{
		public Clip()
		{
		}
		public string ClipID { get; set; }
		public string Name { get; set; }
		public string UserId { get; set; }
		public string ClipPath { get; set; }
		public int Approval { get; set; }
		public string ApprovedBy { get; set; }
		public string Tag { get; set; }
		public Int64 NoView { get; set; }
		public Int64 Point { get; set; }
		public virtual AspNetUser AspNetUser { get; set; }
	}
}
