using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.DTO.AddModel
{
	public class ShiftAdd
	{
		public DateTime? startTime { get; set; }
		public DateTime? endTime { get; set; }
		public int? taxiDriverId { get; set; }
		public int? taxiCompanyId { get; set; }
	}
}
