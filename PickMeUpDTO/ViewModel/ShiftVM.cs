using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.DTO.ViewModel
{
	public class ShiftVM
	{
		public DateTime? startTime { get; set; }
		public DateTime? endTime { get; set; }
		public string? taxiName { get; set; }
		public string? taxiDriverFirstName { get; set; }
		public string? taxiDriverLastName { get; set; }
		public bool? tookABreak { get; set; }
	}
}
