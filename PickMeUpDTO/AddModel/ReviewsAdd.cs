using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.DTO.AddModel
{
	public class ReviewsAdd
	{
		public int taxiId { get; set; }
		public int userId { get; set; }
		public string? comment { get; set; }
		public float? rating { get; set; }
	}
}
