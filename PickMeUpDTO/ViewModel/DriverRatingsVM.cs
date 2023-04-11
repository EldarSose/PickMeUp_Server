using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.DTO.ViewModel
{
	public class DriverRatingsVM
	{
		public string? driverFirstName { get; set; }
		public string? driverLastName { get; set; }
		public string? userFirstName { get; set; }
		public string? userLastName { get; set; }
		public float? rating { get; set; }
		public string? comment { get; set; }
	}
}
