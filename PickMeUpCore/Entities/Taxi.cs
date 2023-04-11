using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Core.Entities
{
	public class Taxi
	{
		[Key]
		public int taxiId { get; set; }
		public string? taxiName { get; set; }
		[ForeignKey(nameof(user))]
		public int? userId { get; set; }
		public User? user { get; set; }
		public float? startingPrice { get; set; }
		public float? pricePerKilometer { get; set;}
		public string? address { get; set; }
		public bool? isDeleted { get; set; }
	}
}
