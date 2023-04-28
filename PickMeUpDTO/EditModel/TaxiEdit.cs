using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.DTO.EditModel
{
	public class TaxiEdit
	{
		public int taxiId { get; set; }
		public float? startingPrice { get; set; }
		public float? pricePerKilometer { get; set; }
		public string? address { get; set; }
	}
}
