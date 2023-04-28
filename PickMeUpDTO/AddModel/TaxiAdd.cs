using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.DTO.AddModel
{
	public class TaxiAdd
	{
		public string? taxiName { get; set; }
		public int? userId { get; set; }
		public float? startingPrice { get; set; }
		public float? pricePerKilometer { get; set; }
		public string? address { get; set; }
	}
}
