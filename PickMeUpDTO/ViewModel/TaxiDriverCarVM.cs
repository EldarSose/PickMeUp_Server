using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.DTO.ViewModel
{
	public class TaxiDriverCarVM
	{
		public int? id { get; set; }
		public string? taxiDriverFirstName { get; set; }
		public string? taxiDriverLastName { get; set; }
		public string? carModel { get; set; }
		public string? plateNumber { get; set; }
		public string? taxiNumber { get; set; }
		public string? taxiName { get; set; }
	}
}
