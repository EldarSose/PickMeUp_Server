using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.DTO.AddModel
{
	public class DriverRatingsAdd
	{
		public int driverId { get; set; }
		public int userId { get; set; }
		public float? rating { get; set; }
		public string? comment { get; set; }
	}
}
