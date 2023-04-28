using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.DTO.ViewModel
{
	public class TaxiVM
	{
		public string? taxiName { get; set; }
		public float? startingPrice { get; set; }
		public float? pricePerKilometer { get; set; }
		public string? address { get; set; }
		public string? userFirstName { get; set; }
		public string? userLastName { get; set;}
	}
}
