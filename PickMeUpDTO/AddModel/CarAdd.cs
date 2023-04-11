using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.DTO.AddModel
{
	public class CarAdd
	{
		public string? carModel { get; set; }
		public string? plateNumber { get; set; }
		public string? taxiNumber { get; set; }
		public int taxiId { get; set; }
	}
}
