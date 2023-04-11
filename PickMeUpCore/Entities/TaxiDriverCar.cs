using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Entities
{
	public class TaxiDriverCar
	{
		[ForeignKey(nameof(car))]
		public int? carId { get; set; }
		public Car? car { get; set; }
		[ForeignKey(nameof(taxiDriver))]
		public int? taxiDriverId { get; set;}
		public User? taxiDriver { get; set; }
		public bool? isDeleted { get; set; }
	}
}
