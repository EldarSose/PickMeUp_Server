using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.DTO.EditModel
{
	public class CarEdit
	{
		public int carId { get; set; }
		public string? carModel { get; set; }
		public string? plateNumber { get; set; }
		public string? taxiNumber { get; set; }
		public int taxiId { get; set; }
	}
}
