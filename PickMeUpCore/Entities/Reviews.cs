using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Entities
{
	public class Reviews
	{
		[Key]
		public int reviewId { get; set; }
		[ForeignKey(nameof(taxi))]
		public int? taxiId { get; set; }
		public Taxi? taxi { get; set; }
		[ForeignKey(nameof(user))]
		public int? userId { get; set; }
		public User? user { get; set; }
		public string? comment { get; set; }
		public float? rating { get; set; }
		public bool? isDeleted { get; set; }
	}
}
