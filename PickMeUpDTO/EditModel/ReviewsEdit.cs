using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.DTO.EditModel
{
	public class ReviewsEdit
	{
		public int reviewId { get; set; }
		public string? comment { get; set; }
		public float? rating { get; set; }
	}
}
