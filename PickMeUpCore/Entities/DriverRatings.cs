using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Entities
{
	public class DriverRatings
	{
		public int driverRatingsId { get; set; }
		[ForeignKey(nameof(driver))]
		public int? driverId { get; set; }
		public User? driver { get; set; }
		[ForeignKey(nameof(user))]
		public int? userId { get; set; }
		public User? user { get; set; }
		public float? rating { get; set; }
		public string? comment { get; set; }
		public bool? isDeleted { get; set; }

	}
}
