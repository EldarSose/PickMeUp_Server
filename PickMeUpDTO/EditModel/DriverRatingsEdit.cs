using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.DTO.EditModel
{
	public class DriverRatingsEdit
	{
		public int driverRatingsId { get; set; }
		public int driverId { get; set; }
		public int userId { get; set; }
		public float? rating { get; set; }
		public string? comment { get; set; }
	}
}
