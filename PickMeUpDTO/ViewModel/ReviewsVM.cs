using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.DTO.ViewModel
{
	public class ReviewsVM
	{
		public string? taxiName { get; set; }
		public string? userFirstName { get; set; }
		public string? userLastName { get; set; }
		public string? comment { get; set; }
		public float? rating { get; set; }
	}
}
